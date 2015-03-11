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
    public class ProgramController : ApiController
    {
        ProgramBusiness programBusiness = new ProgramBusiness();

        [HttpGet]
        public IHttpActionResult GetProgram(int programId)
        {
            return Ok(programBusiness.GetProgramById(programId));
        }

        [HttpGet]
        public IHttpActionResult GetAllPrograms()
        {
            return Ok(programBusiness.GetAllPrograms());
        }

        [HttpGet]
        public IHttpActionResult GetDaysForProgram(int programId)
        {
            return Ok(programBusiness.GetProgramDays(programId));
        }

        [Route("api/Program") ]
        [HttpPost]
        public IHttpActionResult PostNewProgram(Program program)
        {
            return Ok(programBusiness.CreateNewProgram(program));
        }
    }
}
