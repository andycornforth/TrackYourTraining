using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MvcClient.Controllers
{
    public class MuscleController : BaseController
    {
        // GET: Muscle
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Muscle(int muscleId)
        {
            var muscle = GetMuscle(muscleId);
            ViewBag.MuscleName = muscle.MuscleName;
            ViewBag.OtherNames = GetOtherNames(muscle.OtherNames);
            return View("Muscle");
        }

        private DBModels.Muscle GetMuscle(int muscleId)
        {
            return apiLibrary.GetMuscle(muscleId);
        }

        private string GetOtherNames(List<string> otherNames)
        {
            var str = string.Empty;
            if (otherNames != null)
            {
                foreach (var name in otherNames)
                {
                    str += name + "\n";
                }
            }
            return str;
        }
    }
}