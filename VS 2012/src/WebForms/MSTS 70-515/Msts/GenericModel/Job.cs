using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Web;

namespace Msts.GenericModel
{
    [DataContract]
    public class Job
    {
        [DataMember]
        public short JobID { get; set; }

        [DataMember]
        public string Description { get; set; }
    }
}