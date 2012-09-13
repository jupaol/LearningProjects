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
    public partial class _31_HandlingMasterDetailScenarios : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        [WebMethod]
        public static Employee GetDetails(string employeeID)
        {
            var ctx = new PubsDataContext();
            var emp = ctx.employee.FirstOrDefault(x => x.emp_id ==  employeeID);

            if (emp == null)
            {
                return null;
            }

            return new Employee
            {
                EmployeeID = emp.emp_id,
                FirstName = emp.fname,
                LastName = emp.lname
            };
        }
    }
}