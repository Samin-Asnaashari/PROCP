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


        private void createbutton_Click(object sender, EventArgs e)
        {
            controller.Design.allcreatedcrossings.Add(controller.C);
            controller.callinvalidate(panel);
            this.Close();
        }
    }
}
