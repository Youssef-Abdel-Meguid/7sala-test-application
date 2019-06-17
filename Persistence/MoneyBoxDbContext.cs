using _7sala_test_application.Models;
using Microsoft.EntityFrameworkCore;

namespace _7sala_test_application.Persistence
{
    public class MoneyBoxDbContext : DbContext
    {
        public MoneyBoxDbContext(DbContextOptions<MoneyBoxDbContext> options) : base(options)
        {
            
        }
        
        public DbSet<Product> Products { get; set; }

        public DbSet<Category> Categories { get; set; }


    }
}