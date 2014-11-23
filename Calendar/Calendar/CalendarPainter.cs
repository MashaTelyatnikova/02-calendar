using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Calendar
{
    public static class CalendarPainter
    {
        private const int CalendarWidth = 800;
        private const int CalendarHeight = 500;
        private static readonly Color CalendarBackColor = Color.Lavender;
        private const int StartX = 100;
        private const int StartY = 150;
        private const int Width = 100;
        private const int Height = 50;

        public static Bitmap PaintFromCurrentDate(DateTime currentDate)
        {
            var calendarBitmap = new Bitmap(CalendarWidth, CalendarHeight);
            var graphics = Graphics.FromImage(calendarBitmap);
            graphics.Clear(CalendarBackColor);

            DrawCalendarCells(GetCalendarCells(currentDate), graphics);
            return calendarBitmap;
        }

        private static void DrawCalendarCells(IEnumerable<CalendarCell> cells, Graphics graphics )
        {
            var count = 0;

            foreach (var cell in cells)
            {
                if (cell.WithBoundary)
                    graphics.DrawRectangle(Pens.Black, (count % 7) * StartX, StartY + (count / 7) * Height, Width, Height);

                graphics.DrawString(cell.Text, new Font("Arial", 20), new SolidBrush(cell.ForeColor), (count % 7) * StartX, StartY + (count / 7) * Height);
                count++;
            }
        }

        private static IEnumerable<CalendarCell> GetCalendarCells(DateTime currentDate)
        {
            var weekDays = new string[] { "Mon", "Tue", "Wed", "Thu", "Fri", "Sat", "Sun" };
            var days = GetDays(currentDate.Year, currentDate.Month).ToList();
            var emptyCells = 7 - days.TakeWhile(i => i.DayOfWeek != DayOfWeek.Monday).Count();

            return weekDays.Select(weekDay => new CalendarCell(weekDay, true, Color.Black))
                            .Union(Enumerable.Range(0, emptyCells).Select(i => new CalendarCell("", false, Color.Lavender)))
                            .Union(Enumerable.Range(1, days.Count).Select(i => new CalendarCell(i.ToString(), false, Color.Blue)));

        }

        private static IEnumerable<DateTime> GetDays(int year, int month)
        {
            return Enumerable.Range(1, DateTime.DaysInMonth(year, month))
                                .Select(i => new DateTime(year, month, i));
        }
    }
}
