using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnitTestQueries.Data;

namespace UnitTestQueries.Logic
{
    public interface IFindMoviesByTitleQueryHandler : IQueryHandler<FindMoviesByTitleQuery, Movie>
    {
    }
}
