
using W2ColormapGen.UI;

namespace W2ColormapGen
{
    partial class PreviewTerrain
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(PreviewTerrain));
            terrainSettingsGroup = new GroupBox();
            useSeedBox = new FrontendCheckBox();
            seedBox = new TextBox();
            invisibleTerrainBox = new FrontendCheckBox();
            positionIdsBox = new FrontendCheckBox();
            styleBox = new FrontendComboBox();
            label1 = new Label();
            closeBtn = new FrontendButton();
            generateBtn = new FrontendButton();
            waterBox = new FrontendComboBox();
            label2 = new Label();
            groupBox2 = new GroupBox();
            overviewBox = new MinimapPictureBox();
            backPanel = new Panel();
            previewBox = new PictureBox();
            groupBox1 = new GroupBox();
            mgCountLbl = new Label();
            bgCountLbl = new Label();
            fgCountLbl = new Label();
            showBackgroundBox = new FrontendCheckBox();
            showForegroundBox = new FrontendCheckBox();
            terrainSettingsGroup.SuspendLayout();
            groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)overviewBox).BeginInit();
            backPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)previewBox).BeginInit();
            groupBox1.SuspendLayout();
            SuspendLayout();
            // 
            // terrainSettingsGroup
            // 
            terrainSettingsGroup.Controls.Add(useSeedBox);
            terrainSettingsGroup.Controls.Add(seedBox);
            terrainSettingsGroup.Controls.Add(invisibleTerrainBox);
            terrainSettingsGroup.Controls.Add(positionIdsBox);
            terrainSettingsGroup.Controls.Add(styleBox);
            terrainSettingsGroup.Controls.Add(label1);
            terrainSettingsGroup.Controls.Add(closeBtn);
            terrainSettingsGroup.Controls.Add(generateBtn);
            terrainSettingsGroup.Controls.Add(waterBox);
            terrainSettingsGroup.Controls.Add(label2);
            terrainSettingsGroup.Location = new Point(12, 12);
            terrainSettingsGroup.Name = "terrainSettingsGroup";
            terrainSettingsGroup.Size = new Size(312, 147);
            terrainSettingsGroup.TabIndex = 0;
            terrainSettingsGroup.TabStop = false;
            terrainSettingsGroup.Text = "Map settings";
            // 
            // useSeedBox
            // 
            useSeedBox.AutoSize = true;
            useSeedBox.Location = new Point(21, 66);
            useSeedBox.Name = "useSeedBox";
            useSeedBox.Size = new Size(115, 19);
            useSeedBox.Sound = Managers.FrontendSounds.Impact;
            useSeedBox.TabIndex = 12;
            useSeedBox.Text = "Use custom seed";
            useSeedBox.UseVisualStyleBackColor = true;
            useSeedBox.CheckedChanged += useSeedBox_CheckedChanged;
            useSeedBox.MouseEnter += useSeedBox_MouseEnter;
            useSeedBox.MouseLeave += useSeedBox_MouseLeave;
            // 
            // seedBox
            // 
            seedBox.Enabled = false;
            seedBox.Location = new Point(6, 86);
            seedBox.Name = "seedBox";
            seedBox.Size = new Size(141, 23);
            seedBox.TabIndex = 11;
            seedBox.TextChanged += seedBox_TextChanged;
            seedBox.MouseEnter += seedBox_MouseEnter;
            seedBox.MouseLeave += seedBox_MouseLeave;
            // 
            // invisibleTerrainBox
            // 
            invisibleTerrainBox.AutoSize = true;
            invisibleTerrainBox.Location = new Point(154, 66);
            invisibleTerrainBox.Name = "invisibleTerrainBox";
            invisibleTerrainBox.Size = new Size(149, 19);
            invisibleTerrainBox.Sound = Managers.FrontendSounds.Impact;
            invisibleTerrainBox.TabIndex = 10;
            invisibleTerrainBox.Text = "Invisible terrain on save";
            invisibleTerrainBox.UseVisualStyleBackColor = true;
            invisibleTerrainBox.CheckedChanged += invisibleTerrainBox_CheckedChanged;
            invisibleTerrainBox.MouseEnter += invisibleTerrainBox_MouseEnter;
            invisibleTerrainBox.MouseLeave += invisibleTerrainBox_MouseLeave;
            // 
            // positionIdsBox
            // 
            positionIdsBox.AutoSize = true;
            positionIdsBox.Location = new Point(171, 91);
            positionIdsBox.Name = "positionIdsBox";
            positionIdsBox.Size = new Size(120, 19);
            positionIdsBox.Sound = Managers.FrontendSounds.Impact;
            positionIdsBox.TabIndex = 9;
            positionIdsBox.Text = "Show position IDs";
            positionIdsBox.UseVisualStyleBackColor = true;
            positionIdsBox.CheckedChanged += positionIdsBox_CheckedChanged;
            positionIdsBox.MouseEnter += positionIdsBox_MouseEnter;
            positionIdsBox.MouseLeave += positionIdsBox_MouseLeave;
            // 
            // styleBox
            // 
            styleBox.DropDownStyle = ComboBoxStyle.DropDownList;
            styleBox.FormattingEnabled = true;
            styleBox.Items.AddRange(new object[] { "Open", "Cavern" });
            styleBox.Location = new Point(6, 37);
            styleBox.Name = "styleBox";
            styleBox.Size = new Size(141, 23);
            styleBox.Sound = Managers.FrontendSounds.Impact;
            styleBox.TabIndex = 8;
            styleBox.SelectedIndexChanged += styleBox_SelectedIndexChanged;
            styleBox.MouseEnter += styleBox_MouseEnter;
            styleBox.MouseLeave += styleBox_MouseLeave;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(6, 19);
            label1.Name = "label1";
            label1.Size = new Size(64, 15);
            label1.TabIndex = 7;
            label1.Text = "Level style:";
            // 
            // closeBtn
            // 
            closeBtn.Location = new Point(162, 115);
            closeBtn.Name = "closeBtn";
            closeBtn.Size = new Size(141, 23);
            closeBtn.Sound = Managers.FrontendSounds.Click;
            closeBtn.TabIndex = 6;
            closeBtn.Text = "Close";
            closeBtn.UseVisualStyleBackColor = true;
            closeBtn.Click += closeBtn_Click;
            closeBtn.MouseEnter += closeBtn_MouseEnter;
            closeBtn.MouseLeave += ResetText_MouseLeave;
            // 
            // generateBtn
            // 
            generateBtn.Location = new Point(6, 115);
            generateBtn.Name = "generateBtn";
            generateBtn.Size = new Size(141, 23);
            generateBtn.Sound = Managers.FrontendSounds.Click;
            generateBtn.TabIndex = 5;
            generateBtn.Text = "Randomize locations";
            generateBtn.UseVisualStyleBackColor = true;
            generateBtn.Click += generateBtn_Click;
            generateBtn.MouseEnter += generateBtn_MouseEnter;
            generateBtn.MouseLeave += ResetText_MouseLeave;
            // 
            // waterBox
            // 
            waterBox.DropDownStyle = ComboBoxStyle.DropDownList;
            waterBox.FormattingEnabled = true;
            waterBox.Location = new Point(162, 37);
            waterBox.Name = "waterBox";
            waterBox.Size = new Size(141, 23);
            waterBox.Sound = Managers.FrontendSounds.Impact;
            waterBox.TabIndex = 3;
            waterBox.SelectedIndexChanged += terrainBox_SelectedIndexChanged;
            waterBox.MouseEnter += terrainBox_MouseEnter;
            waterBox.MouseLeave += ResetText_MouseLeave;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(162, 19);
            label2.Name = "label2";
            label2.Size = new Size(68, 15);
            label2.TabIndex = 2;
            label2.Text = "Water style:";
            // 
            // groupBox2
            // 
            groupBox2.Controls.Add(overviewBox);
            groupBox2.Location = new Point(504, 12);
            groupBox2.Name = "groupBox2";
            groupBox2.Size = new Size(312, 147);
            groupBox2.TabIndex = 10;
            groupBox2.TabStop = false;
            groupBox2.Text = "Overview";
            // 
            // overviewBox
            // 
            overviewBox.BackColor = Color.Black;
            overviewBox.InterpolationMode = System.Drawing.Drawing2D.InterpolationMode.NearestNeighbor;
            overviewBox.Location = new Point(21, 22);
            overviewBox.Name = "overviewBox";
            overviewBox.ScrollableTarget = backPanel;
            overviewBox.Size = new Size(273, 107);
            overviewBox.SizeMode = PictureBoxSizeMode.StretchImage;
            overviewBox.TabIndex = 0;
            overviewBox.TabStop = false;
            overviewBox.MouseEnter += overviewBox_MouseEnter;
            overviewBox.MouseLeave += ResetText_MouseLeave;
            // 
            // backPanel
            // 
            backPanel.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            backPanel.AutoScroll = true;
            backPanel.BackColor = Color.Black;
            backPanel.Controls.Add(previewBox);
            backPanel.Location = new Point(12, 165);
            backPanel.Name = "backPanel";
            backPanel.Size = new Size(801, 273);
            backPanel.TabIndex = 11;
            backPanel.Scroll += backPanel_Scroll;
            backPanel.MouseDown += backPanel_MouseDown;
            backPanel.MouseEnter += backPanel_MouseEnter;
            backPanel.MouseLeave += ResetText_MouseLeave;
            backPanel.MouseMove += backPanel_MouseMove;
            backPanel.MouseUp += backPanel_MouseUp;
            // 
            // previewBox
            // 
            previewBox.BackColor = Color.Black;
            previewBox.Enabled = false;
            previewBox.Location = new Point(0, 0);
            previewBox.Name = "previewBox";
            previewBox.Size = new Size(1920, 696);
            previewBox.TabIndex = 2;
            previewBox.TabStop = false;
            previewBox.Paint += previewBox_Paint;
            // 
            // groupBox1
            // 
            groupBox1.Controls.Add(mgCountLbl);
            groupBox1.Controls.Add(bgCountLbl);
            groupBox1.Controls.Add(fgCountLbl);
            groupBox1.Controls.Add(showBackgroundBox);
            groupBox1.Controls.Add(showForegroundBox);
            groupBox1.Location = new Point(330, 12);
            groupBox1.Name = "groupBox1";
            groupBox1.Size = new Size(168, 147);
            groupBox1.TabIndex = 12;
            groupBox1.TabStop = false;
            groupBox1.Text = "Layers";
            // 
            // mgCountLbl
            // 
            mgCountLbl.AutoSize = true;
            mgCountLbl.Location = new Point(6, 122);
            mgCountLbl.Name = "mgCountLbl";
            mgCountLbl.Size = new Size(124, 15);
            mgCountLbl.TabIndex = 16;
            mgCountLbl.Text = "Merged color count: 0";
            mgCountLbl.MouseEnter += mgCountLbl_MouseEnter;
            mgCountLbl.MouseLeave += mgCountLbl_MouseLeave;
            // 
            // bgCountLbl
            // 
            bgCountLbl.AutoSize = true;
            bgCountLbl.Location = new Point(6, 100);
            bgCountLbl.Name = "bgCountLbl";
            bgCountLbl.Size = new Size(147, 15);
            bgCountLbl.TabIndex = 15;
            bgCountLbl.Text = "Background color count: 0";
            bgCountLbl.MouseEnter += bgCountLbl_MouseEnter;
            bgCountLbl.MouseLeave += bgCountLbl_MouseLeave;
            // 
            // fgCountLbl
            // 
            fgCountLbl.AutoSize = true;
            fgCountLbl.Location = new Point(6, 78);
            fgCountLbl.Name = "fgCountLbl";
            fgCountLbl.Size = new Size(145, 15);
            fgCountLbl.TabIndex = 14;
            fgCountLbl.Text = "Foreground color count: 0";
            fgCountLbl.MouseEnter += fgCountLbl_MouseEnter;
            fgCountLbl.MouseLeave += fgCountLbl_MouseLeave;
            // 
            // showBackgroundBox
            // 
            showBackgroundBox.AutoSize = true;
            showBackgroundBox.Checked = true;
            showBackgroundBox.CheckState = CheckState.Checked;
            showBackgroundBox.Location = new Point(10, 47);
            showBackgroundBox.Name = "showBackgroundBox";
            showBackgroundBox.Size = new Size(150, 19);
            showBackgroundBox.Sound = Managers.FrontendSounds.Impact;
            showBackgroundBox.TabIndex = 13;
            showBackgroundBox.Text = "Show background layer";
            showBackgroundBox.UseVisualStyleBackColor = true;
            showBackgroundBox.CheckedChanged += showBackgroundBox_CheckedChanged;
            showBackgroundBox.MouseEnter += showBackgroundBox_MouseEnter;
            showBackgroundBox.MouseLeave += showBackgroundBox_MouseLeave;
            // 
            // showForegroundBox
            // 
            showForegroundBox.AutoSize = true;
            showForegroundBox.Checked = true;
            showForegroundBox.CheckState = CheckState.Checked;
            showForegroundBox.Location = new Point(10, 22);
            showForegroundBox.Name = "showForegroundBox";
            showForegroundBox.Size = new Size(146, 19);
            showForegroundBox.Sound = Managers.FrontendSounds.Impact;
            showForegroundBox.TabIndex = 12;
            showForegroundBox.Text = "Show foreground layer";
            showForegroundBox.UseVisualStyleBackColor = true;
            showForegroundBox.CheckedChanged += showForegroundBox_CheckedChanged;
            showForegroundBox.MouseEnter += showForegroundBox_MouseEnter;
            showForegroundBox.MouseLeave += showForegroundBox_MouseLeave;
            // 
            // PreviewTerrain
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(825, 450);
            Controls.Add(groupBox1);
            Controls.Add(backPanel);
            Controls.Add(groupBox2);
            Controls.Add(terrainSettingsGroup);
            DoubleBuffered = true;
            Icon = (Icon)resources.GetObject("$this.Icon");
            Name = "PreviewTerrain";
            ShowIcon = false;
            ShowInTaskbar = false;
            StartPosition = FormStartPosition.CenterParent;
            Text = "Preview terrain";
            WindowState = FormWindowState.Maximized;
            Resize += PreviewTerrain_Resize;
            terrainSettingsGroup.ResumeLayout(false);
            terrainSettingsGroup.PerformLayout();
            groupBox2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)overviewBox).EndInit();
            backPanel.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)previewBox).EndInit();
            groupBox1.ResumeLayout(false);
            groupBox1.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private System.Windows.Forms.GroupBox terrainSettingsGroup;
        private FrontendComboBox waterBox;
        private System.Windows.Forms.Label label2;
        private FrontendButton closeBtn;
        private FrontendButton generateBtn;
        private System.Windows.Forms.GroupBox groupBox2;
        private MinimapPictureBox overviewBox;
        private System.Windows.Forms.Panel backPanel;
        private System.Windows.Forms.PictureBox previewBox;
        private FrontendComboBox styleBox;
        private Label label1;
        private FrontendCheckBox positionIdsBox;
        private FrontendCheckBox invisibleTerrainBox;
        private TextBox seedBox;
        private FrontendCheckBox useSeedBox;
        private GroupBox groupBox1;
        private FrontendCheckBox showBackgroundBox;
        private FrontendCheckBox showForegroundBox;
        private Label mgCountLbl;
        private Label bgCountLbl;
        private Label fgCountLbl;
    }
}