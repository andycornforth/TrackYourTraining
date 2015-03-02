using DBModels;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository
{
    public class ProgramDayRepository : BaseSqlRepository
    {

        public void AddDayToProgram(int programId, int dayId)
        {
            string query = @"INSERT into [Training_DB].[dbo].[ProgramDay] (ProgramId, DayId) VALUES (" + programId + ", " + dayId + ");";

            var command = GetCommand(query, CommandType.Text);
            ExecuteNonQueryChecked(command);
        }

        public List<ProgramDay> GetProgramDaysForProgram(int programId)
        {
            string query = @"SELECT * FROM [Training_DB].[dbo].[ProgramDay] WHERE ProgramId = " + programId;

            var command = GetCommand(query, CommandType.Text);

            return GetEntitiesFromDatabase<ProgramDay>(command).ToList();
        }

        protected override object MapRowToEntity(IDataReader reader)
        {
            var programDay = new ProgramDay();
            programDay.Id = reader.GetInt32(reader.GetOrdinal("ProgramDayId"));
            programDay.ProgramId = reader.GetInt32(reader.GetOrdinal("ProgramId"));
            programDay.DayId = reader.GetInt32(reader.GetOrdinal("DayId"));

            return programDay;
        }
    }
}
