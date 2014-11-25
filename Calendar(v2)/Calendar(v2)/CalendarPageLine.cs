using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Calendar_v2_
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
