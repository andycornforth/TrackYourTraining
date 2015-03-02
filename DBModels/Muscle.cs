using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DBModels
{
    public class Muscle
    {
        public int Id { get; set; }
        public string MuscleName { get; set; }
        public List<string> OtherNames { get; set; }

        public Muscle()
        {

        }

        public Muscle(int id, string name)
        {
            Id = id;
            MuscleName = name;
        }
    }
}
