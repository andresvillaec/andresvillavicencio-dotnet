using AccountService.Api.Data;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContext<AccountServiceContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

// Add services to the container.

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
