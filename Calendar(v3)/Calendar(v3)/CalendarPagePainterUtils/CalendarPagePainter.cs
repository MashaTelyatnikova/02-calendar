using System;
using System.Collections.Generic;
using System.Drawing;
using Calendar_v3_.CalendarPageUtils;
using Calendar_v3_.EasternHoroscopeUtils;
using Calendar_v3_.EasternHoroscopeUtils.Enums;
using Calendar_v3_.CultureUtils;

namespace Calendar_v3_.CalendarPagePainterUtils
{
    public static class CalendarPagePainter
    {
        private const int CalendarPageWidth = 900;
        private const int CalendarPageHeight = 500;
        private const int CellWidth = 90;
        private const int CellHeight = 50;
        private const int SelectionWidth = 45;
        private const int SelectionHeight = 50;

        private static readonly Color CalendarBackColor = Color.FromArgb(240, 248, 255);
        private static readonly Color SelectionColor = Color.FromArgb(121, 205, 205);
        private static readonly Point StartCellLocation = new Point(150, 150);
        private static readonly Font TextFont = new Font("Arial", 17);
        private static readonly Brush TextBrush = new SolidBrush(Color.FromArgb(0, 104, 139));
        private static readonly Font DayFont = new Font("Arial", 23);
        private static readonly Font HeaderFont = new Font("Arial", 23);
        private static readonly Color HolidayColor = Color.Red;
        private static readonly Color WeekdayColor = Color.FromArgb(0, 104, 139);
        private static readonly PointF AnimalLocation = new PointF(0, 0);

        public static Bitmap Paint(CalendarPage calendarPage, Culture culture)
        {
            var calendarPageImage = new Bitmap(CalendarPageWidth, CalendarPageHeight);
            using (var calendarPageGraphics = Graphics.FromImage(calendarPageImage))
            {
                DrawCalendarPage(calendarPage, culture, calendarPageGraphics);
            }
            
            return calendarPageImage;
        }

        private static void DrawCalendarPage(CalendarPage calendarPage, Culture culture, Graphics calendarPageGraphics)
        {
            DrawBackground(calendarPageGraphics);
            DrawAnimal(EasternHoroscope.GetAnimalOfYear(calendarPage.Year), calendarPageGraphics);
            DrawHeader(GetHeader(calendarPage, culture), calendarPageGraphics);
            DrawWeekDays(culture, calendarPageGraphics);
            DrawDays(calendarPage.Days, culture, calendarPageGraphics);
        }

        private static string GetHeader(CalendarPage calendarPage, Culture culture)
        {
            return string.Format("{0}, {1}", culture.GetMonthName(calendarPage.Month), calendarPage.Year);
        }
        private static void DrawBackground(Graphics calendarPageGraphics)
        {
            calendarPageGraphics.Clear(CalendarBackColor);
        }

        private static void DrawAnimal(EasternHoroscopeAnimals animal, Graphics calendarPageGraphics)
        {
            calendarPageGraphics.DrawImage(EasternHoroscope.GetImageOfAnimal(animal), AnimalLocation);
        }

        private static void DrawHeader(string header, Graphics caledarPageGraphics)
        {
            caledarPageGraphics.DrawString(
                            header,
                            HeaderFont,
                            TextBrush,
                            StartCellLocation.X,
                            StartCellLocation.Y - CellHeight
                           );
        }

        private static void DrawWeekDays(Culture culture, Graphics calendarPageGraphics)
        {
            for (var dayOfWeekNumber = 0; dayOfWeekNumber < 7; ++dayOfWeekNumber)
            {
                var dayOfWeek = (DayOfWeek)dayOfWeekNumber;
                var horizontalOffset = culture.GetOffsetDayOfWeek(dayOfWeek);
                calendarPageGraphics.DrawString(
                                                culture.GetAbbreviatedDayName(dayOfWeek),
                                                TextFont,
                                                TextBrush,
                                                StartCellLocation.X + horizontalOffset * CellWidth,
                                                StartCellLocation.Y);
            }
        }

        private static void DrawDays(IEnumerable<CalendarPageDay> days, Culture culture, Graphics calendarPageGraphics)
        {
            var verticalOffset = 1;
            foreach (var day in days)
            {
                var horizontalOffset = culture.GetOffsetDayOfWeek(day.DayOfWeek);
                DrawDay(day, verticalOffset, horizontalOffset, calendarPageGraphics);
                if (day.DayOfWeek == culture.LastDayOfWeek)
                    verticalOffset++;
            }
        }

        private static void DrawDay(CalendarPageDay day, int verticalOffset, int horizontalOffset, Graphics calendarPageGraphics)
        {
            if (day.IsSelected)
                calendarPageGraphics.FillEllipse(new SolidBrush(SelectionColor),
                                            StartCellLocation.X + horizontalOffset * CellWidth,
                                            StartCellLocation.Y + verticalOffset * CellHeight,
                                            SelectionWidth,
                                            SelectionHeight
                                          );

            calendarPageGraphics.DrawString(day.Number+"",
                            DayFont,
                            new SolidBrush(GetColorDayOfWeek(day)),
                            StartCellLocation.X + horizontalOffset * CellWidth,
                            StartCellLocation.Y + verticalOffset * CellHeight);
        }

        private static Color GetColorDayOfWeek(CalendarPageDay day)
        {
            return day.IsHoliday ? HolidayColor : WeekdayColor;
        }
    }
}
