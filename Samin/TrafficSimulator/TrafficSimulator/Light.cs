using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TrafficSimulator
{
    public enum LightColor{red,green}
    class Light
    {
        public int Group { get; set; }
        public LightColor Color { get; set; }

        public Light(int group)
        {
            this.Group = group;
            this.Color = LightColor.red;
        }
    }
}
