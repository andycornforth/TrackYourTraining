using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DBModels
{
    public class Tempo
    {
        public int Id { get; set; }
        public int Eccentric { get; set; }
        public int Pause { get; set; }
        public int Concentric { get; set; }

        public Tempo() { }

        public Tempo(int eccentric, int pause, int concentric)
        {
            Eccentric = eccentric;
            Pause = pause;
            Concentric = concentric;
        }
    }
}
