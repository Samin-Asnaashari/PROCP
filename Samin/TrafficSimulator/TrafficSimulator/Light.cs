using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TrafficSimulator
{
    public enum LightColor{red,green}
    public class Light
    {
        public Point Position { get; set; }
        public LightColor Color { get; set; }
        
        //time
        //group

        public Light()
        {
            this.Color = LightColor.red;
        }
    }
    
}
