using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using Calendar_v3_.EasternHoroscope.Enums;

namespace Calendar_v3_.CalendarPageUtil
{
    public class CalendarPage
    {
        public int Year { get; private set; }
        public int Month { get; private set; }
        public IEnumerable<CalendarPageDay> Days { get; private set; }

        public CalendarPage(DateTime date)
        {
            Year = date.Year;
            Month = date.Month;
            Days = GetDays(date);
        }

        public string GetHeader()
        {
            return string.Format("{0}, {1}", DateTimeFormatInfo.InvariantInfo.GetMonthName(Month), Year);
        }

        private static IEnumerable<CalendarPageDay> GetDays(DateTime date)
        {
            return
                Enumerable.Range(1, DateTime.DaysInMonth(date.Year, date.Month))
                            .Select(day => new DateTime(date.Year, date.Month, day))
                            .Select(d => new CalendarPageDay(d.Day, d.DayOfWeek, d.Day == date.Day));
        }
    }
}
