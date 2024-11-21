using AccountService.Api.Models;
using Microsoft.EntityFrameworkCore;

namespace AccountService.Api.Data
{
    public class AccountServiceContext : DbContext
    {
        public AccountServiceContext(DbContextOptions<AccountServiceContext> options) : base(options) { }

        public DbSet<Account> Accounts { get; set; }
        public DbSet<Movement> Movements { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Account>()
                .HasIndex(a => a.Number)
                .IsUnique();

            // Add configurations if needed
        }
    }
}
