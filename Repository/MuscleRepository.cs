using DBModels;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository
{
    public class MuscleRepository : BaseSqlRepository
    {
        public List<Muscle> GetMuscles()
        {
            var query = "SELECT * FROM [Training_DB].[dbo].[Muscle]";

            var command = GetCommand(query, CommandType.Text);

            return GetEntitiesFromDatabase<Muscle>(command).ToList();
        }

        public Muscle GetMuscle(int muscleId)
        {
            var query = "SELECT * FROM [Training_DB].[dbo].[Muscle] WHERE MuscleId = " + muscleId;

            var command = GetCommand(query, CommandType.Text);

            return GetEntitiesFromDatabase<Muscle>(command).FirstOrDefault();
        }

        protected override object MapRowToEntity(IDataReader reader)
        {
            var muscle = new Muscle();
            muscle.Id = reader.GetInt32(reader.GetOrdinal("MuscleId"));
            muscle.MuscleName = reader.GetString(reader.GetOrdinal("MuscleName"));

            if (!reader.IsDBNull(2))
            {
                muscle.OtherNames = GetOtherNames(reader.GetString(reader.GetOrdinal("Othernames")));
            }

            return muscle;
        }

        private List<string> GetOtherNames(string otherNames)
        {
            if (otherNames != string.Empty)
            {
                return otherNames.Split(new char[] { ',' }).ToList();
            }
            return null;
        }
    }
}
