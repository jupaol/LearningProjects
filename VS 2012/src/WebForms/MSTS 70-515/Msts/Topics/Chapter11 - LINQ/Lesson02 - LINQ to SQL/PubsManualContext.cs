using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.Linq;
using System.Linq;
using System.Web;

namespace Msts.Topics.Chapter11___LINQ.Lesson02___LINQ_to_SQL
{
    public class PubsManualContext : DataContext
    {
        public PubsManualContext()
            : base (ConfigurationManager.ConnectionStrings["Msts"].ConnectionString)
        {

        }

        public Table<JobEnityManual> Jobs
        {
            get
            {
                return this.GetTable<JobEnityManual>();
            }
        }

        //public Table<EmployeeEnitytManual> Employees { get; set; }
    }
}