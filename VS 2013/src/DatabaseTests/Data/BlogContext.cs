using System.Data.Entity;
using Data.Model;

namespace Data
{
    public class BlogContext : DbContext
    {
        public DbSet<Post> Posts { get; set; }

        public DbSet<Blog> Blogs { get; set; }

        public DbSet<Author> Authors { get; set; }
    }
}
