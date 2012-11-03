using Msts.DataAccess;
using Msts.GenericModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Msts.Topics.Chapter09___Scripts.Lesson03___JQuery._06_For_GridView
{
    public partial class _30_PagingAGridView : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        [WebMethod]
        public static EmployeesResult GetEmployees(int skip, int take)
        {
            var ctx = new PubsDataContext();

            return new EmployeesResult
            {
                TotalRecords = ctx.employee.Count(),
                Employees = ctx.employee.Skip(skip).Take(take).Select(x => new Employee
                {
                    EmployeeID = x.emp_id,
                    FirstName = x.fname,
                    LastName = x.lname
                }).ToList()
            };
        }
    }
}