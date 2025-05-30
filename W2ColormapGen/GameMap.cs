
namespace W2ColormapGen
{
    public class GameMap
    {
        public string Water = "Blue";

        public int PaletteSize = 0;
        public Bitmap Image = null;

        public List<Point> ObjectLocations = new List<Point>();

        public bool IndestructibleBorder = false;

        public GameMap() { }
    }
}
