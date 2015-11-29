using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TrafficSimulator
{
    class SimulatorSetting
    {
        public double North { get; set; }
        public double East { get; set; }
        public double West { get; set; }
        public double South { get; set; }

        public int[] Light { get; set; }
        public int[] Pedestrainlight { get; set; }

    }
}
