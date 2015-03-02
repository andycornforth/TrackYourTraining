using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TrainingApi.Models.Mappers
{
    public static class MuscleMapper
    {
        public static Muscle ToMuscleModel(DBModels.Muscle dbMuscle)
        {
            var muscle = new Muscle();
            muscle.Id = dbMuscle.Id;
            muscle.MuscleName = dbMuscle.MuscleName;
            muscle.OtherNames = dbMuscle.OtherNames;

            return muscle;
        }

        public static List<Muscle> ToMuscleModelList(List<DBModels.Muscle> dbMuscles)
        {
            List<Muscle> muscles = new List<Muscle>();
            foreach (var muscle in dbMuscles)
            {
                muscles.Add(ToMuscleModel(muscle));
            }
            return muscles;
        }
    }
}
