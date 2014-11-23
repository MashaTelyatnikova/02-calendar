using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Calendar
{
    public partial class Calendar : Form
    {
        private const int CalendarWidth = 800;
        private const int CalendarHeight = 500;
        private readonly Color calendarBackColor = Color.Lavender;

        public Calendar(DateTime date)
        {
            InitializeComponent();
            DrawCalendar(date);
        }

        private void DrawCalendar(DateTime currentDate)
        {
            ShowCalendar(CalendarPainter.PaintFromCurrentDate(currentDate));
        }

        private void ShowCalendar(Image calendarBitmap)
        {
            this.calendarBox.Image = calendarBitmap;
        }
    }
}
