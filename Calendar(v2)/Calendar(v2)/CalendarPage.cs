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
        public Day SelectedDay { get; private set; }
        public int SelectedDayLineNumber { get; private set; }
        public EasternHoroscopeAnimals Animal { get; private set; }
        public List<CalendarPageLine> CalendarPageLines { get; private set; }
        
        public CalendarPage(DateTime date)
        {
            Year = date.Year;
            Month = date.Month;
            Animal = EasternHoroscope.GetAnimalOfYear(Year);
            CalendarPageLines = GetCalendarPageLines().ToList();
            SelectedDay = new Day(date.Day, date.DayOfWeek);
            SelectedDayLineNumber = GetSelectedDayLineNumber();
        }

        private IEnumerable<CalendarPageLine> GetCalendarPageLines()
        {
            var startDay = GetFirstDay();
            var lastDay = GetLastDay();
            var lineNumber = 1;
            while (startDay.Number <= lastDay.Number)
            {
                var lineDays = GetPageLineDays(startDay.Number, startDay.DayOfWeek, lastDay.Number).ToList();
                yield return new CalendarPageLine(lineDays, lineNumber);
                
                lineNumber++;
                startDay = new Day(lineDays.Last().Number + 1, (DayOfWeek)(((int)lineDays.Last().DayOfWeek + 1)%7));
            }
        }

        private Day GetFirstDay()
        {
            return new Day(1, GetDayOfWeek(1));
        }

        private Day GetLastDay()
        {
            var lastDayNumber = DateTime.DaysInMonth(Year, Month);
            return new Day(lastDayNumber, GetDayOfWeek(lastDayNumber));
        }

        private DayOfWeek GetDayOfWeek(int number)
        {
            return new DateTime(Year, Month, number).DayOfWeek;
        }

        private static IEnumerable<Day> GetPageLineDays(int pageLineStartDay, DayOfWeek pageLineStartDayOfWeek, int lastDay)
        {
            while (pageLineStartDayOfWeek != DayOfWeek.Sunday && pageLineStartDay < lastDay)
            {
                yield return new Day(pageLineStartDay, pageLineStartDayOfWeek);
                pageLineStartDayOfWeek = (DayOfWeek) (((int) pageLineStartDayOfWeek + 1)%7);
                pageLineStartDay++;
            }

            yield return new Day(pageLineStartDay, pageLineStartDayOfWeek);
        }

        private int GetSelectedDayLineNumber()
        {
            return CalendarPageLines.First(line => line.ContainsDay(SelectedDay)).Number;
        }
    }
}
