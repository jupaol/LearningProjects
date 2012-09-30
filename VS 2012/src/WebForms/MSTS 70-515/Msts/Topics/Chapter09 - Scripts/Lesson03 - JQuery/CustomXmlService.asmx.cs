using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Web;
using System.Web.Script.Services;
using System.Web.Services;
using System.Xml.Linq;

namespace Msts.Topics.Chapter09___Scripts.Lesson03___JQuery
{
    /// <summary>
    /// Summary description for CustomXmlService
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // To allow this Web Service to be called from script, using ASP.NET AJAX, uncomment the following line. 
    [ScriptService]
    public class CustomXmlService : System.Web.Services.WebService
    {

        [WebMethod]
        [ScriptMethod(ResponseFormat = ResponseFormat.Xml, UseHttpGet = true)]
        public string GetCustomXml()
        {
            var doc = XDocument.Load(Server.MapPath("~/Topics/Chapter09 - Scripts/Lesson03 - JQuery/MyXmlFile.xml"));
            var s = doc.ToString();

            Thread.Sleep(2000);

            return s;
        }
    }
}
