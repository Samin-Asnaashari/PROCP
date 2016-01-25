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
        public int Size { get; set; }
        public Point StartPoint { get; set; }
        public int CType { get; set; }
        public List<Lane> Lanes;
        public List<Crossing> Neighbors;

        //public Crossing North;
        //public Crossing East;
        //public Crossing West;
        //public Crossing South;

        public Crossing(Point p,Image image, int size)
        {
            this.image = image;
            this.Size = size;
            this.StartPoint = p;
            this.CType = 0;
            Lanes = new List<Lane>();
            Neighbors = new List<Crossing>();
            //this.image = (Image)new Bitmap(new Bitmap(this.Image_Filename.Split('.')[0] + ".png"), this.image.Size);

            //North = null;
            //East = null;
            //West = null;
            //South = null;
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
        } //check

    }
}
