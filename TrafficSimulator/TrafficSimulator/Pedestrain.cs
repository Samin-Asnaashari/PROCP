using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;

namespace TrafficSimulator
{
    public class Pedestrain
    {
       //Properites
		public int ID {set; get;}
		public Lane Path {set; get;}
		public int Speed {set; get;}
		public Point Position {set; get;}

	
		public Pedestrain(int id, Lane path, int speed, Point position)
		{
			this.ID = id;
			this.Path = path;
			this.Speed = speed;
			this.Position = position;
		}

		//Methods
        public void Draw(Graphics gr)
        {
            SolidBrush brush = new SolidBrush(Color.LightPink);
            gr.FillEllipse(brush, this.Position.X, this.Position.Y, 1, 1);
        }
	}
}
