using Msts.DataAccess;
using Msts.GenericModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services;

namespace Msts.Topics.Chapter09___Scripts.Lesson03___JQuery._10_For_AJAX
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
