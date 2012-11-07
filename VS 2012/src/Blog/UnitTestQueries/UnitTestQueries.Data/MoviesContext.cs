using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UnitTestQueries.Data
{
    public class MoviesContext : DbContext
    {
        public MoviesContext()
            : base("MoviesCS")
        {

        }

        public MoviesContext(string connectionString)
            : base(connectionString)
        {

        }

        public DbSet<Movie> Movies { get; set; }
    }
}
