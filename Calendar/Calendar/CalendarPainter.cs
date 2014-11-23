using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Calendar
{
    public class CalendarPainter
    {
        private const int CalendarWidth = 800;
        private const int CalendarHeight = 500;
        private readonly Color calendarBackColor = Color.Lavender;
        private readonly Color selectionColor = Color.HotPink;
        private const int StartX = 100;
        private const int StartY = 150;
        private const int Width = 100;
        private const int Height = 50;
        private const int SelectionWidth = 45;
        private const int SelectionHeight = 40;
        private readonly Font textFont = new Font("Arial", 20);
        private readonly Pen textPen = Pens.Black;
        private readonly Brush textBrush = new SolidBrush(Color.Black);
        private readonly Pen boundaryPen = Pens.Black;
        private readonly Color holidayColor = Color.Red;
        private readonly Color weekdayColor = Color.Blue;

        private DateTime currentDate;
        public CalendarPainter(DateTime currentDate)
        {
            this.currentDate = currentDate;
        }

        public Bitmap PaintFromCurrentDate()
        {
            var calendarBitmap = new Bitmap(CalendarWidth, CalendarHeight);
            var graphics = Graphics.FromImage(calendarBitmap);
            graphics.Clear(calendarBackColor);
           
            DrawHeader(graphics);
            DrawCalendarCells(GetCalendarCells().ToList(), graphics);
            
            return calendarBitmap;
        }

        private void DrawHeader(Graphics graphics)
        {
            var month = Months.GetNameMonthFromCode(currentDate.Month);
            var header = string.Format("{0} {1}", month, currentDate.Year);
            graphics.DrawRectangle(textPen, 0, StartY - Height, 7*Width, Height);
            graphics.DrawString(header, textFont, textBrush, 0, StartY - Height);
        }

        private void DrawCalendarCells(List<CalendarCell> cells, Graphics graphics )
        {
            for (var i = 0; i < cells.Count(); ++i)
            {
                var cell = cells[i];
                if (cell.WithBoundary)
                    graphics.DrawRectangle(boundaryPen, (i % 7) * StartX, StartY + (i / 7) * Height, Width, Height);

                if (cell.IsSelected)
                    graphics.FillEllipse(new SolidBrush(selectionColor), (i % 7) * StartX, StartY + (i / 7) * Height, SelectionWidth, SelectionHeight);

                graphics.DrawString(cell.Text, textFont, new SolidBrush(cell.ForeColor), (i % 7) * StartX, StartY + (i / 7) * Height);
            }
        }

        private IEnumerable<CalendarCell> GetCalendarCells()
        {
            var weekDays = new string[] { "Mon", "Tue", "Wed", "Thu", "Fri", "Sat", "Sun" };
            var days = GetDays(currentDate.Year, currentDate.Month).ToList();
            var emptyCells = 7 - days.TakeWhile(i => i.DayOfWeek != DayOfWeek.Monday).Count();

            return weekDays.Select(weekDay => new CalendarCell(weekDay, true, false, Color.Black))
                .Union(Enumerable.Range(0, emptyCells).Select(i => new CalendarCell("", false, false, Color.Lavender)))
                .Union(days.Select(GetCalendarCell));

        }

        private CalendarCell GetCalendarCell(DateTime day)
        {
            var foreColor = day.DayOfWeek == DayOfWeek.Saturday || day.DayOfWeek == DayOfWeek.Sunday ? 
                            holidayColor : weekdayColor;

            return new CalendarCell(day.Day.ToString(), false, day.Day == currentDate.Day, foreColor);
        }

        private static IEnumerable<DateTime> GetDays(int year, int month)
        {
            return Enumerable.Range(1, DateTime.DaysInMonth(year, month))
                                .Select(i => new DateTime(year, month, i));
        }
    }
}
