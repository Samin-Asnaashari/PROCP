using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TrafficSimulator
{
        [Serializable]
    public class Controller
    {
        public WorkspaceDesign Design;
        public float panelw;
        public float panelh;
        //public Controller controller;

        public int lines;

        public Crossing C;

        public Controller(float pw, float ph , WorkspaceDesign d)
        {
            this.Design = d;
            this.panelw = pw;
            this.panelh = ph;
            lines = 0;
        }

        public void drawthedesigngrid(Graphics gr)
        {
            float x = 0f;
            float y = 0f;
            Pen mypen = new Pen(Brushes.Black,1);

            float xspace = panelw / lines;
            float yspace = panelh / lines;

                //vertical
                for (int i = 0; i < lines + 1; i++)
                {
                    gr.DrawLine(mypen, x,y,x,panelh);
                    x += xspace;
                }
                //horizontal 
                x = 0f;
                //y = 0f;
                for (int i = 0; i < lines + 1; i++)
                {
                    gr.DrawLine(mypen, x, y, panelw, y);
                    y += yspace;
                }
        }

        public void drawcrossing(Graphics gr,Point clickedpoint,Crossing C)
        {
            try
            {
                    Point cellstartpoint = findcell(clickedpoint);
                    int size = Convert.ToInt32(panelw / lines);
                    Rectangle reg = new Rectangle(cellstartpoint.X - 1, cellstartpoint.Y - 1, Convert.ToInt32(panelw / lines), Convert.ToInt32(panelh / lines));
                    gr.DrawImage(C.image, reg);
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
            }
        }

        //study this center of the square 
        public Point findcell(Point clickedpoint)
        {
            Point start;
            int xx= 0 ;
            int yy = 0;

            for (int x = 0; x <= panelw; x += Convert.ToInt32(panelw / lines))
            {
                if (x > clickedpoint.X)
                {
                    xx = x - Convert.ToInt32(panelw / lines);
                    break;
                }
            }

            for (int y = 0; y <= panelh; y += Convert.ToInt32(panelw / lines))
            {
                if (y > clickedpoint.Y)
                {
                    yy= y - Convert.ToInt32(panelw / lines);
                    break;
                }
            }
            start = new Point(xx,yy);
            return start;
        }

        public void callinvalidate(Control C)
        {
            C.Invalidate();
        }

        public bool isTakenCell(Point p)
        {
            bool taken = false;
            foreach (var item in this.Design.allcreatedcrossings)
            {
                if(findcell(item.Position) == findcell(p))
                {
                    taken = true;
                }
            }
            return taken;
        }


    }
}
