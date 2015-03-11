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
    public class SetController : ApiController
    {
        SetBusiness setBusiness = new SetBusiness();

        [HttpGet]
        public IHttpActionResult Get(int id)
        {
            return Ok(setBusiness.GetSet(id));
        }

        [HttpPost]
        public IHttpActionResult Post(Set set)
        {
            return Ok(setBusiness.CreateNewSet(set));
        }
    }
}
