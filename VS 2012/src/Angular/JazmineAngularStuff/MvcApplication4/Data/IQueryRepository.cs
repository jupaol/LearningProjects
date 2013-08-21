using System.Collections.Generic;
using MvcApplication4.Models.Phones;

namespace MvcApplication4.Data
{
    public interface IQueryRepository
    {
        IList<Phone> GetPhones();
    }
}
