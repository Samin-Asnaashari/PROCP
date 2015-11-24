using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TrafficSimulator
{
        [Serializable]
    public class Crossing
    {
        //clicked position (where user clicked)
        public Point Position { get; set; }
        public Image image { get; set; }
        public int Size { get; set; }


        public Crossing(Point position,Image image,int size)
        {
            this.Position = position;
            this.image = image;
            this.Size = size;
            //this.image = (Image)new Bitmap(new Bitmap(this.Image_Filename.Split('.')[0] + ".png"), this.image.Size);
        }
    }
}
