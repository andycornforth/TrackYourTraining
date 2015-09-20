using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DBModels
{
    public class DifficultyLevel
    {
        public int Id { get; set; }
        public string Level { get; set; }

        public DifficultyLevel(int id, string level)
        {
            Id = id;
            Level = level;
        }
    }
}
