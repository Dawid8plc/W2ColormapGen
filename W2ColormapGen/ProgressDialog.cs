
namespace W2ColormapGen
{
    public partial class ProgressDialog : Form
    {
        public bool finished = false;

        public ProgressDialog()
        {
            InitializeComponent();
        }

        private void ProgressDialog_FormClosing(object sender, FormClosingEventArgs e)
        {
            if(!finished)
            {
                e.Cancel = true;
            }
        }
    }
}
