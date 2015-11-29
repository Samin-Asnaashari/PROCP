using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;

namespace TrafficSimulator
{
    public class Pedestrain
    {
        private int x;
        private int y;
        private int dirX;
        private int dirY;
        private int size = 7;
        private SolidBrush brush;

        public Pedestrain(int X, int Y,int directionX, int directionY)
        {
            this.x = X;
            this.y = Y;
            this.dirX = directionX;
            this.dirY = directionY;
            this.brush = new SolidBrush(Color.Blue);
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

        public void DrawPedestrian(Graphics g)
        {
            g.FillEllipse(brush, this.x, this.y, this.size, this.size);
        }
        
    }
}
