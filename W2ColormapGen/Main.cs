using DW2Lib;
using DW2Lib.Worms2;
using System.Diagnostics;
using System.Text;
using W2ColormapGen.Managers;

namespace W2ColormapGen
{
    public partial class Main : Form
    {
        GameMap currentMap = null;

        Bitmap currentGradient = null;

        public Main()
        {
            InitializeComponent();

            foreach (string theme in ThemeManager.TerrainThemes)
            {
                terrainThemeBox.Items.Add(theme);
            }

            terrainThemeBox.SetValueWithoutNotify(0);

            foreach (string theme in ThemeManager.WaterThemes)
            {
                terrainWaterBox.Items.Add(theme);
            }

            terrainWaterBox.SetValueWithoutNotify(0);

            gradientPreview.Paint += GradientPreview_Paint;

            if (File.Exists(Path.Combine(Program.GamePath, @"W2ColormapGen\Theme\LEVEL.DIR")))
            {
                try
                {
                    LoadSavedGradient();
                }
                catch
                {
                    terrainThemeBox.SetValueWithoutNotify(0);
                    ColorMapHelper.CreateEmptyTheme(terrainThemeBox.Text);
                }
            }
            else
            {
                ColorMapHelper.CreateEmptyTheme(terrainThemeBox.Text);
            }

            if (ResourcesManager.Background != null)
                BackgroundImage = ResourcesManager.Background;
        }

        private async void browseBtn_Click(object sender, EventArgs e)
        {
            if (OFD.ShowDialog() == DialogResult.OK)
            {
                string path = OFD.FileName;

                if (path.EndsWith(".dat"))
                {
                    try
                    {
                        Land land = new Land();
                        land.Read(path);

                        if (currentMap != null)
                        {
                            currentMap.Image.Dispose();
                            mapPreview.Image = null;
                        }

                        currentMap = new GameMap();

                        currentMap.Image = land.Foreground.ToBitmap(true);

                        pathBox.Text = path;

                        string waterName = land.WaterTheme.Substring(land.WaterTheme.LastIndexOf('\\') + 1);

                        for (int i = 0; i < terrainWaterBox.Items.Count; i++)
                        {
                            if (terrainWaterBox.Items[i].ToString() == waterName)
                            {
                                terrainWaterBox.SetValueWithoutNotify(i);
                                break;
                            }
                        }

                        currentMap.Water = terrainWaterBox.SelectedItem.ToString();

                        nameBox.Text = Path.GetFileNameWithoutExtension(path);

                        currentMap.ObjectLocations = land.ObjectLocations;

                        currentMap.PaletteSize = land.Foreground.Palette.Count;

                        mapPreview.Image = currentMap.Image;
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show($"Failed to load land data.\n{ex.Message}", "W2ColormapGen", MessageBoxButtons.OK, MessageBoxIcon.Warning);

                        ResetState();
                    }
                }
                else
                {
                    try
                    {
                        if (currentMap != null)
                        {
                            currentMap.Image.Dispose();
                            mapPreview.Image = null;
                        }

                        Bitmap bitmap = new Bitmap(path);

                        if (bitmap.Width != 1920 || bitmap.Height != 696)
                        {
                            MessageBox.Show($"Image isn't 1920x696.", "W2ColormapGen", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            ResetState();
                            return;
                        }

                        if (bitmap.PixelFormat != System.Drawing.Imaging.PixelFormat.Format8bppIndexed)
                        {
                            MessageBox.Show($"Image format isn't 8 bits per pixel indexed.", "W2ColormapGen", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            ResetState();
                            return;
                        }

                        currentMap = new GameMap();

                        currentMap.Image = bitmap;

                        pathBox.Text = path;

                        currentMap.Water = terrainWaterBox.SelectedItem.ToString();

                        nameBox.Text = Path.GetFileNameWithoutExtension(path);

                        RandomizeLocations();

                        currentMap.PaletteSize = currentMap.Image.Palette.Entries.Length;

                        mapPreview.Image = bitmap;
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show($"Failed to load image.\n{ex.Message}", "W2ColormapGen", MessageBoxButtons.OK, MessageBoxIcon.Warning);

                        ResetState();
                    }
                }
            }
        }

        void RandomizeLocations()
        {
            ProgressDialog dialog = new ProgressDialog();

            Task.Run(() =>
            {
                currentMap.ObjectLocations = ColorMapHelper.GenerateSpacedSpawnpoints(currentMap.Image, currentMap.useCustomSeed ? currentMap.customSeed : string.Empty, 18, 100, currentMap.IndestructibleBorder ? 17 : 0);

                if (currentMap.ObjectLocations.Count != 18)
                {
                    for (int i = currentMap.ObjectLocations.Count; i < 18; i++)
                    {
                        currentMap.ObjectLocations.Add(new Point(10, 10)); // Add empty points to fill the list
                    }

                    Invoke(() =>
                    {
                        MessageBox.Show("Failed to find 18 safe spawnpoints, found " + (currentMap.ObjectLocations.Count - 18) + ". The rest got added in top-left corner, please reposition them manually using the Edit map feature and dragging them.", "W2ColormapGen", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    });
                }

                Invoke(() =>
                {
                    dialog.finished = true;
                    dialog.Close();
                });
            });

            dialog.ShowDialog();
        }

        void ResetState()
        {
            if (currentMap != null)
            {
                if (currentMap.Image != null)
                    currentMap.Image.Dispose();
                mapPreview.Image = null;
                pathBox.Text = string.Empty;
                nameBox.Text = string.Empty;
                currentMap = null;
            }
        }

        private void terrainThemeBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                if (File.Exists(Path.Combine(Program.GamePath, "Data", "LEVEL", terrainThemeBox.SelectedItem.ToString(), "LEVEL.DIR")))
                {
                    LoadGradient();
                }
                else
                {
                    MessageBox.Show($"Failed to load gradient.\nLevel.dir is missing from \"{terrainThemeBox.SelectedItem.ToString()}\" theme directory.", "W2ColormapGen", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show($"Failed to load gradient.\n{ex.Message}", "W2ColormapGen", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        void LoadSavedGradient()
        {
            Archive themeArc = new Archive(Path.Combine(Program.GamePath, @"W2ColormapGen\Theme\LEVEL.DIR"));

            bool found = false;
            string themeName = string.Empty;

            if (themeArc.ContainsKey("W2CG.txt"))
            {
                themeName = UTF8Encoding.UTF8.GetString(themeArc["W2CG.txt"]);

                for (int i = 0; i < terrainThemeBox.Items.Count; i++)
                {
                    if (terrainThemeBox.Items[i].ToString() == themeName)
                    {
                        terrainThemeBox.SetValueWithoutNotify(i);
                        found = true;
                        break;
                    }
                }
            }

            if (!found)
            {
                terrainThemeBox.Items.Insert(0, string.IsNullOrWhiteSpace(themeName) ? "Missing theme" : $"{themeName} (missing)");
                terrainThemeBox.SetValueWithoutNotify(0);
            }

            if (themeArc.ContainsKey("gradient.img"))
            {
                Img gradientimg = new Img();
                MemoryStream stream = new MemoryStream(themeArc["gradient.img"]);
                gradientimg.Read(stream);

                if (currentGradient != null)
                    currentGradient.Dispose();

                currentGradient = gradientimg.ToBitmap(true);
                gradientPreview.Invalidate();
                stream.Close();
            }
            else
            {
                terrainThemeBox.SetValueWithoutNotify(1);
                ColorMapHelper.CreateEmptyTheme(terrainThemeBox.Text);

                terrainThemeBox.Items.RemoveAt(0);
            }
        }

        void LoadGradient()
        {
            Archive themeArc = new Archive(Path.Combine(Program.GamePath, "Data", "LEVEL", terrainThemeBox.SelectedItem.ToString(), "LEVEL.DIR"));

            if (themeArc.ContainsKey("gradient.img"))
            {
                Img gradientimg = new Img();
                MemoryStream stream = new MemoryStream(themeArc["gradient.img"]);
                gradientimg.Read(stream);

                if (currentGradient != null)
                    currentGradient.Dispose();

                currentGradient = gradientimg.ToBitmap(true);
                gradientPreview.Invalidate();
                stream.Close();
            }
            else
            {
                MessageBox.Show("The selected theme does not contain a gradient image", "W2ColormapGen", MessageBoxButtons.OK, MessageBoxIcon.Warning);

                if (currentGradient != null)
                    currentGradient.Dispose();

                currentGradient = null;
                gradientPreview.Invalidate();
            }
        }

        private void GradientPreview_Paint(object sender, PaintEventArgs e)
        {
            if (currentGradient == null)
            {
                e.Graphics.Clear(gradientPreview.BackColor);
                return;
            }

            var box = gradientPreview.ClientRectangle;
            int srcW = currentGradient.Width;
            int srcH = currentGradient.Height;
            int destH = box.Height;
            float scaleY = (float)destH / srcH;
            int destW = (int)(srcW * scaleY);

            for (int x = 0; x < box.Width; x += destW)
            {
                e.Graphics.DrawImage(currentGradient, new Rectangle(x, 0, destW, destH), new Rectangle(0, 0, srcW, srcH), GraphicsUnit.Pixel);
            }
        }

        private void saveBtn_Click(object sender, EventArgs e)
        {
            if (currentMap == null)
            {
                MessageBox.Show("Please select an image to turn into a color map", "W2ColormapGen", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            if (string.IsNullOrWhiteSpace(nameBox.Text))
            {
                MessageBox.Show("Please enter a name for the color map", "W2ColormapGen", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            var invalidChars = Path.GetInvalidPathChars().ToList();
            invalidChars.Add('*');
            invalidChars.Add('/');
            invalidChars.Add('\\');
            invalidChars.Add(':');
            invalidChars.Add('?');

            if (invalidChars.Any(nameBox.Text.Contains))
            {
                MessageBox.Show("The color map name contains invalid characters", "W2ColormapGen", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            string finalPath = Path.Combine(Program.GamePath, $"Levels\\Import\\Custom\\{nameBox.Text}.dat");

            if (File.Exists(finalPath))
            {
                if (MessageBox.Show("A map with this name already exists, replace it?", "W2ColormapGen", MessageBoxButtons.YesNo, MessageBoxIcon.Question) != DialogResult.Yes)
                {
                    return;
                }
            }

            string levelPath = Path.Combine(Program.GamePath, "Levels\\Import\\Custom");

            try
            {
                Directory.CreateDirectory(levelPath);

                ColorMapHelper.CreateLandDat(currentMap.Image, finalPath, currentMap.PaletteSize, currentMap.ObjectLocations, currentMap.IndestructibleBorder, $".\\data\\water\\{terrainWaterBox.Text}", currentMap.InvisibleTerrain);

                MessageBox.Show($"Map has been saved to \"Levels\\Import\\Custom\\{nameBox.Text}.dat\"\nCan use the CTerrain tool to play on it!", "W2ColormapGen", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Failed to save map.\n{ex.Message}", "W2ColormapGen", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
        }

        private void applyBtn_Click(object sender, EventArgs e)
        {
            try
            {
                if (ColorMapHelper.CreateEmptyTheme(terrainThemeBox.Text))
                {
                    MessageBox.Show("Sky Gradient Theme for custom color maps applied!", "W2ColormapGen", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch(Exception ex)
            {
                MessageBox.Show($"Failed to apply Sky Gradient Theme.\n{ex.Message}", "W2ColormapGen", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
        }

        private void editBtn_Click(object sender, EventArgs e)
        {
            if (currentMap == null)
            {
                MessageBox.Show("Please select an image to preview", "W2ColormapGen", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            PreviewTerrain preview = new PreviewTerrain(currentMap, currentMap.Image);
            preview.ShowDialog();

            terrainWaterBox.SetValueWithoutNotify(currentMap.Water);
        }

        private void terrainWaterBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (currentMap != null)
                currentMap.Water = terrainWaterBox.SelectedItem.ToString();
        }

        private void Main_FormClosed(object sender, FormClosedEventArgs e)
        {
            SoundManager.Deinitialize();
        }

        private void aboutBtn_Click(object sender, EventArgs e)
        {
            Program.ShowAbout(this);
        }

        private void discordBtn_Click(object sender, EventArgs e)
        {
            Process.Start("explorer", "https://discord.gg/Tvs83972UD");
        }

        private void CTerrainBtn_Click(object sender, EventArgs e)
        {
            string CTerrainPath = Path.Combine(Program.GamePath, "CTerrain.exe");
            if (File.Exists(CTerrainPath))
            {
                ProcessStartInfo psi = new ProcessStartInfo(CTerrainPath);
                psi.WorkingDirectory = Program.GamePath;
                Process.Start(psi);
            }
            else
            {
                if(MessageBox.Show("You don't seem to have the CTerrain tool installed in your game directory and it is required to play on color maps. Would you like to download it now?", "W2ColormapGen", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    Process.Start("explorer", "https://github.com/Carlmundo/CTerrain/releases");
                }
            }
        }
    }
}
