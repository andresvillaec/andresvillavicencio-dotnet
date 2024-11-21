using ClientService.Api.Models;
using Microsoft.EntityFrameworkCore;

namespace ClientService.Api.Data;

public class ClientServiceContext : DbContext
{
    public ClientServiceContext(DbContextOptions<ClientServiceContext> options) : base(options) { }

    public DbSet<Client> Clients { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
    }
}
