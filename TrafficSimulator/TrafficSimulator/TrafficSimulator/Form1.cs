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
<<<<<<< HEAD
        private Image selectedimage;
        bool showgrid = false;

        public Form1()
        {
            InitializeComponent();
        }

        private void gridbutton_Click(object sender, EventArgs e)
        {
            object obj = gridcomboBox.SelectedItem;
            string name = tbname.Text;
            DateTime time = dateTimePicker1.Value;
            if (obj != null && name != "")
            {
                string grid = gridcomboBox.SelectedItem.ToString();
                WorkspaceDesign D = new WorkspaceDesign(grid, name, time);
                controller = new Controller(this.workpanel.Width, this.workpanel.Height, D);
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
                selectedimage = null;
                this.controller.C = new Crossing(new Point(0, 0), null, this.workpanel.Width / this.controller.lines);
                showgrid = true;
                workpanel.Invalidate();
            }
            else
            {
                string s = "😜";
                StatuslistBox.Items.Add("Fisrt:Choose the Grid & Name & Time. "+ s);
            }
=======

        //private Simulator S;

        bool showgrid = false;

        private Image selectedimage;

        public Form1()
        {
            InitializeComponent();
            //controller = new Controller(workpanel.Width , workpanel.Height,D); transfered to creategrid
>>>>>>> refs/remotes/origin/Samin
        }

        private void workpanel_Paint(object sender, PaintEventArgs e)
        {
            Graphics gr = e.Graphics;
<<<<<<< HEAD
            if (showgrid == true)
=======
            if(showgrid == true)
>>>>>>> refs/remotes/origin/Samin
            {
                controller.drawthedesigngrid(gr);
                for (int i = 0; i < controller.Design.allcreatedcrossings.Count; i++)
                {
                    controller.drawcrossing(gr, controller.Design.allcreatedcrossings[i].Position, controller.Design.allcreatedcrossings[i]);
                }
            }
        }

<<<<<<< HEAD
        private void PBtype1_MouseDown(object sender, MouseEventArgs e)
        {
            if (controller!= null)
            {
                Cursor.Current = Cursors.Cross;
                PBtype1.BorderStyle = BorderStyle.FixedSingle;
                selectedimage = (Image)(new Bitmap(new Bitmap("Type1.png")));
                PBtype1.DoDragDrop(selectedimage,DragDropEffects.Copy);
            }
            else
            {
                string s = "😅";
                StatuslistBox.Items.Add("Fisrt Create a Design. " + s);
            }
        }

        private void PBtype2_MouseDown(object sender, MouseEventArgs e)
        {
            if (controller != null)
            {
                Cursor.Current = Cursors.Cross;
                PBtype2.BorderStyle = BorderStyle.FixedSingle;
                selectedimage = (Image)(new Bitmap(new Bitmap("Type2.png")));
                PBtype2.DoDragDrop(selectedimage, DragDropEffects.Copy);
            }
            else
            {
                string s = "😅";
                StatuslistBox.Items.Add("Fisrt Create a Design. " + s);
            }
        }

        private void workpanel_DragEnter(object sender, DragEventArgs e)
        {
            e.Effect = DragDropEffects.Copy;
        }

        private void workpanel_DragDrop(object sender, DragEventArgs e)
        {
                if (selectedimage != null)
                {
                    //Point p = new Point(e.X, e.Y) ;
                    Point p = workpanel.PointToClient(new Point(e.X, e.Y));
                    if (controller.isTakenCell(p) == false)
                    {
                        this.controller.C = new Crossing(p, selectedimage, this.workpanel.Width / this.controller.lines);
                        SetCrossing fcrossing = new SetCrossing();

                        fcrossing.pictureBox1.BackgroundImage = this.controller.C.image;
                        fcrossing.controller = this.controller;
                        fcrossing.panel = this.workpanel;
                        fcrossing.Show();
                    }
                    else
                    {
                        string s = "😘";
                        StatuslistBox.Items.Add("Cell is already Taken. " + s);
                    }
                }
                else
                {
                    string s = "😅";
                    StatuslistBox.Items.Add("First choose a crossing. " + s);
                }
                PBtype1.BorderStyle = BorderStyle.None;
                PBtype2.BorderStyle = BorderStyle.None;
=======
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
>>>>>>> refs/remotes/origin/Samin
        }

        private void buttonclear_Click(object sender, EventArgs e)
        {
            showgrid = false;
            workpanel.Invalidate();
        }

<<<<<<< HEAD
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
       
        private void openToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //////////////////////////////////check it
            Stream sketch = null;
            OpenFileDialog dialog = new OpenFileDialog();

            dialog.InitialDirectory = "c:\\";
            dialog.Filter = "bin files (*.bin)|*.bin|All files (*.*)|*.*";
            dialog.FilterIndex = 2;
            dialog.RestoreDirectory = true;

            if (dialog.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    if ((sketch = dialog.OpenFile()) != null)
                    {
                        using (sketch)
                        {
                            //this.showgrid = false;
                            //this.workpanel.Invalidate();
                            //this.controller = new Controller(this.workpanel.Width,this.workpanel.Height, this.controller.Design);
                            WorkspaceDesign D = new WorkspaceDesign("", dialog.FileName, System.DateTime.Now);
                            controller = new Controller(this.workpanel.Width, this.workpanel.Height, D);
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
                            this.controller.C = new Crossing(new Point(0, 0), null, this.workpanel.Width / this.controller.lines);
                            this.controller.Design.Load(sketch);
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error: Could not read file from disk. Original error: " + ex.Message);
                }
            }

            showgrid = true;
            workpanel.Invalidate();
        }

        private void newToolStripMenuItem_Click(object sender, EventArgs e) ////////////////////
        {
        }

        private void saveToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.controller.Design.Save();
        }

        private void saveAsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Stream sketch_stream;
            SaveFileDialog dialog = new SaveFileDialog();

            dialog.Filter = "bin files (*.bin)|*.bin|All files (*.*)|*.*";
            dialog.FilterIndex = 2;
            dialog.RestoreDirectory = true;

            if (dialog.ShowDialog() == DialogResult.OK)
            {
                if ((sketch_stream = dialog.OpenFile()) != null)
                {
                    this.controller.Design.Name = dialog.FileName;
                    this.controller.Design.SaveAs(sketch_stream);
                    sketch_stream.Close();
                }
            }
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void helpToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form form2 = new Help();
            form2.Show();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            workpanel.AllowDrop = true;
        }

        private void PBtype1_MouseUp(object sender, MouseEventArgs e)///////////
        {
            selectedimage = null;
            PBtype1.BorderStyle = BorderStyle.None;
        }

        private void PBtype2_MouseUp(object sender, MouseEventArgs e)//////////
        {
            selectedimage = null;
            PBtype2.BorderStyle = BorderStyle.None;
        }


=======
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
>>>>>>> refs/remotes/origin/Samin
    }
}
