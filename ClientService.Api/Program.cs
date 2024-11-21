using AccountService.Api.Data;
using Microsoft.AspNetCore.Diagnostics.HealthChecks;
using Microsoft.EntityFrameworkCore;
using System;
// ... other using statements

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllers();

// Add health check services
builder.Services.AddHealthChecks();

builder.Services.AddHttpClient();
builder.Services.AddDbContext<ClientServiceContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

var app = builder.Build();

//using (var scope = app.Services.CreateScope())
//{
//    var dbContext = scope.ServiceProvider.GetRequiredService<ClientServiceContext>();
//    dbContext.Database.Migrate();
//}

// Configure the HTTP request pipeline.
app.MapControllers();

// Map health check endpoint
app.MapHealthChecks("/health");

app.Run();