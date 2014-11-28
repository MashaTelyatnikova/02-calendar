using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Calendar_v2_
{
    public class CalendarPageLine
    {
        private readonly List<Day> days;
        public int Number { get; private set; }

        public CalendarPageLine(IEnumerable<Day> days, int number)
        {
            this.days = days.ToList();
            Number = number;
        }

        public IEnumerable<Day> GetDays()
        {
            return days;
        }

        public bool ContainsDay(Day day)
        {
            return days.Contains(day);
        }
    }
}
