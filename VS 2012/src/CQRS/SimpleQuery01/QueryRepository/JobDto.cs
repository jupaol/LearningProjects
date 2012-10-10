using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace QueryRepository
{
    [DataContract]
    public class JobDto
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
