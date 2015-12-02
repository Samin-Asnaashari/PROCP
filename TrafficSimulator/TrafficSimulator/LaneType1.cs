using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TrafficSimulator
{
    class LaneType1:Lane
    {
        public string Direction { get; set; }

        public LaneType1()
        {
            this.Direction = null;
        }

    }
}
