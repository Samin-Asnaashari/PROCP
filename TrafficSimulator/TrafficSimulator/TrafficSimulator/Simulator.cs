using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TrafficSimulator
{
    class Simulator
    {
        /// <summary>
        /// controller for the simulator 
        /// </summary>
        public delegate void StartCarts();
        public event StartCarts Start;
        public delegate void StopCards();
        public event StartCarts Stop;

        public void Start()
        {
        }
        public void Pause()
        {
        }
        public void Stop()
        {
        }
    }
}
