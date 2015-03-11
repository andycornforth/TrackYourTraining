using Business;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace TrainingApi.Controllers
{
    public class MuscleController : ApiController
    {
        MuscleBusiness muscleBusiness = new MuscleBusiness();

        [HttpGet]
        public IHttpActionResult GetAllMuscles()
        {
            return Ok(muscleBusiness.GetAllMuscles());
        }

        [HttpGet]
        public IHttpActionResult GetMuscle(int id)
        {
            return Ok(muscleBusiness.GetMuscleById(id));
        }
    }
}
