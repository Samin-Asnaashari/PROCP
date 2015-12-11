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
    public partial class SetupSimulator : Form
    {
        public Controller controller;

        public Control ControlPlay;
        public Control ControlPause;
        public Control ControlStop;

        /// <summary>
        /// initial value 25% for all directions
        /// </summary>
        public SetupSimulator()
        {
            InitializeComponent();
            textBoxNorth.Text = "25";
            textBoxEast.Text = "25";
            textBoxWest.Text = "25";
            textBoxSouth.Text = "25";
            labelTotal.Text = "100";
        }

        private void textBoxNorth_TextChanged(object sender, EventArgs e)
        {
            int north = Convert.ToInt32(textBoxNorth.Text);
            int east = Convert.ToInt32(textBoxEast.Text);
            int west = Convert.ToInt32(textBoxWest.Text);
            int south = Convert.ToInt32(textBoxSouth.Text);
            labelTotal.Text = "" + (north + east + west + south);
        }

        private void textBoxEast_TextChanged(object sender, EventArgs e)
        {
            int north = Convert.ToInt32(textBoxNorth.Text);
            int east = Convert.ToInt32(textBoxEast.Text);
            int west = Convert.ToInt32(textBoxWest.Text);
            int south = Convert.ToInt32(textBoxSouth.Text);
            labelTotal.Text = "" + (north + east + west + south);
        }

        private void textBoxWest_TextChanged(object sender, EventArgs e)
        {
            int north = Convert.ToInt32(textBoxNorth.Text);
            int east = Convert.ToInt32(textBoxEast.Text);
            int west = Convert.ToInt32(textBoxWest.Text);
            int south = Convert.ToInt32(textBoxSouth.Text);
            labelTotal.Text = "" + (north + east + west + south);
        }

        private void textBoxSouth_TextChanged(object sender, EventArgs e)
        {
            int north = Convert.ToInt32(textBoxNorth.Text);
            int east = Convert.ToInt32(textBoxEast.Text);
            int west = Convert.ToInt32(textBoxWest.Text);
            int south = Convert.ToInt32(textBoxSouth.Text);
            labelTotal.Text = "" + (north + east + west + south);
        }

        private void setbutton_Click(object sender, EventArgs e)
        {
            if (Convert.ToInt32(labelTotal.Text) == 100)
            {
                double north = Convert.ToDouble(textBoxNorth.Text);
                double east = Convert.ToDouble(textBoxEast.Text);
                double west = Convert.ToDouble(textBoxWest.Text);
                double south = Convert.ToDouble(textBoxSouth.Text);
                controller.setSimulatorSettings(north, east, west, south);
                ControlPlay.Enabled = true;
                ControlPause.Enabled = true;
                ControlStop.Enabled = true;
                this.Close();
            }
            else
            {
                MessageBox.Show("The total value must be 100.");
            }
        }
    }
}
