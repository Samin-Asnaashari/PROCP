using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TrafficSimulator
{
    class CrossingTypeB:Crossing
    {
        public CrossingTypeB(Point point): base(point)
        {
            this.Image_Filename = "Type2.png";
            this.image = Bitmap.FromFile(this.Image_Filename);
        }
    }
}
