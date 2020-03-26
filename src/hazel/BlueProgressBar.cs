using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Hazel_V2
{
    public class BlueProgressBar : ProgressBar
    {
        // We need to override the custom paint, because you can't specify progressbar colours by default.
        public BlueProgressBar()
        {
            this.SetStyle(ControlStyles.UserPaint, true);
        }

        // Credit to https://stackoverflow.com/a/778866/12699435  @Crispy
        protected override void OnPaint(PaintEventArgs e)
        {
            Rectangle rec = e.ClipRectangle;
            rec.Width = (int)(rec.Width * ((double)Value / Maximum)) - 4;

            if (ProgressBarRenderer.IsSupported)
                ProgressBarRenderer.DrawHorizontalBar(e.Graphics, e.ClipRectangle);
            rec.Height = rec.Height;

            var newBlue = new SolidBrush(Color.FromArgb(64, 150, 204));
            e.Graphics.FillRectangle(newBlue, 0, 0, rec.Width, rec.Height);
        }

        protected override void OnPaintBackground(PaintEventArgs pevent)
        {

        }

    }
}
