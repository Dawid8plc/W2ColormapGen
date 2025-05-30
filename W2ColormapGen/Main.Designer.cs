using W2ColormapGen.UI;

namespace W2ColormapGen
{
    partial class Main
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Main));
            OFD = new OpenFileDialog();
            dGroupBox1 = new DGroupBox();
            label6 = new Label();
            label4 = new Label();
            applyBtn = new FrontendButton();
            terrainThemeBox = new FrontendComboBox();
            gradientPreview = new PictureBoxWithInterpolationMode();
            aboutBtn = new FrontendButton();
            dGroupBox2 = new DGroupBox();
            editBtn = new FrontendButton();
            label5 = new Label();
            label3 = new Label();
            terrainWaterBox = new FrontendComboBox();
            label2 = new Label();
            label1 = new Label();
            pathBox = new TextBox();
            saveBtn = new FrontendButton();
            nameBox = new TextBox();
            browseBtn = new FrontendButton();
            mapPreview = new PictureBoxWithInterpolationMode();
            discordBtn = new FrontendButton();
            CTerrainBtn = new FrontendButton();
            dGroupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)gradientPreview).BeginInit();
            dGroupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)mapPreview).BeginInit();
            SuspendLayout();
            // 
            // OFD
            // 
            OFD.Filter = "8bpp Bitmap images|*.bmp|Color map files|*.dat";
            // 
            // dGroupBox1
            // 
            dGroupBox1.BackColor = Color.Transparent;
            dGroupBox1.Controls.Add(label6);
            dGroupBox1.Controls.Add(label4);
            dGroupBox1.Controls.Add(applyBtn);
            dGroupBox1.Controls.Add(terrainThemeBox);
            dGroupBox1.Controls.Add(gradientPreview);
            dGroupBox1.Location = new Point(12, 335);
            dGroupBox1.Name = "dGroupBox1";
            dGroupBox1.Size = new Size(622, 236);
            dGroupBox1.TabIndex = 2;
            dGroupBox1.TabStop = false;
            dGroupBox1.Text = "Sky Gradient Theme";
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Location = new Point(59, 165);
            label6.Name = "label6";
            label6.Size = new Size(79, 15);
            label6.TabIndex = 6;
            label6.Text = "Terrain theme";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(81, 194);
            label4.Name = "label4";
            label4.Size = new Size(468, 30);
            label4.TabIndex = 5;
            label4.Text = "You can change the locally used sky gradient when playing on custom color maps here.\r\nOnly affects color maps generated using W2ColormapGen.";
            label4.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // applyBtn
            // 
            applyBtn.Location = new Point(488, 162);
            applyBtn.Name = "applyBtn";
            applyBtn.Size = new Size(75, 23);
            applyBtn.Sound = Managers.FrontendSounds.Click;
            applyBtn.TabIndex = 4;
            applyBtn.Text = "Apply";
            applyBtn.UseVisualStyleBackColor = true;
            applyBtn.Click += applyBtn_Click;
            // 
            // terrainThemeBox
            // 
            terrainThemeBox.DropDownStyle = ComboBoxStyle.DropDownList;
            terrainThemeBox.FormattingEnabled = true;
            terrainThemeBox.Location = new Point(144, 162);
            terrainThemeBox.Name = "terrainThemeBox";
            terrainThemeBox.Size = new Size(338, 23);
            terrainThemeBox.Sound = Managers.FrontendSounds.Impact;
            terrainThemeBox.TabIndex = 2;
            terrainThemeBox.SelectedIndexChanged += terrainThemeBox_SelectedIndexChanged;
            // 
            // gradientPreview
            // 
            gradientPreview.BorderStyle = BorderStyle.Fixed3D;
            gradientPreview.InterpolationMode = System.Drawing.Drawing2D.InterpolationMode.NearestNeighbor;
            gradientPreview.Location = new Point(144, 22);
            gradientPreview.Name = "gradientPreview";
            gradientPreview.Size = new Size(338, 134);
            gradientPreview.SizeMode = PictureBoxSizeMode.StretchImage;
            gradientPreview.TabIndex = 1;
            gradientPreview.TabStop = false;
            // 
            // aboutBtn
            // 
            aboutBtn.Location = new Point(559, 577);
            aboutBtn.Name = "aboutBtn";
            aboutBtn.Size = new Size(75, 23);
            aboutBtn.Sound = Managers.FrontendSounds.Click;
            aboutBtn.TabIndex = 7;
            aboutBtn.Text = "About";
            aboutBtn.UseVisualStyleBackColor = true;
            aboutBtn.Click += aboutBtn_Click;
            // 
            // dGroupBox2
            // 
            dGroupBox2.BackColor = Color.Transparent;
            dGroupBox2.Controls.Add(editBtn);
            dGroupBox2.Controls.Add(label5);
            dGroupBox2.Controls.Add(label3);
            dGroupBox2.Controls.Add(terrainWaterBox);
            dGroupBox2.Controls.Add(label2);
            dGroupBox2.Controls.Add(label1);
            dGroupBox2.Controls.Add(pathBox);
            dGroupBox2.Controls.Add(saveBtn);
            dGroupBox2.Controls.Add(nameBox);
            dGroupBox2.Controls.Add(browseBtn);
            dGroupBox2.Controls.Add(mapPreview);
            dGroupBox2.Location = new Point(12, 12);
            dGroupBox2.Name = "dGroupBox2";
            dGroupBox2.Size = new Size(622, 317);
            dGroupBox2.TabIndex = 3;
            dGroupBox2.TabStop = false;
            dGroupBox2.Text = "Color Map Generator";
            // 
            // editBtn
            // 
            editBtn.Location = new Point(489, 196);
            editBtn.Name = "editBtn";
            editBtn.Size = new Size(75, 23);
            editBtn.Sound = Managers.FrontendSounds.Click;
            editBtn.TabIndex = 9;
            editBtn.Text = "Edit map";
            editBtn.UseVisualStyleBackColor = true;
            editBtn.Click += editBtn_Click;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(91, 258);
            label5.Name = "label5";
            label5.Size = new Size(438, 45);
            label5.TabIndex = 8;
            label5.Text = resources.GetString("label5.Text");
            label5.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(68, 200);
            label3.Name = "label3";
            label3.Size = new Size(65, 15);
            label3.TabIndex = 7;
            label3.Text = "Water style";
            // 
            // terrainWaterBox
            // 
            terrainWaterBox.DropDownStyle = ComboBoxStyle.DropDownList;
            terrainWaterBox.FormattingEnabled = true;
            terrainWaterBox.Location = new Point(145, 197);
            terrainWaterBox.Name = "terrainWaterBox";
            terrainWaterBox.Size = new Size(339, 23);
            terrainWaterBox.Sound = Managers.FrontendSounds.Impact;
            terrainWaterBox.TabIndex = 6;
            terrainWaterBox.SelectedIndexChanged += terrainWaterBox_SelectedIndexChanged;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(69, 229);
            label2.Name = "label2";
            label2.Size = new Size(64, 15);
            label2.TabIndex = 5;
            label2.Text = "Map name";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(65, 169);
            label1.Name = "label1";
            label1.Size = new Size(67, 15);
            label1.TabIndex = 4;
            label1.Text = "Map image";
            // 
            // pathBox
            // 
            pathBox.Location = new Point(145, 167);
            pathBox.Name = "pathBox";
            pathBox.ReadOnly = true;
            pathBox.Size = new Size(338, 23);
            pathBox.TabIndex = 0;
            // 
            // saveBtn
            // 
            saveBtn.Location = new Point(490, 226);
            saveBtn.Name = "saveBtn";
            saveBtn.Size = new Size(75, 23);
            saveBtn.Sound = Managers.FrontendSounds.Click;
            saveBtn.TabIndex = 3;
            saveBtn.Text = "Save";
            saveBtn.UseVisualStyleBackColor = true;
            saveBtn.Click += saveBtn_Click;
            // 
            // nameBox
            // 
            nameBox.Location = new Point(145, 226);
            nameBox.Name = "nameBox";
            nameBox.Size = new Size(339, 23);
            nameBox.TabIndex = 2;
            // 
            // browseBtn
            // 
            browseBtn.Location = new Point(489, 166);
            browseBtn.Name = "browseBtn";
            browseBtn.Size = new Size(75, 23);
            browseBtn.Sound = Managers.FrontendSounds.Click;
            browseBtn.TabIndex = 1;
            browseBtn.Text = "Browse";
            browseBtn.UseVisualStyleBackColor = true;
            browseBtn.Click += browseBtn_Click;
            // 
            // mapPreview
            // 
            mapPreview.BackColor = Color.Black;
            mapPreview.BorderStyle = BorderStyle.Fixed3D;
            mapPreview.InterpolationMode = System.Drawing.Drawing2D.InterpolationMode.NearestNeighbor;
            mapPreview.Location = new Point(144, 22);
            mapPreview.Name = "mapPreview";
            mapPreview.Size = new Size(338, 134);
            mapPreview.SizeMode = PictureBoxSizeMode.StretchImage;
            mapPreview.TabIndex = 0;
            mapPreview.TabStop = false;
            // 
            // discordBtn
            // 
            discordBtn.Location = new Point(478, 577);
            discordBtn.Name = "discordBtn";
            discordBtn.Size = new Size(75, 23);
            discordBtn.Sound = Managers.FrontendSounds.Click;
            discordBtn.TabIndex = 8;
            discordBtn.Text = "Discord";
            discordBtn.UseVisualStyleBackColor = true;
            discordBtn.Click += discordBtn_Click;
            // 
            // CTerrainBtn
            // 
            CTerrainBtn.Location = new Point(397, 577);
            CTerrainBtn.Name = "CTerrainBtn";
            CTerrainBtn.Size = new Size(75, 23);
            CTerrainBtn.Sound = Managers.FrontendSounds.Click;
            CTerrainBtn.TabIndex = 9;
            CTerrainBtn.Text = "CTerrain";
            CTerrainBtn.UseVisualStyleBackColor = true;
            CTerrainBtn.Click += CTerrainBtn_Click;
            // 
            // Main
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackgroundImageLayout = ImageLayout.Stretch;
            ClientSize = new Size(642, 611);
            Controls.Add(CTerrainBtn);
            Controls.Add(discordBtn);
            Controls.Add(aboutBtn);
            Controls.Add(dGroupBox2);
            Controls.Add(dGroupBox1);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            Icon = (Icon)resources.GetObject("$this.Icon");
            MaximizeBox = false;
            Name = "Main";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "W2ColormapGen";
            FormClosed += Main_FormClosed;
            dGroupBox1.ResumeLayout(false);
            dGroupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)gradientPreview).EndInit();
            dGroupBox2.ResumeLayout(false);
            dGroupBox2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)mapPreview).EndInit();
            ResumeLayout(false);
        }

        #endregion
        private OpenFileDialog OFD;
        private DGroupBox dGroupBox1;
        private DGroupBox dGroupBox2;
        private PictureBoxWithInterpolationMode mapPreview;
        private TextBox pathBox;
        private TextBox nameBox;
        private FrontendButton browseBtn;
        private FrontendButton saveBtn;
        private FrontendComboBox terrainThemeBox;
        private PictureBoxWithInterpolationMode gradientPreview;
        private Label label2;
        private Label label1;
        private FrontendButton applyBtn;
        private FrontendComboBox terrainWaterBox;
        private Label label3;
        private Label label4;
        private Label label5;
        private FrontendButton editBtn;
        private Label label6;
        private FrontendButton aboutBtn;
        private FrontendButton discordBtn;
        private FrontendButton CTerrainBtn;
    }
}
