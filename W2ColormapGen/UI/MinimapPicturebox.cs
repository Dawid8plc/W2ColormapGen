using System;
using System.Collections.Generic;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace W2ColormapGen.UI
{
    /// <summary>
    /// Inherits from PictureBox; adds Interpolation Mode Setting and minimap functionality
    /// </summary>
    public class MinimapPictureBox : PictureBox
    {
        public InterpolationMode InterpolationMode { get; set; }

        public ScrollableControl ScrollableTarget { get; set; }

        private Point lastMouseLocation; // Used to track the last mouse position during dragging
        private bool isDragging;

        protected override void OnPaint(PaintEventArgs paintEventArgs)
        {
            paintEventArgs.Graphics.InterpolationMode = InterpolationMode;
            base.OnPaint(paintEventArgs);

            Graphics g = paintEventArgs.Graphics;

            if (ScrollableTarget == null)
                return;

            // Calculate the scaling factor based on the first PictureBox size and the panel size
            float scaleX = Width / (float)1920;
            float scaleY = Height / (float)696;

            // Calculate the visible rectangle in the second PictureBox
            Rectangle visibleRect = new Rectangle(
                ScrollableTarget.HorizontalScroll.Visible ? (int)(ScrollableTarget.HorizontalScroll.Value * scaleX) : 0,
                ScrollableTarget.VerticalScroll.Visible ? (int)(ScrollableTarget.VerticalScroll.Value * scaleY) : 0,
                (int)(ScrollableTarget.ClientSize.Width * scaleX),
                (int)(ScrollableTarget.ClientSize.Height * scaleY));

            g.DrawRectangle(Pens.White, visibleRect);
        }

        protected override void OnMouseDown(MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                lastMouseLocation = e.Location;
                isDragging = true;

                Cursor = Cursors.SizeAll;
            }

            base.OnMouseDown(e);
        }

        protected override void OnMouseMove(MouseEventArgs e)
        {
            if (isDragging)
            {
                // Calculate the scaling factor based on the control size and the target size
                float scaleX = 1920 / (float)Width;
                float scaleY = 696 / (float)Height;

                // Calculate the scroll position based on the click location
                int scrollX = (int)(e.X * scaleX) - ScrollableTarget.ClientSize.Width / 2;
                int scrollY = (int)(e.Y * scaleY) - ScrollableTarget.ClientSize.Height / 2;

                // Set the scroll position directly using HorizontalScroll and VerticalScroll
                ScrollableTarget.HorizontalScroll.Value = Math.Clamp(scrollX, 0, ScrollableTarget.HorizontalScroll.Maximum);
                ScrollableTarget.VerticalScroll.Value = Math.Clamp(scrollY, 0, ScrollableTarget.VerticalScroll.Maximum); ;

                // Force the control to update
                ScrollableTarget.PerformLayout();
                ScrollableTarget.Invalidate();

                Invalidate();
            }

            base.OnMouseMove(e);
        }

        protected override void OnMouseUp(MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                isDragging = false;

                Cursor = Cursors.Default;
            }

            base.OnMouseUp(e);
        }
    }
}
