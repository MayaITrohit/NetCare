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

    public partial class patient
    {
        public int ID { get; set; }
        public string surname { get; set; }
        public Nullable<double> hospital_no { get; set; }
        public string ward { get; set; }
        public string group_code { get; set; }
        public string lnkpid { get; set; }
        public Nullable<double> current_spell { get; set; }
        public string forenames { get; set; }
        public List<patient> Patient { get; set; }
        public List<patientmed> PatientMeds { get; set; }
        public List<patientTechViewModel> PatientTech { get; set; }
    }

   
}
