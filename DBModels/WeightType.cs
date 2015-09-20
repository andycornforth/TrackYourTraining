using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DBModels
{
    public class WeightType
    {
        public int Id { get; set; }
        public string Type { get; set; }

        public WeightType(int id, string type)
        {
            Id = id;
            Type = type;
        }
    }
}
