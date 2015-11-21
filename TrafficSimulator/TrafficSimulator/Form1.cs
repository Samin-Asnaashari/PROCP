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

        //private bool Mouse_moved;//
        //private bool Mouse_pressed;
        //private Crossing Selected_crossing;
        private Controller controller;
        private int Selected_mode = 0;
        private WorkspaceDesign design;

        public Form1()
        {
            InitializeComponent();
            tbname.Text = "";
            gridcomboBox.Text = "Medium";
            this.design = new WorkspaceDesign(tbname.Text, dateTimePicker1.Value);
            this.controller = new Controller(workpanel.Size, workpanel.CreateGraphics(), design);
        }

        private void workpanel_Paint(object sender, PaintEventArgs e)
        {
            this.controller.resizeDesignCrossings();
            this.controller.redrawGrid();
            this.controller.redrawCrossing();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            
        }

        private void gridbutton_Click(object sender, EventArgs e)
        {
            try
            {
                if (tbname.Text == "")
                {
                    MessageBox.Show("The design must have a name!");
                    return;
                }
                this.design = new WorkspaceDesign(tbname.Text, dateTimePicker1.Value);
                this.controller = new Controller(workpanel.Size, workpanel.CreateGraphics(), design);
                this.controller.Workspace_size = workpanel.Size;
                this.controller.Design.size = this.controller.CreateGrid(gridcomboBox.Text);
                this.controller.resizeDesignCrossings();
                workpanel.Invalidate();
            }
            catch (ArgumentException msg)
            {
                StatuslistBox.Items.Add(msg.Message);
            }
        }

        private void PBtype1_Click(object sender, EventArgs e)
        {
            this.Selected_mode = 0;
        }

        private void PBtype2_Click(object sender, EventArgs e)
        {
            this.Selected_mode = 1;
        }

        private void buttonclear_Click(object sender, EventArgs e)
        {
            //this.controller.Empty();
            this.controller.cleanUp();
            this.controller = new Controller(workpanel.Size, workpanel.CreateGraphics(), design);
            workpanel.Invalidate();
        }

        private void workpanel_MouseClick(object sender, MouseEventArgs e)
        {
            Console.WriteLine(e.Location);
            // Don't do anything if there is no grid
            if (this.controller.Design.size.Width == 1 || this.controller.Design.size.Height == 1) return;

            this.controller.AddCrossing(e.Location, this.Selected_mode);
            workpanel.Invalidate();          
        }

        private void openToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //Stream d = null;
            //OpenFileDialog dialog = new OpenFileDialog();

            //dialog.InitialDirectory = "c:\\";
            //dialog.Filter = "bin files (*.bin)|*.bin|All files (*.*)|*.*";
            //dialog.FilterIndex = 2;
            //dialog.RestoreDirectory = true;

            //if (dialog.ShowDialog() == DialogResult.OK)
            //{
            //    try
            //    {
            //        if ((d = dialog.OpenFile()) != null)
            //        {
            //            using (d)
            //            {
            //                this.controller.cleanUp();
            //                this.controller = new Controller(workpanel.Size, workpanel.CreateGraphics(),.....);
            //                this.controller.LoadDesign(d, dialog.FileName);
            //            }
            //        }
            //    }
            //    catch (Exception ex)
            //    {
            //        MessageBox.Show("Error: Could not read file from disk. Original error: " + ex.Message);
            //    }
            //}

            //workpanel.Invalidate();
        }

        private void newToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.controller.cleanUp();
            this.controller = new Controller(workpanel.Size, workpanel.CreateGraphics(), design);
        }

        private void saveToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.controller.SaveDesign();
        }

        private void saveAsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Stream design_stream;
            SaveFileDialog dialog = new SaveFileDialog();

            dialog.Filter = "bin files (*.bin)|*.bin|All files (*.*)|*.*";
            dialog.FilterIndex = 2;
            dialog.RestoreDirectory = true;

            if (dialog.ShowDialog() == DialogResult.OK)
            {
                if ((design_stream = dialog.OpenFile()) != null)
                {
                    this.controller.SaveDesignAs(design_stream, dialog.FileName);
                    design_stream.Close();
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

        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {

        }

        private void tbname_TextChanged(object sender, EventArgs e)
        {

        }

        private void gridcomboBox_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}
