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
        //
        private int x;
        private int y;
        private int dirX;
        private int dirY;
        public int size = 7;
        private SolidBrush brush;

        public Car(int X, int Y, int directionX, int directionY)
        {
            this.x = X;
            this.y = Y;
            this.dirX = directionX;
            this.dirY = directionY;
            brush = new SolidBrush(Color.Red);
        }

        public int getX()
        {
            return this.x;
        }

        public int setX(int posX)
        {
            return this.x = posX;
        }

        public int getY()
        {
            return this.y;
        }

        public int setY(int posY)
        {
            return this.y = posY;
        }

        public void DrawCar(Graphics gr)
        {
            gr.FillEllipse(brush, this.x, this.y, this.size, this.size);
        }
    
    }
}
