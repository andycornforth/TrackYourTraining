using MvcClient.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MvcClient.Controllers
{
    public class ProgramController : BaseController
    {
        ExercisesController exerciseController = new ExercisesController();
        // GET: Program
        public ActionResult Index()
        {
            // get a list of all the programs
            ViewBag.Programs = GetAllPrograms();
            return View();
        }

        public ActionResult ProgramDetails(int programId)
        {
            ViewBag.Program = GetProgram(programId);
            ViewBag.Days = GetProgramDays(programId);
            return View("ProgramDetails");
        }

        public ActionResult CreateNewProgram()
        {
            ViewBag.Exercises = exerciseController.GetExercises();
            return View("CreateNewProgram");
        }

        private List<DBModels.Program> GetAllPrograms()
        {
            return apiLibrary.GetPrograms().ToList();
        }

        private DBModels.Program GetProgram(int programId)
        {
            return apiLibrary.GetProgram(programId);
        }

        private List<DBModels.Day> GetProgramDays(int programId)
        {
            return apiLibrary.GetProgramDays(programId).ToList();
        }
    }
}