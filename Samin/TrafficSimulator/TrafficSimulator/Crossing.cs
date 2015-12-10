using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TrafficSimulator
{
    [Serializable]
    public class Crossing : IComparable
    {
        public Image image { get; set; }
        public int Size { get; set; } //PANEL IS REGTANGLE 
        public Point StartPoint { get; set; }

        public int CType { get; set; }
        public List<Lane> Lanes;

        public Crossing(Point p,Image image, int size)
        {
            this.image = image;
            this.Size = size;
            this.StartPoint = p;
            this.CType = 0;
            Lanes = new List<Lane>();
            //this.image = (Image)new Bitmap(new Bitmap(this.Image_Filename.Split('.')[0] + ".png"), this.image.Size);
        }
        
        public int CompareTo(object obj)
        {
            if (this.StartPoint.X < ((Crossing)obj).StartPoint.X)
            {
                    return -1;
            }
            else if (this.StartPoint.X == ((Crossing)obj).StartPoint.X && this.StartPoint.Y < ((Crossing)obj).StartPoint.Y)
            {
                    return -1;
            }
            else if (this.StartPoint.X > ((Crossing)obj).StartPoint.X)
            {
                return 1;
            }
            else if (this.StartPoint.X == ((Crossing)obj).StartPoint.X && this.StartPoint.Y > ((Crossing)obj).StartPoint.Y)
            {
                return 1;
            }
            { return 0; }
        }

    }
}
