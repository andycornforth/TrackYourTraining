using Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository
{
    public class MuscleRepository : BaseSqlRepository
    {
        public List<Muscle> GetMuscles()
        {
            var query = "SELECT *" +
                @"FROM Project p
                INNER JOIN Client c ON c.ClientId = p.ClientId
                WHERE p.[ProjectId] = @id";

            var command = GetCommand(query, CommandType.Text);

            return GetEntitiesFromDatabase<Muscle>(command).ToList();
        }
    }
}
