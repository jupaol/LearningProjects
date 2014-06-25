using System;
using Data.SeedExtensions;

namespace Data.Seed
{
    public class DataProvider
    {
        public static void PopulateData(BlogContext context)
        {
            var jpAuthor = context.Authors.AddSeed(context, "JP", "jp@someemail.com");
            var miskoAuthor = context.Authors.AddSeed(context, "Misko Hevery", "misko@google.com");
            var blog = context.Blogs.AddSeed(context, "Super Nerd Blog!");
            
            context.Posts.AddSeed(context, "Database tests using EntityFramework 6 - Code First approach",
                DateTime.Now, blog, jpAuthor);
            context.Posts.AddSeed(context,
                "Building/Publishing ClickOnce projects in a TFS build server without installing Visual Studio",
                new DateTime(2014, 6, 23), blog, jpAuthor);
            context.Posts.AddSeed(context, "Enabling unobtrusive validation from scratch in ASP.Net 4.5 webforms",
                new DateTime(2012, 9, 17), blog, jpAuthor);

            context.Posts.AddSeed(context, "Top 10 Things I do on Every Project",
                new DateTime(2008, 7, 16), blog, miskoAuthor);
            context.Posts.AddSeed(context, "To 'new' or not to 'new'…",
                new DateTime(2008, 9, 30), blog, miskoAuthor);
        }
    }
}
