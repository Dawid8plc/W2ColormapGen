using Microsoft.Win32;
using W2ColormapGen.Managers;

namespace W2ColormapGen
{
    internal static class Program
    {
        public static Random rnd = new Random();

        public static string AppPath = Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().Location);
        public static string GamePath;

        public static string version = "1.0.0";
        public static string versionQuote = "\"New Lands\"";

        /// <summary>
        ///  The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            ApplicationConfiguration.Initialize();

            if (!DiscoverGameLocation())
            {
                MessageBox.Show("Game files not found. Ensure the game is installed properly or put the W2ColormapGen app next to worms2.exe. Quitting.", "W2ColormapGen");
                return;
            }

            try
            {
                ThemeManager.Initialize();
            }
            catch
            {
                MessageBox.Show($"Failed to load terrain and water themes from \"{Path.Combine(GamePath, "Data")}\"! Make sure the game is properly installed. Quitting.", "W2ColormapGen");
                return;
            }

            if(ThemeManager.TerrainThemes.Count == 0)
            {
                MessageBox.Show($"No terrain themes found in \"{Path.Combine(GamePath, "Data\\Level")}\"! At least one terrain theme is needed, make sure your game is properly installed. Quitting.", "W2ColorMapGen");
                return;
            }

            if (ThemeManager.WaterThemes.Count == 0)
            {
                MessageBox.Show($"No water themes found in \"{Path.Combine(GamePath, "Data\\Water")}\"! At least one water theme is needed, make sure your game is properly installed. Quitting.", "W2ColorMapGen");
                return;
            }

            try
            {
                ResourcesManager.Initialize();
            }
            catch { }

            try
            {
                SoundManager.Initialize();
            }
            catch { }

            Application.Run(new Main());
        }

        public static void ShowAbout(Form parent)
        {
            About about = new About();
            about.ShowDialog(parent);
        }

        static bool DiscoverGameLocation()
        {
            //Check if the game exists in the working directory
            GamePath = Directory.GetCurrentDirectory();

            if (File.Exists(Path.Combine(GamePath, "worms2.exe")))
                return true;

            //Check if the game exists in the W2ColormapGen's folder
            GamePath = Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().Location);

            if (File.Exists(Path.Combine(GamePath, "worms2.exe")))
                return true;

            //Check the path in the registry
            if (CheckRegistry(@"Software\Team17SoftwareLTD\Worms2", "W2PATH", RegistryHive.CurrentUser))
                return true;

            if (CheckRegistry(@"Software\GOG.com\GOGWORMS2", "PATH", RegistryHive.LocalMachine))
                return true;

            if (CheckRegistry(@"Software\Microsoft\DirectPlay\Applications\worms2", "Path", RegistryHive.LocalMachine))
                return true;

            //If we got here, we didn't find the game...
            return false;
        }

        static bool CheckRegistry(string subkey, string keyName, RegistryHive hive)
        {
            RegistryKey key = null;

            try
            {
                using (var reg32 = RegistryKey.OpenBaseKey(hive,
                                            RegistryView.Registry32))
                {
                    key = reg32.OpenSubKey(subkey, false);

                    if (key != null)
                    {
                        object pathObj = key.GetValue(keyName);

                        if (pathObj != null)
                        {
                            string path = pathObj.ToString();

                            if (!string.IsNullOrWhiteSpace(path))
                            {
                                GamePath = Path.GetFullPath(path);

                                if (Directory.Exists(GamePath) && File.Exists(Path.Combine(GamePath, "worms2.exe")))
                                {
                                    return true;
                                }
                            }
                        }
                    }
                }
            }
            finally
            {
                key?.Close();
            }

            return false;
        }
    }
}