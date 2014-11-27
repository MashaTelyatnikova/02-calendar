using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Calendar_v2_
{
    public class Day
    {
        public int Number { get; private set; }
        public DayOfWeek DayOfWeek { get; private set; }
        private int hash;

        public Day(int number, DayOfWeek dayOfWeek)
        {
            Number = number;
            DayOfWeek = dayOfWeek;
        }

        public override int GetHashCode()
        {
            return hash;
        }

        public override bool Equals(object obj)
        {
            var other = (Day) obj;
            return other.Number == Number && other.DayOfWeek == DayOfWeek;
        }
    }
}
