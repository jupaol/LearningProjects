using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Msts.Mvc.Tests.DataAccess
{
    public class PubsContext : DbContext
    {
        public PubsContext(string connectionString)
            : base(connectionString)
        {

        }

        public PubsContext()
        {

        }

        public DbSet<Movie> Movies { get; set; }
    }

    public class Movie
    {
        public int ID { get; set; }
    }
}
