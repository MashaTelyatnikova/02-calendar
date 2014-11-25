using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Calendar_v2_
{
    public static class EasternHoroscope
    {
        private const int StartYear = 1948;
        public static EasternHoroscopeAnimals GetAnimalOfYear(int year)
        {
            var result = 0;
            while (year != StartYear)
            {
                if (year <= StartYear)
                {
                    result = ((((result - 1) % 12) + 12) % 12);
                    year++;
                }
                else
                {
                    result = ((result + 1) % 12);
                    year--;
                }
            }
            return (EasternHoroscopeAnimals)result;
        }
    }
}
