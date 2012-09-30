using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Web;
using System.Web.Services;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Msts.Topics.Chapter09___Scripts.Lesson03___JQuery
{
    public partial class AjaxCallToPageMethod : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        [WebMethod]
        public static MyDomainObject GetDomainObject(string name)
        {
            var r = new Random((int)DateTime.Now.Ticks);

            Thread.Sleep(2000);
            //throw new NotImplementedException();

            return new MyDomainObject
            {
                DateTime = DateTime.Now,
                ID = Guid.NewGuid(),
                Name = name + " - approved",
                Range = Enumerable.Range(r.Next(30), r.Next(30, 60))
            };
        }
    }
}