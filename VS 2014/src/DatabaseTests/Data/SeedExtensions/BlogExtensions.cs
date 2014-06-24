using System;
using System.Data.Entity;
using System.Data.Entity.Migrations;
using System.Linq;
using Data.Model;

namespace Data.SeedExtensions
{
    public static class BlogExtensions
    {
        public static Blog AddSeed(this DbSet<Blog> blogs, BlogContext context, string name,
            Action<Blog> configItem = null)
        {
            var item = new Blog
            {
                Name = name
            };

            if (configItem != null)
            {
                configItem(item);
            }

            blogs.AddOrUpdate(x => x.Name, item);
            context.SaveChanges();

            return blogs.First(x => x.Name.Equals(name, StringComparison.CurrentCultureIgnoreCase));
        }
    }
}