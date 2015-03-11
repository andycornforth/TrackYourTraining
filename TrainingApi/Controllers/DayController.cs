using Business;
using DBModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace TrainingApi.Controllers
{
    public class DayController : ApiController
    {
        DayBusiness dayBusiness = new DayBusiness();

        [HttpGet]
        public IHttpActionResult GetDayName(int dayId)
        {
            return Ok(dayBusiness.GetDayName(dayId));
        }

        [HttpGet]
        public IHttpActionResult GetSetsForDay(int dayId)
        {
            return Ok(dayBusiness.GetSetsForDay(dayId));
        }

        [HttpPost]
        public IHttpActionResult PostNewDay(string dayName)
        {
            return Ok(dayBusiness.CreateNewDay(dayName));
        }
    }
}
