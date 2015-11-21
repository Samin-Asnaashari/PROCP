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
        private string[] filenames = { "Type1.png", "Type2.png" };

        public Point Position { get; set; }
        public Image image { get; set; }
        public string Image_Filename { get; set; }
        public int Type { get; set; }

        public Crossing(Point point, int type)
        {
            this.Position = point;
            this.Type = type;
            this.Image_Filename = filenames[type];
            //this.image = (Image)new Bitmap(new Bitmap(this.Image_Filename.Split('.')[0] + ".png"), this.image.Size);
            this.image = Bitmap.FromFile(this.Image_Filename);
        }

        public void resizeImage(Size new_size)
        {
            this.image = (Image)(new Bitmap(new Bitmap(this.Image_Filename), new_size));
        }
    }
}
