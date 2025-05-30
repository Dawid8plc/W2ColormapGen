using DW2Lib;
using System.Runtime.InteropServices;

namespace W2ColormapGen.Managers
{
    public static class ResourcesManager
    {
        public static Bitmap WormSprite;
        public static Bitmap Background;

        private const uint RT_BITMAP = 2;

        public static void Initialize()
        {
            if (File.Exists(Path.Combine(Program.GamePath, @"Data\Gfx\Gfx.dir")))
            {
                Archive gfx = new Archive(Path.Combine(Program.GamePath, @"Data\Gfx\Gfx.dir"));

                if (gfx.ContainsKey("data\\spr\\wbatlnk.spr"))
                {
                    MemoryStream str = null;
                    try
                    {
                        str = new MemoryStream(gfx["data\\spr\\wbatlnk.spr"]);
                        Spr spr = new Spr(str);
                        WormSprite = spr.Frames[0].ToBitmap(spr.Frames[0].CropL, spr.Frames[0].CropU, spr.Frames[0].CropR, spr.Frames[0].CropD, false);
                        WormSprite.MakeTransparent(Color.Black);
                        str.Close();
                    }
                    catch
                    {
                        if (str != null)
                            str.Close();
                    }
                }
            }

            if (File.Exists(Program.GamePath + @"\frontend.exe"))
                Background = LoadBitmapFromExe(Program.GamePath + @"\frontend.exe", 249, 20);
        }

        [DllImport("kernel32.dll", SetLastError = true)]
        static extern IntPtr LoadLibrary(string lpFileName);

        [DllImport("kernel32.dll", SetLastError = true)]
        static extern IntPtr FindResource(IntPtr hModule, IntPtr lpID, uint lpType);

        [DllImport("kernel32.dll", SetLastError = true)]
        static extern IntPtr LoadResource(IntPtr hModule, IntPtr hResInfo);

        [DllImport("kernel32.dll", SetLastError = true)]
        static extern IntPtr LockResource(IntPtr hResData);

        [DllImport("kernel32.dll", SetLastError = true)]
        static extern uint SizeofResource(IntPtr hModule, IntPtr hResInfo);

        public static Bitmap LoadBitmapFromExe(string exePath, int resourceId, int cropTopPixels)
        {
            IntPtr hModule = LoadLibrary(exePath);
            if (hModule == IntPtr.Zero)
                throw new Exception("Failed to load module.");

            IntPtr hResInfo = FindResource(hModule, new IntPtr(resourceId), RT_BITMAP);
            if (hResInfo == IntPtr.Zero)
                throw new Exception("Failed to find resource.");

            uint size = SizeofResource(hModule, hResInfo);
            IntPtr hResData = LoadResource(hModule, hResInfo);
            IntPtr pResource = LockResource(hResData);

            if (pResource == IntPtr.Zero || size == 0)
                throw new Exception("Failed to load resource.");

            byte[] dibData = new byte[size];
            Marshal.Copy(pResource, dibData, 0, (int)size);

            int headerSize = BitConverter.ToInt32(dibData, 0);
            int width = BitConverter.ToInt32(dibData, 4);
            int height = BitConverter.ToInt32(dibData, 8);
            int imageOffset = 14 + headerSize;

            byte[] bmpHeader = new byte[14];
            bmpHeader[0] = (byte)'B';
            bmpHeader[1] = (byte)'M';

            int fileSize = dibData.Length + bmpHeader.Length;
            Array.Copy(BitConverter.GetBytes(fileSize), 0, bmpHeader, 2, 4);
            Array.Copy(BitConverter.GetBytes((int)0), 0, bmpHeader, 6, 4);
            Array.Copy(BitConverter.GetBytes(imageOffset), 0, bmpHeader, 10, 4);

            MemoryStream ms = new MemoryStream();
            ms.Write(bmpHeader, 0, bmpHeader.Length);
            ms.Write(dibData, 0, dibData.Length);
            ms.Position = 0;
            using (Bitmap original = new Bitmap(ms))
            {
                int croppedHeight = original.Height - cropTopPixels;
                if (croppedHeight <= 0)
                    throw new ArgumentException("cropTopPixels is too large for the image height.");

                Bitmap cropped = new Bitmap(original.Width, croppedHeight);
                using (Graphics g = Graphics.FromImage(cropped))
                {
                    g.DrawImage(original, new Rectangle(0, 0, cropped.Width, cropped.Height),
                        new Rectangle(0, cropTopPixels, cropped.Width, croppedHeight),
                        GraphicsUnit.Pixel);
                }
                return cropped;
            }
        }
    }
}
