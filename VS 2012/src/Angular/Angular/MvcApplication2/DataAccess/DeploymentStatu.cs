//------------------------------------------------------------------------------
// <auto-generated>
//    This code was generated from a template.
//
//    Manual changes to this file may cause unexpected behavior in your application.
//    Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace MvcApplication2.DataAccess
{
    using System;
    using System.Collections.Generic;
    
    public partial class DeploymentStatu
    {
        public DeploymentStatu()
        {
            this.DeploymentLogs = new HashSet<DeploymentLog>();
        }
    
        public System.Guid DeploymentStatusId { get; set; }
        public string Status { get; set; }
    
        public virtual ICollection<DeploymentLog> DeploymentLogs { get; set; }
    }
}