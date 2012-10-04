using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;

namespace MyServiceHost
{
    [DataContract]
    public class HelloWorldMessage
    {
        [DataMember]
        public string Name { get; set; }
    }
}
