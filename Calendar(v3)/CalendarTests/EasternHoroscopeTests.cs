using Calendar_v3_.EasternHoroscope;
using Calendar_v3_.EasternHoroscope.Enums;
using NUnit.Framework;

namespace CalendarTests
{
    [TestFixture]
    public class EasternHoroscopeTests
    {
        [TestCase(1900, EasternHoroscopeAnimals.Rat)]
        [TestCase(1948, EasternHoroscopeAnimals.Rat)]
        [TestCase(1968, EasternHoroscopeAnimals.Monkey)]
        [TestCase(1926, EasternHoroscopeAnimals.Tiger)]
        [TestCase(2014, EasternHoroscopeAnimals.Horse)]
        [TestCase(2015, EasternHoroscopeAnimals.Sheep)]
        [TestCase(2000, EasternHoroscopeAnimals.Dragon)]
        public void GetAnimalOfYear_ForRandomYear_ReturnsCorrectAnimal(int year, EasternHoroscopeAnimals expectedAnimal)
        {
            Assert.That(EasternHoroscope.GetAnimalOfYear(year), Is.EqualTo(expectedAnimal));
        }
    }
}
