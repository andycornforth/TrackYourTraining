using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DBModels
{
    public class Set
    {
        public int Id { get; set; }
        public Movement Movement { get; set; }
        public int SetNumber { get; set; }
        public int Reps { get; set; }
        public double Weight { get; set; }
        public Tempo Tempo { get; set; }
        public WeightPercentage WeightPercentage { get; set; }
    }
}
