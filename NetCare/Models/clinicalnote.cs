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
    
    public partial class clinicalnote
    {
        public int ID { get; set; }
        public Nullable<System.DateTime> added_date { get; set; }
        public string reason { get; set; }
        public string F3 { get; set; }
        public string title { get; set; }
        public string lnkpid { get; set; }
        public Nullable<double> lnkspell { get; set; }
        public string added_by { get; set; }
        public string drug_name { get; set; }
        public Nullable<double> lnkordid { get; set; }
    }
}
