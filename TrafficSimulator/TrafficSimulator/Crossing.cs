using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TrafficSimulator
{
    class Crossing
    {
        public Point Position { get; set; }
        public Image image { get; set; }
        public string Image_Filename { get; set; }


        public Crossing(Point point)
        {
            this.Position = point;
            this.image = (Image)new Bitmap(new Bitmap(this.Image_Filename.Split('.')[0] + ".png"), this.image.Size);
        }

        public void resizeImage(Size new_size)
        {
            this.image = (Image)(new Bitmap(new Bitmap(this.Image_Filename), new_size));
        }
    }
}
