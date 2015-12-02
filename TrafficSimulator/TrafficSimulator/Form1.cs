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
        //maybe better when a window pups up main one become background 

        private Controller controller;
        private Image selectedimage;
        bool showgrid = false;
        bool start = false;
        Graphics selectCrossing;



        public Form1()
        {
            InitializeComponent();

            PBtype1.Enabled = false;
            PBtype2.Enabled = false;
            editbutton.Enabled = false;
            buttonremove.Enabled = false;
            buttonclear.Enabled = false;
            setbutton.Enabled = false;
            playbutton.Enabled = false;
            pausebutton.Enabled = false;
            stopbutton.Enabled = false;
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
                this.controller = new Controller(this.workpanel.Width, this.workpanel.Height, D);
                if (D.Grid == "Small")
                {
                    //6*6
                    this.controller.lines = 4;
                }
                else if (D.Grid == "Medium")
                {
                    //3*3
                    this.controller.lines = 3;
                }
                else if (D.Grid == "Large")
                {
                    //2*2
                    this.controller.lines = 2;
                }
                selectedimage = null;
                this.controller.C = new Crossing(null, this.workpanel.Width / this.controller.lines);
                showgrid = true;
                this.workpanel.Invalidate();
                StatuslistBox.Items.Clear();

                PBtype1.Enabled = true;
                PBtype2.Enabled = true;
                editbutton.Enabled = true;
                buttonremove.Enabled = true;
                buttonclear.Enabled = true;
                setbutton.Enabled = true;

            }
            else
            {
                string s = "😜";
                StatuslistBox.Items.Add("Fisrt:Choose the Grid & Name & Time. " + s);
            }
        }

        private void workpanel_Paint(object sender, PaintEventArgs e)
        {
            Graphics gr = e.Graphics;
            if (showgrid == true)
            {
                this.controller.drawthedesigngrid(gr);
                for (int i = 0; i < controller.Design.allcreatedcrossings.Count; i++)
                {
                    this.controller.drawcrossing(gr, controller.Design.allcreatedcrossings[i].StartPoint, controller.Design.allcreatedcrossings[i]);
                }
                if (start == true)
                {
                }
            }
        }

        private void PBtype1_MouseDown(object sender, MouseEventArgs e)
        {
            if (this.controller != null) //is not needed anymore 
            {
                Cursor.Current = Cursors.Cross;
                PBtype1.BorderStyle = BorderStyle.FixedSingle;
                selectedimage = (Image)(new Bitmap(new Bitmap("Type1.png")));
                controller.CType = 1;
                PBtype1.DoDragDrop(selectedimage, DragDropEffects.Copy);
            }
            else
            {
                string s = "😅";
                StatuslistBox.Items.Add("Fisrt Create a Design. " + s);
            }
        }

        private void PBtype2_MouseDown(object sender, MouseEventArgs e)
        {
            if (controller != null) //is not needed anymore
            {
                Cursor.Current = Cursors.Cross;
                PBtype2.BorderStyle = BorderStyle.FixedSingle;
                selectedimage = (Image)(new Bitmap(new Bitmap("Type2.png")));
                controller.CType = 2;
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
                    this.controller.C = new Crossing(selectedimage, this.workpanel.Width / this.controller.lines);
                    controller.C.StartPoint = controller.findcell(p);
                    SetCrossing fcrossing = new SetCrossing();

                    if (this.controller.CType == 1)
                    {
                        fcrossing.pictureBox1.BackgroundImage = (Image)(new Bitmap(new Bitmap("T1.png")));
                    }
                    else
                    {
                        fcrossing.pictureBox1.BackgroundImage = (Image)(new Bitmap(new Bitmap("T2.png")));
                    }
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
        }

        private void buttonclear_Click(object sender, EventArgs e)
        {
            //////
        }

        private void editbutton_Click(object sender, EventArgs e)
        {

        }

        private void buttonremove_Click(object sender, EventArgs e)
        {

        }

        private void setbutton_Click(object sender, EventArgs e)
        {
            if (controller.Design.CheckIfIsValidToSetUpSimulator())
            {
                SetupSimulator CarsDirectionStatic = new SetupSimulator();
                CarsDirectionStatic.controller = this.controller;
                CarsDirectionStatic.ControlPlay = playbutton;
                CarsDirectionStatic.ControlPause = pausebutton;
                CarsDirectionStatic.ControlStop = stopbutton;
                CarsDirectionStatic.Show();
            }
            else
            {
                StatuslistBox.Items.Add("All crossing need to have a path!!");
                StatuslistBox.Items.Add("Please fix the design first..😅");
            }
        }

        private void playbutton_Click(object sender, EventArgs e)
        {
            timer1.Enabled = true;
        }

        private void pausebutton_Click(object sender, EventArgs e)
        {

        }

        private void stopbutton_Click(object sender, EventArgs e)
        {
            timer1.Enabled = false;
        }

        private void openToolStripMenuItem_Click(object sender, EventArgs e)
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
            this.workpanel.AllowDrop = true;
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

        private void timer1_Tick(object sender, EventArgs e)
        {
            start = true;
            workpanel.Invalidate();
        }

        //select a crossing when click.
        private void workpanel_MouseClick(object sender, MouseEventArgs e)
        {
            Point cellstartpoint = controller.findcell(new Point(e.X, e.Y));
            if (controller.isTakenCell(cellstartpoint) == true)
            {
                foreach (var crossing in controller.Design.allcreatedcrossings)
                {
                    if (crossing.StartPoint == controller.findcell(cellstartpoint))
                    {
                        //add more code ...
                        selectCrossing = this.workpanel.CreateGraphics();
                        selectCrossing.DrawRectangle(new Pen(Brushes.Black, 3), new Rectangle(cellstartpoint.X, cellstartpoint.Y, Convert.ToInt32(controller.panelw / controller.lines), Convert.ToInt32(controller.panelw / controller.lines)));
                    }


                }
            }
        }


    }
}
