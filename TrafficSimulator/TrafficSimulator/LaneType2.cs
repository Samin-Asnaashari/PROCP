using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TrafficSimulator
{
    class LaneType2:Lane
    {
        public string[] Direction;

        public LaneType2()
        {
            this.Direction=new string[2];
        }
    }
}
