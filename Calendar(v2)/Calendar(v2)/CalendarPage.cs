using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Calendar_v2_
{
    public class CalendarPage
    {
        public int Year { get; private set; }
        public int Month { get; private set; }

        public CalendarPage(int year, int month)
        {
            Year = year;
            Month = month;
        }

        public IEnumerable<CalendarPageLine> GetCalendarPageLines()
        {
            var daysCount = DateTime.DaysInMonth(Year, Month);
            var currentLine = new CalendarPageLine();
            foreach (var day in Enumerable.Range(1, daysCount).Select(day => new DateTime(Year, Month, day)))
            {
                currentLine.Add(day.Day, day.DayOfWeek);
                if (day.DayOfWeek != DayOfWeek.Sunday) continue;

                yield return currentLine;
                currentLine = new CalendarPageLine();
            }

            yield return currentLine;
        }
    }
}
