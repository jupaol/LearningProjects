using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;

namespace MyServiceHost
{
    [DataContract]
    public class HelloWorldDto
    {
        [DataMember]
        public DateTime ProcessDate { get; set; }

        [DataMember]
        public string Message { get; set; }

        [DataMember]
        public int ServerTicks { get; set; }
    }
}
