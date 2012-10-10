using ClientProxy;
using QueryRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace CQRS_SimpleQuery01
{
    public partial class CallingSimpleWcfService : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        public IQueryable<JobDto> gv_GetData()
        {
            return new Proxy().GetJobs();
        }
    }
}