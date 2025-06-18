
namespace W2ColormapGen
{
    public class GameMap
    {
        public string Water = "Blue";

        public int PaletteSize = 0;
        public int PaletteBGSize = 0;
        public int PaletteMergedSize = 0;
        public Bitmap Image = null;
        public Bitmap Background = null;
        public Bitmap Merged = null;

        public List<Point> ObjectLocations = new List<Point>();

        public bool IndestructibleBorder = false;
        public bool InvisibleTerrain = false;

        public bool useCustomSeed = false;
        public string customSeed = string.Empty;

        public GameMap() { }
    }
}
