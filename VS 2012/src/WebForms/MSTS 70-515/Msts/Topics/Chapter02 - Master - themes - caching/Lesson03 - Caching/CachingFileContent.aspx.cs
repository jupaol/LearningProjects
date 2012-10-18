using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Caching;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Msts.Topics.Chapter02.Lesson03
{
    public partial class CachingFileContent : System.Web.UI.Page
    {
        private const string FileName = "~/Topics/Chapter02 - Master - themes - caching/Lesson03 - Caching/Licence.txt";

        protected void Page_Load(object sender, EventArgs e)
        {
            this.fileName.Text = Server.HtmlEncode(FileName);
            this.fileName2.Text = Server.HtmlEncode(FileName);
            this.fileContent.Text = this.GetFileContent(FileName);
            this.fileContent2.Text = this.GetFileContent2(FileName);
        }

        private string GetFileContent(string relativeFilePath)
        {
            if (string.IsNullOrWhiteSpace(relativeFilePath))
            {
                throw new ArgumentNullException("relativeFilePath");
            }

            var file = this.Cache["file"];
            var textFromFile = string.Empty;
            var absoluteFilePath = this.Server.MapPath(relativeFilePath);

            if (file == null)
            {
                this.Trace.Warn("Reading directly from file");
                this.msg.Text = "Reading directly from file";
                textFromFile = this.GetTextFromFile(absoluteFilePath);

                var fileCacheDependency = new CacheDependency(new[] { absoluteFilePath });

                this.Cache.Insert("file", textFromFile, fileCacheDependency, Cache.NoAbsoluteExpiration, Cache.NoSlidingExpiration, CacheItemPriority.High, null);
            }
            else
            {
                this.Trace.Warn("Reading directly from cache");
                this.msg.Text = "Reading directly from cache";
                textFromFile = file.ToString();
            }

            return textFromFile;
        }

        private string GetFileContent2(string relativeFilePath)
        {
            if (string.IsNullOrWhiteSpace(relativeFilePath))
            {
                throw new ArgumentNullException("relativeFilePath");
            }

            var file = this.Cache["file2"];
            var textFromFile = string.Empty;
            var absoluteFilePath = this.Server.MapPath(relativeFilePath);

            if (file == null)
            {
                textFromFile = this.GetTextFromFile(absoluteFilePath);

                var fileCacheDependency = new CacheDependency(new[] { absoluteFilePath });
                var aggregateCacheDependencies = new AggregateCacheDependency();

                this.Cache.Insert("trigger", DateTime.Now, null, DateTime.Now.AddSeconds(30), Cache.NoSlidingExpiration, CacheItemPriority.High, null);
                var cacheItemCacheDependency = new CacheDependency(null, new[] { "trigger" });

                aggregateCacheDependencies.Add(fileCacheDependency, cacheItemCacheDependency);

                this.Cache.Insert("file2", textFromFile, aggregateCacheDependencies, Cache.NoAbsoluteExpiration, TimeSpan.FromSeconds(10), CacheItemPriority.High, null);

                this.Trace.Warn("Reading directly from file (2)");
                this.msg2.Text = "Reading directly from file";
            }
            else
            {
                this.Trace.Warn("Reading directly from cache (2)");
                this.msg2.Text = "Reading directly from cache";
                textFromFile = file.ToString();
            }

            return textFromFile;
        }

        private string GetTextFromFile(string absoluteFilePath)
        {
            var textFromFile = string.Empty;

            using (var stream = new StreamReader(absoluteFilePath))
            {
                textFromFile = stream.ReadToEnd();
            }

            return textFromFile;
        }
    }
}