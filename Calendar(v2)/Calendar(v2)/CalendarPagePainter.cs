using System;
using System.Collections.Generic;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Calendar_v2_
{
    public static class CalendarPagePainter
    {
        private const int CalendarPageWidth = 900;
        private const int CalendarPageHeight = 500;
        private static readonly Color CalendarBackColor = Color.Lavender;
        private static readonly Color SelectionColor = Color.HotPink;
        private const int StartX = 150;
        private const int StartY = 150;
        private const int CellWidth = 100;
        private const int CellHeight = 50;
        private const int SelectionWidth = 45;
        private const int SelectionHeight = 40;
        private static readonly Font TextFont = new Font("Arial", 20);
        private static readonly Brush TextBrush = new SolidBrush(Color.Black);
        private static readonly Pen BoundaryPen = Pens.Black;
        private static readonly Color HolidayColor = Color.Red;
        private static readonly Color WeekdayColor = Color.Blue;
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
            var graphics = Graphics.FromImage(calendarImage);
            graphics.Clear(CalendarBackColor);

            DrawAnimal(graphics, calendarPage.Animal);
            DrawHeader(graphics, calendarPage.Year, calendarPage.Month);
            DrawWeekDays(graphics);
            DrawCalendarPageLines(graphics, calendarPage.CalendarPageLines);
            SelectDay(calendarPage.SelectedDay, calendarPage.SelectedDayLineNumber, graphics);

            return calendarImage;
        }

        private static void DrawAnimal(Graphics graphics, EasternHoroscopeAnimals animal)
        {
            graphics.DrawImage(ImageOfAnimal[animal], 0, 0);
        }

        private static void DrawHeader(Graphics graphics, int year, int month)
        {
            graphics.DrawRectangle(BoundaryPen, StartX, StartY - CellHeight, 7 * CellWidth, CellHeight);

            graphics.DrawString(Months.GetMonthName(month) + " " + year,
                            TextFont,
                            TextBrush,
                            StartX,
                            StartY - CellHeight
                           );
        }

        private static void DrawWeekDays(Graphics graphics)
        {
            var weekDays = new[] { "Mon", "Tue", "Wed", "Thu", "Fri", "Sat", "Sun" };
            for (var i = 0; i < weekDays.Count(); ++i)
            {
                graphics.DrawRectangle(BoundaryPen, StartX + i * CellWidth, StartY, CellWidth, CellHeight);
                graphics.DrawString(weekDays[i], TextFont, TextBrush, StartX + i * CellWidth, StartY);
            }
        }

        private static void DrawCalendarPageLines(Graphics graphics, IEnumerable<CalendarPageLine> calendarPageLines )
        {
            var lines = calendarPageLines.ToList();
            foreach (var pageLine in lines)
                DrawCalendarPageLine(pageLine,  graphics);
        }

        private static void DrawCalendarPageLine(CalendarPageLine calendarPageLine, Graphics graphics)
        {
            var line = calendarPageLine.GetDays();
            foreach (var day in line)
            {
                var offset = (int)day.DayOfWeek == 0 ? 6 : (int)day.DayOfWeek - 1;
                DrawDay(day, StartX + offset * CellWidth, StartY + calendarPageLine.Number * CellHeight, graphics);
            }
        }

        private static void DrawDay(Day day, int x, int y, Graphics graphics)
        {
            graphics.DrawString(day.Number.ToString(), TextFont, new SolidBrush(GetColorDayOfWeek(day.DayOfWeek)), x, y);
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
