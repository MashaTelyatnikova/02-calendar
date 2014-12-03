using System;
using System.Globalization;

namespace Calendar_v3_.CultureUtils
{
    public class Culture
    {
        private readonly DateTimeFormatInfo cultureInfo;
        private readonly DayOfWeek firstDayOfWeek;
        public Culture(DateTimeFormatInfo cultureInfo)
        {
            this.cultureInfo = cultureInfo;
            firstDayOfWeek = cultureInfo.FirstDayOfWeek;
        }

        public DayOfWeek GetLastDayOfWeek()
        {
            return GetLastDayOfWeek(firstDayOfWeek);
        }

        public string GetAbbreviatedDayName(DayOfWeek dayOfWeek)
        {
            return cultureInfo.GetAbbreviatedDayName(dayOfWeek);
        }

        public string GetMonthName(int monthNumber)
        {
            return cultureInfo.GetMonthName(monthNumber);
        }

        public int GetOffsetDayOfWeek(DayOfWeek dayOfWeek)
        {
            return GetOffsetDayOfWeek(dayOfWeek, firstDayOfWeek);
        }

        public static DayOfWeek GetLastDayOfWeek(DayOfWeek firstDayOfWeek)
        {
            return (DayOfWeek)(((int)firstDayOfWeek + 6) % 7);
        }

        public static int GetOffsetDayOfWeek(DayOfWeek dayOfWeek, DayOfWeek firstDayOfWeek)
        {
            var offset = 0;
            for (var day = firstDayOfWeek; day != dayOfWeek; day = (DayOfWeek)(((int)(day) + 1) % 7))
            {
                ++offset;
            }

            return offset;
        }
    }
}
