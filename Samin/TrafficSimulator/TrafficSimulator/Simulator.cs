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
        public bool Start { get; set; }
        public bool Pause { get; set; }
        public bool Stop { get; set; }

        public Simulator()
        {
            this.Start = false;
            this.Pause = false;
            this.Stop = false;
        }

        public void StartSimulator()
        {
            //impliment it 
        }
        public void PauseSimulator()
        {
        }
        public void StopSimulator()
        {
        }
    }
}
