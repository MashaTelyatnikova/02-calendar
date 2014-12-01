using System;

namespace Calendar_v3_.CalendarPageUtils
{
    public class CalendarPageDay
    {
        public int Number { get; private set; }
        public DayOfWeek DayOfWeek { get; private set; }
        public bool IsHoliday { get; private set; }
        public bool IsSelected { get; private set; }

        public CalendarPageDay(int number, DayOfWeek dayOfWeek, bool isSelected)
        {
            Number = number;
            DayOfWeek = dayOfWeek;
            IsSelected = isSelected;
            IsHoliday = dayOfWeek == DayOfWeek.Saturday || dayOfWeek == DayOfWeek.Sunday;
        }

        public override bool Equals(object obj)
        {
            var other = (CalendarPageDay)obj;
            return other.Number == Number && other.DayOfWeek == DayOfWeek && other.IsHoliday == IsHoliday && other.IsSelected == IsSelected;
        }

        public override int GetHashCode()
        {
            return Number ^ (int)DayOfWeek;
        }
    }
}
