namespace TrafficSimulator
{
    partial class Form1
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.newToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.openToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.saveToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.saveAsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.exitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.helpToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.crossingpanel = new System.Windows.Forms.Panel();
            this.PBtype2 = new System.Windows.Forms.PictureBox();
            this.PBtype1 = new System.Windows.Forms.PictureBox();
            this.crossinglabel = new System.Windows.Forms.Label();
            this.gridpanel = new System.Windows.Forms.Panel();
            this.dateTimePicker1 = new System.Windows.Forms.DateTimePicker();
            this.tbname = new System.Windows.Forms.TextBox();
            this.timelabel = new System.Windows.Forms.Label();
            this.namelabel = new System.Windows.Forms.Label();
            this.workspacelabel = new System.Windows.Forms.Label();
            this.gridbutton = new System.Windows.Forms.Button();
            this.gridcomboBox = new System.Windows.Forms.ComboBox();
            this.gridlabel = new System.Windows.Forms.Label();
            this.workpanel = new System.Windows.Forms.Panel();
            this.controlpanel = new System.Windows.Forms.Panel();
            this.stopbutton = new System.Windows.Forms.Button();
            this.pausebutton = new System.Windows.Forms.Button();
            this.playbutton = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            this.setbutton = new System.Windows.Forms.Button();
            this.editpanel = new System.Windows.Forms.Panel();
            this.buttonclear = new System.Windows.Forms.Button();
            this.buttonremove = new System.Windows.Forms.Button();
            this.editbutton = new System.Windows.Forms.Button();
            this.OverviewlistBox = new System.Windows.Forms.ListBox();
            this.StatuslistBox = new System.Windows.Forms.ListBox();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.menuStrip1.SuspendLayout();
            this.crossingpanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.PBtype2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.PBtype1)).BeginInit();
            this.gridpanel.SuspendLayout();
            this.controlpanel.SuspendLayout();
            this.editpanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.BackColor = System.Drawing.Color.Teal;
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem,
            this.helpToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(1193, 28);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // fileToolStripMenuItem
            // 
            this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.newToolStripMenuItem,
            this.openToolStripMenuItem,
            this.saveToolStripMenuItem,
            this.saveAsToolStripMenuItem,
            this.exitToolStripMenuItem});
            this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            this.fileToolStripMenuItem.Size = new System.Drawing.Size(44, 24);
            this.fileToolStripMenuItem.Text = "File";
            // 
            // newToolStripMenuItem
            // 
            this.newToolStripMenuItem.Name = "newToolStripMenuItem";
            this.newToolStripMenuItem.Size = new System.Drawing.Size(127, 24);
            this.newToolStripMenuItem.Text = "New";
            // 
            // openToolStripMenuItem
            // 
            this.openToolStripMenuItem.Name = "openToolStripMenuItem";
            this.openToolStripMenuItem.Size = new System.Drawing.Size(127, 24);
            this.openToolStripMenuItem.Text = "Open";
            this.openToolStripMenuItem.Click += new System.EventHandler(this.openToolStripMenuItem_Click);
            // 
            // saveToolStripMenuItem
            // 
            this.saveToolStripMenuItem.Name = "saveToolStripMenuItem";
            this.saveToolStripMenuItem.Size = new System.Drawing.Size(127, 24);
            this.saveToolStripMenuItem.Text = "Save";
            this.saveToolStripMenuItem.Click += new System.EventHandler(this.saveToolStripMenuItem_Click);
            // 
            // saveAsToolStripMenuItem
            // 
            this.saveAsToolStripMenuItem.Name = "saveAsToolStripMenuItem";
            this.saveAsToolStripMenuItem.Size = new System.Drawing.Size(127, 24);
            this.saveAsToolStripMenuItem.Text = "Save as";
            this.saveAsToolStripMenuItem.Click += new System.EventHandler(this.saveAsToolStripMenuItem_Click);
            // 
            // exitToolStripMenuItem
            // 
            this.exitToolStripMenuItem.Name = "exitToolStripMenuItem";
            this.exitToolStripMenuItem.Size = new System.Drawing.Size(127, 24);
            this.exitToolStripMenuItem.Text = "Exit";
            this.exitToolStripMenuItem.Click += new System.EventHandler(this.exitToolStripMenuItem_Click);
            // 
            // helpToolStripMenuItem
            // 
            this.helpToolStripMenuItem.Name = "helpToolStripMenuItem";
            this.helpToolStripMenuItem.Size = new System.Drawing.Size(53, 24);
            this.helpToolStripMenuItem.Text = "Help";
            this.helpToolStripMenuItem.Click += new System.EventHandler(this.helpToolStripMenuItem_Click);
            // 
            // crossingpanel
            // 
            this.crossingpanel.BackColor = System.Drawing.Color.Silver;
            this.crossingpanel.Controls.Add(this.PBtype2);
            this.crossingpanel.Controls.Add(this.PBtype1);
            this.crossingpanel.Controls.Add(this.crossinglabel);
            this.crossingpanel.Location = new System.Drawing.Point(12, 277);
            this.crossingpanel.Name = "crossingpanel";
            this.crossingpanel.Size = new System.Drawing.Size(256, 175);
            this.crossingpanel.TabIndex = 1;
            // 
            // PBtype2
            // 
            this.PBtype2.BackColor = System.Drawing.Color.Transparent;
            this.PBtype2.BackgroundImage = global::TrafficSimulator.Properties.Resources.Type22;
            this.PBtype2.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.PBtype2.Location = new System.Drawing.Point(134, 45);
            this.PBtype2.Name = "PBtype2";
            this.PBtype2.Size = new System.Drawing.Size(108, 116);
            this.PBtype2.TabIndex = 4;
            this.PBtype2.TabStop = false;
            this.PBtype2.MouseDown += new System.Windows.Forms.MouseEventHandler(this.PBtype2_MouseDown);
            this.PBtype2.MouseUp += new System.Windows.Forms.MouseEventHandler(this.PBtype2_MouseUp);
            // 
            // PBtype1
            // 
            this.PBtype1.BackColor = System.Drawing.Color.Transparent;
            this.PBtype1.BackgroundImage = global::TrafficSimulator.Properties.Resources.Type11;
            this.PBtype1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.PBtype1.Location = new System.Drawing.Point(18, 45);
            this.PBtype1.Name = "PBtype1";
            this.PBtype1.Size = new System.Drawing.Size(110, 116);
            this.PBtype1.TabIndex = 3;
            this.PBtype1.TabStop = false;
            this.PBtype1.MouseDown += new System.Windows.Forms.MouseEventHandler(this.PBtype1_MouseDown);
            this.PBtype1.MouseUp += new System.Windows.Forms.MouseEventHandler(this.PBtype1_MouseUp);
            // 
            // crossinglabel
            // 
            this.crossinglabel.AutoSize = true;
            this.crossinglabel.Font = new System.Drawing.Font("Comic Sans MS", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.crossinglabel.Location = new System.Drawing.Point(14, 11);
            this.crossinglabel.Name = "crossinglabel";
            this.crossinglabel.Size = new System.Drawing.Size(93, 25);
            this.crossinglabel.TabIndex = 1;
            this.crossinglabel.Text = "Crossing :";
            // 
            // gridpanel
            // 
            this.gridpanel.Controls.Add(this.dateTimePicker1);
            this.gridpanel.Controls.Add(this.tbname);
            this.gridpanel.Controls.Add(this.timelabel);
            this.gridpanel.Controls.Add(this.namelabel);
            this.gridpanel.Controls.Add(this.workspacelabel);
            this.gridpanel.Controls.Add(this.gridbutton);
            this.gridpanel.Controls.Add(this.gridcomboBox);
            this.gridpanel.Controls.Add(this.gridlabel);
            this.gridpanel.Location = new System.Drawing.Point(12, 46);
            this.gridpanel.Name = "gridpanel";
            this.gridpanel.Size = new System.Drawing.Size(256, 215);
            this.gridpanel.TabIndex = 0;
            // 
            // dateTimePicker1
            // 
            this.dateTimePicker1.CalendarForeColor = System.Drawing.SystemColors.ActiveCaption;
            this.dateTimePicker1.CalendarMonthBackground = System.Drawing.SystemColors.ButtonShadow;
            this.dateTimePicker1.CalendarTitleBackColor = System.Drawing.Color.CadetBlue;
            this.dateTimePicker1.Location = new System.Drawing.Point(64, 120);
            this.dateTimePicker1.Name = "dateTimePicker1";
            this.dateTimePicker1.Size = new System.Drawing.Size(178, 28);
            this.dateTimePicker1.TabIndex = 8;
            // 
            // tbname
            // 
            this.tbname.BackColor = System.Drawing.Color.CadetBlue;
            this.tbname.Location = new System.Drawing.Point(70, 80);
            this.tbname.Name = "tbname";
            this.tbname.Size = new System.Drawing.Size(155, 28);
            this.tbname.TabIndex = 7;
            // 
            // timelabel
            // 
            this.timelabel.AutoSize = true;
            this.timelabel.Font = new System.Drawing.Font("Comic Sans MS", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.timelabel.Location = new System.Drawing.Point(7, 120);
            this.timelabel.Name = "timelabel";
            this.timelabel.Size = new System.Drawing.Size(51, 21);
            this.timelabel.TabIndex = 5;
            this.timelabel.Text = "Time:";
            // 
            // namelabel
            // 
            this.namelabel.AutoSize = true;
            this.namelabel.Font = new System.Drawing.Font("Comic Sans MS", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.namelabel.Location = new System.Drawing.Point(4, 88);
            this.namelabel.Name = "namelabel";
            this.namelabel.Size = new System.Drawing.Size(57, 21);
            this.namelabel.TabIndex = 4;
            this.namelabel.Text = "Name:";
            // 
            // workspacelabel
            // 
            this.workspacelabel.AutoSize = true;
            this.workspacelabel.Font = new System.Drawing.Font("Comic Sans MS", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.workspacelabel.Location = new System.Drawing.Point(3, 12);
            this.workspacelabel.Name = "workspacelabel";
            this.workspacelabel.Size = new System.Drawing.Size(222, 21);
            this.workspacelabel.TabIndex = 3;
            this.workspacelabel.Text = "Design the Workspace panel:";
            // 
            // gridbutton
            // 
            this.gridbutton.BackColor = System.Drawing.Color.DarkGray;
            this.gridbutton.Location = new System.Drawing.Point(162, 158);
            this.gridbutton.Name = "gridbutton";
            this.gridbutton.Size = new System.Drawing.Size(80, 47);
            this.gridbutton.TabIndex = 2;
            this.gridbutton.Text = "Create";
            this.gridbutton.UseVisualStyleBackColor = false;
            this.gridbutton.Click += new System.EventHandler(this.gridbutton_Click);
            // 
            // gridcomboBox
            // 
            this.gridcomboBox.BackColor = System.Drawing.Color.CadetBlue;
            this.gridcomboBox.FormattingEnabled = true;
            this.gridcomboBox.Items.AddRange(new object[] {
            "Small",
            "Medium",
            "Large"});
            this.gridcomboBox.Location = new System.Drawing.Point(70, 43);
            this.gridcomboBox.Name = "gridcomboBox";
            this.gridcomboBox.Size = new System.Drawing.Size(86, 28);
            this.gridcomboBox.TabIndex = 1;
            // 
            // gridlabel
            // 
            this.gridlabel.AutoSize = true;
            this.gridlabel.Font = new System.Drawing.Font("Comic Sans MS", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gridlabel.Location = new System.Drawing.Point(3, 43);
            this.gridlabel.Name = "gridlabel";
            this.gridlabel.Size = new System.Drawing.Size(61, 25);
            this.gridlabel.TabIndex = 0;
            this.gridlabel.Text = "Grid :";
            // 
            // workpanel
            // 
            this.workpanel.BackColor = System.Drawing.Color.DarkGray;
            this.workpanel.Location = new System.Drawing.Point(274, 58);
            this.workpanel.Name = "workpanel";
            this.workpanel.Size = new System.Drawing.Size(603, 586);
            this.workpanel.TabIndex = 0;
            this.workpanel.DragDrop += new System.Windows.Forms.DragEventHandler(this.workpanel_DragDrop);
            this.workpanel.DragEnter += new System.Windows.Forms.DragEventHandler(this.workpanel_DragEnter);
            this.workpanel.Paint += new System.Windows.Forms.PaintEventHandler(this.workpanel_Paint);
            // 
            // controlpanel
            // 
            this.controlpanel.BackColor = System.Drawing.Color.Silver;
            this.controlpanel.Controls.Add(this.stopbutton);
            this.controlpanel.Controls.Add(this.pausebutton);
            this.controlpanel.Controls.Add(this.playbutton);
            this.controlpanel.Controls.Add(this.label4);
            this.controlpanel.Controls.Add(this.setbutton);
            this.controlpanel.Location = new System.Drawing.Point(12, 543);
            this.controlpanel.Name = "controlpanel";
            this.controlpanel.Size = new System.Drawing.Size(256, 101);
            this.controlpanel.TabIndex = 0;
            // 
            // stopbutton
            // 
            this.stopbutton.BackColor = System.Drawing.Color.DarkGray;
            this.stopbutton.BackgroundImage = global::TrafficSimulator.Properties.Resources.stop;
            this.stopbutton.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.stopbutton.Location = new System.Drawing.Point(151, 51);
            this.stopbutton.Name = "stopbutton";
            this.stopbutton.Size = new System.Drawing.Size(46, 41);
            this.stopbutton.TabIndex = 8;
            this.stopbutton.UseVisualStyleBackColor = false;
            this.stopbutton.Click += new System.EventHandler(this.stopbutton_Click);
            // 
            // pausebutton
            // 
            this.pausebutton.BackColor = System.Drawing.Color.DarkGray;
            this.pausebutton.BackgroundImage = global::TrafficSimulator.Properties.Resources.pause;
            this.pausebutton.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.pausebutton.Location = new System.Drawing.Point(99, 51);
            this.pausebutton.Name = "pausebutton";
            this.pausebutton.Size = new System.Drawing.Size(46, 41);
            this.pausebutton.TabIndex = 8;
            this.pausebutton.UseVisualStyleBackColor = false;
            this.pausebutton.Click += new System.EventHandler(this.pausebutton_Click);
            // 
            // playbutton
            // 
            this.playbutton.BackColor = System.Drawing.Color.DarkGray;
            this.playbutton.BackgroundImage = global::TrafficSimulator.Properties.Resources.start;
            this.playbutton.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.playbutton.Location = new System.Drawing.Point(47, 51);
            this.playbutton.Name = "playbutton";
            this.playbutton.Size = new System.Drawing.Size(46, 41);
            this.playbutton.TabIndex = 8;
            this.playbutton.UseVisualStyleBackColor = false;
            this.playbutton.Click += new System.EventHandler(this.playbutton_Click);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(9, 15);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(79, 20);
            this.label4.TabIndex = 1;
            this.label4.Text = "Controls : ";
            // 
            // setbutton
            // 
            this.setbutton.BackColor = System.Drawing.Color.DarkGray;
            this.setbutton.Location = new System.Drawing.Point(92, 6);
            this.setbutton.Name = "setbutton";
            this.setbutton.Size = new System.Drawing.Size(150, 39);
            this.setbutton.TabIndex = 2;
            this.setbutton.Text = "Set-up Simulator";
            this.setbutton.UseVisualStyleBackColor = false;
            this.setbutton.Click += new System.EventHandler(this.setbutton_Click);
            // 
            // editpanel
            // 
            this.editpanel.Controls.Add(this.buttonclear);
            this.editpanel.Controls.Add(this.buttonremove);
            this.editpanel.Controls.Add(this.editbutton);
            this.editpanel.Location = new System.Drawing.Point(12, 458);
            this.editpanel.Name = "editpanel";
            this.editpanel.Size = new System.Drawing.Size(256, 79);
            this.editpanel.TabIndex = 5;
            // 
            // buttonclear
            // 
            this.buttonclear.BackgroundImage = global::TrafficSimulator.Properties.Resources.clear;
            this.buttonclear.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.buttonclear.Location = new System.Drawing.Point(151, 15);
            this.buttonclear.Name = "buttonclear";
            this.buttonclear.Size = new System.Drawing.Size(53, 48);
            this.buttonclear.TabIndex = 0;
            this.buttonclear.UseVisualStyleBackColor = true;
            this.buttonclear.Click += new System.EventHandler(this.buttonclear_Click);
            // 
            // buttonremove
            // 
            this.buttonremove.BackgroundImage = global::TrafficSimulator.Properties.Resources.eraser_;
            this.buttonremove.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.buttonremove.Location = new System.Drawing.Point(92, 15);
            this.buttonremove.Name = "buttonremove";
            this.buttonremove.Size = new System.Drawing.Size(53, 48);
            this.buttonremove.TabIndex = 0;
            this.buttonremove.UseVisualStyleBackColor = true;
            this.buttonremove.Click += new System.EventHandler(this.buttonremove_Click);
            // 
            // editbutton
            // 
            this.editbutton.BackColor = System.Drawing.Color.DarkGray;
            this.editbutton.Font = new System.Drawing.Font("Comic Sans MS", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.editbutton.Location = new System.Drawing.Point(19, 15);
            this.editbutton.Name = "editbutton";
            this.editbutton.Size = new System.Drawing.Size(67, 48);
            this.editbutton.TabIndex = 2;
            this.editbutton.Text = "Edit";
            this.editbutton.UseVisualStyleBackColor = false;
            this.editbutton.Click += new System.EventHandler(this.editbutton_Click);
            // 
            // OverviewlistBox
            // 
            this.OverviewlistBox.BackColor = System.Drawing.Color.CadetBlue;
            this.OverviewlistBox.FormattingEnabled = true;
            this.OverviewlistBox.ItemHeight = 20;
            this.OverviewlistBox.Items.AddRange(new object[] {
            "Overview:"});
            this.OverviewlistBox.Location = new System.Drawing.Point(883, 58);
            this.OverviewlistBox.Name = "OverviewlistBox";
            this.OverviewlistBox.Size = new System.Drawing.Size(295, 344);
            this.OverviewlistBox.TabIndex = 6;
            // 
            // StatuslistBox
            // 
            this.StatuslistBox.BackColor = System.Drawing.Color.DarkGray;
            this.StatuslistBox.Font = new System.Drawing.Font("Arial Unicode MS", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.StatuslistBox.ForeColor = System.Drawing.Color.DarkRed;
            this.StatuslistBox.FormattingEnabled = true;
            this.StatuslistBox.ItemHeight = 20;
            this.StatuslistBox.Items.AddRange(new object[] {
            "Status:"});
            this.StatuslistBox.Location = new System.Drawing.Point(883, 420);
            this.StatuslistBox.Name = "StatuslistBox";
            this.StatuslistBox.SelectionMode = System.Windows.Forms.SelectionMode.None;
            this.StatuslistBox.Size = new System.Drawing.Size(295, 224);
            this.StatuslistBox.TabIndex = 6;
            // 
            // timer1
            // 
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.LightGray;
            this.ClientSize = new System.Drawing.Size(1193, 665);
            this.Controls.Add(this.StatuslistBox);
            this.Controls.Add(this.OverviewlistBox);
            this.Controls.Add(this.editpanel);
            this.Controls.Add(this.controlpanel);
            this.Controls.Add(this.workpanel);
            this.Controls.Add(this.gridpanel);
            this.Controls.Add(this.crossingpanel);
            this.Controls.Add(this.menuStrip1);
            this.Font = new System.Drawing.Font("Comic Sans MS", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MainMenuStrip = this.menuStrip1;
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.MaximumSize = new System.Drawing.Size(1211, 712);
            this.MinimumSize = new System.Drawing.Size(1211, 712);
            this.Name = "Form1";
            this.Text = "Traffic Simulator";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.crossingpanel.ResumeLayout(false);
            this.crossingpanel.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.PBtype2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.PBtype1)).EndInit();
            this.gridpanel.ResumeLayout(false);
            this.gridpanel.PerformLayout();
            this.controlpanel.ResumeLayout(false);
            this.controlpanel.PerformLayout();
            this.editpanel.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem openToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem saveToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem saveAsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem exitToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem helpToolStripMenuItem;
        private System.Windows.Forms.Panel crossingpanel;
        private System.Windows.Forms.Panel gridpanel;
        private System.Windows.Forms.PictureBox PBtype2;
        private System.Windows.Forms.PictureBox PBtype1;
        private System.Windows.Forms.Label crossinglabel;
        private System.Windows.Forms.Button gridbutton;
        private System.Windows.Forms.ComboBox gridcomboBox;
        private System.Windows.Forms.Label gridlabel;
        private System.Windows.Forms.Panel controlpanel;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox tbname;
        private System.Windows.Forms.Label timelabel;
        private System.Windows.Forms.Label namelabel;
        private System.Windows.Forms.Label workspacelabel;
        private System.Windows.Forms.Button stopbutton;
        private System.Windows.Forms.Button pausebutton;
        private System.Windows.Forms.Button playbutton;
        private System.Windows.Forms.Panel editpanel;
        private System.Windows.Forms.Button buttonclear;
        private System.Windows.Forms.Button buttonremove;
        private System.Windows.Forms.Button setbutton;
        private System.Windows.Forms.Button editbutton;
        private System.Windows.Forms.ListBox OverviewlistBox;
        private System.Windows.Forms.ListBox StatuslistBox;
        private System.Windows.Forms.ToolStripMenuItem newToolStripMenuItem;
        private System.Windows.Forms.DateTimePicker dateTimePicker1;
        public System.Windows.Forms.Panel workpanel;
        private System.Windows.Forms.Timer timer1;
    }
}

