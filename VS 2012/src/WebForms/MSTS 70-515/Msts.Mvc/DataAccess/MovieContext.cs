using Msts.Mvc.Areas.Movies.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace Msts.Mvc.DataAccess
{
    public class MovieContext : DbContext
    {
        public MovieContext()
        {

        }

        public MovieContext(string connectionString)
            : base(connectionString)
        {

        }

        public DbSet<Movie> Movies { get; set; }
    }
}