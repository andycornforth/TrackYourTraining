﻿using Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository
{
    public class MovementRepository : BaseSqlRepository
    {
        public List<Movement> GetMovements()
        {
            var query = "SELECT *" +
                @"FROM Project p
                INNER JOIN Client c ON c.ClientId = p.ClientId
                WHERE p.[ProjectId] = @id";

            return GetEntitiesFromDatabase<Movement>(command).ToList();
        }
    }
}
