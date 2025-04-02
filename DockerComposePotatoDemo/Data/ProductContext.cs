using DockerComposePotatoDemo.Models;
using Microsoft.EntityFrameworkCore;

namespace DockerComposePotatoDemo.Data
{
    public class ProductContext : DbContext
    {
        public ProductContext(DbContextOptions options) :base(options) { }

        public DbSet<Product> Products { get; set; }
    }
}
