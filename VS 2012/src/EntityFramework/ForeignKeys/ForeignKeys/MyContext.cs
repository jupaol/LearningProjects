using System.Data.Entity;

namespace ForeignKeys
{
    public class MyContext : DbContext
    {
        public MyContext()
        {
            Configuration.LazyLoadingEnabled = false;
        }

        public DbSet<Product> Products { get; set; }
        public DbSet<Category> Categories { get; set; }
    }
}
