using System;
using System.Globalization;

namespace Calendar_v3_.CultureUtils
{
    public class CultureHelper
    {
        private readonly CultureInfo cultureInfo;

        public DayOfWeek FirstDayOfWeek
        {
            get { return cultureInfo.DateTimeFormat.FirstDayOfWeek; } 
        }

        public DayOfWeek LastDayOfWeek
        {
            get
            {
                return (DayOfWeek)(((int)FirstDayOfWeek + 6) % 7);
            }
        }

        public CultureHelper(CultureInfo cultureInfo)
        {
            this.cultureInfo = cultureInfo;
        }

        public string GetAbbreviatedDayName(DayOfWeek dayOfWeek)
        {
            return cultureInfo.DateTimeFormat.GetAbbreviatedDayName(dayOfWeek);
        }

        public string GetMonthName(int monthNumber)
        {
            return cultureInfo.DateTimeFormat.GetMonthName(monthNumber);
        }

        public int GetOffsetDayOfWeek(DayOfWeek dayOfWeek)
        {
            var offset = (7 - (int) LastDayOfWeek + (int) dayOfWeek)%7 - 1;
            return dayOfWeek == LastDayOfWeek ? 6 : offset;
        }
    }
}
