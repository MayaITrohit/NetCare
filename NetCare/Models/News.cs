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
    
    public partial class News
    {
        public int ID { get; set; }
        public string NewsHead { get; set; }
        public string NewsBody { get; set; }
        public string NewsImagePath { get; set; }
        public Nullable<System.DateTime> NewsDate { get; set; }
        public Nullable<bool> IsActive { get; set; }
        public Nullable<System.DateTime> LastUpdate { get; set; }
    }
}
