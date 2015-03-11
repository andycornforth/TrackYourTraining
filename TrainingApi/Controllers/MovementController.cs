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
    public class MovementController : ApiController
    {
        MovementBusiness movementRepository = new MovementBusiness();

        [HttpGet]
        public IHttpActionResult GetAllMovements()
        {
            return Ok(movementRepository.GetAllMovements());
        }

        [HttpGet]
        public IHttpActionResult GetMovementById(int id)
        {
            return Ok(movementRepository.GetMovementById(id));
        }

        [HttpPost]
        public IHttpActionResult PostNewMovement(Movement movement)
        {
            return Ok(movementRepository.InsertNewMovement(movement));
        }

    }
}