﻿using System;
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
    public partial class SetupSimulator : Form
    {
        public Controller controller;

        public Control ControlPlay;
        public Control ControlPause;
        public Control ControlStop;

        public SetupSimulator()
        {
            InitializeComponent();
        }

        private void setbutton_Click(object sender, EventArgs e)
        {
            ControlPlay.Enabled = true;
            ControlPause.Enabled = true;
            ControlStop.Enabled = true;
        }
    }
}
