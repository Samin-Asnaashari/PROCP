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
        public int ID { get; set; }

        public Car(int id,Point pos, Direction D, int size)
        {
            this.Position = pos;
            this.Size = size;
            this.Direction = D;
            this.ID = id;
            this.Color = Color.FromArgb(randonGen.Next(255), randonGen.Next(255), randonGen.Next(255));
        }

        public void DrawCar(Graphics gr)
        {
            Brush B = new SolidBrush(this.Color);
            gr.FillEllipse(B, this.Position.X, this.Position.Y, this.Size, this.Size);
        }

        public bool CheckMove(Lane L,Point p)
        {
            if (L.Cars.Find(x => (x.ID != this.ID) && CheckCarExist(L,x.Position,p)) == null)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public bool CheckCarExist(Lane L,Point c1, Point newc2)
        {
            if (L.DirectionIsTo == Direction.north)
            {
                if ((c1.Y <= newc2.Y - 5) && (c1.Y >= newc2.Y + 5) && c1.X == newc2.X)
                    return true;
            }
            else if (L.DirectionIsTo == Direction.south)
            {
                if ((c1.Y <= newc2.Y - 5) && (c1.Y >= newc2.Y + 5) && c1.X == newc2.X)
                    return true;
            }
            else if (L.DirectionIsTo == Direction.east)
            {
                if ((c1.X <= newc2.X - 5) && (c1.X >= newc2.X + 5) && c1.Y == newc2.Y)
                    return true;
            }
            else if (L.DirectionIsTo == Direction.west)
            {
                if ((c1.X <= newc2.X - 5) && (c1.X >= newc2.X + 5) && c1.Y == newc2.Y)
                    return true;
            }
            return false;
        }

        public void MoveTheCar(Direction D, Lane L)
        {
            if (Direction == Direction.north)
            {
                Point p = new Point(Position.X, Position.Y - 1);
                if (CheckMove(L,p))
                    this.Position = p;
            }
            else if (Direction == Direction.south)
            {
                Point p = new Point(Position.X, Position.Y + 1);
                if (CheckMove(L,p))
                    this.Position = p;
            }
            else if (Direction == Direction.east)
            {
                Point p = new Point(Position.X + 1, Position.Y);
                if (CheckMove(L,p))
                    this.Position = p;
            }
            else if (Direction == Direction.west)
            {
                Point p = new Point(Position.X - 1, Position.Y);
                if (CheckMove(L,p))
                    this.Position = p;
            }
        }
    }
}
