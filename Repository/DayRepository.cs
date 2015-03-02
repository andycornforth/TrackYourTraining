using DBModels;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository
{
    public class DayRepository : BaseSqlRepository
    {

        public void CreateNewDay(string name)
        {
            string insertion = @"INSERT into [Training_DB].[dbo].[Day] (DayName) 
                VALUES ('" + name + "');";

            var command = GetCommand(insertion, CommandType.Text);
            ExecuteNonQueryChecked(command);
        }

        public void AddSetToDay(int dayId, int setId)
        {
            string insertion = @"INSERT into [Training_DB].[dbo].[DaySet] (DayId, SetId) 
                VALUES (" + dayId + ", " + setId + ");";

            var command = GetCommand(insertion, CommandType.Text);
            ExecuteNonQueryChecked(command);
        }

        public Day GetDayName(int dayId)
        {
            string query = @"SELECT [Training_DB].[dbo].[Day].DayId, [Training_DB].[dbo].[Day].DayName WHERE DayId = " + dayId;

            var command = GetCommand(query, CommandType.Text);

            return GetEntitiesFromDatabase<Day>(command).FirstOrDefault();
        }


        protected override object MapRowToEntity(IDataReader reader)
        {
            var day = new Day();

            day.Id = reader.GetInt32(reader.GetOrdinal("DayId"));
            day.Name = reader.GetString(reader.GetOrdinal("DayName"));

            return day;
        }
    }
}
