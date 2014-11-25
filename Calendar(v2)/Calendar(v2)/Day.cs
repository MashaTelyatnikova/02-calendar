using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Calendar_v2_
{
    public class Day
    {
        public int Number { get; set; }
        public DayOfWeek DayOfWeek { get; set; }

        public Day(int number, DayOfWeek dayOfWeek)
        {
            Number = number;
            DayOfWeek = dayOfWeek;
        }
    }
}
