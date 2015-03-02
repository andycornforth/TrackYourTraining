using DBModels;
using Repository;
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
        MovementRepository movementRepoitory = new MovementRepository();

        public List<Movement> GetAllMovements()
        {
            return movementRepoitory.GetMovements();
        }

        public Movement GetMovementById(int id)
        {
            return movementRepoitory.GetMovement(id);
        }
    }
}
