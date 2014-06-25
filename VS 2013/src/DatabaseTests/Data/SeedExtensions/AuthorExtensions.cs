using System;
using System.Data.Entity;
using System.Data.Entity.Migrations;
using System.Linq;
using Data.Model;

namespace Data.SeedExtensions
{
    public static class AuthorExtensions
    {
        public static Author AddSeed(this DbSet<Author> authors, BlogContext context, string name, string email,
            Action<Author> configItem = null)
        {
            var item = new Author
            {
                Name = name,
                Email = email
            };

            if (configItem != null)
            {
                configItem(item);
            }

            authors.AddOrUpdate(x => x.Name, item);
            context.SaveChanges();

            return authors.First(x => x.Name.Equals(name, StringComparison.CurrentCultureIgnoreCase));
        }
    }
}