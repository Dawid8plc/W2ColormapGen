using System.ComponentModel;

namespace W2ColormapGen.UI
{
    internal class DGroupBox : GroupBox
    {
        private string _Text = "";
        public DGroupBox()
        {
            base.Text = "";
        }

        [Browsable(true)]
        [Category("Appearance")]
        [DefaultValue("GroupBoxText")]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)]
        public new string Text
        {
            get
            {

                return _Text;
            }
            set
            {

                _Text = value;
                Invalidate();
            }
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            DrawGroupBox(this, e.Graphics, Color.Black);

            var g = e.Graphics;

            var textSize = TextRenderer.MeasureText(Text, Font);
            int textX = (Width - textSize.Width) / 2;
            int textY = 0;

            var parent = Parent;
            if (parent?.BackgroundImage != null && parent.BackgroundImageLayout == ImageLayout.Stretch)
            {
                var img = parent.BackgroundImage;
                var parentSize = parent.ClientSize;

                float scaleX = (float)img.Width / parentSize.Width;
                float scaleY = (float)img.Height / parentSize.Height;

                Point rel = this.Location;

                Rectangle srcRect = new Rectangle(
                    (int)((rel.X + textX) * scaleX),
                    (int)((rel.Y + textY) * scaleY),
                    (int)(textSize.Width * scaleX),
                    (int)(textSize.Height * scaleY)
                );

                g.DrawImage(
                    img,
                    new Rectangle(textX - 5, textY, textSize.Width + 5, textSize.Height),
                    srcRect,
                    GraphicsUnit.Pixel
                );
            }
            else
            {
                using var bgBrush = new SolidBrush(parent?.BackColor ?? BackColor);
                g.FillRectangle(bgBrush, textX, textY, textSize.Width, textSize.Height);
            }

            using var textBrush = new SolidBrush(ForeColor);
            g.DrawString(Text, Font, textBrush, new PointF(textX, textY));
        }

        private void DrawGroupBox(GroupBox box, Graphics g, Color borderColor)
        {
            if (box != null)
            {
                Brush borderBrush = new SolidBrush(borderColor);
                Pen borderPen = new Pen(borderBrush);
                SizeF strSize = g.MeasureString(_Text, box.Font);
                Rectangle rect = new Rectangle(box.ClientRectangle.X,
                                               box.ClientRectangle.Y + (int)(strSize.Height / 2),
                                               box.ClientRectangle.Width - 1,
                                               box.ClientRectangle.Height - (int)(strSize.Height / 2) - 1);

                // Drawing Border
                //Left
                g.DrawLine(borderPen, rect.Location, new Point(rect.X, rect.Y + rect.Height));
                //Right
                g.DrawLine(borderPen, new Point(rect.X + rect.Width, rect.Y), new Point(rect.X + rect.Width, rect.Y + rect.Height));
                //Bottom
                g.DrawLine(borderPen, new Point(rect.X, rect.Y + rect.Height), new Point(rect.X + rect.Width, rect.Y + rect.Height));
                //Top
                g.DrawLine(borderPen, new Point(rect.X, rect.Y), new Point(rect.X + rect.Width, rect.Y));
            }
        }
    }

}
