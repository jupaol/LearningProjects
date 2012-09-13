using JQueryRecipesForAsp.Net.DataAccess;
using JQueryRecipesForAsp.Net.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace JQueryRecipesForAsp.Net.Receipes.ForGridView
{
    public partial class _30_PagingGridView : System.Web.UI.Page
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
                    EmployeeID = x.emp_id, FirstName = x.fname, LastName = x.lname
                }).ToList()
            };
        }
    }
}