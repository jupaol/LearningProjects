using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace JQueryRecipesForAsp.Net.Model
{
    public class EmployeesResult
    {
        public List<Employee> Employees { get; set; }
        public int TotalRecords { get; set; }
    }
}