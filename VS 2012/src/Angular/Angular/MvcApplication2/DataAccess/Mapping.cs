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
    
    public partial class Mapping
    {
        public Mapping()
        {
            this.QualityMappings = new HashSet<QualityMapping>();
        }
    
        public System.Guid MappingId { get; set; }
        public string MappingName { get; set; }
        public System.Guid ScriptPath_ScriptPathId { get; set; }
        public System.Guid Build_BuildId { get; set; }
        public Nullable<System.Guid> Group_GroupId { get; set; }
    
        public virtual Build Build { get; set; }
        public virtual Group Group { get; set; }
        public virtual ScriptPath ScriptPath { get; set; }
        public virtual ICollection<QualityMapping> QualityMappings { get; set; }
    }
}