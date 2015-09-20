using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DBModels
{
    public class Day
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public Day(string name)
        {
            Name = name;
        }

        public Day() { }
    }
}
