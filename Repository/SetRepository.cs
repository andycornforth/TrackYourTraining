using DBModels;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository
{
    public class SetRepository : BaseSqlRepository
    {

        public int CreateNewSet(Set set)
        {
            string insertion = @"INSERT into [Training_DB].[dbo].[Set] (MovementId, SetNumber, Reps, Weight, TempoId) 
                VALUES (" + set.Movement.Id + ", " + set.SetNumber + ", " + set.Reps + ", " + set.Weight + ", " + set.Tempo.Id + ");  SELECT SCOPE_IDENTITY()";

            var command = GetCommand(insertion, CommandType.Text);
            return ExecuteInt32Scalar(command);
        }

        public Set GetSet(int setId)
        {
            var query = @"SELECT [Training_DB].[dbo].[Set].SetId, [Training_DB].[dbo].[Set].SetNumber, [Training_DB].[dbo].[Set].Reps, [Training_DB].[dbo].[Set].Weight,
                            [Training_DB].[dbo].[Set].TempoId, [Training_DB].[dbo].[Movement].MovementId, [Training_DB].[dbo].[Movement].MovementName, [Training_DB].[dbo].[Movement].PrimaryMuscleId, 
                            [Training_DB].[dbo].[Movement].WeightTypeId, [Training_DB].[dbo].[Movement].DifficultyLevelId, 
                            [Training_DB].[dbo].[Movement].Description, [Training_DB].[dbo].[Muscle].MuscleName, [Training_DB].[dbo].[WeightType].Name, [Training_DB].[dbo].[DifficultyLevel].Level
                            FROM [Training_DB].[dbo].[Set]
                            INNER JOIN [Training_DB].[dbo].[Movement]
                            ON [Training_DB].[dbo].[Set].MovementId = [Training_DB].[dbo].[Movement].MovementId
                            INNER JOIN [Training_DB].[dbo].[Muscle]
                            ON [Training_DB].[dbo].[Movement].PrimaryMuscleId = [Training_DB].[dbo].[Muscle].MuscleId
                            INNER JOIN [Training_DB].[dbo].[WeightType]
                            ON  [Training_DB].[dbo].[Movement].WeightTypeId = [Training_DB].[dbo].[WeightType].WeightTypeId
                            INNER JOIN [Training_DB].[dbo].[DifficultyLevel]
                            ON  [Training_DB].[dbo].[Movement].DifficultyLevelId = [Training_DB].[dbo].[DifficultyLevel].DifficultyLevelId
                            WHERE SetId = " + setId;

            var command = GetCommand(query, CommandType.Text);

            return GetEntitiesFromDatabase<Set>(command).FirstOrDefault();
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
            set.Movement.WeightType = new WeightType(reader.GetInt32(reader.GetOrdinal("WeightTypeId")), reader.GetString(reader.GetOrdinal("Name")));
            set.Movement.DifficultyLevel = new DifficultyLevel(reader.GetInt32(reader.GetOrdinal("DifficultyLevelId")), reader.GetString(reader.GetOrdinal("Level")));
            set.Movement.Description = (string)reader["Description"];

            return set;
        }
    }
}
