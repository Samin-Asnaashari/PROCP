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
        public Point ClickedPosition { get; set; }
        public Image image { get; set; }
        public int Size { get; set; }

        public int Lights { get; set; }
        public int pedestrainLights { get; set; }

        public Crossing(Point position,Image image,int size)
        {
            this.ClickedPosition = position;
            this.image = image;
            this.Size = size;
            this.Lights=new int();
            this.pedestrainLights = new int();
            //this.image = (Image)new Bitmap(new Bitmap(this.Image_Filename.Split('.')[0] + ".png"), this.image.Size);
        }

        public void SetCrossingLights()
        {

        }
    }
}
