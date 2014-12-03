using System;
using System.Globalization;
using NUnit.Framework;
using Calendar_v3_.CultureUtils;

namespace CalendarTests
{
    [TestFixture]
    public class CultureHelperTests
    {
        [Test]
        public void CultureHelper_ForRussianCulture_ReturnsCorrectProperties()
        {
            var cultureHelper = new CultureHelper(new CultureInfo("ru-ru"));
            
            Assert.That(cultureHelper.FirstDayOfWeek, Is.EqualTo(DayOfWeek.Monday));
            Assert.That(cultureHelper.LastDayOfWeek, Is.EqualTo(DayOfWeek.Sunday));
        }

        [Test]
        public void CultureHelper_ForInvariantCulture_ReturnsCorrectProperties()
        {
            var cultureHelper = new CultureHelper(CultureInfo.InvariantCulture);
            
            Assert.That(cultureHelper.FirstDayOfWeek, Is.EqualTo(DayOfWeek.Sunday));
            Assert.That(cultureHelper.LastDayOfWeek, Is.EqualTo(DayOfWeek.Saturday));
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
            var cultureHelper = new CultureHelper(new CultureInfo("ru-ru"));

            Assert.That(cultureHelper.GetOffsetDayOfWeek(dayOfWeek), Is.EqualTo(expectedOffset));
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
            var cultureHelper = new CultureHelper(CultureInfo.InvariantCulture);

            Assert.That(cultureHelper.GetOffsetDayOfWeek(dayOfWeek), Is.EqualTo(expectedOffset));
        }

        [TestCase(DayOfWeek.Monday, 2)]
        [TestCase(DayOfWeek.Tuesday, 3)]
        [TestCase(DayOfWeek.Wednesday, 4)]
        [TestCase(DayOfWeek.Thursday, 5)]
        [TestCase(DayOfWeek.Friday, 6)]
        [TestCase(DayOfWeek.Saturday, 0)]
        [TestCase(DayOfWeek.Sunday, 1)]
        public void GetOffsetDayOfWeek_ForPersianIran_ReturnsCorrectOffset(DayOfWeek dayOfWeek, int expectedOffset)
        {
            var cultureHelper = new CultureHelper(new CultureInfo("fa-IR"));

            Assert.That(cultureHelper.GetOffsetDayOfWeek(dayOfWeek), Is.EqualTo(expectedOffset));
        }
    }
}
