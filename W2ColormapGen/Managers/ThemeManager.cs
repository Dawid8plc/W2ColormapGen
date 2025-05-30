
namespace W2ColormapGen.Managers
{
    public class ThemeManager
    {
        public static List<string> TerrainThemes = new List<string>();
        public static List<string> WaterThemes = new List<string>();

        public static void Initialize()
        {
            string[] terrainThemes = Directory.GetDirectories(Path.Combine(Program.GamePath, @"Data\LEVEL"));

            TerrainThemes.Clear();

            foreach (string theme in terrainThemes)
            {
                TerrainThemes.Add(Path.GetFileName(theme));
            }

            string[] waterThemes = Directory.GetDirectories(Path.Combine(Program.GamePath, @"Data\Water"));

            WaterThemes.Clear();

            foreach (string theme in waterThemes)
            {
                WaterThemes.Add(Path.GetFileName(theme));
            }
        }
    }
}
