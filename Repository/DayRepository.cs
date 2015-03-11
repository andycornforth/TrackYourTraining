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

        public int CreateNewDay(string name)
        {
            string insertion = @"INSERT into [Training_DB].[dbo].[Day] (DayName) 
                VALUES ('" + name + "'); SELECT SCOPE_IDENTITY()";

            var command = GetCommand(insertion, CommandType.Text);
            return ExecuteInt32Scalar(command);
        }

        public Day GetDay(int dayId)
        {
            string query = @"SELECT * FROM [Training_DB].[dbo].[Day] WHERE DayId = " + dayId;

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
