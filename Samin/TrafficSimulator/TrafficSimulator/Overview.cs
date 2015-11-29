using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TrafficSimulator
{
    class Overview
    {
        /// <summary>
        /// overview base on the fact achieved in simulator 
        /// </summary>
        public int NrOfAccident { get; set; }
        public int Traffics { get; set; }

        public Overview()
        {
            this.NrOfAccident = 0;
            this.Traffics = 0;
        }
    }
}
