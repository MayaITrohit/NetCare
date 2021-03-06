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
    
    public partial class GetInpatientOrder_Result
    {
        public int ID { get; set; }
        public string drug_description { get; set; }
        public string surname { get; set; }
        public string forenames { get; set; }
        public Nullable<double> hospital_no { get; set; }
        public string frequency_description { get; set; }
        public string frequency_code { get; set; }
        public string ward { get; set; }
        public string discontinued_by { get; set; }
        public string order_type { get; set; }
        public Nullable<double> secondary_dose { get; set; }
        public string status { get; set; }
        public string primary_dose_description { get; set; }
        public Nullable<double> primary_dose { get; set; }
        public string lnkpid { get; set; }
        public Nullable<double> current_spell { get; set; }
        public string prn { get; set; }
        public string stop_date { get; set; }
        public string stop_days_doses { get; set; }
        public string stop_days_doses_flag { get; set; }
        public string lnkpid1 { get; set; }
        public string route { get; set; }
        public string stat { get; set; }
        public string stop_date1 { get; set; }
        public string prescribing_drug_id { get; set; }
        public Nullable<double> lnkordid { get; set; }
        public string lnkpid2 { get; set; }
        public string c_alt_dose { get; set; }
        public Nullable<double> c_bulk { get; set; }
    }
}
