using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;

namespace Msts.DynamicDataSite.DataAccess
{
    public class Employee_Metadata
    {
        [UIHint("CustomDate")]
        public object hire_date { get; set; }
    }
}
