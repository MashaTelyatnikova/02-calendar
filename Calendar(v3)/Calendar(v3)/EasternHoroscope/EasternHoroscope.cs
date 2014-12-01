using System;
using Calendar_v3_.EasternHoroscope.Enums;

namespace Calendar_v3_.EasternHoroscope
{
    public static class EasternHoroscope
    {
        private const int StartYear = 1948;
        public static EasternHoroscopeAnimals GetAnimalOfYear(int year)
        {
            var difference = Math.Abs(StartYear - year) % 12;
            if (year <= StartYear)
                return (EasternHoroscopeAnimals)((12 - difference) % 12);
            return (EasternHoroscopeAnimals)(difference % 12);
        }
    }
}
