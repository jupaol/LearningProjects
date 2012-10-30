using CuttingEdge.Conditions;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;

namespace Msts.Topics.Chapter05___Validation_and_navigation.Lesson02___Site_Navigation
{
    public class FilesLocator
    {
        public IEnumerable<string> FindFiles(string path, bool recursively = false, string filter = "*.*")
        {
            Condition.Requires(filter).IsNotNullOrWhiteSpace();
            Condition.Requires(path).IsNotNullOrWhiteSpace();
            Condition.Requires(Directory.Exists(path)).IsTrue();

            var files = Enumerable.Empty<string>();

            if (!recursively)
            {
                files = Directory.EnumerateFiles(path, filter, SearchOption.TopDirectoryOnly);
            }
            else
            {
                files = Directory.EnumerateFiles(path, filter, SearchOption.AllDirectories);
            }

            return files;
        }
    }
}