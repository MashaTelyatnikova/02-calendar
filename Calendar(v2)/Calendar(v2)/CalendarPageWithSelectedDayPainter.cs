using System;
using System.Collections.Generic;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Calendar_v2_
{
    public class CalendarPageWithSelectedDayPainter
    {
        private readonly CalendarPage calendarPage;
        private readonly int selectedDay;
        private const int CalendarPageWidth = 900;
        private const int CalendarPageHeight = 500;
        private readonly Color calendarBackColor = Color.Lavender;
        private readonly Color selectionColor = Color.HotPink;
        private const int StartX = 150;
        private const int StartY = 150;
        private const int CellWidth = 100;
        private const int CellHeight = 50;
        private const int SelectionWidth = 45;
        private const int SelectionHeight = 40;
        private readonly Font textFont = new Font("Arial", 20);
        private readonly Brush textBrush = new SolidBrush(Color.Black);
        private readonly Pen boundaryPen = Pens.Black;
        private readonly Color holidayColor = Color.Red;
        private readonly Color weekdayColor = Color.Blue;
        private readonly Dictionary<EasternHoroscopeAnimals, Image> imageOfAnimal = new Dictionary<EasternHoroscopeAnimals, Image>()
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

        public CalendarPageWithSelectedDayPainter(CalendarPage calendarPage, int selectedDay)
        {
            this.calendarPage = calendarPage;
            this.selectedDay = selectedDay;
        }

        public Image Paint()
        {
            var calendarImage = new Bitmap(CalendarPageWidth, CalendarPageHeight);
            var graphics = Graphics.FromImage(calendarImage);
            graphics.Clear(calendarBackColor);

            DrawAnimal(graphics);
            DrawHeader(graphics);
            DrawWeekDays(graphics);
            DrawCalendarPageLines(graphics);

            return calendarImage;
        }

        private void DrawAnimal(Graphics graphics)
        {
            var animal = EasternHoroscope.GetAnimalOfYear(calendarPage.Year);
            graphics.DrawImage(imageOfAnimal[animal], 0, 0);
        }

        private void DrawHeader(Graphics graphics)
        {
            graphics.DrawRectangle(boundaryPen, StartX, StartY - CellHeight, 7 * CellWidth, CellHeight);

            graphics.DrawString(Months.GetMonthName(calendarPage.Month) + " " + calendarPage.Year,
                            textFont,
                            textBrush,
                            StartX,
                            StartY - CellHeight
                           );
        }

        private void DrawWeekDays(Graphics graphics)
        {
            var weekDays = new[] { "Mon", "Tue", "Wed", "Thu", "Fri", "Sat", "Sun" };
            for (var i = 0; i < weekDays.Count(); ++i)
            {
                graphics.DrawRectangle(boundaryPen, StartX + i * CellWidth, StartY, CellWidth, CellHeight);
                graphics.DrawString(weekDays[i], textFont, textBrush, StartX + i * CellWidth, StartY);
            }
        }

        private void DrawCalendarPageLines(Graphics graphics)
        {
            var lines = calendarPage.GetCalendarPageLines().ToList();
            for (var i = 0; i < lines.Count; ++i)
                DrawCalendarPageLine(lines[i], i + 1, graphics);

        }

        private void DrawCalendarPageLine(CalendarPageLine calendarPageLine, int number, Graphics graphics)
        {
            var line = calendarPageLine.GetDays();
            foreach (var day in line)
            {
                var offset = (int)day.DayOfWeek == 0 ? 6 : (int)day.DayOfWeek - 1;
                if (day.Number == selectedDay)
                    graphics.FillEllipse(new SolidBrush(selectionColor),
                                            StartX + offset * CellWidth,
                                            StartY + number * CellHeight,
                                            SelectionWidth,
                                            SelectionHeight
                                          );

                graphics.DrawString(day.Number.ToString(CultureInfo.InvariantCulture),
                                    textFont,
                                    new SolidBrush(GetColorDayOfWeek(day.DayOfWeek)),
                                    StartX + offset * CellWidth,
                                    StartY + number * CellHeight);
            }
        }

        private Color GetColorDayOfWeek(DayOfWeek dayOfWeek)
        {
            return dayOfWeek == DayOfWeek.Saturday || dayOfWeek == DayOfWeek.Sunday ? holidayColor : weekdayColor;
        }
    }
}
