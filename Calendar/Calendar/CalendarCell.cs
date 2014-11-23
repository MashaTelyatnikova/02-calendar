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
        public bool IsSelected { get; set; }

        public CalendarCell(string text, bool withBoundary, bool isSelected, Color foreColor)
        {
            this.Text = text;
            this.WithBoundary = withBoundary;
            this.IsSelected = isSelected;
            this.ForeColor = foreColor;
        }
    }
}
