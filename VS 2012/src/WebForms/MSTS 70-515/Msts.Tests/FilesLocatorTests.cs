using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using FluentAssertions;
using System.IO;
using Msts.Topics.Chapter05___Validation_and_navigation.Lesson02___Site_Navigation;

namespace Msts.Tests
{
    [TestClass]
    public class FilesLocatorTests
    {
        [TestClass]
        public class TheFindFilesMethod
        {
            public TestContext TestContext { get; set; }

            [TestMethod]
            public void it_should_return_all_the_files_from_the_top_directory_when_the_recursively_parameter_is_false()
            {
                var sut = new FilesLocator();
                var path = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "TestingFiles");
                var filter = "*.aspx";

                IEnumerable<string> res = sut.FindFiles(path: path, filter: filter);

                res.Should().NotBeNull().And.NotBeEmpty().And.NotContainNulls().And.OnlyHaveUniqueItems()
                    .And.HaveCount(3)
                    .And.ContainSingle(x => x.Contains("Page1.aspx"))
                    .And.ContainSingle(x => x.Contains("Page2.aspx"))
                    .And.ContainSingle(x => x.Contains("Page3.aspx"));
            }

            [TestMethod]
            public void it_should_return_all_the_files_from_the_top_directory_only_when_the_recursively_parameter_is_false_and_the_filter_parameter_is_null_or_empty()
            {
                var sut = new FilesLocator();
                var path = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "TestingFiles");
                var expectedFiles = new[]
                    {
                        Path.Combine(path, "Page1.aspx"),
                        Path.Combine(path, "Page2.aspx"),
                        Path.Combine(path, "Page3.aspx"),
                        Path.Combine(path, "Page1.aspx.cs"),
                        Path.Combine(path, "Page2.aspx.cs"),
                        Path.Combine(path, "Page3.aspx.cs")
                    };
                expectedFiles = expectedFiles.OrderBy(x => x).ToArray();

                IEnumerable<string> res = sut.FindFiles(path: path);
                res = res.OrderBy(x => x);

                res.Should().NotBeNull().And.NotBeEmpty().And.NotContainNulls().And.OnlyHaveUniqueItems()
                    .And.HaveCount(6)
                    .And.ContainInOrder(expectedFiles);
            }

            [TestMethod]
            public void it_should_return_the_matching_files_from_all_directories_when_the_filter_is_specified_and_the_recursively_parameter_is_true()
            {
                var sut = new FilesLocator();
                var path = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "TestingFiles");
                var filter = "*.aspx";

                var res = sut.FindFiles(path, true, filter);

                res.Should().NotBeNull().And.HaveCount(8);
            }

            [TestMethod]
            public void it_should_return_all_the_files_from_all_directories_when_the_filter_is_not_specified_and_the_recursively_parameter_is_true()
            {
                var sut = new FilesLocator();
                var path = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "TestingFiles");

                var res = sut.FindFiles(path, true);

                res.Should().NotBeNull().And.HaveCount(16);
            }
        }
    }
}
