using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TrainingApi.Models
{
    public class Muscle
    {
        public int Id { get; set; }
        public string MuscleName { get; set; }
        public List<string> OtherNames { get; set; }
    }
}
