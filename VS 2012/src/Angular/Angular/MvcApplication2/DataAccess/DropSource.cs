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
    
    public partial class DropSource
    {
        public DropSource()
        {
            this.DatabaseDeployments = new HashSet<DatabaseDeployment>();
            this.FileDeployments = new HashSet<FileDeployment>();
            this.NugetDeployments = new HashSet<NugetDeployment>();
            this.PowerShellModuleDeployments = new HashSet<PowerShellModuleDeployment>();
            this.SsisDeployments = new HashSet<SsisDeployment>();
            this.WebDeployments = new HashSet<WebDeployment>();
            this.ZipDeployments = new HashSet<ZipDeployment>();
        }
    
        public System.Guid DropSourceId { get; set; }
        public string Name { get; set; }
        public System.Guid Configuration_ConfigurationId { get; set; }
        public System.Guid Platform_PlatformId { get; set; }
        public Nullable<System.Guid> Solution_SolutionId { get; set; }
    
        public virtual Configuration Configuration { get; set; }
        public virtual ICollection<DatabaseDeployment> DatabaseDeployments { get; set; }
        public virtual Platform Platform { get; set; }
        public virtual Solution Solution { get; set; }
        public virtual ICollection<FileDeployment> FileDeployments { get; set; }
        public virtual ICollection<NugetDeployment> NugetDeployments { get; set; }
        public virtual ICollection<PowerShellModuleDeployment> PowerShellModuleDeployments { get; set; }
        public virtual ICollection<SsisDeployment> SsisDeployments { get; set; }
        public virtual ICollection<WebDeployment> WebDeployments { get; set; }
        public virtual ICollection<ZipDeployment> ZipDeployments { get; set; }
    }
}
