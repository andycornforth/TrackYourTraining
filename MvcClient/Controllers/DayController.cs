using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MvcClient.Controllers
{
    public class DayController : BaseController
    {
        // GET: Day
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult ViewDay(int dayId, string dayName)
        {
            ViewBag.DayName = dayName;
            ViewBag.Sets = GetSetsForDay(dayId);
            return View();
        }

        private List<DBModels.Set> GetSetsForDay(int dayId)
        {
            return apiLibrary.GetSetsForDay(dayId).ToList();
        }
    }
}