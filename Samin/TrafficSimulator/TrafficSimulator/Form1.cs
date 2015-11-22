using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace TrafficSimulator
{
    public partial class Form1 : Form
    {
        private Controller controller;

        //private Simulator S;

        bool showgrid = false;

        private Image selectedimage;

        public Form1()
        {
            InitializeComponent();
            //controller = new Controller(workpanel.Width , workpanel.Height,D); transfered to creategrid
        }

        private void workpanel_Paint(object sender, PaintEventArgs e)
        {
            Graphics gr = e.Graphics;
            if(showgrid == true)
            {
                controller.drawthedesigngrid(gr);
                for (int i = 0; i < controller.Design.allcreatedcrossings.Count; i++)
                {
                    controller.drawcrossing(gr, controller.Design.allcreatedcrossings[i].Position, controller.Design.allcreatedcrossings[i]);
                }
            }
        }

        private void gridbutton_Click(object sender, EventArgs e)
        {
            string grid = gridcomboBox.SelectedItem.ToString();
            string name = tbname.Text;
            DateTime time = dateTimePicker1.Value;
            WorkspaceDesign D = new WorkspaceDesign(grid,name,time);
            controller = new Controller(this.workpanel.Width , this.workpanel.Height,D);
            if (D.Grid == "Small")
            {
                //6*6
                controller.lines = 6;
            }
            else if (D.Grid == "Medium")
            {
                //3*3
                controller.lines = 3;
            }
            else if (D.Grid == "Large")
            {
                //2*2
                controller.lines = 2;
            }
            this.controller.C = new Crossing(new Point(0,0),null,this.workpanel.Width / this.controller.lines);
            showgrid = true;
            workpanel.Invalidate();
        }

        private void PBtype1_Click(object sender, EventArgs e)
        {
            //this.controller.C.image = (Image)(new Bitmap(new Bitmap("Type1.png")));
            selectedimage = (Image)(new Bitmap(new Bitmap("Type1.png")));
        }

        private void PBtype2_Click(object sender, EventArgs e)
        {
            //this.controller.C.image = (Image)(new Bitmap(new Bitmap("Type2.png")));
            selectedimage = (Image)(new Bitmap(new Bitmap("Type2.png")));
        }

        private void buttonclear_Click(object sender, EventArgs e)
        {
            showgrid = false;
            workpanel.Invalidate();
        }

        private void workpanel_MouseClick(object sender, MouseEventArgs e)
        {
            
        }

        private void openToolStripMenuItem_Click(object sender, EventArgs e)
        {
            
        }

        private void newToolStripMenuItem_Click(object sender, EventArgs e)
        {
           
        }

        private void saveToolStripMenuItem_Click(object sender, EventArgs e)
        {
            
        }

        private void saveAsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void helpToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form form2 = new Help();
            form2.Show();
        }

        private void editbutton_Click(object sender, EventArgs e)
        {

        }

        private void buttonremove_Click(object sender, EventArgs e)
        {

        }

        private void setbutton_Click(object sender, EventArgs e)
        {

        }

        private void playbutton_Click(object sender, EventArgs e)
        {

        }

        private void pausebutton_Click(object sender, EventArgs e)
        {

        }

        private void stopbutton_Click(object sender, EventArgs e)
        {

        }

        private void workpanel_MouseDown(object sender, MouseEventArgs e)
        {
            Point p;
            p = new Point(e.X,e.Y);
            this.controller.C = new Crossing(p, selectedimage, this.workpanel.Width / this.controller.lines);

            SetCrossing fcrossing = new SetCrossing();
            fcrossing.pictureBox1.BackgroundImage = this.controller.C.image;
            fcrossing.controller = this.controller;

            fcrossing.panel = this.workpanel;

            fcrossing.Show();
        }
    }
}
