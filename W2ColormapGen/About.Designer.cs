namespace W2ColormapGen
{
    partial class About
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(About));
            pictureBox1 = new PictureBox();
            label1 = new Label();
            label2 = new Label();
            verLabel = new Label();
            label4 = new Label();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            SuspendLayout();
            // 
            // pictureBox1
            // 
            pictureBox1.BorderStyle = BorderStyle.FixedSingle;
            pictureBox1.Image = Properties.Resources.W2ColormapGen;
            pictureBox1.Location = new Point(12, 9);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(64, 64);
            pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;
            pictureBox1.TabIndex = 0;
            pictureBox1.TabStop = false;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.BackColor = Color.Transparent;
            label1.Font = new Font("Microsoft Sans Serif", 26.25F);
            label1.Location = new Point(82, 9);
            label1.Name = "label1";
            label1.Size = new Size(285, 39);
            label1.TabIndex = 1;
            label1.Text = "W2ColormapGen";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.BackColor = Color.Transparent;
            label2.Font = new Font("Microsoft Sans Serif", 12F);
            label2.Location = new Point(85, 48);
            label2.Name = "label2";
            label2.Size = new Size(225, 20);
            label2.TabIndex = 2;
            label2.Text = "Worms 2 Color Map Generator";
            // 
            // verLabel
            // 
            verLabel.BackColor = Color.Transparent;
            verLabel.Font = new Font("Microsoft Sans Serif", 9.75F);
            verLabel.Location = new Point(12, 87);
            verLabel.Name = "verLabel";
            verLabel.Size = new Size(346, 20);
            verLabel.TabIndex = 3;
            verLabel.Text = "Version";
            verLabel.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.BackColor = Color.Transparent;
            label4.Font = new Font("Microsoft Sans Serif", 12F);
            label4.Location = new Point(232, 117);
            label4.Name = "label4";
            label4.Size = new Size(126, 20);
            label4.TabIndex = 4;
            label4.Text = "Made by Dawid8";
            // 
            // About
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackgroundImageLayout = ImageLayout.Stretch;
            ClientSize = new Size(370, 146);
            Controls.Add(label4);
            Controls.Add(verLabel);
            Controls.Add(label2);
            Controls.Add(label1);
            Controls.Add(pictureBox1);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            Icon = (Icon)resources.GetObject("$this.Icon");
            MaximizeBox = false;
            Name = "About";
            StartPosition = FormStartPosition.CenterParent;
            Text = "W2ColormapGen - About";
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private PictureBox pictureBox1;
        private Label label1;
        private Label label2;
        private Label verLabel;
        private Label label4;
    }
}