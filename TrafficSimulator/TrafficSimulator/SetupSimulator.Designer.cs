namespace TrafficSimulator
{
    partial class SetupSimulator
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(SetupSimulator));
            this.setbutton = new System.Windows.Forms.Button();
            this.sidelistBox = new System.Windows.Forms.ListBox();
            this.textBoxNorth = new System.Windows.Forms.TextBox();
            this.textBoxEast = new System.Windows.Forms.TextBox();
            this.textBoxWest = new System.Windows.Forms.TextBox();
            this.textBoxSouth = new System.Windows.Forms.TextBox();
            this.labelTotal = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // setbutton
            // 
            this.setbutton.BackColor = System.Drawing.Color.CadetBlue;
            this.setbutton.Font = new System.Drawing.Font("Comic Sans MS", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.setbutton.Location = new System.Drawing.Point(318, 244);
            this.setbutton.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.setbutton.Name = "setbutton";
            this.setbutton.Size = new System.Drawing.Size(90, 68);
            this.setbutton.TabIndex = 0;
            this.setbutton.Text = "Set";
            this.setbutton.UseVisualStyleBackColor = false;
            this.setbutton.Click += new System.EventHandler(this.setbutton_Click);
            // 
            // sidelistBox
            // 
            this.sidelistBox.BackColor = System.Drawing.Color.CadetBlue;
            this.sidelistBox.Font = new System.Drawing.Font("Comic Sans MS", 13.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.sidelistBox.FormattingEnabled = true;
            this.sidelistBox.ItemHeight = 30;
            this.sidelistBox.Items.AddRange(new object[] {
            "",
            "",
            "  North:\t\t        %",
            "",
            "  East:\t\t        %",
            "",
            "  West:\t\t        %",
            "",
            "  South:\t\t        %",
            "",
            "  Total:\t\t        %"});
            this.sidelistBox.Location = new System.Drawing.Point(19, 20);
            this.sidelistBox.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.sidelistBox.Name = "sidelistBox";
<<<<<<< HEAD
            this.sidelistBox.Size = new System.Drawing.Size(278, 244);
=======
            this.sidelistBox.Size = new System.Drawing.Size(278, 292);
>>>>>>> origin/master
            this.sidelistBox.TabIndex = 1;
            // 
            // textBoxNorth
            // 
            this.textBoxNorth.BackColor = System.Drawing.Color.Silver;
            this.textBoxNorth.Location = new System.Drawing.Point(126, 71);
            this.textBoxNorth.Name = "textBoxNorth";
            this.textBoxNorth.Size = new System.Drawing.Size(100, 28);
            this.textBoxNorth.TabIndex = 2;
            this.textBoxNorth.Text = "25";
            this.textBoxNorth.TextChanged += new System.EventHandler(this.textBoxNorth_TextChanged);
            // 
            // textBoxEast
            // 
            this.textBoxEast.BackColor = System.Drawing.Color.Silver;
            this.textBoxEast.Location = new System.Drawing.Point(126, 119);
            this.textBoxEast.Name = "textBoxEast";
            this.textBoxEast.Size = new System.Drawing.Size(100, 28);
            this.textBoxEast.TabIndex = 2;
            this.textBoxEast.Text = "25";
            this.textBoxEast.TextChanged += new System.EventHandler(this.textBoxEast_TextChanged);
            // 
            // textBoxWest
            // 
            this.textBoxWest.BackColor = System.Drawing.Color.Silver;
            this.textBoxWest.Location = new System.Drawing.Point(126, 167);
            this.textBoxWest.Name = "textBoxWest";
            this.textBoxWest.Size = new System.Drawing.Size(100, 28);
            this.textBoxWest.TabIndex = 2;
            this.textBoxWest.Text = "25";
            this.textBoxWest.TextChanged += new System.EventHandler(this.textBoxWest_TextChanged);
            // 
            // textBoxSouth
            // 
            this.textBoxSouth.BackColor = System.Drawing.Color.Silver;
            this.textBoxSouth.Location = new System.Drawing.Point(126, 214);
            this.textBoxSouth.Name = "textBoxSouth";
            this.textBoxSouth.Size = new System.Drawing.Size(100, 28);
            this.textBoxSouth.TabIndex = 2;
            this.textBoxSouth.Text = "25";
            this.textBoxSouth.TextChanged += new System.EventHandler(this.textBoxSouth_TextChanged);
            // 
            // labelTotal
            // 
            this.labelTotal.AutoSize = true;
            this.labelTotal.BackColor = System.Drawing.Color.Transparent;
            this.labelTotal.Font = new System.Drawing.Font("Comic Sans MS", 13.2F);
            this.labelTotal.Location = new System.Drawing.Point(186, 261);
            this.labelTotal.Name = "labelTotal";
            this.labelTotal.Size = new System.Drawing.Size(40, 24);
            this.labelTotal.TabIndex = 3;
            this.labelTotal.Text = "100";
            // 
            // SetupSimulator
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Silver;
            this.ClientSize = new System.Drawing.Size(430, 328);
            this.Controls.Add(this.labelTotal);
            this.Controls.Add(this.textBoxSouth);
            this.Controls.Add(this.textBoxWest);
            this.Controls.Add(this.textBoxEast);
            this.Controls.Add(this.textBoxNorth);
            this.Controls.Add(this.sidelistBox);
            this.Controls.Add(this.setbutton);
            this.Font = new System.Drawing.Font("Comic Sans MS", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "SetupSimulator";
            this.Text = "SetupSimulator";
            this.Click += new System.EventHandler(this.setbutton_Click);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button setbutton;
        private System.Windows.Forms.ListBox sidelistBox;
        private System.Windows.Forms.TextBox textBoxNorth;
        private System.Windows.Forms.TextBox textBoxEast;
        private System.Windows.Forms.TextBox textBoxWest;
        private System.Windows.Forms.TextBox textBoxSouth;
        private System.Windows.Forms.Label labelTotal;
    }
}