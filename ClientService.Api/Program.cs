using Microsoft.AspNetCore.Diagnostics.HealthChecks;
// ... other using statements

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllers();

// Add health check services
builder.Services.AddHealthChecks();

// Add DbContext
//builder.Services.AddDbContext<AccountContext>(options =>
//    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));
// For ClientService.Api, use ClientContext and adjust accordingly

var app = builder.Build();

// Configure the HTTP request pipeline.
app.MapControllers();

// Map health check endpoint
app.MapHealthChecks("/health");

app.Run();