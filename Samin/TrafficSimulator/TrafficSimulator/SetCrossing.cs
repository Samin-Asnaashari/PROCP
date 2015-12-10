using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TrafficSimulator
{
    public partial class SetCrossing : Form
    {
        //set the lights p , n
        public Controller controller;
        public Control panel;

        public SetCrossing()
        {
            InitializeComponent();
            axWindowsMediaPlayer1.URL = "Video.mp4";
            axWindowsMediaPlayer1.Ctlcontrols.play();
        }

        public void setgrouplights()
        {
            if (this.controller.C.CType == 1)
            {
                lightlistBox2.Visible = false;
                textBox6.Visible = false;
                textBox7.Visible = false;
                textBox8.Visible = false;
                textBox9.Visible = false;
                textBox10.Visible = false;
            }
            else
            {
                lightlistBox1.Visible = false;
            }
        }

        private void createbutton_Click(object sender, EventArgs e)
        {
            controller.Design.allcreatedcrossings.Add(controller.C);
            controller.callinvalidate(panel);
            this.Close();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            axWindowsMediaPlayer1.Ctlcontrols.play();
        }
    }
}
