using System;
using System.Linq;
using Calendar_v2_;
using NUnit.Framework;

namespace CalendarTests
{
    [TestFixture]
    public static class CalendarPage_Test
    {
        [Test]
        public static void Test1()
        {
            var calendarPage = new CalendarPage(new DateTime(2014, 11, 28));
           
            Assert.That(calendarPage.Animal, Is.EqualTo(EasternHoroscopeAnimals.Horse));
            Assert.That(calendarPage.Year, Is.EqualTo(2014));
            Assert.That(calendarPage.Month, Is.EqualTo(11));
            Assert.That(calendarPage.SelectedDay, Is.EqualTo(new Day(28, DayOfWeek.Friday)));
            Assert.That(calendarPage.SelectedDayLineNumber, Is.EqualTo(5));
            Assert.That(calendarPage.CalendarPageLines.Count, Is.EqualTo(5));
            Assert.That(TestPageLine(calendarPage.CalendarPageLines[0], 1, DayOfWeek.Saturday, 2));
            Assert.That(TestPageLine(calendarPage.CalendarPageLines[1], 3, DayOfWeek.Monday, 7));
            Assert.That(TestPageLine(calendarPage.CalendarPageLines[2], 10, DayOfWeek.Monday, 7));
            Assert.That(TestPageLine(calendarPage.CalendarPageLines[3], 17, DayOfWeek.Monday, 7));
            Assert.That(TestPageLine(calendarPage.CalendarPageLines[4], 24, DayOfWeek.Monday, 7));
            
        }

        [Test]
        public static void Test2()
        {
            var calendarPage = new CalendarPage(new DateTime(2014, 12, 28));

            Assert.That(calendarPage.Animal, Is.EqualTo(EasternHoroscopeAnimals.Horse));
            Assert.That(calendarPage.Year, Is.EqualTo(2014));
            Assert.That(calendarPage.Month, Is.EqualTo(12));
            Assert.That(calendarPage.SelectedDay, Is.EqualTo(new Day(28, DayOfWeek.Sunday)));
            Assert.That(calendarPage.SelectedDayLineNumber, Is.EqualTo(4));
            Assert.That(calendarPage.CalendarPageLines.Count, Is.EqualTo(5));
            Assert.That(TestPageLine(calendarPage.CalendarPageLines[0], 1, DayOfWeek.Monday, 7));
            Assert.That(TestPageLine(calendarPage.CalendarPageLines[1], 8, DayOfWeek.Monday, 7));
            Assert.That(TestPageLine(calendarPage.CalendarPageLines[2], 15, DayOfWeek.Monday, 7));
            Assert.That(TestPageLine(calendarPage.CalendarPageLines[3], 22, DayOfWeek.Monday, 7));
            Assert.That(TestPageLine(calendarPage.CalendarPageLines[4], 29, DayOfWeek.Monday, 3));

        }

        [Test]
        public static void Test3()
        {
            var calendarPage = new CalendarPage(new DateTime(2015, 2, 28));

            Assert.That(calendarPage.Animal, Is.EqualTo(EasternHoroscopeAnimals.Sheep));
            Assert.That(calendarPage.Year, Is.EqualTo(2015));
            Assert.That(calendarPage.Month, Is.EqualTo(2));
            Assert.That(calendarPage.SelectedDay, Is.EqualTo(new Day(28, DayOfWeek.Saturday)));
            Assert.That(calendarPage.SelectedDayLineNumber, Is.EqualTo(5));
            Assert.That(calendarPage.CalendarPageLines.Count, Is.EqualTo(5));
            Assert.That(TestPageLine(calendarPage.CalendarPageLines[0], 1, DayOfWeek.Sunday, 1));
            Assert.That(TestPageLine(calendarPage.CalendarPageLines[1], 2, DayOfWeek.Monday, 7));
            Assert.That(TestPageLine(calendarPage.CalendarPageLines[2], 9, DayOfWeek.Monday, 7));
            Assert.That(TestPageLine(calendarPage.CalendarPageLines[3], 16, DayOfWeek.Monday, 7));
            Assert.That(TestPageLine(calendarPage.CalendarPageLines[4], 23, DayOfWeek.Monday, 6));

        }

        [Test]
        public static void Test4()
        {
            var calendarPage = new CalendarPage(new DateTime(2000, 2, 29));

            Assert.That(calendarPage.Animal, Is.EqualTo(EasternHoroscopeAnimals.Dragon));
            Assert.That(calendarPage.Year, Is.EqualTo(2000));
            Assert.That(calendarPage.Month, Is.EqualTo(2));
            Assert.That(calendarPage.SelectedDay, Is.EqualTo(new Day(29, DayOfWeek.Tuesday)));
            Assert.That(calendarPage.SelectedDayLineNumber, Is.EqualTo(5));
            Assert.That(calendarPage.CalendarPageLines.Count, Is.EqualTo(5));
            Assert.That(TestPageLine(calendarPage.CalendarPageLines[0], 1, DayOfWeek.Tuesday, 6));
            Assert.That(TestPageLine(calendarPage.CalendarPageLines[1], 7, DayOfWeek.Monday, 7));
            Assert.That(TestPageLine(calendarPage.CalendarPageLines[2], 14, DayOfWeek.Monday, 7));
            Assert.That(TestPageLine(calendarPage.CalendarPageLines[3], 21, DayOfWeek.Monday, 7));
            Assert.That(TestPageLine(calendarPage.CalendarPageLines[4], 28, DayOfWeek.Monday, 2));

        }

        private static bool TestPageLine(CalendarPageLine actual, int startDay, DayOfWeek startDayOfWeek, int expectedCount)
        {
            var days = actual.GetDays().ToList();
            if (expectedCount != days.Count) return false;
            for (var i = 0; i < days.Count(); ++i)
            {
                if (days[i].Number != startDay || days[i].DayOfWeek != startDayOfWeek)
                    return false;
                startDay++;
                startDayOfWeek = (DayOfWeek)(((int)startDayOfWeek + 1)% 7);
            }

            return true;
        }
    }
}
