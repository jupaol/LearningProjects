using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.IO;
using System.Linq;
using System.Web;
using System.Xml.Linq;

namespace Msts.Topics.Chapter05.Lesson02
{
    public class CustomSiteMapProvider : StaticSiteMapProvider
    {
        private SiteMapNode rootNode { get; set; }
        private readonly object LockObject = new Object();

        public override SiteMapNode BuildSiteMap()
        {
            lock (LockObject)
            {
                if (this.rootNode != null)
                {
                    return this.rootNode;
                }

                this.Clear();

                var topicsPath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Topics");
                var root = new SiteMapNode(this, "Home", "/", "Home", "Home");                
                var files = this.GetFiles(topicsPath).ToList();

                this.rootNode = root;
                this.AddNode(root);

                var tracing = new SiteMapNode(this, "tracinKey", "/trace.axd", "Tracing page");

                this.AddNode(tracing, root);

                foreach (var filePath in files)
                {
                    var fileName = Path.GetFileName(filePath);

                    var currentFile = new FileInfo(filePath);
                    var currentDirectory = new DirectoryInfo(currentFile.DirectoryName);
                    var previousDirectory = new DirectoryInfo(currentDirectory.Parent.FullName);

                    var currentDirectoryName = currentDirectory.Name;
                    var previousDirectoryName = previousDirectory.Name;

                    var currentDirectoryKey = string.Format("{0} - {1}", previousDirectoryName, currentDirectoryName);
                    var previousDirectoryKey = string.Format("{0}", previousDirectoryName);
                    
                    var currentNode = this.FindSiteMapNodeFromKey(currentDirectoryKey);
                    var previousNode = this.FindSiteMapNodeFromKey(previousDirectoryKey);

                    if (previousNode == null)
                    {
                        previousNode = new SiteMapNode(this, previousDirectoryKey, string.Empty, previousDirectoryName);
                        this.AddNode(previousNode, root);
                    }

                    if (currentNode == null)
                    {
                        currentNode = new SiteMapNode(this, currentDirectoryKey, string.Empty, currentDirectoryName) { ParentNode = root };
                        this.AddNode(currentNode, previousNode);
                    }

                    var fileNode = new SiteMapNode(this, filePath, string.Format("~/Topics/{0}/{1}/{2}", previousDirectoryName, currentDirectoryName, fileName), Path.GetFileNameWithoutExtension(fileName));

                    this.AddNode(fileNode, currentNode);
                }

                return root;
            }
        }

        protected override void Clear()
        {
            lock (LockObject)
            {
                this.rootNode = null;

                base.Clear();
            }
        }

        private List<string> GetFiles(string rootPath)
        {
            var d = new DirectoryInfo(rootPath);
            var directoryFullName = Path.GetDirectoryName(d.FullName);
            var directoryName = d.Name;
            //var newNode = this.FindSiteMapNodeFromKey(directoryFullName);
            var files = new List<string>();

            //if (newNode == null)
            //{
            //    newNode = new SiteMapNode(this, directoryFullName, null, directoryName, directoryName)
            //        {
            //            ParentNode = parentNode
            //        };
            //    this.AddNode(newNode, parentNode);
            //}

            foreach (var file in d.GetFiles("*.aspx"))
            {
                files.Add(file.FullName);
            }

            foreach (var dir in d.GetDirectories())
            {
                files.AddRange(this.GetFiles(dir.FullName));
            }

            return files;
        }

        protected override SiteMapNode GetRootNodeCore()
        {
            return this.BuildSiteMap();
        }
    }
}