using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using MvcApplication2.Hubs;
using MvcApplication2.Models;

namespace MvcApplication2.DataAccess
{
    public class JobRepository
    {

        public IEnumerable<JobModel> GetData(short minLevel)
        {

            using (var connection = new SqlConnection(ConfigurationManager.ConnectionStrings["PubsEntitiesSimpleConnectionString"].ConnectionString))
            {
                connection.Open();
                using (var command = new SqlCommand(string.Format(@"SELECT [job_id],[job_desc]
                FROM [dbo].[jobs]"), connection))
                //WHERE [min_lvl] > {0}", minLevel), connection))
                {
                    // Make sure the command object does not already have
                    // a notification object associated with it.
                    command.Notification = null;

                    var dependency = new SqlDependency(command);
                    dependency.OnChange += dependency_OnChange;

                    if (connection.State == ConnectionState.Closed)
                    {
                        connection.Open();
                    }

                    using (var reader = command.ExecuteReader())
                    {
                        return reader.Cast<IDataRecord>()
                                     .Select(x => new JobModel
                                         {
                                             job_id = x.GetInt16(0),
                                             job_desc = x.GetString(1)
                                         }).ToList();
                    }
                }
            }
        }
        private void dependency_OnChange(object sender, SqlNotificationEventArgs e)
        {
            JobHub.Show();
        }


    }
}