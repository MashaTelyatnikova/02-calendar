using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Calendar_v2_
{
    public static class Months
    {
        private static readonly Dictionary<int, string> MonthNameOfNumber = new Dictionary<int, string>()
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

        public static string GetMonthName(int number)
        {
            if (MonthNameOfNumber.ContainsKey(number))
                return MonthNameOfNumber[number];

            throw new ArgumentException("Incorrect number months");
        }
    }
}
