using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Web;

namespace Msts.Mvc
{
    [DataContract]
    public class HelloWorldDto
    {
        [DataMember]
        public string Message { get; set; }
    }
}