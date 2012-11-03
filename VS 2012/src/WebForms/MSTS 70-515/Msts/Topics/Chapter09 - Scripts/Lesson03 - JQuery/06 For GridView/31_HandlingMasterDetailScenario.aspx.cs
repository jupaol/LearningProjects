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
    public partial class _31_HandlingMasterDetailScenario : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        [WebMethod]
        public static Employee GetDetails(string employeeID)
        {
            var ctx = new PubsDataContext();
            var emp = ctx.employee.FirstOrDefault(x => x.emp_id == employeeID);

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