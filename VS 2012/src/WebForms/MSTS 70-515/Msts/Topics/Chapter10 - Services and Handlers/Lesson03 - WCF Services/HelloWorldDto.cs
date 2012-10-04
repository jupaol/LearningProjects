using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Web;

namespace Msts.Topics.Chapter10___Services_and_Handlers.Lesson03___WCF_Services
{
    [DataContract]
    public class HelloWorldDto
    {
        [DataMember]
        public string Message { get; set; }

        [DataMember]
        public DateTime BirthdayDate { get; set; }

        [DataMember]
        public DateTime ProcessedDate { get; set; }
    }
}