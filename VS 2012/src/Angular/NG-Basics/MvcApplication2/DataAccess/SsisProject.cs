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
    
    public partial class SsisProject
    {
        public SsisProject()
        {
            this.SsisDeployments = new HashSet<SsisDeployment>();
        }
    
        public System.Guid SsisProjectId { get; set; }
        public string Name { get; set; }
    
        public virtual ICollection<SsisDeployment> SsisDeployments { get; set; }
    }
}
