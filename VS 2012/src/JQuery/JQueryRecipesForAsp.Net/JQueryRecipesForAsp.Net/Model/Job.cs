using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Web;

namespace JQueryRecipesForAsp.Net.Model
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