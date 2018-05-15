using NetCare.Models;
using NetCare.Repository;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using Newtonsoft.Json;
namespace NetCare.Controllers
{
    public class AdminController : Controller
    {
        private JacEntities db = new JacEntities();

        private IRepository<actualprescriptionmed> _prescriptionmed = null;
        private IRepository<GuidelineManagement> _guidline = null;
        private IRepository<patientmed> _patientmed = null;
        private IRepository<superuser> _superuser = null;
        private IRepository<wardstock> _wardstock = null;
        private IRepository<Medicine> _medicine = null;
        private IRepository<patient> _patient = null;
        private IRepository<Ward> _ward = null;
        private IRepository<News> _news = null;

        public AdminController()
        {
            this._prescriptionmed = new Repository<actualprescriptionmed>();
            this._guidline = new Repository<GuidelineManagement>();
            this._patientmed = new Repository<patientmed>();
            this._superuser = new Repository<superuser>();
            this._wardstock = new Repository<wardstock>();
            this._medicine = new Repository<Medicine>();
            this._patient = new Repository<patient>();
            this._ward = new Repository<Ward>();
            this._news = new Repository<News>();

        }

        // GET: Admin
        [Authorize(Roles = "Dispensary,Pharmacist,Tech,Admin")]
        public ActionResult Index()
        {
            List<patient> myPatient = _patient.GetAll().OrderByDescending(m => m.ID).ToList();
            ViewBag.PatientCount = myPatient.Count;
            ViewBag.Patient = myPatient.Take(10).ToList();
            ViewBag.News = _news.GetAll().OrderByDescending(m => m.NewsDate).Take(4).ToList();
            TempData["WardName"] = _ward.GetAll().OrderBy(m => m.ID).ToList();
            TempData.Keep("WardName");
            return View();
        }

        #region Login
        [AllowAnonymous]
        public ActionResult Logout()
        {
            Session.Abandon();
            Session.Clear();
            FormsAuthentication.SignOut();
            Response.Redirect("/Admin/Login");
            return View();
        }
        [HttpGet]
        [AllowAnonymous]
        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        [AllowAnonymous]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Login(LoginViewModel model, string returnUrl)
        {
            if (!ModelState.IsValid)
            {
                TempData["Alert"] = string.Format("Please Fill UserName and Password !!!");
                return View(model);
            }
            LoginViewModel user = new LoginViewModel() { UserName = model.UserName, Password = model.Password };
            UserViewModel userView = LoginRepository.GetUserDetails(user);

            if (userView.Roles != null)
            {
                FormsAuthentication.SetAuthCookie(model.UserName, false);
                var authTicket = new FormsAuthenticationTicket(1, userView.UserName, DateTime.Now, DateTime.Now.AddMinutes(20), false, userView.Roles);
                string encryptedTicket = FormsAuthentication.Encrypt(authTicket);

                HttpCookie authCookie = System.Web.HttpContext.Current.Request.Cookies[FormsAuthentication.FormsCookieName];
                if (authCookie != null)
                {
                    if (!string.IsNullOrEmpty(authCookie.Value))
                    {
                        authTicket = FormsAuthentication.Decrypt(authCookie.Value);
                        string UserName = authTicket.Name;
                    }
                }
                authCookie = new HttpCookie(FormsAuthentication.FormsCookieName, encryptedTicket);
                HttpContext.Response.Cookies.Add(authCookie);
                return RedirectToAction("Index", "Admin");
            }
            else
            {
                TempData["Alert"] = string.Format("Invalid Credential !!!");
                return View(model);
            }
        }
        #endregion Login

        /****************************List For Guidline Page Link on Index Page Sidebar**********************************/
        [HttpGet]
        public ActionResult Guidelines()
        {
            return View(db.GuidelineManagements.ToList());
        }
        #region Maintanance  //All Maintanance Pages//

        /****************************List For Super User Maintanance Link on Index Page Sidebar**********************************/
        #region SuperUser
        [HttpGet]
        public ActionResult SuperUserList()
        {
            return View(db.superusers.ToList());
        }

        /****************************Save Super User **********************************/
        [HttpGet]
        public ActionResult SuperUserSave()
        {
            return View();
        }

        [HttpPost]
        public ActionResult SuperUserSave(superuser obj)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    if (obj.ID == 0)
                    {
                        obj.CreatedDate = DateTime.Now;
                        obj.UltimateUser = "Yes";
                        _superuser.Insert(obj);
                        _superuser.Save();
                        TempData["Message"] = string.Format("Super User Saved Successfully!!!");
                    }
                    return RedirectToAction("SuperUserList");
                }
                else
                {
                    return View(obj);
                }
            }
            catch (Exception ex)
            {
                TempData["Alert"] = string.Format("A server error occurred. Please contact the administrator.");
                return RedirectToAction("SuperUserList");
            }
        }

        /****************************Update/Edit Super User **********************************/
        [HttpGet]
        public ActionResult SuperUserUpdate(int? id)
        {
            superuser model = new superuser();
            model = db.superusers.Where(m => m.ID == id).FirstOrDefault();
            if (model == null)
            {
                TempData["Alert"] = string.Format("A server error occurred. Please contact the administrator.");
            }
            return View(model);
        }

        [HttpPost]
        public ActionResult SuperUserUpdate(superuser obj)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    if (obj.ID > 0)
                    {
                        _superuser.Update(obj);
                        _superuser.Save();
                        TempData["Message"] = string.Format("Super User Updated Successfully!!!");
                    }
                    return RedirectToAction("SuperUserList");
                }
                else
                {
                    return View(obj);
                }
            }
            catch (Exception ex)
            {
                TempData["Alert"] = string.Format("A server error occurred. Please contact the administrator.");
                return RedirectToAction("SuperUserList");
            }
        }
        #endregion SuperUser

        #region Prime User
        [HttpGet]
        public ActionResult PrimeUserList()
        {
            return View(db.superusers.ToList());
        }

        [HttpGet]
        public ActionResult PrimeUserSave()
        {
            return View();
        }

        [HttpPost]
        public ActionResult PrimeUserSave(superuser obj)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    if (obj.ID == 0)
                    {
                        obj.CreatedDate = DateTime.Now;
                        obj.UltimateUser = "Yes";
                        _superuser.Insert(obj);
                        _superuser.Save();
                        TempData["Message"] = string.Format("Super User Saved Successfully!!!");
                    }
                    return RedirectToAction("SuperUserList");
                }
                else
                {
                    return View(obj);
                }
            }
            catch (Exception ex)
            {
                TempData["Alert"] = string.Format("A server error occurred. Please contact the administrator.");
                return RedirectToAction("SuperUserList");
            }
        }

        [HttpGet]
        public ActionResult PrimeUserUpdate(int? id)
        {
            superuser model = new superuser();
            model = db.superusers.Where(m => m.ID == id).FirstOrDefault();
            if (model == null)
            {
                TempData["Alert"] = string.Format("A server error occurred. Please contact the administrator.");
            }
            return View(model);
        }

        [HttpPost]
        public ActionResult PrimeUserUpdate(superuser obj)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    if (obj.ID > 0)
                    {
                        _superuser.Update(obj);
                        _superuser.Save();
                        TempData["Message"] = string.Format("Super User Updated Successfully!!!");
                    }
                    return RedirectToAction("SuperUserList");
                }
                else
                {
                    return View(obj);
                }
            }
            catch (Exception ex)
            {
                TempData["Alert"] = string.Format("A server error occurred. Please contact the administrator.");
                return RedirectToAction("SuperUserList");
            }
        }
        #endregion Prime User

        #region News
        /****************************List Live Message into News Section under Maintanance Link**********************************/
        [HttpGet]
        public JsonResult GetNews(int? page, int? limit, string sortBy, string direction, string searchString = null)
        {
            List<News> records = null;
            int total = 0;
            var objNews = _news.GetAll().Where(m => m.IsActive == true).AsQueryable<News>();
            total = objNews.Count();
            if (!string.IsNullOrWhiteSpace(searchString))
            {
                objNews = objNews.Where(p => p.NewsHead.ToUpper().Contains(searchString.Trim().ToUpper()));
            }

            if (!string.IsNullOrEmpty(sortBy) && !string.IsNullOrEmpty(direction))
            {
                if (direction.Trim().ToLower() == "asc")
                {
                    objNews = SortHelper.OrderBy(objNews, sortBy);
                }
                else
                {
                    objNews = SortHelper.OrderByDescending(objNews, sortBy);
                }
            }
            if (page.HasValue && limit.HasValue)
            {
                int start = (page.Value - 1) * limit.Value;
                objNews = objNews.Skip(start).Take(limit.Value);
            }
            records = objNews.ToList<News>();

            return Json(new { records, total }, JsonRequestBehavior.AllowGet);
        }


        [HttpGet]
        public ActionResult NewsList()
        {
            return View();
        }


        [HttpGet]
        public ActionResult NewsSave()
        {
            return View();
        }
        [HttpPost]
        public JsonResult NewsSave(News obj)
        {
            try
            {
                if (obj.ID == 0)      /***************Save Live Message into News Section under Maintanance Link***************/
                {
                    obj.IsActive = true;
                    obj.NewsDate = DateTime.Now;
                    _news.Insert(obj);
                    _news.Save();
                    TempData["Message"] = string.Format("News Saved Successfully!!!");
                }
                else       /***************Update Live Message into News Section under Maintanance Link***************/
                {
                    obj.IsActive = true;
                    obj.LastUpdate = DateTime.Now;
                    _news.Update(obj);
                    _news.Save();
                    TempData["Message"] = string.Format("News Updated Successfully!!!");
                }
            }
            catch (Exception ex)
            {
                TempData["Alert"] = string.Format("A server error occurred. Please contact the administrator.");
            }
            return Json(true);
        }   

        /****************************Delete Live Message into News Section under Maintanance Link**********************************/
        public JsonResult NewsDelete(int id)
        {
            try
            {
                News obj = new News();
                _news.Delete(id);
                _news.Save();
                TempData["DeleteMessage"] = string.Format("News Deleted Successfully!!!");
            }
            catch (Exception e)
            {
                TempData["Alert"] = string.Format("A server error occurred. Please contact the administrator.");
            }
            return Json(true);
        }
        #endregion News

        #region Guidelines
        /****************************List For Guidline Page Information under Maintanance Link**********************************/
        [HttpGet]
        public JsonResult GetGuidelines(int? page, int? limit, string sortBy, string direction, string searchString = null)
        {
            List<GuidelineManagement> records = null;
            int total = 0;
            var objGuidline = _guidline.GetAll().AsQueryable<GuidelineManagement>();
            total = objGuidline.Count();
            if (!string.IsNullOrWhiteSpace(searchString))
            {
                objGuidline = objGuidline.Where(p => p.GuidelineName.ToUpper().Contains(searchString.Trim().ToUpper()));
            }

            if (!string.IsNullOrEmpty(sortBy) && !string.IsNullOrEmpty(direction))
            {
                if (direction.Trim().ToLower() == "asc")
                {
                    objGuidline = SortHelper.OrderBy(objGuidline, sortBy);
                }
                else
                {
                    objGuidline = SortHelper.OrderByDescending(objGuidline, sortBy);
                }
            }
            if (page.HasValue && limit.HasValue)
            {
                int start = (page.Value - 1) * limit.Value;
                objGuidline = objGuidline.Skip(start).Take(limit.Value);
            }
            records = objGuidline.ToList<GuidelineManagement>();

            return Json(new { records, total }, JsonRequestBehavior.AllowGet);
        }

        [HttpGet]
        public ActionResult GuidelinesList()
        {
            return View();
        }

        /****************************Save Guidline Page Information under Maintanance Link**********************************/
        [HttpGet]
        public ActionResult GuidelinesSave()
        {
            return View();
        }

        [HttpPost]
        public JsonResult GuidelinesSave(GuidelineManagement obj)
        {
            try
            {
                if (obj.ID == 0)
                {
                    obj.CreatedDate = DateTime.Now;
                    _guidline.Insert(obj);
                    _guidline.Save();
                    TempData["Message"] = string.Format("Guidelines Saved Successfully!!!");
                }
                else
                {
                    obj.ModifiedDate = DateTime.Now;
                    _guidline.Update(obj);
                    _guidline.Save();
                    TempData["Message"] = string.Format("Guidelines Updated Successfully!!!");
                }
            }
            catch (Exception ex)
            {
                TempData["Alert"] = string.Format("A server error occurred. Please contact the administrator.");
            }
            return Json(true);
        }        

        /****************************Delete Guidline Page Information under Maintanance Link**********************************/

        public JsonResult GuidelinesDelete(int id)
        {
            try
            {
                GuidelineManagement obj = new GuidelineManagement();
                _guidline.Delete(id);
                _guidline.Save();
                TempData["DeleteMessage"] = string.Format("Guideline Deleted Successfully!!!");
            }
            catch (Exception e)
            {
                TempData["Alert"] = string.Format("A server error occurred. Please contact the administrator.");
            }
            return Json(true);
        }
        #endregion Guidelines

        #region Medicine
        /****************************List Medicine Information under Maintanance Link**********************************/
        [HttpGet]
        public ActionResult MedicineList()
        {
            return View(db.Medicines.ToList());
        }

        /****************************Update Risk Number under Maintanance Link**********************************/
        [HttpGet]
        public ActionResult RiskNumberForm(int? id)
        {
            Medicine model = new Medicine();
            model = db.Medicines.Where(m => m.ID == id).FirstOrDefault();
            if (model == null)
            {
                TempData["Alert"] = string.Format("A server error occurred. Please contact the administrator.");
            }
            return View(model);
        }

        [HttpPost]
        public ActionResult RiskNumberForm(RiskNumberViewModel obj)
        {
            try
            {
                Medicine objmed = _medicine.GetAll().Where(m => m.ID == obj.ID).FirstOrDefault();
                objmed.RiskFactor = obj.RiskFactor;
                _medicine.Update(objmed);
                _medicine.Save();
                TempData["Message"] = string.Format("Risk Factor Updated Successfully!!!");
            }
            catch (Exception ex)
            {
                TempData["Alert"] = string.Format("A server error occurred. Please contact the administrator.");
                return RedirectToAction("MedicineList");
            }
            return RedirectToAction("MedicineList");
        }


        /****************************Save Medicine Information under Maintanance Link**********************************/

        [HttpGet]
        public ActionResult MedicineSave()
        {
            return View();
        }

        [HttpPost]
        public ActionResult MedicineSave(Medicine obj)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    if (obj.ID == 0)
                    {
                        _medicine.Insert(obj);
                        _medicine.Save();
                        TempData["Message"] = string.Format("Medicine Saved Successfully!!!");
                    }
                    return RedirectToAction("MedicineList");
                }
                else
                {
                    return View(obj);
                }
            }
            catch (Exception ex)
            {
                TempData["Alert"] = string.Format("A server error occurred. Please contact the administrator.");
                return RedirectToAction("MedicineList");
            }
        }

        /****************************Update Medicine Information under Maintanance Link**********************************/
        [HttpGet]
        public ActionResult MedicineEdit(int? id)
        {
            Medicine model = new Medicine();
            model = db.Medicines.Where(m => m.ID == id).FirstOrDefault();
            if (model == null)
            {
                TempData["Alert"] = string.Format("A server error occurred. Please contact the administrator.");
            }
            return View(model);
        }

        [HttpPost]
        public ActionResult MedicineEdit(Medicine obj)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    if (obj.ID > 0)
                    {
                        _medicine.Update(obj);
                        _medicine.Save();
                        TempData["Message"] = string.Format("Medicine Updated Successfully!!!");
                    }
                    return RedirectToAction("MedicineList");
                }
                else
                {
                    return View(obj);
                }
            }
            catch (Exception ex)
            {
                TempData["Alert"] = string.Format("A server error occurred. Please contact the administrator.");
                return RedirectToAction("MedicineList");
            }
        }
        #endregion Medicine

        [Authorize(Roles = "Admin")]
        public ActionResult Maintanance()
        {
            return View();
        }
        #endregion Maintanance

        #region Pharmacists Ward Page
        [Authorize(Roles = "Pharmacist")]
        [HttpGet]
        public ActionResult PharmacistsWardPage(string ward)
        {
            ViewBag.ward = ward;
            string method = "PharmacistsWardPage/" + ward;
            patient obj = new patient();
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("http://testproject5.info/api/");
                //HTTP GET
                var responseTask = client.GetAsync(method);
                responseTask.Wait();

                var result = responseTask.Result;
                if (result.IsSuccessStatusCode)
                {
                    var readTask = result.Content.ReadAsAsync<string>();
                    readTask.Wait();
                    obj.PatientTech = JsonConvert.DeserializeObject<List<patientTechViewModel>>(readTask.Result);

                }
                else //web api sent error response 
                {
                    //log response status here..

                    obj.PatientTech = null;

                    ModelState.AddModelError(string.Empty, "Server error. Please contact administrator.");
                }
            }
            return View(obj);
        }
        #endregion Pharmacists Ward Page

        #region Technician Ward Page
        [Authorize(Roles = "Tech")]
        [HttpGet]
        public ActionResult TechnicianWardPage(string ward)
        {
            ViewBag.Techward = ward;
            string method = "TechnicianWardPage/" + ward;
            patient obj = new patient();
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("http://testproject5.info/api/");
                //HTTP GET
                var responseTask = client.GetAsync(method);
                responseTask.Wait();

                var result = responseTask.Result;
                if (result.IsSuccessStatusCode)
                {
                    var readTask = result.Content.ReadAsAsync<string>();
                    readTask.Wait();
                    obj.PatientTech = JsonConvert.DeserializeObject<List<patientTechViewModel>>(readTask.Result);

                }
                else //web api sent error response 
                {
                    //log response status here..

                    obj.PatientTech = null;

                    ModelState.AddModelError(string.Empty, "Server error. Please contact administrator.");
                }
            }
            return View(obj);
        }
        #endregion Technician Ward Page

        #region Pharmacy Stores Order
        [Authorize(Roles = "Dispensary,Pharmacist,Tech")]
        [HttpGet]
        public ActionResult PharmacyStoresOrder(string WardName)
        {
            wardstockMainModel obj = new wardstockMainModel();
            try
            {
                if (WardName != null)
                {
                    var wardList = db.Wards.ToList().Where(a => a.WardName == WardName);
                    obj.WardList = (from d in wardList
                                    where d.WardName == WardName
                                    select new SelectListItem
                                    {
                                        Value = d.ID.ToString(),
                                        Text = d.WardName
                                    }).ToList();

                    var qq = (from e in db.wardstocks
                              select new wardstockMainModel
                              {
                                  ID = e.ID,
                                  lnkdid = e.lnkdid,
                                  costcentre = e.costcentre,
                                  drugfull = e.drugfull,
                                  drug_form = e.drug_form,
                                  drug_name = e.drug_name,
                                  drug_packsize = e.drug_packsize,
                                  drug_strength = e.drug_strength
                              }).ToList();

                    obj.WardstockList = qq;
                }
                else
                {
                    var wardList = db.Wards.ToList().Where(a => a.ID > 0);
                    obj.WardList = (from d in wardList
                                    select new SelectListItem
                                    {
                                        Value = d.ID.ToString(),
                                        Text = d.WardName
                                    }).ToList();
                    var qq = (from e in db.wardstocks
                              select new wardstockMainModel
                              {
                                  ID = e.ID,
                                  lnkdid = e.lnkdid,
                                  costcentre = e.costcentre,
                                  drugfull = e.drugfull,
                                  drug_form = e.drug_form,
                                  drug_name = e.drug_name,
                                  drug_packsize = e.drug_packsize,
                                  drug_strength = e.drug_strength
                              }).ToList();

                    obj.WardstockList = qq;
                }
            }
            catch (Exception ex)
            {
                TempData["Alert"] = string.Format("A server error occurred. Please contact the administrator.");
            }
            return View("PharmacyStoresOrder", obj);
        }

        public ActionResult PharmacyStoresOrder(wardstockMainModel obj)
        {

            var wardList = db.Wards.ToList().Where(a => a.ID > 0);
            obj.WardList = (from d in wardList
                            select new SelectListItem
                            {
                                Value = d.ID.ToString(),
                                Text = d.WardName
                            }).ToList();
            //string ward_Name = Ward_Name;
            int ID = Convert.ToInt32(obj.ID);
            Ward objm = new Ward();
            //var qq = y;
            objm = db.Wards.Where(e => e.ID == ID).FirstOrDefault();
            if (objm == null)
            {
                obj.WardstockList = (from e in db.wardstocks
                                     select new wardstockMainModel
                                     {
                                         ID = e.ID,
                                         lnkdid = e.lnkdid,
                                         costcentre = e.costcentre,
                                         drugfull = e.drugfull,
                                         drug_form = e.drug_form,
                                         drug_name = e.drug_name,
                                         drug_packsize = e.drug_packsize,
                                         drug_strength = e.drug_strength
                                     }).ToList();
            }
            else
            {
                obj.WardstockList = (from e in db.wardstocks
                                     where e.costcentre == objm.WardName
                                     select new wardstockMainModel
                                     {
                                         ID = e.ID,
                                         lnkdid = e.lnkdid,
                                         costcentre = e.costcentre,
                                         drugfull = e.drugfull,
                                         drug_form = e.drug_form,
                                         drug_name = e.drug_name,
                                         drug_packsize = e.drug_packsize,
                                         drug_strength = e.drug_strength
                                     }).ToList();
            }

            return View(obj);
        }
        #endregion Pharmacy Stores Order

        #region Inpatient orders
        [Authorize(Roles = "Pharmacist,Tech")]
        [HttpGet]
        public ActionResult MedicationsOrderPage(string Ward)
        {
            string method = "MedicationsOrderPage/" + Ward;
            PatientMedicationOrder obj = new PatientMedicationOrder();
            obj.Patients = db.patients.Where(m => m.ward == Ward).FirstOrDefault();
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("http://testproject5.info/api/");
                //HTTP GET
                var responseTask = client.GetAsync(method);
                responseTask.Wait();
                var result = responseTask.Result;
                if (result.IsSuccessStatusCode)
                {
                    var readTask = result.Content.ReadAsAsync<string>();
                    readTask.Wait();
                    obj.PatientMedList = JsonConvert.DeserializeObject<List<PatientMedicationViewModel>>(readTask.Result);
                }
                else //web api sent error response 
                {
                    obj.PatientMedList = null;
                    ModelState.AddModelError(string.Empty, "Server error. Please contact administrator.");
                }
            }
            return View(obj);
        }

        [Authorize(Roles = "Pharmacist,Tech")]
        public ActionResult MedicationsOrderPage2(string id)
        {
            string method = "MedicationsOrderPage2/" + id;
            PatientMedicationOrder obj = new PatientMedicationOrder();
            obj.Patients = db.patients.Where(m => m.lnkpid == id).FirstOrDefault();
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("http://testproject5.info/api/");
                //HTTP GET
                var responseTask = client.GetAsync(method);
                responseTask.Wait();
                var result = responseTask.Result;
                if (result.IsSuccessStatusCode)
                {
                    var readTask = result.Content.ReadAsAsync<string>();
                    readTask.Wait();
                    obj.PatientMedList = JsonConvert.DeserializeObject<List<PatientMedicationViewModel>>(readTask.Result);
                }
                else //web api sent error response 
                {
                    obj.PatientMedList = null;
                    ModelState.AddModelError(string.Empty, "Server error. Please contact administrator.");
                }
            }
            return View(obj);
        }

        [Authorize(Roles = "Pharmacist,Tech")]
        public ActionResult MedicationsOrderPage3()
        {
            string method = "MedicationsOrderPage3/";
            PatientMedicationOrder obj = new PatientMedicationOrder();
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("http://testproject5.info/api/");
                //HTTP GET
                var responseTask = client.GetAsync(method);
                responseTask.Wait();
                var result = responseTask.Result;
                if (result.IsSuccessStatusCode)
                {
                    var readTask = result.Content.ReadAsAsync<string>();
                    readTask.Wait();
                    obj.PatientMedList = JsonConvert.DeserializeObject<List<PatientMedicationViewModel>>(readTask.Result);
                }
                else //web api sent error response 
                {
                    obj.PatientMedList = null;
                    ModelState.AddModelError(string.Empty, "Server error. Please contact administrator.");
                }
            }
            return View(obj);
        }
        #endregion Inpatient orders
    }
}