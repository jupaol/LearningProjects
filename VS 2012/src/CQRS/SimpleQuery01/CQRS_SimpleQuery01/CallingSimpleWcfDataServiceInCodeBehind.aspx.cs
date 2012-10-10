using Newtonsoft.Json;
using QueryRepository;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace CQRS_SimpleQuery01
{
    public partial class CallingSimpleWcfDataServiceInCodeBehind : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        public IEnumerable<JobDto> gv_GetData(int startRowIndex, int maximumRows, out int totalRowCount)
        {
            var client = new RestClient("http://localhost:58284/JobsWcfDataService.svc");
            var request = new RestRequest("jobs/?$top=" + maximumRows.ToString() + "&$skip=" + startRowIndex + "&$format=json", Method.GET);
            request.RequestFormat = DataFormat.Json;

            var response = client.Execute(request);
            var content = response.Content;
            var res = JsonConvert.DeserializeObject<Tmp>(content);

            request = new RestRequest("jobs/$count?$format=json", Method.GET);
            var count = JsonConvert.DeserializeObject<int>(client.Execute(request).Content);

            totalRowCount = count;


            return res.d.Select(x => new JobDto
                {
                    Description = x.job_desc,
                    ID = x.job_id,
                    Maximum = x.max_lvl,
                    Minimum = x.min_lvl
                }).AsEnumerable();
        }
    }

    public class __metadata
    {
        public string id { get; set; }
        public string uri { get; set; }
        public string type { get; set; }
    }

    public class JobDtoTmp
    {
        //public __metadata __metadata { get; set; }

        public Int16 job_id { get; set; }

        public string job_desc { get; set; }

        public byte min_lvl { get; set; }

        public byte max_lvl { get; set; }
    }

    public class Tmp
    {
        public JobDtoTmp[] d { get; set; }
    }
}