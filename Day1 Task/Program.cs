using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Day1_Task.Data;

var builder = WebApplication.CreateBuilder(args);

// Get the current environment
var environment = builder.Environment.EnvironmentName;

// Get the correct connection string from appsettings.json
var connectionString = builder.Configuration.GetConnectionString(environment)
                       ?? builder.Configuration.GetConnectionString("DefaultConnection");

// Register DbContext with the selected connection string
builder.Services.AddDbContext<EFCoreDbContext>(options =>
{
    options.UseSqlServer(connectionString);
});

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseAuthorization();
app.MapControllers();

app.MapGet("/", () => $"Running in {environment} environment with {connectionString}");

app.Run();
