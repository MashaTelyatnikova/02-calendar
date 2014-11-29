using System;
using System.Collections.Generic;
using System.Drawing;
using System.Globalization;

namespace Calendar_v2_
{
    public static class CalendarPagePainter
    {
        private const int CalendarPageWidth = 900;
        private const int CalendarPageHeight = 500;
        private static readonly Color CalendarBackColor = Color.FromArgb(240, 248, 255);
        private static readonly Color SelectionColor = Color.FromArgb(121, 205, 205);
        private const int StartX = 150;
        private const int StartY = 150;
        private const int CellWidth = 100;
        private const int CellHeight = 50;
        private const int SelectionWidth = 45;
        private const int SelectionHeight = 40;
        private static readonly Font TextFont = new Font("Arial", 17);
        private static readonly Brush TextBrush = new SolidBrush(Color.FromArgb(0, 104, 139));
        private static readonly Font DayFont = new Font("Arial", 23);
        private static readonly Font HeaderFont = new Font("Arial", 23);
        private static readonly Color HolidayColor = Color.Red;
        private static readonly Color WeekdayColor = Color.FromArgb(0, 104, 139);
        private static readonly PointF AnimalLocation = new PointF(0, 0);
        private static readonly Dictionary<EasternHoroscopeAnimals, Image> ImageOfAnimal = new Dictionary<EasternHoroscopeAnimals, Image>()
        {
            {EasternHoroscopeAnimals.Bull, CalendarResources.bull},
            {EasternHoroscopeAnimals.Cock, CalendarResources.cock},
            {EasternHoroscopeAnimals.Dog, CalendarResources.dog},
            {EasternHoroscopeAnimals.Dragon, CalendarResources.dragon},
            {EasternHoroscopeAnimals.Horse, CalendarResources.horse},
            {EasternHoroscopeAnimals.Monkey, CalendarResources.monkey},
            {EasternHoroscopeAnimals.Pig, CalendarResources.pig},
            {EasternHoroscopeAnimals.Rabbit, CalendarResources.rabbit},
            {EasternHoroscopeAnimals.Rat, CalendarResources.rat},
            {EasternHoroscopeAnimals.Sheep, CalendarResources.sheep},
            {EasternHoroscopeAnimals.Snake, CalendarResources.snake},
            {EasternHoroscopeAnimals.Tiger, CalendarResources.tiger}
        };

        public static Image Paint(CalendarPage calendarPage)
        {
            var calendarImage = new Bitmap(CalendarPageWidth, CalendarPageHeight);
            var graphics = GetStartCalendarPageGraphics(calendarImage);

            DrawAnimal(graphics, calendarPage.Animal);
            DrawHeader(graphics, calendarPage.Year, calendarPage.Month);
            DrawWeekDays(graphics);
            DrawCalendarPageLines(graphics, calendarPage.CalendarPageLines);
            SelectDay(calendarPage.SelectedDay, calendarPage.SelectedDayLineNumber, graphics);

            return calendarImage;
        }

        private static Graphics GetStartCalendarPageGraphics(Image calendarPageImage)
        {
            var graphics = Graphics.FromImage(calendarPageImage);
            graphics.Clear(CalendarBackColor);
            return graphics;
        }

        private static void DrawAnimal(Graphics graphics, EasternHoroscopeAnimals animal)
        {
            graphics.DrawImage(ImageOfAnimal[animal], AnimalLocation);
        }

        private static void DrawHeader(Graphics graphics, int year, int month)
        {
            graphics.DrawString(DateTimeFormatInfo.InvariantInfo.GetMonthName(month) + " " + year,
                            HeaderFont,
                            TextBrush,
                            StartX,
                            StartY - CellHeight
                           );
        }

        private static void DrawWeekDays(Graphics graphics)
        {
            var weekDays = DateTimeFormatInfo.InvariantInfo.AbbreviatedDayNames;
            for (var i = 1; i <= 7; ++i)
                graphics.DrawString(weekDays[i % 7], TextFont, TextBrush, StartX + (i - 1) * CellWidth, StartY);
        }

        private static void DrawCalendarPageLines(Graphics graphics, IEnumerable<CalendarPageLine> calendarPageLines)
        {
            foreach (var pageLine in calendarPageLines)
                DrawCalendarPageLine(pageLine, graphics);
        }

        private static void DrawCalendarPageLine(CalendarPageLine calendarPageLine, Graphics graphics)
        {
            foreach (var day in calendarPageLine.GetDays())
            {
                var offset = (int)day.DayOfWeek == 0 ? 6 : (int)day.DayOfWeek - 1;
                DrawDay(day, StartX + offset * CellWidth, StartY + calendarPageLine.Number * CellHeight, graphics);
            }
        }

        private static void DrawDay(Day day, int x, int y, Graphics graphics)
        {
            graphics.DrawString(day.Number.ToString(CultureInfo.InvariantCulture),
                                DayFont,
                                new SolidBrush(GetColorDayOfWeek(day.DayOfWeek)),
                                x,
                                y);
        }

        private static Color GetColorDayOfWeek(DayOfWeek dayOfWeek)
        {
            return dayOfWeek == DayOfWeek.Saturday || dayOfWeek == DayOfWeek.Sunday ? HolidayColor : WeekdayColor;
        }

        private static void SelectDay(Day day, int pageLineNumber, Graphics graphics)
        {
            var offset = (int)day.DayOfWeek == 0 ? 6 : (int)day.DayOfWeek - 1;
            graphics.FillEllipse(new SolidBrush(SelectionColor),
                                            StartX + offset * CellWidth,
                                            StartY + pageLineNumber * CellHeight,
                                            SelectionWidth,
                                            SelectionHeight
                                          );
            DrawDay(day, StartX + offset * CellWidth, StartY + pageLineNumber * CellHeight, graphics);
        }
    }
}
