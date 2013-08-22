using System.Data.Entity;

namespace NinjectWithInMvcAndWcf.Data
{
    public class MyDataContext : DbContext
    {
        public MyDataContext(string connectionString)
            : base(connectionString)
        {
            
        }
    }
}