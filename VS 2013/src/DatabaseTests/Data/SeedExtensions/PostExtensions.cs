using System;
using System.Data.Entity;
using System.Data.Entity.Migrations;
using System.Linq;
using Data.Model;

namespace Data.SeedExtensions
{
    public static class PostExtensions
    {
        public static Post AddSeed(this DbSet<Post> posts, BlogContext context, string title, DateTime publishDate,
            Blog blog, Author author, Action<Post> configItem = null)
        {
            var item = new Post
            {
                Author = author,
                AuthorId = author.AuthorId,
                Blog = blog,
                BlogId = blog.BlogId,
                PublishDate = publishDate,
                Title = title
            };

            if (configItem != null)
            {
                configItem(item);
            }

            posts.AddOrUpdate(x => x.Title, item);
            context.SaveChanges();

            return posts.First(x => x.Title.Equals(title, StringComparison.CurrentCultureIgnoreCase));
        }
    }
}