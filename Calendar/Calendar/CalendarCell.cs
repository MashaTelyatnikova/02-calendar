using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Calendar
{
    public class CalendarCell
    {
        public string Text { get; set; }
        public bool WithBoundary { get; set; }
        public Color ForeColor { get; set; }

        public CalendarCell(string text, bool withBoundary, Color foreColor)
        {
            this.Text = text;
            this.WithBoundary = withBoundary;
            this.ForeColor = foreColor;
        }
    }
}
