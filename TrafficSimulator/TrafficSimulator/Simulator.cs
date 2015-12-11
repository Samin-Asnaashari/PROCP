using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TrafficSimulator
{
    public class Simulator
    {
        /// <summary>
        /// controller for the simulator 
        /// </summary>
        private SimulatorSetting settings;

        public bool Start { get; set; }
        public bool Pause { get; set; }
        public bool Stop { get; set; }
        public SimulatorSetting Settings { get { return settings; } set { settings = value; } }

        public Simulator()
        {
            this.Start = false;
            this.Pause = false;
            this.Stop = false;
            this.settings = new SimulatorSetting();
        }

        public void StartSimulator()
        {
        }
        public void PauseSimulator()
        {
        }
        public void StopSimulator()
        {
        }
    }
}
