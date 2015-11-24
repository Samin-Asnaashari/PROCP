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
<<<<<<< HEAD
        //public bool isType_1=false;
=======
>>>>>>> refs/remotes/origin/Samin

        public Control panel;

        public SetCrossing()
        {
            InitializeComponent();
            axWindowsMediaPlayer1.URL = "Video.mp4";
            axWindowsMediaPlayer1.Ctlcontrols.play();
        }


        private void createbutton_Click(object sender, EventArgs e)
        {
<<<<<<< HEAD
            controller.Design.allcreatedcrossings.Add(controller  .C);
            controller.callinvalidate(panel);
            this.Close();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            axWindowsMediaPlayer1.Ctlcontrols.play();            
        }

        private void SetCrossing_Load(object sender, EventArgs e)
        {
            Image im = (Image)(new Bitmap("Type1.png"));
            if (this.controller.C.image == im)
            {
                this.labelpl.Visible = false;
                this.plightlistBox.Visible = false;
                this.ptextBox1.Visible = false;
                this.ptextBox2.Visible = false;
            }
        }
=======
            controller.Design.allcreatedcrossings.Add(controller.C);
            controller.callinvalidate(panel);
            this.Close();
        }
>>>>>>> refs/remotes/origin/Samin
    }
}
