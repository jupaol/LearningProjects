using System;
using System.IO;
using System.Linq;
using System.Web;

namespace MixedSiteMapProvider
{
    public class CustomSitemapProvider : XmlSiteMapProvider
    {
        private const string FileSystemContentNodeTitle = "My File System Content";
        private const string PubsContentNodeTitle = "PUBS Jobs";
        private readonly object LockObject = new Object();
        private SiteMapNode WorkingNode { get; set; }
        private bool BuildingNodes { get; set; }

        // this method has to be overriden in order to create the sitemap nodes
        public override SiteMapNode BuildSiteMap()
        {
            // we block the method to make it thread-safe
            lock (LockObject)
            {
                // this condition is the KEY, we need to ensure that this method is executed
                // only once. The problem is that internally, the SiteMapProvider class calls
                // this method several times. If we do not use this condition, we would get a
                // StackOverflowException
                if (this.BuildingNodes)
                {
                    return this.WorkingNode;
                }

                // we call the base BuildSiteMap method to get all the static nodes registered
                // statically in the Web.sitemap file. From here, we will configure this SiteMapNode
                // collection to add our custom nodes
                this.WorkingNode = base.BuildSiteMap();
                this.BuildingNodes = true;

                var fileSystemNode = 
                    this.WorkingNode.ChildNodes.OfType<SiteMapNode>().FirstOrDefault(x => x.Title.Equals(FileSystemContentNodeTitle, StringComparison.InvariantCultureIgnoreCase));

                if (fileSystemNode == null)
                {
                    // if we didn't find a node to explicitly add our content from the file system
                    // we will create a custom node
                    fileSystemNode = new SiteMapNode(this, FileSystemContentNodeTitle, string.Empty, FileSystemContentNodeTitle);
                    this.AddNode(fileSystemNode, this.WorkingNode);
                }

                // we iterate through all the files contained in the filesystem folder
                foreach (var file in Directory.GetFiles(HttpContext.Current.Server.MapPath("~/Topics/"), "*.aspx"))
                {
                    this.AddNode(
                        new SiteMapNode(this, file, VirtualPathUtility.ToAbsolute("~/Topics/") + Path.GetFileName(file), Path.GetFileNameWithoutExtension(file)), 
                        fileSystemNode);
                }

                // adding the jobs and employees from the database to the sitemap
                var pubsNode = this.WorkingNode.ChildNodes.OfType<SiteMapNode>().FirstOrDefault(x => x.Title.Equals(PubsContentNodeTitle, StringComparison.InvariantCultureIgnoreCase));

                // if the node does not exists, we will create a new node to serve as the base
                // for our database nodes
                if (pubsNode == null)
                {
                    pubsNode = new SiteMapNode(this, PubsContentNodeTitle, VirtualPathUtility.ToAbsolute("~/JobsList.aspx"), PubsContentNodeTitle);
                    this.AddNode(pubsNode, this.WorkingNode);
                }

                using (var ctx = new PubsDataContext())
                {
                    foreach (var empl in ctx.employee)
                    {
                        var job = empl.jobs;
                        var jobNode = this.FindSiteMapNodeFromKey(string.Format("Job:{0}", job.job_desc));

                        // if the job node has not been created yet, we will create it
                        if (jobNode == null)
                        {
                            jobNode = new SiteMapNode(this, string.Format("Job:{0}", job.job_desc), VirtualPathUtility.ToAbsolute("~/JobDetails.aspx?id=" + job.job_id.ToString()), job.job_desc);
                            this.AddNode(jobNode, pubsNode);
                        }

                        // we add the employee node
                        this.AddNode(
                            new SiteMapNode(this, "Employee:" + empl.emp_id, VirtualPathUtility.ToAbsolute("~/EmployeeDetails.aspx?id=" + empl.emp_id), empl.fname + " " + empl.lname), 
                            jobNode);
                    }
                }

                return this.WorkingNode;
            }
        }
    }
}