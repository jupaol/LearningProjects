using JQueryRecipesForAsp.Net.DataAccess;
using JQueryRecipesForAsp.Net.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Activation;
using System.Text;

namespace JQueryRecipesForAsp.Net.Receipes.ForAjax
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "EmployeesServiceWCF" in code, svc and config file together.
    // NOTE: In order to launch WCF Test Client for testing this service, please select EmployeesServiceWCF.svc or EmployeesServiceWCF.svc.cs at the Solution Explorer and start debugging.
    [AspNetCompatibilityRequirements(RequirementsMode = AspNetCompatibilityRequirementsMode.Allowed)]
    public class EmployeesServiceWCF : IEmployeesServiceWCF
    {
        public List<Employee> GetEmployees(int page)
        {
            var ctx = new PubsDataContext();
            var pageSize = 10;

            return ctx.employee.Skip(page * pageSize).Take(pageSize).Select(x => new Employee
                {
                    EmployeeID = x.emp_id,
                    FirstName = x.fname,
                    LastName = x.lname
                }).ToList();
        }

        public List<Job> GetJobs()
        {
            var ctx = new PubsDataContext();

            return ctx.jobs.Select(x => new Job
                {
                    JobID = x.job_id,
                    Description = x.job_desc
                }).ToList();
        }

        public List<Employee> GetEmployeeByJob(short jobID)
        {
            var ctx = new PubsDataContext();

            return ctx.employee.Where(x => x.job_id == jobID).Select(x => new Employee
                {
                    EmployeeID = x.emp_id,
                    FirstName = x.fname,
                    LastName = x.lname
                }).ToList();
        }
    }
}
