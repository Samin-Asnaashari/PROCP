using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.Threading;
using System.ComponentModel;

namespace TrafficSimulator
{
    [Serializable]
    public class Crossing : IComparable
    {
        public Image image { get; set; }
        public int Size { get; set; } //PANEL IS REGTANGLE 
        public Point StartPoint { get; set; }
        private Timer tLightTimer;   //Traffic light timer
        public int CType { get; set; }
        public List<Lane> Lanes;

        public int gTime { set; get; }
        public string Type { set; get; }

        //Traffic light groups
        private static int[,] lightSet = {{ 0, 1, 3 },
                                          { 3, 4, 6 },
                                          { 6, 7, 9 },
                                          { 9, 10, 0 }};
        public int step { get; private set; }


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
        /// <summary>
        /// Timer runs this method to change traffic lights every specified 
        /// amount of time and restarts it at the end
        /// </summary>
        /// <param name="state"></param>
        private void Callback(Object state)
        {

            if (this.step < 3)
            {
                // change light set on "step"
                Parallel.For(0, 3, i =>
                {
                    Lanes[lightSet[this.step, i]].
                    ChangeLight();
                });
                // step ++
                this.step++;
                // change light set on "step+1"
                Parallel.For(0, 3, i =>
                {
                    if (Lanes.Count > i)
                        Lanes[lightSet[this.step, i]].
                        ChangeLight();
                });
            }
            else
            {
                // change light set on "step = 3"
                Parallel.For(0, 3, i =>
                {
                    Lanes[lightSet[this.step, i]].
                    ChangeLight();
                });
                // go back to step 0
                this.step = 0;
                // change light set on "step = 0"
                Parallel.For(0, 3, i =>
                {
                    Lanes[lightSet[this.step, i]].
                    ChangeLight();
                });
            }
            // Restart timer
            tLightTimer.Change(1000 * gTime, Timeout.Infinite);
        }

        /// <summary>
        /// Starts traffic lights after synchronizing them
        /// </summary>
        private void SynchronizeTrafficLights()
        {
            Parallel.For(0, 3, i =>
            {
                Lanes[lightSet[this.step, i]].ChangeLight();
            });
        }
    }
}
