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
            controller.SetTheLaneGroupsT(controller.C);
            setLightTime();
            controller.Design.allcreatedcrossings.Add(controller.C);
            controller.callinvalidate(panel);
            this.Close();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            axWindowsMediaPlayer1.Ctlcontrols.play();
        }

        public void setLightTime()
        {
            if (controller.C.CType == 1)
            {
                controller.C.Groups.Add(Convert.ToInt32(textBox1.Text));
                controller.C.Groups.Add(Convert.ToInt32(textBox2.Text));
                controller.C.Groups.Add(Convert.ToInt32(textBox3.Text));
                controller.C.Groups.Add(Convert.ToInt32(textBox4.Text));
                controller.C.Groups.Add(Convert.ToInt32(textBox5.Text));
                controller.C.LightCounter = 0;
            }
            else
            {
                controller.C.Groups.Add(Convert.ToInt32(textBox1.Text));
                controller.C.Groups.Add(Convert.ToInt32(textBox2.Text));
                controller.C.Groups.Add(Convert.ToInt32(textBox3.Text));
                controller.C.Groups.Add(Convert.ToInt32(textBox4.Text));
                controller.C.Groups.Add(Convert.ToInt32(textBox5.Text));
                controller.C.Groups.Add(Convert.ToInt32(textBox6.Text));
                controller.C.Groups.Add(Convert.ToInt32(textBox7.Text));
                controller.C.Groups.Add(Convert.ToInt32(textBox8.Text));
                controller.C.Groups.Add(Convert.ToInt32(textBox9.Text));
                controller.C.Groups.Add(Convert.ToInt32(textBox10.Text));
                controller.C.LightCounter = 0;
            }
        }
    }
}
