using NetCare.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace NetCare.Controllers
{
    public class SchedulerController : Controller
    {
        // GET: Scheduler
        public ActionResult Index()
        {
            return View();
        }

        public string Init()
        {
            //bool rslt = Utils.InitialiseDiary();
            return "";
        }

        public void UpdateEvent(int id, string NewEventStart, string NewEventEnd, string Description, string Title)
        {
            DiaryEvent.UpdateDiaryEvent(id, NewEventStart, NewEventEnd, Description, Title);
        }


        public bool SaveEvent(string Title, string NewEventDate, string NewEventTime, string NewEventDuration, string Description)
        {
            //int InspectorID = LoginRepository.GetUserID(User.Identity.Name);
            return DiaryEvent.CreateNewEvent(Title, NewEventDate, NewEventTime, NewEventDuration, Description, 1);
        }

        public JsonResult GetDiarySummary(double start, double end)
        {
            var ApptListForDate = DiaryEvent.LoadAppointmentSummaryInDateRange(start, end);
            var eventList = from e in ApptListForDate
                            select new
                            {
                                id = e.ID,
                                title = e.Title,
                                start = e.StartDateString,
                                end = e.EndDateString,
                                someKey = e.SomeImportantKeyID,
                                allDay = false
                            };
            var rows = eventList.ToArray();
            return Json(rows, JsonRequestBehavior.AllowGet);
        }

        public JsonResult GetDiaryEvents(double start, double end)
        {
            var ApptListForDate = DiaryEvent.LoadAllAppointmentsInDateRange(start, end);
            var eventList = from e in ApptListForDate
                            select new
                            {
                                id = e.ID,
                                title = e.Title,
                                start = e.StartDateString,
                                end = e.EndDateString,
                                color = e.StatusColor,
                                className = e.ClassName,
                                someKey = e.SomeImportantKeyID,
                                allDay = false,
                                Description = e.Description
                            };
            var rows = eventList.ToArray();
            return Json(rows, JsonRequestBehavior.AllowGet);
        }
    }
}