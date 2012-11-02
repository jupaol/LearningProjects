using CuttingEdge.Conditions;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;

namespace Msts.Topics.Chapter05___Validation_and_navigation.Lesson02___Site_Navigation
{
    public class SiteMapNodeGenerator
    {
        private HttpContext context;

        public SiteMapNodeGenerator()
        {
            this.context = HttpContext.Current;
        }

        public SiteMapNode CreateSiteMapNode(SiteMapNode rootSiteMapNode, string rootPath, Action<SiteMapNode, SiteMapNode> addNodeDelegate, params string[] approvedDirectories)
        {
            Condition.Requires(rootSiteMapNode).IsNotNull();
            Condition.Requires(addNodeDelegate).IsNotNull();
            Condition.Requires(rootPath).IsNotNullOrWhiteSpace();

            var res = this.CreateSiteMapNodeRecursively(rootSiteMapNode, new DirectoryInfo(rootPath), addNodeDelegate, approvedDirectories);

            Condition.Ensures(res).IsNotNull();
            return res;
        }

        private string CalculateUrl(DirectoryInfo directory)
        {
            return string.Format("/ShowDirectoryPages.aspx?path=" + directory.FullName);
        }

        private string CalculateUrl(string path)
        {
            var s = path.Replace(this.context.Server.MapPath("~").TrimEnd('\\'), string.Empty);
            var segments = s.Replace("\\", "/");

            if (string.IsNullOrWhiteSpace(segments))
            {
                segments = "/";
            }

            return segments;
        }

        private SiteMapNode CreateSiteMapNodeRecursively(SiteMapNode workingNode, DirectoryInfo workingDirectory, Action<SiteMapNode, SiteMapNode> addNodeDelegate, params string[] approvedDirectories)
        {
            var url = this.CalculateUrl(workingDirectory);
            var title = workingDirectory.Name;
            var key = workingDirectory.FullName;
            var node = new SiteMapNode(workingNode.Provider, key, url, title);
            var files = this.GetFiles(workingDirectory);

            if (workingNode.Provider.FindSiteMapNodeFromKey(key) == null)
            {
                addNodeDelegate(node, workingNode);
            }
            else
            {
                node = workingNode;
            }

            foreach (var file in files)
            {
                var linkNodeKey = file;
                var linkNodeUrl = this.CalculateUrl(file);
                var linkNodeTitle = string.Empty;
                var fileExtension = Path.GetExtension(file);

                if (fileExtension.Equals(".aspx", StringComparison.InvariantCultureIgnoreCase))
                {
                    linkNodeTitle = Path.GetFileNameWithoutExtension(file);
                }
                else
                {
                    linkNodeTitle = Path.GetFileName(file);
                }

                var linkNode = new SiteMapNode(workingNode.Provider, linkNodeKey, linkNodeUrl, linkNodeTitle);

                addNodeDelegate(linkNode, node);
            }

            var workingDirectories = workingDirectory.EnumerateDirectories();

            if (workingNode.RootNode.Equals(node))
            {
                workingDirectories = workingDirectories.Where(x => approvedDirectories.Contains(x.Name.ToLowerInvariant()));
            }

            foreach (var directory in workingDirectories)
            {
                this.CreateSiteMapNodeRecursively(node, directory, addNodeDelegate, approvedDirectories);
            }

            return workingNode.RootNode;
        }

        private IEnumerable<string> GetValidExtensions()
        {
            yield return ".aspx";
            yield return ".myhandler";
            yield return ".ashx";
            yield return ".asmx";
            yield return ".svc";
        }

        private IEnumerable<string> GetFiles(DirectoryInfo rootDirectory)
        {
            var files = rootDirectory.EnumerateFiles("*.*", SearchOption.TopDirectoryOnly)
                .Where(x => this.GetValidExtensions().Contains(x.Extension))
                .Select(x => x.FullName);

            return files;
        }
    }
}