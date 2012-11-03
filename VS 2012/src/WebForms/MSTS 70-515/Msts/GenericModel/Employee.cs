using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;

namespace Msts.GenericModel
{
    [DataContract]
    public class Employee
    {
        [DataMember]
        public string EmployeeID { get; set; }

        [DataMember]
        public string FirstName { get; set; }

        [DataMember]
        public string LastName { get; set; }
    }
}
