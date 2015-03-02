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
                            [Training_DB].[dbo].[Muscle].MuscleName, [Training_DB].[dbo].[Movement].WeightTypeId, [Training_DB].[dbo].[Movement].DifficultyLevelId, 
                            [Training_DB].[dbo].[Movement].Description
                            FROM [Training_DB].[dbo].[Movement]
                            INNER JOIN [Training_DB].[dbo].[Muscle]
                            ON [Training_DB].[dbo].[Movement].PrimaryMuscleId = [Training_DB].[dbo].[Muscle].MuscleId";

            var command = GetCommand(query, CommandType.Text);

            return GetEntitiesFromDatabase<Movement>(command).ToList();
        }

        public Movement GetMovement(int movementId)
        {
            var query =  @"SELECT [Training_DB].[dbo].[Movement].MovementId, [Training_DB].[dbo].[Movement].MovementName, [Training_DB].[dbo].[Muscle].MuscleId, 
                            [Training_DB].[dbo].[Muscle].MuscleName, [Training_DB].[dbo].[Movement].WeightTypeId, [Training_DB].[dbo].[Movement].DifficultyLevelId, 
                            [Training_DB].[dbo].[Movement].Description
                            FROM [Training_DB].[dbo].[Movement]
                            INNER JOIN [Training_DB].[dbo].[Muscle]
                            ON [Training_DB].[dbo].[Movement].PrimaryMuscleId = [Training_DB].[dbo].[Muscle].MuscleId
                            WHERE MovementId = " + movementId; 

            var command = GetCommand(query, CommandType.Text);

            return GetEntitiesFromDatabase<Movement>(command).FirstOrDefault();
        }

        public void InsertNewMovement(string name, string primaryMuscleId, string secondaryMuscles, WeightType weightType,
            DifficultyLevel difficultyLevel, string description)
        {
            string insertion = @"INSERT into [Training_DB].[dbo].[Movement] (MovementName, PrimaryMuscleId, SecondaryMuscles, WeightTypeId, DifficultyLevelId, Description) 
                VALUES ('" +
                name + "', '" +
                primaryMuscleId + "', '" +
                secondaryMuscles + "', '" +
                Convert.ChangeType(weightType, weightType.GetTypeCode()) + "', '" +
                Convert.ChangeType(difficultyLevel, difficultyLevel.GetTypeCode()) + "', '" +
                description + "');";

            var command = GetCommand(insertion, CommandType.Text);
            ExecuteNonQueryChecked(command);
        }

        public void InsertNewMovement(string name, string primaryMuscleId, WeightType weightType,
            DifficultyLevel difficultyLevel, string description)
        {
            string insertion = @"INSERT into [Training_DB].[dbo].[Movement] (MovementName, PrimaryMuscleId,WeightTypeId, DifficultyLevelId, Description) 
                VALUES ('" +
                name + "', '" +
                primaryMuscleId + "', '" +
                Convert.ChangeType(weightType, weightType.GetTypeCode()) + "', '" +
                Convert.ChangeType(difficultyLevel, difficultyLevel.GetTypeCode()) + "', '" +
                description + "');";

            var command = GetCommand(insertion, CommandType.Text);
            ExecuteNonQueryChecked(command);
        }

        protected override object MapRowToEntity(IDataReader reader)
        {
            var movement = new Movement();
            movement.Id = reader.GetInt32(reader.GetOrdinal("MovementId"));
            movement.Name = reader.GetString(reader.GetOrdinal("MovementName"));
            movement.PrimaryMuscle = new Muscle(reader.GetInt32(reader.GetOrdinal("MuscleId")), reader.GetString(reader.GetOrdinal("MuscleName")));
            movement.WeightType = (WeightType) reader.GetInt32(reader.GetOrdinal("WeightTypeId"));
            movement.DifficultyLevel = (DifficultyLevel)reader.GetInt32(reader.GetOrdinal("DifficultyLevelId"));
            movement.Description = (string) reader["Description"];

            return movement;
        }
    }
}
