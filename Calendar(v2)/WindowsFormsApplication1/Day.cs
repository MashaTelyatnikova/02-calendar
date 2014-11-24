using System;

namespace WindowsFormsApplication1
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
