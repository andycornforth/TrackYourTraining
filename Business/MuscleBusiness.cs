using DBModels;
using Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business
{
    public class MuscleBusiness
    {
        MuscleRepository muscleRepository = new MuscleRepository();

        public List<Muscle> GetAllMuscles()
        {
            return muscleRepository.GetMuscles();
        }

        public Muscle GetMuscleById(int id)
        {
            return muscleRepository.GetMuscle(id);
        }
    }
}
