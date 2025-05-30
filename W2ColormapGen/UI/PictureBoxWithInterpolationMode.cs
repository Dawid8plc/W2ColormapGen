using System.Drawing.Drawing2D;

namespace W2ColormapGen.UI
{
    /// <summary>
    /// Inherits from PictureBox; adds Interpolation Mode Setting
    /// </summary>
    public class PictureBoxWithInterpolationMode : PictureBox
    {
        public InterpolationMode InterpolationMode { get; set; }

        public PictureBoxWithInterpolationMode()
        {
            DoubleBuffered = true;
        }

        protected override void OnPaint(PaintEventArgs paintEventArgs)
        {
            paintEventArgs.Graphics.InterpolationMode = InterpolationMode;
            base.OnPaint(paintEventArgs);
        }
    }
}
