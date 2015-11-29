using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TrafficSimulator
{
    class Moving
    {
        Car Car;
        public int Step { get; set; }
        //public delegate void StartCars();
        //public event StartCars Start;
        //public delegate void StopCars();
        //public event StartCars Stop;

        public Moving(Car c)
        {
            this.Car = c;
            this.Step = 0;
        }

        public void MoveInRoad(Crossing cross)
        {
            this.Step++;
        }

    }
}
