namespace Msts.Mvc.Migrations
{
    using Msts.Mvc.Areas.Movies.Models;
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<Msts.Mvc.DataAccess.MovieContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = true;
        }

        protected override void Seed(Msts.Mvc.DataAccess.MovieContext context)
        {
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method 
            //  to avoid creating duplicate seed data. E.g.
            //
            //    context.People.AddOrUpdate(
            //      p => p.FullName,
            //      new Person { FullName = "Andrew Peters" },
            //      new Person { FullName = "Brice Lambson" },
            //      new Person { FullName = "Rowan Miller" }
            //    );
            //

            context.Movies.AddOrUpdate(x => x.Title,
                new Movie
                {
                    Genre = "Science Fiction",
                    Price = 43.54m,
                    ReleaseData = DateTime.Now,
                    Title = "World Of Warcraft",
                    Rating = "G"
                });
        }
    }
}
