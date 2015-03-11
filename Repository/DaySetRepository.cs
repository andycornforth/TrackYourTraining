using DBModels;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository
{
    public class DaySetRepository : BaseSqlRepository
    {
        public int AddSetToDay(int dayId, int setId)
        {
            string query = @"INSERT into [Training_DB].[dbo].[DaySet] (DayId, SetId) VALUES (" + dayId + ", " + setId + ");  SELECT SCOPE_IDENTITY()";

            var command = GetCommand(query, CommandType.Text);
            return ExecuteInt32Scalar(command);
        }

        public List<DaySet> GetSetIdsForDay(int dayId)
        {
            string query = @"SELECT * FROM [Training_DB].[dbo].[DaySet] WHERE DayId = " + dayId;

            var command = GetCommand(query, CommandType.Text);

            return GetEntitiesFromDatabase<DaySet>(command).ToList();
        }

        protected override object MapRowToEntity(IDataReader reader)
        {
            var daySet = new DaySet();
            daySet.Id = reader.GetInt32(reader.GetOrdinal("DaySetId"));
            daySet.DayId = reader.GetInt32(reader.GetOrdinal("DayId"));
            daySet.SetId = reader.GetInt32(reader.GetOrdinal("SetId"));

            return daySet;
        }
    }
}
