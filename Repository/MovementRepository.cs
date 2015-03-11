using Exceptions;
using DBModels;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository
{
    public class MovementRepository : BaseSqlRepository
    {
        public List<Movement> GetMovements()
        {
            var query = @"SELECT [Training_DB].[dbo].[Movement].MovementId, [Training_DB].[dbo].[Movement].MovementName, [Training_DB].[dbo].[Muscle].MuscleId, 
                            [Training_DB].[dbo].[Muscle].MuscleName, [Training_DB].[dbo].[Movement].SecondaryMuscles, [Training_DB].[dbo].[Movement].WeightTypeId, [Training_DB].[dbo].[Movement].DifficultyLevelId, 
                            [Training_DB].[dbo].[Movement].Description, [Training_DB].[dbo].[WeightType].Name, [Training_DB].[dbo].[DifficultyLevel].Level
                            FROM [Training_DB].[dbo].[Movement]
                            INNER JOIN [Training_DB].[dbo].[Muscle]
                            ON [Training_DB].[dbo].[Movement].PrimaryMuscleId = [Training_DB].[dbo].[Muscle].MuscleId
                            INNER JOIN [Training_DB].[dbo].[WeightType]
                            ON  [Training_DB].[dbo].[Movement].WeightTypeId = [Training_DB].[dbo].[WeightType].WeightTypeId
                            INNER JOIN [Training_DB].[dbo].[DifficultyLevel]
                            ON  [Training_DB].[dbo].[Movement].DifficultyLevelId = [Training_DB].[dbo].[DifficultyLevel].DifficultyLevelId";

            var command = GetCommand(query, CommandType.Text);

            return GetEntitiesFromDatabase<Movement>(command).ToList();
        }

        public Movement GetMovement(int movementId)
        {
            var query = @"SELECT [Training_DB].[dbo].[Movement].MovementId, [Training_DB].[dbo].[Movement].MovementName, [Training_DB].[dbo].[Muscle].MuscleId, 
                            [Training_DB].[dbo].[Muscle].MuscleName, [Training_DB].[dbo].[Movement].SecondaryMuscles, [Training_DB].[dbo].[Movement].WeightTypeId, [Training_DB].[dbo].[Movement].DifficultyLevelId, 
                            [Training_DB].[dbo].[Movement].Description, [Training_DB].[dbo].[WeightType].Name, [Training_DB].[dbo].[DifficultyLevel].Level
                            FROM [Training_DB].[dbo].[Movement]
                            INNER JOIN [Training_DB].[dbo].[Muscle]
                            ON [Training_DB].[dbo].[Movement].PrimaryMuscleId = [Training_DB].[dbo].[Muscle].MuscleId
                            INNER JOIN [Training_DB].[dbo].[WeightType]
                            ON  [Training_DB].[dbo].[Movement].WeightTypeId = [Training_DB].[dbo].[WeightType].WeightTypeId
                            INNER JOIN [Training_DB].[dbo].[DifficultyLevel]
                            ON  [Training_DB].[dbo].[Movement].DifficultyLevelId = [Training_DB].[dbo].[DifficultyLevel].DifficultyLevelId
                            WHERE MovementId = " + movementId;

            var command = GetCommand(query, CommandType.Text);

            return GetEntitiesFromDatabase<Movement>(command).FirstOrDefault();
        }

        public int InsertNewMovement(Movement movement)
        {
            string insertion = @"INSERT into [Training_DB].[dbo].[Movement] (MovementName, PrimaryMuscleId, SecondaryMuscles, WeightTypeId, DifficultyLevelId, Description) 
                VALUES ('" +
                movement.Name + "', '" +
                movement.PrimaryMuscle.Id + "', '" +
                SplitSecondaryMuscles(movement.SecondaryMuscles) + "', '" +
                movement.WeightType.Id + "', '" +
                movement.DifficultyLevel.Id + "', '" +
                movement.Description + "'); SELECT SCOPE_IDENTITY()";

            var command = GetCommand(insertion, CommandType.Text);
            return ExecuteInt32Scalar(command);
        }

        protected override object MapRowToEntity(IDataReader reader)
        {
            var movement = new Movement();
            movement.Id = reader.GetInt32(reader.GetOrdinal("MovementId"));
            movement.Name = reader.GetString(reader.GetOrdinal("MovementName"));
            movement.PrimaryMuscle = new Muscle(reader.GetInt32(reader.GetOrdinal("MuscleId")), reader.GetString(reader.GetOrdinal("MuscleName")));
            movement.SecondaryMuscles = GetSecondaryMuscles(reader.GetString(reader.GetOrdinal("SecondaryMuscles")));
            movement.WeightType = new WeightType(reader.GetInt32(reader.GetOrdinal("WeightTypeId")),reader.GetString(reader.GetOrdinal("Name")));
            movement.DifficultyLevel = new DifficultyLevel(reader.GetInt32(reader.GetOrdinal("DifficultyLevelId")),reader.GetString(reader.GetOrdinal("Level")));
            movement.Description = (string)reader["Description"];

            return movement;
        }

        private List<string> GetSecondaryMuscles(string str)
        {
            var secondaryMuscles = new List<string>();
            if (str != null)
            {
                secondaryMuscles = str.Split(new char[] { ',' }).ToList();
            }
            return secondaryMuscles;
        }

        private string SplitSecondaryMuscles(List<string> secondaryMuscles)
        {
            string str = string.Empty;
            if (secondaryMuscles != null)
            {
                foreach (var muscle in secondaryMuscles)
                {
                    str += muscle + ",";
                }
            }
            return str;
        }
    }
}
