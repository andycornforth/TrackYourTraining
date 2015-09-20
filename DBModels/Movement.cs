using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DBModels
{
    public class Movement
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public Muscle PrimaryMuscle { get; set; }
        public List<string> SecondaryMuscles { get; set; }
        public WeightType WeightType { get; set; }
        public DifficultyLevel DifficultyLevel { get; set; }
        public string Description { get; set; }
        public string AdditionalInformation { get; set; }
    }
}
