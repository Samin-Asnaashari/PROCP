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
        /// <summary>
        /// class to control the form 
        /// </summary>

        public WorkspaceDesign Design;
        public float panelw;
        public float panelh;
        public int lines;

        public Crossing C;
        public int tempCType;

        public Controller(float pw, float ph, WorkspaceDesign d)
        {
            this.Design = d;
            this.panelw = pw;
            this.panelh = ph;
            lines = 0;
            tempCType = 0;
        }

        /// <summary>
        /// crate a grid in workspace area base on user choice(small,medium,large)
        /// </summary>
        /// <param name="gr"></param>
        public void drawthedesigngrid(Graphics gr)
        {
            float x = 0f;
            float y = 0f;
            Pen mypen = new Pen(Brushes.Black, 1);

            float xspace = panelw / lines;
            float yspace = panelh / lines;

            //vertical
            for (int i = 0; i < lines + 1; i++)
            {
                gr.DrawLine(mypen, x, y, x, panelh);
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

        /// <summary>
        /// draw one crossing in a chosen cell and crossing type picture 
        /// user click and drag the crossing type to the workspace area 
        /// </summary>
        /// <param name="gr"></param>
        /// <param name="clickedpoint"></param>
        /// <param name="C"></param>
        public void drawcrossing(Graphics gr, Point position, Crossing C)
        {
            try
            {
                int size = Convert.ToInt32(panelw / lines);
                Rectangle reg = new Rectangle(position.X - 1, position.Y - 1, Convert.ToInt32(panelw / lines), Convert.ToInt32(panelh / lines));
                gr.DrawImage(C.image, reg);
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
            }
        }


        //study this center of the square 
        /// <summary>
        /// find the cell base on the user click position 
        /// </summary>
        /// <param name="clickedpoint"></param>
        /// <returns></returns>
        public Point findcell(Point clickedpoint)
        {
            Point start;
            int xx = 0;
            int yy = 0;

            for (int x = 0; x <= panelw + Convert.ToInt32(panelw / lines); x += Convert.ToInt32(panelw / lines))
            {
                if (x > clickedpoint.X)
                {
                    xx = x - Convert.ToInt32(panelw / lines);
                    break;
                }
            }

            for (int y = 0; y <= panelh + Convert.ToInt32(panelw / lines); y += Convert.ToInt32(panelh / lines))
            {
                if (y > clickedpoint.Y)
                {
                    yy = y - Convert.ToInt32(panelh / lines);
                    break;
                }
            }
            start = new Point(xx, yy);
            return start;
        }

        public void callinvalidate(Control Control)
        {
            Control.Invalidate();
        }

        /// <summary>
        /// check if the cell is occupied
        /// </summary>
        /// <param name="p"></param>
        /// <returns></returns>
        public bool isTakenCell(Point p)
        {
            bool taken = false;
            foreach (var item in this.Design.allcreatedcrossings)
            {
                if (item.StartPoint == findcell(p))
                {
                    taken = true;
                    break;
                }
            }
            return taken;
        }

    }
}
