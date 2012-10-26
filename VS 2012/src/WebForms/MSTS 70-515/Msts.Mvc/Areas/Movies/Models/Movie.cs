using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Msts.Mvc.Areas.Movies.Models
{
    public class Movie
    {
        public int ID { get; set; }
        public string Title { get; set; }
        public DateTime ReleaseData { get; set; }
        public string Genre { get; set; }
        public decimal Price { get; set; }
        public string Rating { get; set; }
        public string Audience { get; set; }
    }
}