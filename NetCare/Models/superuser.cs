//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace NetCare.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class superuser
    {
        public int ID { get; set; }
        public string username { get; set; }
        public string password { get; set; }
        public string surname { get; set; }
        public string forenames { get; set; }
        public string UltimateUser { get; set; }
        public Nullable<System.DateTime> CreatedDate { get; set; }
        public Nullable<System.DateTime> ModifiedDate { get; set; }
    }
}
