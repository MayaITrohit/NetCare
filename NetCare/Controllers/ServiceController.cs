using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using NetCare.Models;
using Newtonsoft.Json;

namespace NetCare.Controllers
{
    public class ServiceController : ApiController
    {
        JacEntities db = new JacEntities();
        [HttpGet]
        [Route("api/PharmacistsWardPage/{ward}")]
        public object PharmacistsWardPage(string ward)
        {
            List<patientTechViewModel> obj = new List<patientTechViewModel>();
            SqlParameter pWard = new SqlParameter("@ward", ward);
            obj = db.Database.SqlQuery<patientTechViewModel>("exec GetMedicine @ward", pWard).ToList();
            return JsonConvert.SerializeObject(obj);
        }


        [HttpGet]
        [Route("api/TechnicianWardPage/{ward}")]
        public object TechnicianWardPage(string ward)
        {
            List<patientTechViewModel> obj = new List<patientTechViewModel>();
            SqlParameter pWard = new SqlParameter("@ward", ward);
            obj = db.Database.SqlQuery<patientTechViewModel>("exec GetMedicine @ward", pWard).ToList();
            return JsonConvert.SerializeObject(obj);
        }

        [HttpGet]
        [Route("api/MedicationsOrderPage/{Ward}")]
        public object MedicationsOrderPage(string Ward)
        {
            List<PatientMedicationViewModel> obj = new List<PatientMedicationViewModel>();
            SqlParameter pWard = new SqlParameter("@Ward", Ward);
            obj = db.Database.SqlQuery<PatientMedicationViewModel>("exec MedicationOrders1 @Ward", pWard).Distinct().OrderBy(m => m.drug_description).ToList();
            return JsonConvert.SerializeObject(obj);
        }

        [HttpGet]
        [Route("api/MedicationsOrderPage2/{id}")]
        public object MedicationsOrderPage2(string id)
        {
            List<PatientMedicationViewModel> obj = new List<PatientMedicationViewModel>();
            SqlParameter plnkpid = new SqlParameter("@lnkpid", id);
            obj = db.Database.SqlQuery<PatientMedicationViewModel>("exec MedicationOrders2 @lnkpid", plnkpid).OrderBy(m => m.drug_description).ToList();
            return JsonConvert.SerializeObject(obj);
        }

        [HttpGet]
        [Route("api/MedicationsOrderPage3/")]
        public object MedicationsOrderPage3()
        {
            List<PatientMedicationViewModel> obj = new List<PatientMedicationViewModel>();
            obj = db.Database.SqlQuery<PatientMedicationViewModel>("exec MedicationOrders3").Distinct().OrderBy(m => m.drug_description).ToList();
            return JsonConvert.SerializeObject(obj);
        }
    }
}
