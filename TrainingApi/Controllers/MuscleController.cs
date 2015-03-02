using Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using TrainingApi.Models;
using TrainingApi.Models.Mappers;

namespace TrainingApi.Controllers
{
    public class MuscleController : ApiController
    {
        MuscleRepository muscleRepository = new MuscleRepository();

        public List<Muscle> GetAllMuscles()
        {
            var muscles = MuscleMapper.ToMuscleModelList(muscleRepository.GetMuscles());
            return muscles;
        }

        public IHttpActionResult GetMuscle(int id)
        {
            var muscle = muscleRepository.GetMuscle(id);

            return Ok(muscle);
        }
    }
}
