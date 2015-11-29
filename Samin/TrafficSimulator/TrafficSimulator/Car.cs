using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace TrafficSimulator
{
    class Car
    {
        /// <summary>
        /// stores the basic info needed for creat a car(point)    maybe not needed 
        /// </summary>
        public int LocationX { get; set; }
        public int LocationY { get; set; }
        public int Size { get; set; }
        public Color Color { get; set; }
        public Direction Direction{ get; set; }

        public Car(int x,int y, Direction D,int size)
        {
            this.LocationX = x;
            this.LocationY = y;
            this.Size = size;
            this.Direction= D;
            Random randonGen = new Random();
            this.Color= Color.FromArgb(randonGen.Next(255), randonGen.Next(255),randonGen.Next(255));
        }

        public void DrawCar(Graphics gr)
        {
            Brush B = new SolidBrush(this.Color);
            gr.FillEllipse(B,this.LocationX,this.LocationY,this.Size,this.Size);
        }

        public void MoveX()
        {
            LocationX++;
        }

        public void MoveY()
        {
            LocationY++;
        }
    }
}
