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
                    //path = AppDomain.CurrentDomain.BaseDirectory;
                    path = this.Server.MapPath("~");
                }

                this.directory.Text = Server.HtmlEncode(path);

                var dir = new DirectoryInfo(path);

                this.gv.DataSource = dir.EnumerateFiles().OrderBy(x => x.Name)
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

                var directories = dir.EnumerateDirectories();

                if (path.Equals(this.Server.MapPath("~"), StringComparison.InvariantCultureIgnoreCase))
                {
                    directories = directories.Where(x => x.FullName.Equals(this.Server.MapPath("~/Topics"), StringComparison.InvariantCultureIgnoreCase));
                }

                this.gvDirectories.DataSource = directories.OrderBy(x => x.Name)
                    .Select(x =>
                    {
                        return new
                        {
                            Url = string.Format("{0}?path={1}", 
                                this.ResolveClientUrl("~/ShowDirectoryPages.aspx"),
                                x.FullName),
                            Display = x.Name
                        };
                    });
                this.gvDirectories.DataBind();
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