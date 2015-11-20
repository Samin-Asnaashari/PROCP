using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TrafficSimulator
{
    class CrossingTypeA:Crossing
    {
        public CrossingTypeA(Point point): base(point)
        {
            this.Image_Filename = "Type1.png";
            this.image = Bitmap.FromFile(this.Image_Filename);
        }
    }
}
