using System;
using System.Collections.Generic;

namespace WindowsFormsApplication1
{
    public class CalendarPageLine
    {
        private readonly HashSet<Day> days;
        public CalendarPageLine()
        {
            days = new HashSet<Day>();
        }

        public void Add(int day, DayOfWeek dayOfWeek)
        {
            days.Add(new Day(day, dayOfWeek));
        }

        public HashSet<Day> GetDays()
        {
            return days;
        }
    }
}
