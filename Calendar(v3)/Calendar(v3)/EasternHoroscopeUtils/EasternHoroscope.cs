using System;
using System.Collections.Generic;
using System.Drawing;
using Calendar_v3_.EasternHoroscopeUtils.Enums;

namespace Calendar_v3_.EasternHoroscopeUtils
{
    public static class EasternHoroscope
    {
        private const int StartYear = 1948;
        private static readonly Dictionary<EasternHoroscopeAnimals, Image> ImageOfAnimal = new Dictionary<EasternHoroscopeAnimals, Image>()
        {
            {EasternHoroscopeAnimals.Bull, EasternHoroscopeResources.bull},
            {EasternHoroscopeAnimals.Cock, EasternHoroscopeResources.cock},
            {EasternHoroscopeAnimals.Dog, EasternHoroscopeResources.dog},
            {EasternHoroscopeAnimals.Dragon, EasternHoroscopeResources.dragon},
            {EasternHoroscopeAnimals.Horse, EasternHoroscopeResources.horse},
            {EasternHoroscopeAnimals.Monkey, EasternHoroscopeResources.monkey},
            {EasternHoroscopeAnimals.Pig, EasternHoroscopeResources.pig},
            {EasternHoroscopeAnimals.Rabbit, EasternHoroscopeResources.rabbit},
            {EasternHoroscopeAnimals.Rat, EasternHoroscopeResources.rat},
            {EasternHoroscopeAnimals.Sheep, EasternHoroscopeResources.sheep},
            {EasternHoroscopeAnimals.Snake, EasternHoroscopeResources.snake},
            {EasternHoroscopeAnimals.Tiger, EasternHoroscopeResources.tiger}
        };

        public static EasternHoroscopeAnimals GetAnimalOfYear(int year)
        {
            var difference = Math.Abs(StartYear - year) % 12;
            if (year <= StartYear)
                return (EasternHoroscopeAnimals)((12 - difference) % 12);
            return (EasternHoroscopeAnimals)(difference % 12);
        }

        public static Image GetImageOfAnimal(EasternHoroscopeAnimals animal)
        {
            return ImageOfAnimal[animal];
        }
    }
}
