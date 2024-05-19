namespace PresentationLayer
{
    partial class frmMain
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmMain));
            grass = new PictureBox();
            duck1 = new PictureBox();
            dog = new PictureBox();
            duck2 = new PictureBox();
            toolStrip1 = new ToolStrip();
            scoreDisplay = new ToolStripLabel();
            ((System.ComponentModel.ISupportInitialize)grass).BeginInit();
            ((System.ComponentModel.ISupportInitialize)duck1).BeginInit();
            ((System.ComponentModel.ISupportInitialize)dog).BeginInit();
            ((System.ComponentModel.ISupportInitialize)duck2).BeginInit();
            toolStrip1.SuspendLayout();
            SuspendLayout();
            // 
            // grass
            // 
            grass.BackColor = Color.Transparent;
            grass.BackgroundImageLayout = ImageLayout.None;
            grass.Image = Properties.Resources.grass;
            grass.Location = new Point(0, 303);
            grass.Name = "grass";
            grass.Size = new Size(524, 176);
            grass.SizeMode = PictureBoxSizeMode.StretchImage;
            grass.TabIndex = 0;
            grass.TabStop = false;
            // 
            // duck1
            // 
            duck1.BackColor = Color.Transparent;
            duck1.Image = Properties.Resources.up1;
            duck1.Location = new Point(246, 337);
            duck1.Name = "duck1";
            duck1.Size = new Size(30, 30);
            duck1.SizeMode = PictureBoxSizeMode.StretchImage;
            duck1.TabIndex = 1;
            duck1.TabStop = false;
            duck1.Click += duck1_Click;
            // 
            // dog
            // 
            dog.BackColor = Color.Transparent;
            dog.Image = Properties.Resources.laugh;
            dog.Location = new Point(233, 328);
            dog.Name = "dog";
            dog.Size = new Size(92, 112);
            dog.SizeMode = PictureBoxSizeMode.StretchImage;
            dog.TabIndex = 2;
            dog.TabStop = false;
            // 
            // duck2
            // 
            duck2.BackColor = Color.Transparent;
            duck2.Image = Properties.Resources.up1;
            duck2.Location = new Point(282, 339);
            duck2.Name = "duck2";
            duck2.Size = new Size(30, 30);
            duck2.SizeMode = PictureBoxSizeMode.StretchImage;
            duck2.TabIndex = 5;
            duck2.TabStop = false;
            duck2.Click += duck2_Click;
            // 
            // toolStrip1
            // 
            toolStrip1.Dock = DockStyle.Bottom;
            toolStrip1.Items.AddRange(new ToolStripItem[] { scoreDisplay });
            toolStrip1.Location = new Point(0, 454);
            toolStrip1.Name = "toolStrip1";
            toolStrip1.Size = new Size(520, 25);
            toolStrip1.TabIndex = 6;
            toolStrip1.Text = "toolStrip1";
            // 
            // scoreDisplay
            // 
            scoreDisplay.Font = new Font("Ringbearer", 9F, FontStyle.Bold, GraphicsUnit.Point);
            scoreDisplay.Name = "scoreDisplay";
            scoreDisplay.Size = new Size(65, 22);
            scoreDisplay.Text = "Score: 0";
            // 
            // frmMain
            // 
            AutoScaleDimensions = new SizeF(96F, 96F);
            AutoScaleMode = AutoScaleMode.Dpi;
            AutoSizeMode = AutoSizeMode.GrowAndShrink;
            BackgroundImage = Properties.Resources.back;
            BackgroundImageLayout = ImageLayout.Stretch;
            ClientSize = new Size(520, 479);
            Controls.Add(toolStrip1);
            Controls.Add(grass);
            Controls.Add(duck1);
            Controls.Add(duck2);
            Controls.Add(dog);
            Cursor = Cursors.Cross;
            DoubleBuffered = true;
            Font = new Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            Icon = (Icon)resources.GetObject("$this.Icon");
            MaximizeBox = false;
            Name = "frmMain";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Duck Hunt";
            TopMost = true;
            Load += frmMain_Load;
            ((System.ComponentModel.ISupportInitialize)grass).EndInit();
            ((System.ComponentModel.ISupportInitialize)duck1).EndInit();
            ((System.ComponentModel.ISupportInitialize)dog).EndInit();
            ((System.ComponentModel.ISupportInitialize)duck2).EndInit();
            toolStrip1.ResumeLayout(false);
            toolStrip1.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private PictureBox grass;
        private PictureBox duck1;
        private PictureBox dog;
        private PictureBox duck2;
        private ToolStrip toolStrip1;
        private ToolStripLabel scoreDisplay;
    }
}