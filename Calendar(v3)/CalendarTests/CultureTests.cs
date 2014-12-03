using System;
using System.Globalization;
using NUnit.Framework;
using Calendar_v3_.CultureUtils;

namespace CalendarTests
{
    [TestFixture]
    public class CultureTests
    {
        [Test]
        public void Culture_ForRussianCulture_ReturnsCorrectProperties()
        {
            var culture = new Culture(new CultureInfo("ru-ru"));
            
            Assert.That(culture.FirstDayOfWeek, Is.EqualTo(DayOfWeek.Monday));
            Assert.That(culture.LastDayOfWeek, Is.EqualTo(DayOfWeek.Sunday));
        }

        [Test]
        public void Culture_ForInvariantCulture_ReturnsCorrectProperties()
        {
            var culture = new Culture(CultureInfo.InvariantCulture);
            
            Assert.That(culture.FirstDayOfWeek, Is.EqualTo(DayOfWeek.Sunday));
            Assert.That(culture.LastDayOfWeek, Is.EqualTo(DayOfWeek.Saturday));
        }

        [TestCase(DayOfWeek.Monday, 0)]
        [TestCase(DayOfWeek.Tuesday, 1)]
        [TestCase(DayOfWeek.Wednesday, 2)]
        [TestCase(DayOfWeek.Thursday, 3)]
        [TestCase(DayOfWeek.Friday, 4)]
        [TestCase(DayOfWeek.Saturday, 5)]
        [TestCase(DayOfWeek.Sunday, 6)]
        public void GetOffsetDayOfWeek_ForRussianCulture_ReturnsCorrectOffset(DayOfWeek dayOfWeek, int expectedOffset)
        {
            var culture = new Culture(new CultureInfo("ru-ru"));

            Assert.That(expectedOffset, Is.EqualTo(culture.GetOffsetDayOfWeek(dayOfWeek)));
        }

        [TestCase(DayOfWeek.Monday, 1)]
        [TestCase(DayOfWeek.Tuesday, 2)]
        [TestCase(DayOfWeek.Wednesday, 3)]
        [TestCase(DayOfWeek.Thursday, 4)]
        [TestCase(DayOfWeek.Friday, 5)]
        [TestCase(DayOfWeek.Saturday, 6)]
        [TestCase(DayOfWeek.Sunday, 0)]
        public void GetOffsetDayOfWeek_ForInvariantCulture_ReturnsCorrectOffset(DayOfWeek dayOfWeek, int expectedOffset)
        {
            var culture = new Culture(CultureInfo.InvariantCulture);

            Assert.That(expectedOffset, Is.EqualTo(culture.GetOffsetDayOfWeek(dayOfWeek)));
        }
    }
}
