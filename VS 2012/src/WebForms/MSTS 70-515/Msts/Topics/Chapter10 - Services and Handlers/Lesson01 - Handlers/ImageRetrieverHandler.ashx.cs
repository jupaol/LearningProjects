using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Msts.Topics.Chapter10___Services_and_Handlers.Lesson01___Handlers
{
    /// <summary>
    /// Summary description for ImageRetrieverHandler
    /// </summary>
    public class ImageRetrieverHandler : IHttpHandler
    {

        public void ProcessRequest(HttpContext context)
        {
            context.Response.ContentType = "image/jpg";
            context.Response.TransmitFile(context.Request.PhysicalApplicationPath + "/Content/Images/logo.jpg");
        }

        public bool IsReusable
        {
            get
            {
                return false;
            }
        }
    }
}