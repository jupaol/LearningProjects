
using Msts.Topics.Chapter05___Validation_and_navigation.Lesson02___Site_Navigation;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace Msts.Tests
{
    public class SiteMapNodeGeneratorBuilder
    {
        public static SiteMapNodeGeneratorBuilder New
        {
            get
            {
                return new SiteMapNodeGeneratorBuilder();
            }
        }

        public SiteMapNodeGeneratorBuilder()
        {
            var sut = new SiteMapNodeGenerator();

            this.RootPath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "TestingFiles");
            this.RootSiteMapNode = new SiteMapNode(new XmlSiteMapProvider(), this.RootPath, this.RootPath, this.RootPath);

            this.Instance = sut;
        }

        public static implicit operator SiteMapNodeGenerator(SiteMapNodeGeneratorBuilder builder)
        {
            return builder.Build();
        }

        public SiteMapNodeGeneratorBuilder ChangeRootPath(string rootPath)
        {
            this.RootPath = rootPath;
            return this;
        }

        public SiteMapNodeGeneratorBuilder ChangeRootSiteMapNode(SiteMapNode rootSiteMapNode)
        {
            this.RootSiteMapNode = rootSiteMapNode;
            return this;
        }

        public SiteMapNode InvokeCreateSiteMapNode()
        {
            var instance = this.Build();

            return instance.CreateSiteMapNode(this.RootSiteMapNode, this.RootPath, (x, y) => { });
        }

        private SiteMapNodeGenerator Build()
        {
            return this.Instance;
        }

        private SiteMapNodeGenerator Instance { get; set; }
        public string RootPath { get; private set; }
        public SiteMapNode RootSiteMapNode { get; private set; }
        public string FilePath { get; private set; }
    }
}
