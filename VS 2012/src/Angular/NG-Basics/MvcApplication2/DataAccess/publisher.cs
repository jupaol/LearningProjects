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
    
    public partial class publisher
    {
        public publisher()
        {
            this.employees = new HashSet<employee>();
            this.titles = new HashSet<title>();
        }
    
        public string pub_id { get; set; }
        public string pub_name { get; set; }
        public string city { get; set; }
        public string state { get; set; }
        public string country { get; set; }
    
        public virtual ICollection<employee> employees { get; set; }
        public virtual pub_info pub_info { get; set; }
        public virtual ICollection<title> titles { get; set; }
    }
}