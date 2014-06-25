using System.Data.Entity.Migrations;
using Data.Seed;

namespace Data.Migrations
{
    internal sealed class Configuration : DbMigrationsConfiguration<BlogContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(BlogContext context)
        {
            DataProvider.PopulateData(context);
        }
    }
}
