using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DBModels
{
    public class WeightPercentage
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public WeightPercentage() { }

        public WeightPercentage(int id, string name)
        {
            Id = id;
            Name = name;
        }
    }
}
