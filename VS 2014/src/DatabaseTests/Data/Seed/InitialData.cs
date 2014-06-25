using Data.SeedExtensions;

namespace Data.Seed
{
    public class DataProvider
    {
        public static void PopulateData(BlogContext context)
        {
            var saganAuthor = context.Authors.AddSeed(context, "JP", "jp@someemail.com");
            
        }
    }
}
