using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace NetCare.Models
{
    public class MainModel
    {
    }

    public class UserViewModel
    {
        public int ID { get; set; }
        public string UserName { get; set; }
        public string Roles { get; set; }
    }

    public class LoginViewModel
    {
        [Required]
        [Display(Name = "UserName")]
        public string UserName { get; set; }
        [Required]
        [DataType(DataType.Password)]
        [Display(Name = "Password")]
        public string Password { get; set; }
        [Display(Name = "Remember me?")]
        public bool RememberMe { get; set; }
    }

    /*************For PharmacyStoresOrder****************/
    public class wardstockMainModel
    {

        [Required(ErrorMessage = "Select A Ward")]
        public int ID { get; set; }
        public string lnkdid { get; set; }
        public string costcentre { get; set; }
        public string drugfull { get; set; }
        public string drug_form { get; set; }
        public string drug_name { get; set; }
        public string drug_packsize { get; set; }
        public string drug_strength { get; set; }
        public string ward { get; set; }
        public List<wardstockMainModel> WardstockList { get; set; }
        public List<SelectListItem> WardList { get; set; }
    }


    /*************Medications Order Page*****************/
    public class PatientMedicationOrder
    {
        public string PatientName { get; set; }
        public string PharmacistName { get; set; }
        [Required]
        public string Bleep { get; set; }
        public string WardName { get; set; }
        public Nullable<double> HospitalNo { get; set; }
        public patient Patients { get; set; }
        public List<PatientMedicationModel> PatientList { get; set; } //For Medication Method 1 and 3
        public List<PatientMedicationViewModel> PatientMedList { get; set; } //For Medication Method 2
    }

    /*************Medications Order Method 2*****************/
    public class PatientMedicationViewModel
    {
        public string lnkpid { get; set; }
        public string WardName { get; set; }
        public string PatientName { get; set; }
        public Nullable<double> hospital_no { get; set; }
        public string drug_description { get; set; }
        public string Primary_Dose { get; set; }
        public string SpecialConsid_Output { get; set; }
        public string Screened_Output { get; set; }
        public string frequency_description { get; set; }
        public string route { get; set; }
        public string prn { get; set; }
        public string stat { get; set; }
        public string PackSize_Output { get; set; }
        public string Nomad_Output { get; set; }
        public string WardStock_Output { get; set; }
        public string c_alt_dose { get; set; }
    }


    public class PatientMedicationModel
    {
        public string lnkpid { get; set; }
        public string lnkdid { get; set; }
        public string WardName { get; set; }
        public string PatientName { get; set; }
        public Nullable<double> hospital_no { get; set; }
        public string drug_description { get; set; }
        public string primary_dose { get; set; }
        public string frequency_description { get; set; }
        public string route { get; set; }
        public string prn { get; set; }
        public string stat { get; set; }
        public string drug_packsize { get; set; }
        public string drugfull { get; set; }
        public string speccon_description { get; set; }
        public string NOMAD { get; set; }
        public Nullable<DateTime> LastOrdered { get; set; }
        public Nullable<bool> IP { get; set; }
        public Nullable<bool> OSD { get; set; }
        public string NewInstruction { get; set; }
        public string Quantity { get; set; }
        public string Priority { get; set; }
        public Nullable<bool> Order { get; set; }
    }

    /*************Technician Ward Page*****************/
    public class TechWardViewModel
    {
        public string lnkpid { get; set; }
        public string drug_description { get; set; }
    }

    /*************Risk Number For Medicine Page*****************/
    public class RiskNumberViewModel
    {
        public int ID { get; set; }
        public int RiskFactor { get; set; }

    }

    /***********For Tech And Pharmacist Ward Page*************/

    public class patientTechViewModel
    {
        public string lnkpid { get; set; }
        public string title { get; set; }
        public string PatientName { get; set; }
        public string Medicine_Output { get; set; }
        public string Follow_Output { get; set; }
        public string Screened_Output { get; set; }
        public string Reason_Output { get; set; }
        public string Dose_Output { get; set; }
        public string RequireCounselling { get; set; }
    }
}