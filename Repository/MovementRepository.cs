using Exceptions;
using Models;
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
            var query = @"SELECT [Traning_DB].[dbo].[Movements].MovementId, [Traning_DB].[dbo].[Movements].MovementName, [Traning_DB].[dbo].[Muscles].MuscleId, [Traning_DB].[dbo].[Muscles].MuscleName, [Traning_DB].[dbo].[Movements].WeightTypeId, [Traning_DB].[dbo].[Movements].DifficultyLevelId, [Traning_DB].[dbo].[Movements].Description, [Traning_DB].[dbo].[Movements].AdditionalInformation
                            FROM [Traning_DB].[dbo].[Movements]
                            INNER JOIN [Traning_DB].[dbo].[Muscles]
                            ON [Traning_DB].[dbo].[Movements].PrimaryMuscleId = [Traning_DB].[dbo].[Muscles].MuscleId";

            var command = GetCommand(query, CommandType.Text);

            return GetEntitiesFromDatabase<Movement>(command).ToList();
        }

        public Movement GetMovement(int movementId)
        {
            var query = "SELECT * FROM [Traning_DB].[dbo].[Movements] WHERE MovementId = " + movementId; ;

            var command = GetCommand(query, CommandType.Text);

            return GetEntitiesFromDatabase<Movement>(command).FirstOrDefault();
        }

        public void InsertNewMovement(string name, Muscle primaryMuscle, Muscle secondaryMuscle, Muscle tertiaryMuscle, WeightType weightType,
            DifficultyLevel difficultyLevel, string description)
        {
            string insertion = @"INSERT into [Traning_DB].[dbo].[Movements] (MovementName, PrimaryMuscleId, SecondaryMuscleId, TertiaryMuscleId, WeightTypeId, DifficultyLevelId, Description) 
                VALUES ('" +
                name + "', '" +
                primaryMuscle.Id + "', '" +
                secondaryMuscle.Id + "', '" +
                tertiaryMuscle.Id + "', '" +
                Convert.ChangeType(weightType, weightType.GetTypeCode()) + "', '" +
                Convert.ChangeType(difficultyLevel, difficultyLevel.GetTypeCode()) + "', '" +
                description + "');";

            var command = GetCommand(insertion, CommandType.Text);
            ExecuteNonQueryChecked(command);
        }

        public void InsertNewMovement(string name, Muscle primaryMuscle, Muscle secondaryMuscle, WeightType weightType,
            DifficultyLevel difficultyLevel, string description)
        {
            string insertion = @"INSERT into [Traning_DB].[dbo].[Movements] (MovementName, PrimaryMuscleId, SecondaryMuscleId, WeightTypeId, DifficultyLevelId, Description) 
                VALUES ('" +
                name + "', '" +
                primaryMuscle.Id + "', '" +
                secondaryMuscle.Id + "', '" +
                Convert.ChangeType(weightType, weightType.GetTypeCode()) + "', '" +
                Convert.ChangeType(difficultyLevel, difficultyLevel.GetTypeCode()) + "', '" +
                description + "');";

            var command = GetCommand(insertion, CommandType.Text);
            ExecuteNonQueryChecked(command);
        }

        public void InsertNewMovement(string name, Muscle primaryMuscle, WeightType weightType,
            DifficultyLevel difficultyLevel, string description)
        {
            string insertion = @"INSERT into [Traning_DB].[dbo].[Movements] (MovementName, PrimaryMuscleId,WeightTypeId, DifficultyLevelId, Description) 
                VALUES ('" +
                name + "', '" +
                primaryMuscle.Id + "', '" +
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
            if (!DBNull.Value.Equals(reader["AdditionalInformation"]))
            {
                movement.AdditionalInformation = (string)reader["AdditionalInformation"];
            }

            return movement;
        }
    }
}
