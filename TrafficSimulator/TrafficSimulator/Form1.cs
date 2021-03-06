﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using System.Runtime.Serialization;
using System.Reflection;

namespace TrafficSimulator
{
    public partial class Form1 : Form
    {
        //panelBuffer p;
        private Controller controller;

        bool showgrid = false;
        bool start = false;

        bool IsSet = false;

        private Image selectedimage;
        private Crossing selectedCrossinginpanel;

        public Form1()
        {
            InitializeComponent();
            PBtype1.Enabled = false;
            PBtype2.Enabled = false;
            cursorbutton.Enabled = false;
            buttonremove.Enabled = false;
            buttonclear.Enabled = false;
            setbutton.Enabled = false;
            playbutton.Enabled = false;
            pausebutton.Enabled = false;
            stopbutton.Enabled = false;
            workpanel.MakeDoubleBuffered(true);
        }

        private void gridbutton_Click(object sender, EventArgs e)
        {
            OverviewlistBox.Items.Clear();
            object obj = gridcomboBox.SelectedItem;
            string name = tbname.Text;
            DateTime time = dateTimePicker1.Value;

            if (obj != null && name != "")
            {
                string grid = gridcomboBox.SelectedItem.ToString();
                WorkspaceDesign D = new WorkspaceDesign(grid, name, time);
                this.controller = Controller.getController();
                this.controller.setSettings(this.workpanel.Width, this.workpanel.Height, D);

                if (D.Grid == "Small")
                {
                    //4*4
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
                selectedCrossinginpanel = null;
                showgrid = true;
                this.workpanel.Invalidate();
                StatuslistBox.Items.Clear();

                PBtype1.Enabled = true;
                PBtype2.Enabled = true;
                cursorbutton.Enabled = true;
                buttonremove.Enabled = true;
                buttonclear.Enabled = true;
                setbutton.Enabled = true;

                IsSet = false;
            }
            else
            {
                string s = "😜";
                StatuslistBox.Items.Add("First:Choose the Grid & Name & Time. " + s);
            }
        }

        int Count = 0;
        private void workpanel_Paint(object sender, PaintEventArgs e)
        {
            //Graphics gr = e.Graphics;
            if (showgrid == true)
            {
                if (selectedCrossinginpanel != null)
                {
                    e.Graphics.DrawRectangle(new Pen(Brushes.DarkCyan, 3), new Rectangle(selectedCrossinginpanel.StartPoint.X, selectedCrossinginpanel.StartPoint.Y,
                        Convert.ToInt32(workpanel.Width / controller.lines), Convert.ToInt32(workpanel.Height / controller.lines)));
                } 

                this.controller.drawthedesigngrid(e.Graphics);

                for (int i = 0; i < controller.Design.allcreatedcrossings.Count; i++)
                {
                    this.controller.drawcrossing(e.Graphics, controller.Design.allcreatedcrossings[i].StartPoint, controller.Design.allcreatedcrossings[i]);
                }
                if (start == true)
                {
                    //draw cars
                    controller.DrawLights(e.Graphics);
                    controller.SetCars(e.Graphics);
                    if (Count == 5)
                    {
                        OverviewlistBox.Items.Clear();
                        foreach (var citem in controller.Design.allcreatedcrossings)
                        {
                            foreach (var litem in citem.Lanes)
                            {
                                OverviewlistBox.Items.Add("Lane :" + litem.LaneID);
                                OverviewlistBox.Items.Add("---Entrance: " + litem.Entrance.ToString() + " Intersection" + litem.Intersection.ToString());
                                OverviewlistBox.Items.Add("---NR of Cars: " + litem.Cars.Count);
                                OverviewlistBox.Items.Add("---Light: " + litem.Light.Color.ToString());
                            }
                        }
                        Count = 0;
                    }
                }
            }
        }

        private void PBtype1_MouseDown(object sender, MouseEventArgs e)
        {
            if (this.controller != null) //Just in case 
            {
                Cursor.Current = Cursors.Cross;
                PBtype1.BorderStyle = BorderStyle.FixedSingle;
                selectedimage = (Image)(new Bitmap(new Bitmap("Type1.png")));
                controller.tempCType = 1;
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
            if (controller != null) //Just in case 
            {
                Cursor.Current = Cursors.Cross;
                PBtype2.BorderStyle = BorderStyle.FixedSingle;
                selectedimage = (Image)(new Bitmap(new Bitmap("Type2.png")));
                controller.tempCType = 2;
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
            Cursor.Current = Cursors.Cross;
        }

        private void workpanel_DragDrop(object sender, DragEventArgs e)
        {
            if (selectedimage != null)
            {
                //Point p = new Point(e.X, e.Y) ;
                Point p = workpanel.PointToClient(new Point(e.X, e.Y));
                if (controller.isTakenCell(p) == false)
                {
                    this.controller.C = new Crossing(controller.findcell(p),selectedimage, this.workpanel.Width / this.controller.lines);
                    controller.C.CType = controller.tempCType;

                    SetCrossing fcrossing = new SetCrossing();

                    if (this.controller.C.CType == 1)
                    {
                        fcrossing.pictureBox1.BackgroundImage = (Image)(new Bitmap(new Bitmap("T1.png")));
                    }
                    else if(this.controller.C.CType == 2)
                    {
                        fcrossing.pictureBox1.BackgroundImage = (Image)(new Bitmap(new Bitmap("T2.png")));
                    }
                    fcrossing.controller = this.controller;
                    fcrossing.setgrouplights();
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

        //CLEAR all the created crossing 
        private void buttonclear_Click(object sender, EventArgs e)
        {
            this.controller.Design.allcreatedcrossings.Clear();
            this.workpanel.Invalidate();
            //this.controller.C = new Crossing(new Point(0, 0), null, this.workpanel.Width / this.controller.lines);
            this.controller.C = null;
            selectedimage = null;
            selectedCrossinginpanel = null;
        }

        //REMOVE seletedCrossing;
        private void buttonremove_Click(object sender, EventArgs e) //needs to fix and work better 
        {
            if (selectedCrossinginpanel != null)
            {
                Crossing cross = controller.Design.allcreatedcrossings.Find(x => x.StartPoint == selectedCrossinginpanel.StartPoint);
                controller.Design.allcreatedcrossings.Remove(cross);
                this.workpanel.Invalidate();
                selectedCrossinginpanel = null;
            }
            else
            {
                StatuslistBox.Items.Add("Select a crossing on the grid first..😅");
            }
        }

        private void setbutton_Click(object sender, EventArgs e)
        {
            controller.ClearSimulator();
            if (controller.Design.allcreatedcrossings.Count != 0)
            {
                controller.Design.SetUpLanes(controller.Design.allcreatedcrossings);
                controller.Design.SetNextLaneCrossingNeigborC1();
                controller.Design.SetNextLaneCrossingNeigborC2();
                foreach (Crossing item in controller.Design.allcreatedcrossings)
                {
                    controller.SetTheLights(item);
                }
                //controller.Design.setEnterancesLanes();


                if (controller.Design.CheckIfIsValidToSetUpSimulator())
                {
                    controller.Design.setEnterancesLanes();

                    SetupSimulator CarsDirectionStatistic = new SetupSimulator();
                    CarsDirectionStatistic.controller = this.controller;
                    CarsDirectionStatistic.ControlPlay = playbutton;
                    CarsDirectionStatistic.ControlPause = pausebutton;
                    CarsDirectionStatistic.ControlStop = stopbutton;
                    CarsDirectionStatistic.Show();
                    IsSet = true;
                }
                else
                {
                    StatuslistBox.Items.Add("All crossing need to have a path!!");
                    StatuslistBox.Items.Add("Please fix the design first..😅");
                }
            }
            else
            {
                StatuslistBox.Items.Add("Draw Crossing First!!");
            }
        }

        private void playbutton_Click(object sender, EventArgs e)
        {
            if (IsSet)
            {
                PBtype1.Enabled = false;
                PBtype2.Enabled = false;
                cursorbutton.Enabled = false;
                buttonremove.Enabled = false;
                buttonclear.Enabled = false;
                setbutton.Enabled = false;
                playbutton.Enabled = false;
                gridbutton.Enabled = false;
                controller.Started = false;

                //controller.Design.SetUpLanes(controller.Design.allcreatedcrossings);
                //controller.Design.SetNextLaneCrossingNeigborC1();
                //controller.Design.SetNextLaneCrossingNeigborC2();
                //controller.Design.setEnterancesLanes();

                this.controller.lightsTimer.Enabled = true;
                timer1.Enabled = true;
            }
            else
            {
                StatuslistBox.Items.Add("Set The Crossing First!!");
            }
        }

        private void pausebutton_Click(object sender, EventArgs e)
        {
            playbutton.Enabled = true;
            start = false;
            timer1.Enabled = false;
            gridbutton.Enabled = true;
            this.controller.lightsTimer.Enabled = false;
            workpanel.Invalidate();
        }

        private void stopbutton_Click(object sender, EventArgs e)
        {
            IsSet = false;
            PBtype1.Enabled = true;
            PBtype2.Enabled = true;
            cursorbutton.Enabled = true;
            buttonremove.Enabled = true;
            buttonclear.Enabled = true;
            setbutton.Enabled = true;
            playbutton.Enabled = true;
            start = false;
            timer1.Enabled = false;
            gridbutton.Enabled = true;
            this.controller.lightsTimer.Enabled = false;
            controller.ClearSimulator();
            workpanel.Invalidate();
        }

        //OPEN a simulation file;
        private void openToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (this.showgrid == true)
            {

                DialogResult dialogResult = MessageBox.Show("Would you like to save your current work?", "Save file ?", MessageBoxButtons.YesNo);
                //if user clicks YES
                if (dialogResult == DialogResult.Yes)
                {
                    this.controller.Design.SaveAs(this.controller);
                    OpenFile();
                }
                else
                    this.OpenFile();
            }
            else
            {
                this.OpenFile();
            }

            showgrid = true;
            PBtype1.Enabled = true;
            PBtype2.Enabled = true;
            cursorbutton.Enabled = true;
            buttonremove.Enabled = true;
            buttonclear.Enabled = true;
            workpanel.Invalidate();
        }

        private void saveToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.controller.Design.Save(this.controller);   ////NEEDS TO BE FIXED
        }

        private void saveAsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.controller.Design.SaveAs(this.controller);
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (this.showgrid == true) 
            {
                DialogResult dialogResult = MessageBox.Show("Would you like to save your current work?", "Save file ?", MessageBoxButtons.YesNo);
                //User clicks YES
                if (dialogResult == DialogResult.Yes)
                {
                    this.controller.Design.SaveAs(this.controller);
                    this.Close();
                }
                else
                {
                    this.Close();
                }
            }
            else
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

        private void timer1_Tick(object sender, EventArgs e)
        {
            //timer1.Stop();
            start = true;
            Count++;
            workpanel.Invalidate();
            //timer1.Start();
        }

        //When user selects a crossing , stores all the information in selectedCrossing;
        private void workpanel_MouseClick(object sender, MouseEventArgs e)
        {
           if(this.controller != null)
           {
            Point p = workpanel.PointToClient(new Point(e.X, e.Y));
            Point cellstartpoint = controller.findcell(new Point(e.X, e.Y));

            if (controller.isTakenCell(cellstartpoint) == true)
            {
                foreach (var crossing in controller.Design.allcreatedcrossings)
                {
                    if (crossing.StartPoint == controller.findcell(cellstartpoint))
                    {
                        selectedCrossinginpanel = crossing;
                        workpanel.Invalidate();
                    }
                }
            }
           }
        }

        public bool OpenFile()
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();

            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                FileStream fs = null;
                BinaryFormatter bf = null;

                openFileDialog.Filter = "SimulatorExtension files (*.simex)|*.simex";
                openFileDialog.FilterIndex = 1;
                openFileDialog.RestoreDirectory = true;


                fs = new FileStream(openFileDialog.FileName, FileMode.Open, FileAccess.Read);
                bf = new BinaryFormatter();
                Controller loadController = (Controller)(bf.Deserialize(fs));
                this.controller = loadController;
                this.controller.Design.allcreatedcrossings = loadController.Design.allcreatedcrossings;
                //OverviewlistBox.Items.Clear();
                return true;
            }
            else
                return false;

        }

        private void cursorbutton_Click(object sender, EventArgs e)
        {
            selectedCrossinginpanel = null;
            workpanel.Invalidate();
        }

        private void newToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (showgrid == false)
            {
                //OverviewlistBox.Items.Clear();
                this.tbname.Clear();
                this.gridcomboBox.Invalidate();
                PBtype1.Enabled = false;
                PBtype2.Enabled = false;
                buttonremove.Enabled = false;
                buttonclear.Enabled = false;
                setbutton.Enabled = false;
                playbutton.Enabled = false;
                pausebutton.Enabled = false;
                stopbutton.Enabled = false;
                this.workpanel.Invalidate();
            }
            else
            {
                DialogResult dialogResult = MessageBox.Show("Would you like to save your current work?", "Save file ?", MessageBoxButtons.YesNo);
                //User clicks YES
                if (dialogResult == DialogResult.Yes)
                {
                    this.controller.Design.SaveAs(this.controller);
                    if (this.controller.Design.allcreatedcrossings.Count != 0)
                    {
                        this.controller.Design.allcreatedcrossings.Clear();
                    }
                    showgrid = false;
                    this.tbname.Clear();
                    this.gridcomboBox.Invalidate();
                    PBtype1.Enabled = false;
                    PBtype2.Enabled = false;
                    buttonremove.Enabled = false;
                    buttonclear.Enabled = false;
                    setbutton.Enabled = false;
                    playbutton.Enabled = false;
                    pausebutton.Enabled = false;
                    stopbutton.Enabled = false;
                    this.workpanel.Invalidate();
                }
                else
                    if (this.controller.Design.allcreatedcrossings.Count != 0)
                    {
                        this.controller.Design.allcreatedcrossings.Clear();
                    }

                OverviewlistBox.Items.Clear();
                showgrid = false;
                this.tbname.Clear();
                this.gridcomboBox.Invalidate();
                PBtype1.Enabled = false;
                PBtype2.Enabled = false;
                buttonremove.Enabled = false;
                buttonclear.Enabled = false;
                setbutton.Enabled = false;
                playbutton.Enabled = false;
                pausebutton.Enabled = false;
                stopbutton.Enabled = false;
                this.workpanel.Invalidate();
            }

        }
    }
}
