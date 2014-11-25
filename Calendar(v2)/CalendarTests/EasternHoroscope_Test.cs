using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Calendar_v2_;
using NUnit.Framework;

namespace CalendarTests
{
    [TestFixture]
    public static class EasternHoroscope_Test
    {
        [TestCase(1900, EasternHoroscopeAnimals.Rat)]
        [TestCase(1948, EasternHoroscopeAnimals.Rat)]
        [TestCase(1968, EasternHoroscopeAnimals.Monkey)]
        [TestCase(1926, EasternHoroscopeAnimals.Tiger)]
        [TestCase(2014, EasternHoroscopeAnimals.Horse)]
        [TestCase(2015, EasternHoroscopeAnimals.Sheep)]
        [TestCase(2000, EasternHoroscopeAnimals.Dragon)]
        public static void GetAnimalOfYear_Test(int year, EasternHoroscopeAnimals expectedAnimal)
        {
            Assert.That(EasternHoroscope.GetAnimalOfYear(year), Is.EqualTo(expectedAnimal));
        }
    }
}
