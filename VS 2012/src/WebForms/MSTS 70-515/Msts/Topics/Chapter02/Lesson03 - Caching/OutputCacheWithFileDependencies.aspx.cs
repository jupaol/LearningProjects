using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Msts.Topics.Chapter02.Lesson03
{
    public partial class OutputCacheWithFileDependencies : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            var filePath = Server.MapPath("~/Topics/Chapter02/Lesson03 - Caching/Licence.txt");

            this.fileContent.Text = File.ReadAllText(filePath);
            this.msg.Text = DateTime.Now.ToString();

            this.Response.AddFileDependency(filePath);
        }

        public static string CustomSubstitution(HttpContext context)
        {
            return DateTime.Now.ToString();
        }
    }
}