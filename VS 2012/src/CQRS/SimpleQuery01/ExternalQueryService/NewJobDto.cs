using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Web;

namespace ExternalQueryService
{
    [DataContract]
    public class NewJobDto
    {
        [DataMember]
        public Int16 ID { get; set; }

        [DataMember]
        public string Description { get; set; }

        [DataMember]
        public byte Minimum { get; set; }

        [DataMember]
        public byte Maximum { get; set; }
    }
}