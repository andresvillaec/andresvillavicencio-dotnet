using ClientService.Api.Data;
using ClientService.Api.Mappers;
using ClientService.Api.Mappers.Interfaces;
using ClientService.Api.Repositories;
using ClientService.Api.Repositories.Interfaces;
using ClientService.Api.Services;
using ClientService.Api.Services.Interfaces;
using Microsoft.EntityFrameworkCore;
// ... other using statements

internal class Program
{
    private static void Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);

        builder.Services.AddDbContext<ClientServiceContext>(options =>
            options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

        builder.Services.AddScoped<IClientRepository, ClientRepository>();
        builder.Services.AddScoped<IClientsService, ClientsService>();
        builder.Services.AddScoped<IClientMapper, ClientMapper>();

        // Add services to the container.
        builder.Services.AddControllers();

        // Add health check services
        builder.Services.AddHealthChecks();

        builder.Services.AddHttpClient();

        var app = builder.Build();

        using (var scope = app.Services.CreateScope())
        {
            var dbContext = scope.ServiceProvider.GetRequiredService<ClientServiceContext>();
            dbContext.Database.Migrate();
        }

        // Configure the HTTP request pipeline.
        app.MapControllers();

        // Map health check endpoint
        app.MapHealthChecks("/health");

        app.Run();
    }
}