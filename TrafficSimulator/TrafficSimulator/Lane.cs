using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TrafficSimulator
{
    /// <summary>
    /// group of possibilities for green lights 
    /// </summary>
    public enum GroupLightsTypeA
    {
        Lights123, Lights345, Lights567, Lights1357, Lights178
    }
    /// <summary>
    /// group of possibilities for green lights 
    /// </summary>
    public enum GroupLightsType2
    {
        Light2, Light6, Lights34, Lights14, Lights35, Lights17, Lights73, Lights78, Lights84, Lights85
    }
    public class Lane
    {
        public Point[] Entrance { get; set; }
        public Point[] Intersection { get; set; }

        public Lane()
        {
            Entrance=new Point[4];
            Intersection = new Point[4];
        }

    }
}
