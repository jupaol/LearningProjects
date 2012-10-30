using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Web;
using FluentAssertions;
using Msts.Topics.Chapter05___Validation_and_navigation.Lesson02___Site_Navigation;
using System.IO;

namespace Msts.Tests
{
    [TestClass]
    public class SiteMapNodeGeneratorTests
    {
        [TestClass]
        public class TheCreateSiteMapNodeMethod
        {
            [TestMethod]
            [Ignore]
            public void it_should_create_a_simple_SiteMapNode_when_the_specified_file_is_under_the_path_specified()
            {
                var sut = SiteMapNodeGeneratorBuilder.New;

                SiteMapNode res = sut.InvokeCreateSiteMapNode();

                res.Should().NotBeNull();
            }
        }
    }
}
