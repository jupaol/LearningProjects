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
    
    public partial class Server
    {
        public Server()
        {
            this.NetworkResources = new HashSet<NetworkResource>();
            this.SsisDeployments = new HashSet<SsisDeployment>();
        }
    
        public System.Guid ServerId { get; set; }
        public string Name { get; set; }
        public string Alias { get; set; }
        public bool UseAliasToConnect { get; set; }
        public bool UsePowerShellRemoteCredentials { get; set; }
        public string PowerShellRemoteUsername { get; set; }
        public string PowerShellRemotePassword { get; set; }
        public string Description { get; set; }
    
        public virtual ICollection<NetworkResource> NetworkResources { get; set; }
        public virtual ICollection<SsisDeployment> SsisDeployments { get; set; }
    }
}
