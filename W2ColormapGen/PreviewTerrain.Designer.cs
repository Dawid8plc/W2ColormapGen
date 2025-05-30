
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
            terrainSettingsGroup.SuspendLayout();
            groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)overviewBox).BeginInit();
            backPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)previewBox).BeginInit();
            SuspendLayout();
            // 
            // terrainSettingsGroup
            // 
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
            groupBox2.Location = new Point(330, 12);
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
            backPanel.Size = new Size(776, 273);
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
            // PreviewTerrain
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
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
    }
}