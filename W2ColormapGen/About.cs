using W2ColormapGen.Managers;

namespace W2ColormapGen
{
    public partial class About : Form
    {
        public About()
        {
            InitializeComponent();

            if(ResourcesManager.Background != null)
            {
                BackgroundImage = ResourcesManager.Background;
            }

            verLabel.Text = "Version " + Program.version + " " + Program.versionQuote;
        }
    }
}
