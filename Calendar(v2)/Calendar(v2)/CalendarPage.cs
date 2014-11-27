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
            SelectedDay = new Day(date.Day, date.DayOfWeek);
            Animal = EasternHoroscope.GetAnimalOfYear(Year);
            CalendarPageLines = GetCalendarPageLines().ToList();
        }

        private IEnumerable<CalendarPageLine> GetCalendarPageLines()
        {
            var currentPageLineDays = new List<Day>();
            var number = 1;
            foreach (var day in GetAllDays(Year, Month))
            {
                currentPageLineDays.Add(day);
                if (SelectedDay.Equals(day))
                    SelectedDayLineNumber = number;

                if (day.DayOfWeek != DayOfWeek.Sunday) continue;

                yield return new CalendarPageLine(currentPageLineDays, number);
                number++;
                currentPageLineDays = new List<Day>();
            }

            yield return new CalendarPageLine(currentPageLineDays, number);
        }

        private static IEnumerable<Day> GetAllDays(int year, int month)
        {
            return Enumerable.Range(1, DateTime.DaysInMonth(year, month))
                    .Select(day => new DateTime(year, month, day))
                    .Select(i => new Day(i.Day, i.DayOfWeek))
                    .ToList();
        }
    }
}
