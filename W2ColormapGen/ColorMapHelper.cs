using DW2Lib;
using DW2Lib.Worms2;
using System.Drawing.Imaging;
using System.Text;
using W2ColormapGen.Properties;

namespace W2ColormapGen
{
    public class ColorMapHelper
    {
        public static bool CreateEmptyTheme(string theme)
        {
            if(!File.Exists(Path.Combine(Program.GamePath, @$"Data\LEVEL\{theme}\LEVEL.DIR")))
            {
                MessageBox.Show($"Theme \"{theme}\" doesn't exist!", "W2ColormapGen");
                return false;
            }

            MemoryStream stream = new MemoryStream(Resources.EmptyTheme);

            Archive archive = new Archive(stream);
            Archive LevelDir = new Archive(Path.Combine(Program.GamePath, @$"Data\LEVEL\{theme}\LEVEL.DIR"));

            archive.Remove("gradient.img");

            archive.Add("gradient.img", LevelDir["gradient.img"]);
            archive.Add("W2CG.txt", UTF8Encoding.UTF8.GetBytes(theme));

            Directory.CreateDirectory(Path.Combine(Program.GamePath, @"W2ColormapGen\Theme"));

            try
            {
                archive.Write(Path.Combine(Program.GamePath, @"W2ColormapGen\Theme\LEVEL.DIR"));
            }
            catch(Exception e)
            {
                MessageBox.Show($"Failed to save theme \"{Path.Combine(Program.GamePath, @"W2ColormapGen\Theme\LEVEL.DIR")}\"!\n{e.StackTrace}", "W2ColormapGen");
                return false;
            }

            stream.Close();
            return true;
        }

        public static void CreateLandDat(Bitmap CollisionBmp, Bitmap VisualBmp, string path, int paletteSize, List<Point> spawnPoints, bool indestructibleBorder, string WaterDir, bool invisibleTerrain = false)
        {
            //Create foreground img
            Img img = new Img();

            img.BitsPerPixel = 8;
            img.Size = new Size(CollisionBmp.Width, CollisionBmp.Height);

            byte[] CollisionData;
            byte[] ForegroundData;

            CollisionData = GetImageData(CollisionBmp);

            List<Color> pallete = new List<Color>();

            if (CollisionBmp == VisualBmp)
            {
                ForegroundData = CollisionData;
            }
            else
            {
                ForegroundData = GetImageData(VisualBmp);
            }

            //Load palette
            for (int i = 0; i < paletteSize; i++)
            {
                Color item = VisualBmp.Palette.Entries[i];
                pallete.Add(item);
            }
            //Load palette

            img.Palette = pallete;
            img.PaletteColorAmount = (short)(pallete.Count - 1);

            if (!invisibleTerrain)
            {
                img.Data = ForegroundData;
            }
            else
            {
                img.Data = new byte[1336320];
            }

            if (CollisionBmp == VisualBmp)
            {
                img.Description = "\0";
            }
            else
            {
                img.Description = "DualLayer\0";
            }
            //Create foreground img

            //Create land.dat
            Land data = new Land();

            data.Size = new Size(CollisionBmp.Width, CollisionBmp.Height);
            data.IndestructibleBorder = indestructibleBorder;

            data.WaterTheme = WaterDir;
            data.LandTheme = $".\\W2ColormapGen\\Theme";

            data.Foreground = img;
            data.CollisionMask = ConvertTo1bpp3(CollisionData, img.Size);
            data.Background = data.CollisionMask;
            data.UnknownImage = GenerateEmptyImg();

            data.ObjectLocations = spawnPoints;

            FileStream stream = File.Create(path);

            data.Write(stream);

            stream.Close();
            //Create land.dat
        }

        /// <summary>
        /// Merges two 8bpp indexed images, merging palettes as needed. Foreground pixels that are not black are kept; black pixels are replaced by background, and background colors are added to the palette if needed.
        /// </summary>
        /// <param name="foreground">The foreground 8bpp indexed bitmap.</param>
        /// <param name="background">The background 8bpp indexed bitmap.</param>
        /// <returns>A new merged 8bpp indexed bitmap.</returns>
        public static Bitmap Merge8bppIndexed(Bitmap foreground, Bitmap background, out List<Color> palette)
        {
            if (foreground.Width != background.Width || foreground.Height != background.Height)
                throw new ArgumentException("Bitmaps must be the same size.");
            if (foreground.PixelFormat != PixelFormat.Format8bppIndexed || background.PixelFormat != PixelFormat.Format8bppIndexed)
                throw new ArgumentException("Both bitmaps must be 8bpp indexed.");

            int width = foreground.Width;
            int height = foreground.Height;
            Bitmap result = new Bitmap(width, height, PixelFormat.Format8bppIndexed);

            // Copy palette from foreground
            ColorPalette fgPalette = foreground.Palette;
            ColorPalette bgPalette = background.Palette;
            ColorPalette resultPalette = result.Palette;
            List<Color> paletteList = new List<Color>(fgPalette.Entries);
            // Remove trailing empty palette entries
            paletteList = paletteList.Where(c => c.A != 0 || (c.R != 0 || c.G != 0 || c.B != 0)).ToList();

            // Map for fast color lookup
            Dictionary<Color, byte> colorToIndex = new Dictionary<Color, byte>();
            for (byte i = 0; i < paletteList.Count; i++)
                if (!colorToIndex.ContainsKey(paletteList[i]))
                    colorToIndex[paletteList[i]] = i;

            BitmapData fgData = foreground.LockBits(new Rectangle(0, 0, width, height), ImageLockMode.ReadOnly, PixelFormat.Format8bppIndexed);
            BitmapData bgData = background.LockBits(new Rectangle(0, 0, width, height), ImageLockMode.ReadOnly, PixelFormat.Format8bppIndexed);
            BitmapData resData = result.LockBits(new Rectangle(0, 0, width, height), ImageLockMode.WriteOnly, PixelFormat.Format8bppIndexed);

            try
            {
                int stride = fgData.Stride;
                byte[] fgRow = new byte[stride];
                byte[] bgRow = new byte[stride];
                byte[] resRow = new byte[stride];
                for (int y = 0; y < height; y++)
                {
                    System.Runtime.InteropServices.Marshal.Copy(fgData.Scan0 + y * stride, fgRow, 0, stride);
                    System.Runtime.InteropServices.Marshal.Copy(bgData.Scan0 + y * stride, bgRow, 0, stride);
                    for (int x = 0; x < width; x++)
                    {
                        byte fgIdx = fgRow[x];
                        Color fgColor = fgPalette.Entries[fgIdx];
                        if (fgColor.R != 0 || fgColor.G != 0 || fgColor.B != 0)
                        {
                            // Use foreground
                            resRow[x] = fgIdx;
                        }
                        else
                        {
                            byte bgIdx = bgRow[x];
                            Color bgColor = bgPalette.Entries[bgIdx];
                            if (colorToIndex.TryGetValue(bgColor, out byte idx))
                            {
                                resRow[x] = idx;
                            }
                            else
                            {
                                if (paletteList.Count >= 256)
                                    throw new InvalidOperationException("Palette would exceed 256 colors.");
                                paletteList.Add(bgColor);
                                byte newIdx = (byte)(paletteList.Count - 1);
                                colorToIndex[bgColor] = newIdx;
                                resRow[x] = newIdx;
                            }
                        }
                    }
                    System.Runtime.InteropServices.Marshal.Copy(resRow, 0, resData.Scan0 + y * stride, stride);
                }
            }
            finally
            {
                foreground.UnlockBits(fgData);
                background.UnlockBits(bgData);
                result.UnlockBits(resData);
            }
            // Fill result palette
            for (int i = 0; i < 256; i++)
            {
                if (i < paletteList.Count)
                    resultPalette.Entries[i] = paletteList[i];
                else
                    resultPalette.Entries[i] = Color.Black;
            }
            result.Palette = resultPalette;
            palette = paletteList;
            return result;
        }

        public static Img GenerateEmptyImg()
        {
            Img img = new Img();
            img.BitsPerPixel = 1;
            img.Compressed = false;

            byte[] bytes = new byte[2610];

            img.Data = bytes;

            img.Description = "\0";
            img.Palette = null;
            img.Size = new Size(240, 87);

            return img;
        }

        public static bool FindSafePosition(Bitmap bitmap, int x, int y, out Point point)
        {
            int radius = 15;

            int yOffset = 30;

            for (int j = y; j > 0; j--)
            {
                if (!IsSolid(bitmap.GetPixel(x, j)))
                {
                    //We must now make sure that all tiles around are not solid
                    if (IsEnclosed(bitmap, x, j - yOffset, radius))
                    {
                        if (IsEnclosed(bitmap, x, j - yOffset - 20, radius))
                        {
                            point = Point.Empty;
                            return false;
                        }
                        else
                        {
                            point = new Point(x, j - yOffset - 20);
                            return true;
                        }
                    }

                    point = new Point(x, j - yOffset);
                    return true;
                }
            }

            point = Point.Empty;
            return false;
        }

        public static bool IsSolid(Color a)
        {
            return !(a.R == Color.Black.R && a.G == Color.Black.G && a.B == Color.Black.B);
        }

        private static double Distance(Point a, Point b)
        {
            int dx = a.X - b.X;
            int dy = a.Y - b.Y;
            return Math.Sqrt(dx * dx + dy * dy);
        }

        /// <summary>
        /// Generates spawn points spaced out over the map, all above solid ground, with a minimum distance between them.
        /// </summary>
        /// <param name="bitmap">The map bitmap.</param>
        /// <param name="numberOfSpawnPoints">Number of spawn points to generate.</param>
        /// <param name="minDistance">Minimum distance between spawn points.</param>
        /// <param name="minY">Minimum allowed Y value for spawn points (inclusive).</param>
        /// <returns>List of spawn points (Point).</returns>
        public static List<Point> GenerateSpacedSpawnpoints(Bitmap bitmap, string seed, int numberOfSpawnPoints, int minDistance, int minY = 0)
        {
            List<Point> spawnPositions = new List<Point>();
            Random rnd;
            if (string.IsNullOrWhiteSpace(seed))
                rnd = Program.rnd;
            else
                rnd = Program.GetRNG(seed);
            int minDistanceCurrent = minDistance;
            int minDistanceLowerBound = 0;
            double relaxFactor = 0.9; // Reduce minDistance by 10% each time
            int maxAttemptsPerSpawn = 200;
            int globalAttempts = 0;
            int maxGlobalAttempts = numberOfSpawnPoints * 2000; // Only relax if this is exceeded
            int lastPlacedCount = 0;

            int thisAttempt = 0;

            while (spawnPositions.Count < numberOfSpawnPoints)
            {
                thisAttempt++;
                if (thisAttempt > 500)
                    return spawnPositions;

                int attempts = 0;
                Point? bestCandidate = null;
                double bestDist = -1;
                bool found = false;
                Point lastTried = Point.Empty;
                while (attempts < maxAttemptsPerSpawn)
                {
                    attempts++;
                    globalAttempts++;
                    int x = rnd.Next(0, bitmap.Width);
                    int y = rnd.Next(0, bitmap.Height);
                    Color a = bitmap.GetPixel(x, y);
                    if (!IsSolid(a)) continue;
                    if (!FindSafePosition(bitmap, x, y, out Point position)) continue;
                    if (position.Y < minY) continue;
                    if (spawnPositions.Contains(position))
                    {
                        lastTried = position;
                        continue;
                    }

                    // Find the minimum distance to existing spawns
                    double minDist = double.MaxValue;
                    foreach (var pt in spawnPositions)
                    {
                        double d = Distance(pt, position);
                        if (d < minDist) minDist = d;
                    }
                    if (spawnPositions.Count == 0) minDist = double.MaxValue;

                    if (minDist >= minDistanceCurrent)
                    {
                        spawnPositions.Add(position);
                        thisAttempt = 0;
                        found = true;
                        lastPlacedCount = globalAttempts;
                        break;
                    }
                    // Track the farthest candidate if we can't meet minDistance
                    if (minDist > bestDist && position.Y >= minY && !spawnPositions.Contains(position))
                    {
                        bestDist = minDist;
                        bestCandidate = position;
                    }
                }
                if (!found)
                {
                    if (bestCandidate.HasValue && !spawnPositions.Contains(bestCandidate.Value))
                    {
                        spawnPositions.Add(bestCandidate.Value);
                        thisAttempt = 0;
                        lastPlacedCount = globalAttempts;
                    }
                    else
                    {
                        // Fallback: try to place at the next available Y above last tried position, ensuring uniqueness
                        if (lastTried != Point.Empty)
                        {
                            Point fallback = lastTried;
                            bool placed = false;
                            for (int y = fallback.Y - 1; y >= minY; y--)
                            {
                                Point tryPos = new Point(fallback.X, y);
                                if (!spawnPositions.Contains(tryPos))
                                {
                                    // Only place if it's over solid ground and FindSafePosition is true
                                    if (!IsSolid(bitmap.GetPixel(fallback.X, y)))
                                    {
                                        if (FindSafePosition(bitmap, fallback.X, y, out Point safePos) && safePos.Y >= minY && !spawnPositions.Contains(safePos))
                                        {
                                            spawnPositions.Add(safePos);
                                            thisAttempt = 0;
                                            placed = true;
                                            break;
                                        }
                                    }
                                }
                            }
                            if (placed) continue;
                        }
                        // If no candidate found at all, try a new random X (by continuing outer loop)
                        continue;
                    }
                }
                // Only relax if we've made no progress for a long time
                if (spawnPositions.Count < numberOfSpawnPoints && minDistanceCurrent > minDistanceLowerBound)
                {
                    if (globalAttempts - lastPlacedCount > maxGlobalAttempts)
                    {
                        minDistanceCurrent = (int)Math.Max(minDistanceLowerBound, minDistanceCurrent * relaxFactor);
                        lastPlacedCount = globalAttempts;
                    }
                }
            }
            return spawnPositions;
        }

        /// <summary>
        /// Checks if a given point is a valid spawn location according to the rules of GenerateSpacedSpawnpoints.
        /// </summary>
        /// <param name="bitmap">The map bitmap.</param>
        /// <param name="existingSpawns">List of already chosen spawn points.</param>
        /// <param name="candidate">The point to check.</param>
        /// <param name="minDistance">Minimum distance from other spawn points.</param>
        /// <param name="minY">Minimum allowed Y value for spawn points (inclusive).</param>
        /// <returns>True if the point is valid, false otherwise.</returns>
        public static bool IsValidSpawnpoint(Bitmap bitmap, List<Point> existingSpawns, Point candidate, int minDistance, int minY = 0)
        {
            if (candidate.Y < minY) return false;
            if (existingSpawns.Contains(candidate)) return false;
            if (!IsSolid(bitmap.GetPixel(candidate.X, candidate.Y))) return false;
            if (!FindSafePosition(bitmap, candidate.X, candidate.Y, out Point safePos)) return false;
            //if (safePos != candidate) return false;
            foreach (var pt in existingSpawns)
            {
                if (Distance(pt, candidate) < minDistance)
                    return false;
            }
            return true;
        }

        static bool IsAirBelow(Bitmap bitmap, int x, int y)
        {
            // Check if there is at least one air pixel below the given position
            for (int i = y + 1; i < bitmap.Height; i++)
            {
                Color a = bitmap.GetPixel(x, i);
                if (a.R == Color.Black.R && a.G == Color.Black.G && a.B == Color.Black.B)
                {
                    // Solid pixel found below, so there is no air
                    return false;
                }
            }

            // No solid pixel found below, so there is air
            return true;
        }

        static bool IsEnclosed(Bitmap bitmap, int x, int y, int radius)
        {
            // Check if all pixels within the specified radius are air
            for (int i = x - radius; i <= x + radius; i++)
            {
                for (int j = y - radius; j <= y + radius; j++)
                {
                    if (i >= 0 && i < bitmap.Width && j >= 0 && j < bitmap.Height)
                    {
                        Color a = bitmap.GetPixel(i, j);
                        if (!(a.R == Color.Black.R && a.G == Color.Black.G && a.B == Color.Black.B))
                        {
                            // Solid pixel found, so it's not completely enclosed
                            return true;
                        }
                    }
                }
            }

            // All nearby pixels are air, so it's completely enclosed
            return false;
        }

        public static byte[] GetImageData(Bitmap bitmap)
        {
            Rectangle rect = new Rectangle(0, 0, bitmap.Width, bitmap.Height);
            BitmapData bmpData = bitmap.LockBits(rect, ImageLockMode.ReadOnly, bitmap.PixelFormat);

            try
            {
                // Calculate the total size of the image data
                int dataSize = bmpData.Stride * bitmap.Height;

                // Create a byte array to hold the image data
                byte[] imageData = new byte[dataSize];

                // Copy the data from the bitmap to the byte array
                System.Runtime.InteropServices.Marshal.Copy(bmpData.Scan0, imageData, 0, dataSize);

                return imageData;
            }
            finally
            {
                // Unlock the bits and release the bitmap
                bitmap.UnlockBits(bmpData);
            }
        }

        public static Img ConvertTo1bpp3(byte[] bmpBytes, Size size)
        {
            int imgBytesLength = (bmpBytes.Length - 1) / 8 + 1; // = bmpBytes/8 rounding up I believe
            byte[] imgBytes = new byte[imgBytesLength];

            for (int i = 0; i < bmpBytes.Length; i++)
            {
                byte imgBit = bmpByteToBool(bmpBytes[i]) ? (byte)1 : (byte)0;
                imgBit <<= i % 8;
                imgBytes[i / 8] |= imgBit;
            }

            Img newImg = new Img();

            newImg.BitsPerPixel = 1;
            newImg.Size = new Size(size.Width, size.Height);
            newImg.Description = "\0";
            newImg.Data = imgBytes;

            return newImg;
        }

        static bool bmpByteToBool(byte bmpByte)
        {
            // this might need to be more complex depending on how the bmp palette is arranged and which colours need to be mapped how
            return bmpByte != 0;
        }
    }

}
