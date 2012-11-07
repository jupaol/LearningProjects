using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnitTestQueries.Data;

namespace UnitTestQueries.Logic
{
    public sealed class FindMoviesByTitleQuery : IQuery
    {
        public FindMoviesByTitleQuery(string title)
        {
            this.Title = title;
        }

        public string Title { get; private set; }
    }
}
