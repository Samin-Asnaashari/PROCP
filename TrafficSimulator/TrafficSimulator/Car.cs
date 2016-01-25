using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace TrafficSimulator
{
    [Serializable]
    public class Car
    {
        /// <summary>
        /// stores the basic info needed for creat a car(point)
        /// </summary>
        public Point Position { get; set; }
        public int Size { get; set; }
        public Color Color { get; set; }
        public Direction Direction { get; set; } //direction that wants to go 
        public Lane Lane { get; set; }
        private static Random randonGen = new Random();

        //maybe for overview we need the time that car enter the simulator till exit

        public Car(Point pos, Direction D, int size)
        {
            this.Position = pos;
            this.Size = size;
            this.Direction = D;

            this.Color = Color.FromArgb(randonGen.Next(255), randonGen.Next(255), randonGen.Next(255));
        }

        public void DrawCar(Graphics gr)
        {
            Brush B = new SolidBrush(this.Color);
            gr.FillEllipse(B, this.Position.X, this.Position.Y, this.Size, this.Size);
        }

        public void MoveTheCar(Direction D)
        {
            if (Direction == Direction.north)
            {
                Point p = new Point(Position.X, Position.Y -1 );
                this.Position = p;
            }
            else if (Direction == Direction.south)
            {
                Point p = new Point(Position.X, Position.Y +1);
                this.Position = p;
            }
            else if (Direction == Direction.east)
            {
                Point p = new Point(Position.X+1, Position.Y);
                this.Position = p;
            }
            else if (Direction == Direction.west)
            {
                Point p = new Point(Position.X-1, Position.Y);
                this.Position = p;
            }
        }
    }
}
