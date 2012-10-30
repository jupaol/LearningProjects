using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.ModelBinding;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Msts
{
    public partial class ShowDirectoryPages : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!this.IsPostBack)
            {
                var path = this.Request.QueryString["path"];

                if (path == null)
                {
                    path = AppDomain.CurrentDomain.BaseDirectory;
                }

                this.directory.Text = Server.HtmlEncode(path);

                var dir = new DirectoryInfo(path);

                this.gv.DataSource = dir.EnumerateFiles()
                    .Where(x => this.GetValidExtensions().Contains(x.Extension))
                    .Select(x =>
                    {
                        var url = x.FullName.Replace(Server.MapPath("~").TrimEnd('\\'), string.Empty).Replace("\\", "/");

                        if (string.IsNullOrWhiteSpace(url))
                        {
                            url = "/";
                        }

                        return new
                        {
                            Display = Path.GetFileNameWithoutExtension(x.Name),
                            Url = url
                        };
                    }).AsQueryable();
                this.gv.DataBind();
            }
        }

        private IEnumerable<string> GetValidExtensions()
        {
            yield return ".aspx";
            yield return ".myhandler";
            yield return ".ashx";
            yield return ".asmx";
            yield return ".svc";
        }
    }
}