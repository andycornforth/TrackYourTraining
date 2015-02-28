using Models;
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

        public List<Set> GetDay(int dayId)
        {
            string query = @"SELECT [Training_DB].[dbo].[DaySet].DayId, [Training_DB].[dbo].[DaySet].SetId, [Training_DB].[dbo].[Set].SetNumber, 
                            [Training_DB].[dbo].[Set].Reps, [Training_DB].[dbo].[Set].Weight, [Training_DB].[dbo].[Movement].MovementId, 
                            [Training_DB].[dbo].[Movement].MovementName, [Training_DB].[dbo].[Movement].PrimaryMuscleId, 
                            [Training_DB].[dbo].[Movement].WeightTypeId, [Training_DB].[dbo].[Movement].DifficultyLevelId, 
                            [Training_DB].[dbo].[Movement].Description, [Training_DB].[dbo].[Muscle].MuscleName
                            FROM [Training_DB].[dbo].[DaySet]
                            INNER JOIN [Training_DB].[dbo].[Set]
                            ON [Training_DB].[dbo].[DaySet].SetId = [Training_DB].[dbo].[Set].SetId
                            INNER JOIN [Training_DB].[dbo].[Movement]
                            ON [Training_DB].[dbo].[Set].MovementId = [Training_DB].[dbo].[Movement].MovementId
                            INNER JOIN [Training_DB].[dbo].[Muscle]
                            ON [Training_DB].[dbo].[Movement].PrimaryMuscleId = [Training_DB].[dbo].[Muscle].MuscleId
                            WHERE DayId = " + dayId;

            var command = GetCommand(query, CommandType.Text);

            return GetEntitiesFromDatabase<Set>(command).ToList();
        }

        protected override object MapRowToEntity(IDataReader reader)
        {
            var set = new Set();
            set.Movement = new Movement();
            set.Id = reader.GetInt32(reader.GetOrdinal("SetId"));
            set.SetNumber = reader.GetInt32(reader.GetOrdinal("SetNumber"));
            set.Reps = reader.GetInt32(reader.GetOrdinal("Reps"));
            set.Weight = reader.GetDouble(reader.GetOrdinal("Weight"));
            set.Movement.Id = reader.GetInt32(reader.GetOrdinal("MovementId"));
            set.Movement.Name = reader.GetString(reader.GetOrdinal("MovementName"));
            set.Movement.PrimaryMuscle = new Muscle(reader.GetInt32(reader.GetOrdinal("PrimaryMuscleId")), reader.GetString(reader.GetOrdinal("MuscleName")));
            set.Movement.WeightType = (WeightType)reader.GetInt32(reader.GetOrdinal("WeightTypeId"));
            set.Movement.DifficultyLevel = (DifficultyLevel)reader.GetInt32(reader.GetOrdinal("DifficultyLevelId"));
            set.Movement.Description = (string)reader["Description"];

            return set;
        }
    }
}
