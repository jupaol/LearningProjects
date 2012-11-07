using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UnitTestQueries.Logic
{
    public sealed class MovieID : IQueryID
    {
        public MovieID(Guid id)
        {
            this.ID = id;
        }

        public Guid ID { get; private set; }
    }
}
