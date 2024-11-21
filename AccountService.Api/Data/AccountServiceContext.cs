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

            // Configure relationships
            modelBuilder.Entity<Account>()
                .HasMany(a => a.Movements)
                .WithOne(m => m.Account)
                .HasForeignKey(m => m.AccountId);

            modelBuilder.Entity<Account>()
                .HasIndex(a => a.Number)
                .IsUnique();

            // Add configurations if needed
        }
    }
}
