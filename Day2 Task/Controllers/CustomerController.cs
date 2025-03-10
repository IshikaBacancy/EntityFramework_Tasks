using Microsoft.AspNetCore.Mvc;
using Day2_Task.Models;
using Day2_Task.Data;
using Microsoft.EntityFrameworkCore;

namespace Day2_Task.Controllers
    
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomerController : ControllerBase
    {
        private readonly EFCoreDbContext _context;
        
        public CustomerController(EFCoreDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Customer>>> GetCustomers()
        {
            var customers = await _context.Customers.ToListAsync();
            return Ok(customers);  
        }

        [HttpPost]
        public async Task<IActionResult> InsertCustomer([FromBody] Customer customer)
        {
            if (customer == null)
            {
                return BadRequest("Customer data is required.");
            }

            
            customer.CustomerId = 0; 

         
            if (_context.Customers.Any(c => c.CustomerName == customer.CustomerName))
            {
                return BadRequest("Customer with this name already exists.");
            }

            
            _context.Customers.Add(customer);
            await _context.SaveChangesAsync();

            
            var result = new
            {
                customer.CustomerId,
                customer.CustomerName,
                customer.Email
            };

            return CreatedAtAction(nameof(GetCustomers), new { id = customer.CustomerId }, result);
        }


    }
}
