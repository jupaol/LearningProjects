using JQueryRecipesForAsp.Net.DataAccess;
using JQueryRecipesForAsp.Net.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel.Web;
using System.Web;
using System.Web.Services;

namespace JQueryRecipesForAsp.Net.Receipes.ForAjax
{
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    [System.Web.Script.Services.ScriptService]
    public class EmployeesService : System.Web.Services.WebService
    {
        [WebMethod]
        public List<Employee> GetEmployees()
        {
            var ctx = new PubsDataContext();

            return ctx.employee.Select(x => new Employee
                {
                    EmployeeID = x.emp_id,
                    FirstName = x.fname,
                    LastName = x.lname
                }).ToList();
        }
    }
}
