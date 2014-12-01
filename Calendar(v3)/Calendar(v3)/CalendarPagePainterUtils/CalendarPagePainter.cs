using System;
using System.Collections.Generic;
using System.Drawing;
using System.Globalization;
using Calendar_v3_.CalendarPageUtils;
using Calendar_v3_.EasternHoroscope.Enums;

namespace Calendar_v3_.CalendarPagePainterUtils
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
            {EasternHoroscopeAnimals.Bull, CalendarPagePainterResources.bull},
            {EasternHoroscopeAnimals.Cock, CalendarPagePainterResources.cock},
            {EasternHoroscopeAnimals.Dog, CalendarPagePainterResources.dog},
            {EasternHoroscopeAnimals.Dragon, CalendarPagePainterResources.dragon},
            {EasternHoroscopeAnimals.Horse, CalendarPagePainterResources.horse},
            {EasternHoroscopeAnimals.Monkey, CalendarPagePainterResources.monkey},
            {EasternHoroscopeAnimals.Pig, CalendarPagePainterResources.pig},
            {EasternHoroscopeAnimals.Rabbit, CalendarPagePainterResources.rabbit},
            {EasternHoroscopeAnimals.Rat, CalendarPagePainterResources.rat},
            {EasternHoroscopeAnimals.Sheep, CalendarPagePainterResources.sheep},
            {EasternHoroscopeAnimals.Snake, CalendarPagePainterResources.snake},
            {EasternHoroscopeAnimals.Tiger, CalendarPagePainterResources.tiger}
        };

        public static Bitmap Paint(CalendarPage calendarPage)
        {
            var calendarPageImage = new Bitmap(CalendarPageWidth, CalendarPageHeight);
            using (var calendarPageGraphics = Graphics.FromImage(calendarPageImage))
            {
                DrawCalendarPage(calendarPage, calendarPageGraphics);
            }
            
            return calendarPageImage;
        }

        private static void DrawCalendarPage(CalendarPage calendarPage, Graphics calendarPageGraphics)
        {
            DrawBackground(calendarPageGraphics);
            DrawAnimal(EasternHoroscope.EasternHoroscope.GetAnimalOfYear(calendarPage.Year), calendarPageGraphics);
            DrawHeader(calendarPage.GetHeader(), calendarPageGraphics);
            DrawWeekDays(calendarPageGraphics);
            DrawDays(calendarPage.Days, calendarPageGraphics);
        }

        private static void DrawBackground(Graphics calendarPageGraphics)
        {
            calendarPageGraphics.Clear(CalendarBackColor);
        }

        private static void DrawAnimal(EasternHoroscopeAnimals animal, Graphics calendarPageGraphics)
        {
            calendarPageGraphics.DrawImage(ImageOfAnimal[animal], AnimalLocation);
        }

        private static void DrawHeader(string header, Graphics caledarPageGraphics)
        {
            caledarPageGraphics.DrawString(
                            header,
                            HeaderFont,
                            TextBrush,
                            StartX,
                            StartY - CellHeight
                           );
        }

        private static void DrawWeekDays(Graphics calendarPageGraphics)
        {
            for (var dayOfWeekNumber = 0; dayOfWeekNumber < 7; ++dayOfWeekNumber)
            {
                var dayOfWeek = (DayOfWeek)dayOfWeekNumber;
                var offset = GetOffsetDayOfWeek(dayOfWeek);
                calendarPageGraphics.DrawString(
                                                DateTimeFormatInfo.InvariantInfo.GetAbbreviatedDayName(dayOfWeek),
                                                TextFont,
                                                TextBrush,
                                                StartX + offset * CellWidth,
                                                StartY);
            }
        }

        private static void DrawDays(IEnumerable<CalendarPageDay> days, Graphics calendarPageGraphics)
        {
            var verticalOffset = 1;
            foreach (var day in days)
            {
                DrawDay(day, verticalOffset, calendarPageGraphics);
                if (day.DayOfWeek == GetLastDayOfWeek())
                    verticalOffset++;
            }
        }

        private static void DrawDay(CalendarPageDay day, int verticalOffset, Graphics calendarPageGraphics)
        {
            var horizontalOffset = GetOffsetDayOfWeek(day.DayOfWeek);

            if (day.IsSelected)
                calendarPageGraphics.FillEllipse(new SolidBrush(SelectionColor),
                                            StartX + horizontalOffset * CellWidth,
                                            StartY + verticalOffset * CellHeight,
                                            SelectionWidth,
                                            SelectionHeight
                                          );

            calendarPageGraphics.DrawString(day.Number.ToString(CultureInfo.InvariantCulture),
                            DayFont,
                            new SolidBrush(GetColorDayOfWeek(day)),
                            StartX + horizontalOffset * CellWidth,
                            StartY + verticalOffset * CellHeight);
        }

        private static DayOfWeek GetFirstDayOfWeek()
        {
            return DateTimeFormatInfo.CurrentInfo != null
                ? DateTimeFormatInfo.CurrentInfo.FirstDayOfWeek
                : DateTimeFormatInfo.InvariantInfo.FirstDayOfWeek;
        }

        private static DayOfWeek GetLastDayOfWeek()
        {
            return (DayOfWeek) (((int) GetFirstDayOfWeek() + 6)%7);
        }

        private static int GetOffsetDayOfWeek(DayOfWeek dayOfWeek)
        {
            var offset = 0;
            for (var day = GetFirstDayOfWeek(); day != dayOfWeek; day = (DayOfWeek) (((int) (day) + 1)%7))
            {
                offset++;
            }

            return offset;
        }

        private static Color GetColorDayOfWeek(CalendarPageDay day)
        {
            return day.IsHoliday ? HolidayColor : WeekdayColor;
        }
    }
}
