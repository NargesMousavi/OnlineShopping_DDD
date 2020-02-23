using Microsoft.EntityFrameworkCore;
using OnlineShopping.BusinessModel;

namespace OnlineShopping.Presentation.DataAccess
{
    public class OnlineShoppingDbContext : DbContext
    {
        public DbSet<CustomerAccount> CustomerAccounts { get; set; }
        public DbSet<Product> Products { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(
                @"Data Source=.;Initial Catalog=OnlineShopping;persist security info=True;user id=sa;password=123456;MultipleActiveResultSets=True;Connection Timeout=960;");
        }
    }
}