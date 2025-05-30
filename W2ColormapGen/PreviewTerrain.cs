using W2ColormapGen.Managers;

namespace W2ColormapGen
{
    public partial class PreviewTerrain : Form
    {
        private Point previousMouseLocation;
        private Point accumulatedMovement;
        private bool isDragging = false;

        GameMap parameters;
        Bitmap map;

        Bitmap grafitti = null;

        public bool changedMap = false;

        private int? draggingObjectIndex = null;
        private Point dragOffset;

        public PreviewTerrain(GameMap parameters, Bitmap map)
        {
            InitializeComponent();

            this.map = map;
            this.parameters = parameters;

            previewBox.Image = map;
            overviewBox.Image = map;

            foreach (string theme in ThemeManager.WaterThemes)
            {
                waterBox.Items.Add(theme);
            }

            waterBox.SetValueWithoutNotify(parameters.Water);

            backPanel.MouseWheel += BackPanel_MouseWheel;

            previewBox.Enabled = true;
            previewBox.MouseDown += previewBox_MouseDown;
            previewBox.MouseMove += previewBox_MouseMove;
            previewBox.MouseUp += previewBox_MouseUp;

            if (parameters.IndestructibleBorder)
            {
                styleBox.SetValueWithoutNotify(1);
            }
            else
            {
                styleBox.SetValueWithoutNotify(0);
            }
        }

        private void BackPanel_MouseWheel(object sender, MouseEventArgs e)
        {
            overviewBox.Invalidate();
            backPanel.Invalidate();
        }

        private void backPanel_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                previousMouseLocation = e.Location;
                isDragging = true;

                Cursor = Cursors.SizeAll;
            }
        }

        private void backPanel_MouseMove(object sender, MouseEventArgs e)
        {
            if (isDragging)
            {
                int deltaX = previousMouseLocation.X - e.X;
                int deltaY = previousMouseLocation.Y - e.Y;

                accumulatedMovement = new Point(
                    accumulatedMovement.X + deltaX,
                    accumulatedMovement.Y + deltaY
                );

                backPanel.AutoScrollPosition = new Point(
                    accumulatedMovement.X,
                    accumulatedMovement.Y
                );

                previousMouseLocation = e.Location;

                overviewBox.Invalidate();
                backPanel.Invalidate();
            }
        }

        private void backPanel_MouseUp(object sender, MouseEventArgs e)
        {
            isDragging = false;
            Cursor = Cursors.Default;
        }

        private void closeBtn_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void backPanel_Scroll(object sender, ScrollEventArgs e)
        {
            overviewBox.Invalidate();
            backPanel.Invalidate();
        }

        private void PreviewTerrain_Resize(object sender, EventArgs e)
        {
            overviewBox.Invalidate();
            backPanel.Invalidate();
        }

        void SetText(string text)
        {
            if (string.IsNullOrWhiteSpace(text))
            {
                Text = "Preview terrain";
            }
            else
            {
                Text = "Preview terrain - " + text;
            }
        }

        private void overviewBox_MouseEnter(object sender, EventArgs e)
        {
            SetText("This is an overview of the current terrain.");
        }

        private void closeBtn_MouseEnter(object sender, EventArgs e)
        {
            SetText("Close this window.");
        }

        private void generateBtn_MouseEnter(object sender, EventArgs e)
        {
            SetText("Randomize worm and mine spawn locations.");
        }

        private void objectSlider_MouseEnter(object sender, EventArgs e)
        {
            SetText("Set how many objects will appear on this terrain.");
        }

        private void terrainBox_MouseEnter(object sender, EventArgs e)
        {
            SetText("Select a different water style.");
        }

        private void backPanel_MouseEnter(object sender, EventArgs e)
        {
            SetText("Shows a preview of how the current terrain will appear.");
        }

        private void ResetText_MouseLeave(object sender, EventArgs e)
        {
            SetText(string.Empty);
        }

        private void previewBox_Paint(object sender, PaintEventArgs e)
        {
            foreach (var item in parameters.ObjectLocations)
            {
                if (ResourcesManager.WormSprite != null)
                {
                    e.Graphics.DrawImage(ResourcesManager.WormSprite, item.X - 8, item.Y - 8, 16, 16);
                }
                else
                {
                    e.Graphics.FillEllipse(Brushes.Red, item.X - 8, item.Y - 8, 16, 16);
                }
            }
        }

        private void terrainBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            parameters.Water = waterBox.Text;
        }

        private void previewBox_MouseDown(object sender, MouseEventArgs e)
        {
            for (int i = 0; i < parameters.ObjectLocations.Count; i++)
            {
                var pt = parameters.ObjectLocations[i];
                var ellipseRect = new Rectangle(pt.X - 8, pt.Y - 8, 16, 16);
                if (ellipseRect.Contains(e.Location))
                {
                    draggingObjectIndex = i;
                    dragOffset = new Point(e.Location.X - pt.X, e.Location.Y - pt.Y);
                    previewBox.Capture = true;
                    break;
                }
            }
        }

        private void previewBox_MouseMove(object sender, MouseEventArgs e)
        {
            if (draggingObjectIndex.HasValue && e.Button == MouseButtons.Left)
            {
                int idx = draggingObjectIndex.Value;
                int newX = e.Location.X - dragOffset.X;
                int newY = e.Location.Y - dragOffset.Y;

                newX = Math.Clamp(newX, 0, 1920);
                newY = Math.Clamp(newY, 0, 696);

                parameters.ObjectLocations[idx] = new Point(newX, newY);
                previewBox.Invalidate();
            }
        }

        private void previewBox_MouseUp(object sender, MouseEventArgs e)
        {
            if (draggingObjectIndex.HasValue)
            {
                draggingObjectIndex = null;
                previewBox.Capture = false;
            }
        }

        private void generateBtn_Click(object sender, EventArgs e)
        {
            ProgressDialog dialog = new ProgressDialog();

            Task.Run(() =>
            {
                parameters.ObjectLocations = ColorMapHelper.GenerateSpacedSpawnpoints(map, 18, 100, parameters.IndestructibleBorder ? 17 : 0);

                if (parameters.ObjectLocations.Count != 18)
                {
                    for (int i = parameters.ObjectLocations.Count; i < 18; i++)
                    {
                        parameters.ObjectLocations.Add(new Point(10, 10));
                    }

                    Invoke(() =>
                    {
                        MessageBox.Show("Failed to find 18 safe spawnpoints, found " + (parameters.ObjectLocations.Count - 18) + ". The rest got added in top-left corner, please reposition them manually by dragging.", "W2ColormapGen", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    });
                }

                previewBox.Invalidate();

                Invoke(() =>
                {
                    dialog.finished = true;
                    dialog.Close();
                });
            });

            dialog.ShowDialog();
        }

        private void styleBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            parameters.IndestructibleBorder = styleBox.SelectedIndex == 1;
        }

        private void styleBox_MouseEnter(object sender, EventArgs e)
        {
            SetText("Choose between open and cavern terrain types.");
        }

        private void styleBox_MouseLeave(object sender, EventArgs e)
        {
            SetText(string.Empty);
        }
    }
}
