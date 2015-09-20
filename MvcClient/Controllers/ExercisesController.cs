using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MvcClient.Controllers
{
    public class ExercisesController : BaseController
    {
        // GET: Exercises
        public ActionResult Index()
        {
            ViewBag.Exercises = GetExercises();
            return View();
        }

        public ActionResult ExerciseDetails(int exerciseId)
        {
            ViewBag.Exercise = GetExercise(exerciseId);
            return View("ExerciseDetail");
        }

        private DBModels.Movement GetExercise(int exerciseId)
        {
            return apiLibrary.GetMovement(exerciseId);
        }

        public List<DBModels.Movement> GetExercises()
        {
            return apiLibrary.GetMovements().ToList();
        }
    }
}