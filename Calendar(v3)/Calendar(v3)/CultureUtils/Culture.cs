using System;
using System.Globalization;

namespace Calendar_v3_.CultureUtils
{
    public class Culture
    {
        private readonly CultureInfo cultureInfo;
        public DayOfWeek FirstDayOfWeek { get; private set; }
        public DayOfWeek LastDayOfWeek { get; private set; }

        public Culture(CultureInfo cultureInfo)
        {
            this.cultureInfo = cultureInfo;
            
            FirstDayOfWeek = GetFirstDayOfWeek();
            LastDayOfWeek = GetLastDayOfWeek();
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
            var offset = 0;
            for (var day = FirstDayOfWeek; day != dayOfWeek; day = (DayOfWeek)(((int)(day) + 1) % 7))
            {
                ++offset;
            }
            return offset;
        }

        private DayOfWeek GetFirstDayOfWeek()
        {
            return cultureInfo.DateTimeFormat.FirstDayOfWeek;
        }

        private DayOfWeek GetLastDayOfWeek()
        {
            return (DayOfWeek)(((int)FirstDayOfWeek + 6) % 7);
        }
    }
}
