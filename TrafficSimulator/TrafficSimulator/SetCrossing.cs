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
        public SetCrossing()
        {
            InitializeComponent();
            axWindowsMediaPlayer1.URL = "Video.mp4";
            axWindowsMediaPlayer1.Ctlcontrols.play();
        }
    }
}
