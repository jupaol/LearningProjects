using System;
using System.Collections.Generic;
using System.Linq;
using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace UnitTestProject2
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestMethod1()
        {
            var m = new MyClass();

            m.Invoking(x => x.Catch()).ShouldThrow<Exception>()
             .WithMessage("Inner nested1", ComparisonMode.Substring);

        }
    }



    public class MyClass
    {
        public void Raise()
        {
            var exc1 = new Exception("Inner nested1");
            var exc2 = new Exception("Inner nested2", exc1);
            var exc3 = new Exception("Inner nested3", exc2);
            var exc4 = new Exception("Inner nested4", exc3);
            var exc5 = new Exception("Inner nested5", exc4);
            var exc6 = new Exception("Inner nested6", exc5);
            var exc7 = new Exception("Inner nested7", exc6);

            throw exc7;
        }

        public void Catch()
        {
            try
            {
                Raise();
            }
            catch (Exception exc)
            {
                var m = ExceptionMessageFormatter.Format(exc, null);
                throw new Exception(string.Join("\n", m.ToArray()));
            }
        }
    }

    public static class ExceptionMessageFormatter
    {
        public static List<string> Format(Exception exception, List<string> messages)
        {
            if (messages == null)
            {
                messages = new List<string>();
            }

            messages.Add(exception.Message);

            if (exception.InnerException == null)
            {
                return messages;
            }

            Format(exception.InnerException, messages);

            return messages;
        }
    }
}
