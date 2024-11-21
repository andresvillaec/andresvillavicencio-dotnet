using AccountService.Api.Data;
using AccountService.Api.Mappers;
using AccountService.Api.Mappers.Interfaces;
using AccountService.Api.Repositories;
using AccountService.Api.Repositories.Interfaces;
using AccountService.Api.Services;
using AccountService.Api.Services.Interfaces;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContext<AccountServiceContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

// Add services to the container.

builder.Services.AddScoped<IAccountRepository, AccountRepository>();
builder.Services.AddScoped<IAccountsService, AccountsService>();

builder.Services.AddScoped<IMovementRepository, MovementRepository>();
builder.Services.AddScoped<IMovementService, MovementService>();
builder.Services.AddScoped<IMovementMapper, MovementMapper>();

builder.Services.AddControllers();

builder.Services.AddHealthChecks();

builder.Services.AddHttpClient();


var app = builder.Build();

using (var scope = app.Services.CreateScope())
{
    var dbContext = scope.ServiceProvider.GetRequiredService<AccountServiceContext>();
    dbContext.Database.Migrate();
}

// Configure the HTTP request pipeline.

//app.UseHttpsRedirection();


app.MapControllers();

// Map health check endpoint
app.MapHealthChecks("/health");

app.Run();
