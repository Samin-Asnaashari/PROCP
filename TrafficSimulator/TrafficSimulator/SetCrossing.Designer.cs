namespace TrafficSimulator
{
    partial class SetCrossing
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(SetCrossing));
            this.label1 = new System.Windows.Forms.Label();
            this.lightlistBox1 = new System.Windows.Forms.ListBox();
            this.createbutton = new System.Windows.Forms.Button();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.axWindowsMediaPlayer1 = new AxWMPLib.AxWindowsMediaPlayer();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.textBox2 = new System.Windows.Forms.TextBox();
            this.textBox3 = new System.Windows.Forms.TextBox();
            this.textBox4 = new System.Windows.Forms.TextBox();
            this.textBox5 = new System.Windows.Forms.TextBox();
            this.lightlistBox2 = new System.Windows.Forms.ListBox();
            this.textBox6 = new System.Windows.Forms.TextBox();
            this.textBox7 = new System.Windows.Forms.TextBox();
            this.textBox8 = new System.Windows.Forms.TextBox();
            this.textBox9 = new System.Windows.Forms.TextBox();
            this.textBox10 = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.axWindowsMediaPlayer1)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Comic Sans MS", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(15, 220);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(218, 29);
            this.label1.TabIndex = 3;
            this.label1.Text = "Green Lights Timing:";
            // 
            // lightlistBox1
            // 
            this.lightlistBox1.BackColor = System.Drawing.Color.Gainsboro;
            this.lightlistBox1.FormattingEnabled = true;
            this.lightlistBox1.ItemHeight = 20;
            this.lightlistBox1.Items.AddRange(new object[] {
            "LightsNumber:",
            "",
            "Lights 1 , 2 , 3:",
            "",
            "Lights 3 ,4, 5:",
            "",
            "Lights 5 ,6 ,7:",
            "",
            "Lights 1 ,3 ,5 ,7:",
            "",
            "Lights 1, 7, 8:"});
            this.lightlistBox1.Location = new System.Drawing.Point(12, 261);
            this.lightlistBox1.Name = "lightlistBox1";
            this.lightlistBox1.Size = new System.Drawing.Size(251, 244);
            this.lightlistBox1.TabIndex = 4;
            // 
            // createbutton
            // 
            this.createbutton.BackColor = System.Drawing.Color.LightSlateGray;
            this.createbutton.Font = new System.Drawing.Font("Comic Sans MS", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.createbutton.Location = new System.Drawing.Point(424, 502);
            this.createbutton.MaximumSize = new System.Drawing.Size(119, 60);
            this.createbutton.MinimumSize = new System.Drawing.Size(119, 60);
            this.createbutton.Name = "createbutton";
            this.createbutton.Size = new System.Drawing.Size(119, 60);
            this.createbutton.TabIndex = 5;
            this.createbutton.Text = "Create";
            this.createbutton.UseVisualStyleBackColor = false;
            this.createbutton.Click += new System.EventHandler(this.createbutton_Click);
            // 
            // timer1
            // 
            this.timer1.Enabled = true;
            this.timer1.Interval = 110;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackColor = System.Drawing.Color.SlateGray;
            this.pictureBox1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.pictureBox1.Location = new System.Drawing.Point(20, 12);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(201, 194);
            this.pictureBox1.TabIndex = 1;
            this.pictureBox1.TabStop = false;
            // 
            // axWindowsMediaPlayer1
            // 
            this.axWindowsMediaPlayer1.Enabled = true;
            this.axWindowsMediaPlayer1.Location = new System.Drawing.Point(329, 12);
            this.axWindowsMediaPlayer1.Name = "axWindowsMediaPlayer1";
            this.axWindowsMediaPlayer1.OcxState = ((System.Windows.Forms.AxHost.State)(resources.GetObject("axWindowsMediaPlayer1.OcxState")));
            this.axWindowsMediaPlayer1.Size = new System.Drawing.Size(205, 194);
            this.axWindowsMediaPlayer1.TabIndex = 0;
            // 
            // textBox1
            // 
            this.textBox1.BackColor = System.Drawing.Color.LightGray;
            this.textBox1.Location = new System.Drawing.Point(133, 293);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(46, 28);
            this.textBox1.TabIndex = 6;
            this.textBox1.Text = "10";
            // 
            // textBox2
            // 
            this.textBox2.BackColor = System.Drawing.Color.LightGray;
            this.textBox2.Location = new System.Drawing.Point(133, 336);
            this.textBox2.Name = "textBox2";
            this.textBox2.Size = new System.Drawing.Size(46, 28);
            this.textBox2.TabIndex = 6;
            this.textBox2.Text = "10";
            // 
            // textBox3
            // 
            this.textBox3.BackColor = System.Drawing.Color.LightGray;
            this.textBox3.Location = new System.Drawing.Point(133, 370);
            this.textBox3.Name = "textBox3";
            this.textBox3.Size = new System.Drawing.Size(46, 28);
            this.textBox3.TabIndex = 6;
            this.textBox3.Text = "10";
            // 
            // textBox4
            // 
            this.textBox4.BackColor = System.Drawing.Color.LightGray;
            this.textBox4.Location = new System.Drawing.Point(133, 417);
            this.textBox4.Name = "textBox4";
            this.textBox4.Size = new System.Drawing.Size(46, 28);
            this.textBox4.TabIndex = 6;
            this.textBox4.Text = "10";
            // 
            // textBox5
            // 
            this.textBox5.BackColor = System.Drawing.Color.LightGray;
            this.textBox5.Location = new System.Drawing.Point(133, 460);
            this.textBox5.Name = "textBox5";
            this.textBox5.Size = new System.Drawing.Size(46, 28);
            this.textBox5.TabIndex = 6;
            this.textBox5.Text = "10";
            // 
            // lightlistBox2
            // 
            this.lightlistBox2.BackColor = System.Drawing.Color.Gainsboro;
            this.lightlistBox2.FormattingEnabled = true;
            this.lightlistBox2.ItemHeight = 20;
            this.lightlistBox2.Items.AddRange(new object[] {
            "LightsNumber:",
            "",
            "Light 2:\t\t          Lights 1 ,7:  ",
            "",
            "Light 6:                           Lights 7 ,3:",
            "",
            "Lights 3 ,4:                      Lights 7 ,8:",
            "",
            "Lights 1 ,4:                      Lights 8 ,4:  ",
            "",
            "Lights 3 ,5                       Lights 8 ,5:  "});
            this.lightlistBox2.Location = new System.Drawing.Point(45, 261);
            this.lightlistBox2.Name = "lightlistBox2";
            this.lightlistBox2.Size = new System.Drawing.Size(337, 244);
            this.lightlistBox2.TabIndex = 4;
            // 
            // textBox6
            // 
            this.textBox6.BackColor = System.Drawing.Color.LightGray;
            this.textBox6.Location = new System.Drawing.Point(307, 293);
            this.textBox6.Name = "textBox6";
            this.textBox6.Size = new System.Drawing.Size(46, 28);
            this.textBox6.TabIndex = 6;
            this.textBox6.Text = "10";
            // 
            // textBox7
            // 
            this.textBox7.BackColor = System.Drawing.Color.LightGray;
            this.textBox7.Location = new System.Drawing.Point(307, 336);
            this.textBox7.Name = "textBox7";
            this.textBox7.Size = new System.Drawing.Size(46, 28);
            this.textBox7.TabIndex = 6;
            this.textBox7.Text = "10";
            // 
            // textBox8
            // 
            this.textBox8.BackColor = System.Drawing.Color.LightGray;
            this.textBox8.Location = new System.Drawing.Point(307, 370);
            this.textBox8.Name = "textBox8";
            this.textBox8.Size = new System.Drawing.Size(46, 28);
            this.textBox8.TabIndex = 6;
            this.textBox8.Text = "10";
            // 
            // textBox9
            // 
            this.textBox9.BackColor = System.Drawing.Color.LightGray;
            this.textBox9.Location = new System.Drawing.Point(307, 417);
            this.textBox9.Name = "textBox9";
            this.textBox9.Size = new System.Drawing.Size(46, 28);
            this.textBox9.TabIndex = 6;
            this.textBox9.Text = "10";
            // 
            // textBox10
            // 
            this.textBox10.BackColor = System.Drawing.Color.LightGray;
            this.textBox10.Location = new System.Drawing.Point(307, 460);
            this.textBox10.Name = "textBox10";
            this.textBox10.Size = new System.Drawing.Size(46, 28);
            this.textBox10.TabIndex = 6;
            this.textBox10.Text = "10";
            // 
            // SetCrossing
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.CadetBlue;
            this.ClientSize = new System.Drawing.Size(555, 574);
            this.Controls.Add(this.textBox10);
            this.Controls.Add(this.textBox9);
            this.Controls.Add(this.textBox5);
            this.Controls.Add(this.textBox8);
            this.Controls.Add(this.textBox4);
            this.Controls.Add(this.textBox7);
            this.Controls.Add(this.textBox3);
            this.Controls.Add(this.textBox6);
            this.Controls.Add(this.textBox2);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.createbutton);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.axWindowsMediaPlayer1);
            this.Controls.Add(this.lightlistBox2);
            this.Controls.Add(this.lightlistBox1);
            this.Font = new System.Drawing.Font("Comic Sans MS", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.MaximumSize = new System.Drawing.Size(573, 621);
            this.MinimumSize = new System.Drawing.Size(573, 621);
            this.Name = "SetCrossing";
            this.Text = "Set The Crossing:";
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.axWindowsMediaPlayer1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private AxWMPLib.AxWindowsMediaPlayer axWindowsMediaPlayer1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button createbutton;
        public System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.TextBox textBox2;
        private System.Windows.Forms.TextBox textBox3;
        private System.Windows.Forms.TextBox textBox4;
        private System.Windows.Forms.TextBox textBox5;
        public System.Windows.Forms.TextBox textBox6;
        public System.Windows.Forms.TextBox textBox7;
        public System.Windows.Forms.TextBox textBox8;
        public System.Windows.Forms.TextBox textBox9;
        public System.Windows.Forms.TextBox textBox10;
        public System.Windows.Forms.ListBox lightlistBox1;
        public System.Windows.Forms.ListBox lightlistBox2;
    }
}