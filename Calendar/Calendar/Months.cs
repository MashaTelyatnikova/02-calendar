using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Calendar
{
    public static class Months
    {
        private static readonly Dictionary<int, string> MonthsNameFromCode = new Dictionary<int, string>()
        {
            {1, "January"},
            {2, "February"},
            {3, "March"},
            {4, "April"},
            {5, "May"},
            {6, "June"},
            {7, "July"},
            {8, "August"},
            {9, "September"},
            {10, "October"},
            {11, "November"},
            {12, "December"}
        };

        public static string GetNameMonthFromCode(int code)
        {
            if (MonthsNameFromCode.ContainsKey(code))
                return MonthsNameFromCode[code];

            throw new ArgumentException("Incorrect code months");
        }
    }
}
