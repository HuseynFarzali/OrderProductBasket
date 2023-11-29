using DefaultWebApplication.Models.Domain_Models.Bridge_Models;
using DefaultWebApplication.Models.Domain_Models.Main_Models;
using Microsoft.EntityFrameworkCore;

namespace DefaultWebApplication.Database
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        public DbSet<Product> Products { get; set; }
        public DbSet<Size> Sizes { get; set; }
        public DbSet<Color> Colors { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<Item> Items { get; set; }
        public DbSet<BasketItem> BasketItems { get; set; }
    }
}
