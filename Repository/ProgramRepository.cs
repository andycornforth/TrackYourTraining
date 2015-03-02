using DBModels;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository
{
    public class ProgramRepository : BaseSqlRepository
    {
        public List<Program> GetPrograms()
        {
            var query = "SELECT * FROM [Training_DB].[dbo].[Program]";

            var command = GetCommand(query, CommandType.Text);

            return GetEntitiesFromDatabase<Program>(command).ToList();
        }

        protected override object MapRowToEntity(IDataReader reader)
        {
            var program = new Program();
            program.Id = reader.GetInt32(reader.GetOrdinal("ProgramId"));
            program.Name = reader.GetString(reader.GetOrdinal("ProgramName"));
            program.FitnessGoal = (FitnessGoal)reader.GetInt32(reader.GetOrdinal("FitnessGoalId"));
            if (!reader.IsDBNull(3))
            {
                program.Description = reader.GetString(reader.GetOrdinal("Description"));
            }

            return program;
        }
    }
}
