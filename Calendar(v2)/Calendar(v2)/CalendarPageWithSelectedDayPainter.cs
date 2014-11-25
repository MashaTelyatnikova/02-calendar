using System;
using System.Collections.Generic;
using System.Drawing;
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
        private readonly Dictionary<EasternHoroscopeAnimals, string> imageOfAnimal = new Dictionary<EasternHoroscopeAnimals, string>()
        {
            {EasternHoroscopeAnimals.Bull, "img/bull.png"},
            {EasternHoroscopeAnimals.Cock, "img/cock.png"},
            {EasternHoroscopeAnimals.Dog, "img/dog.png"},
            {EasternHoroscopeAnimals.Dragon, "img/dragon.png"},
            {EasternHoroscopeAnimals.Horse, "img/horse.png"},
            {EasternHoroscopeAnimals.Monkey, "img/monkey.png"},
            {EasternHoroscopeAnimals.Pig, "img/pig.png"},
            {EasternHoroscopeAnimals.Rabbit, "img/rabbit.png"},
            {EasternHoroscopeAnimals.Rat, "img/rat.png"},
            {EasternHoroscopeAnimals.Sheep, "img/sheep.png"},
            {EasternHoroscopeAnimals.Snake, "img/snake.png"},
            {EasternHoroscopeAnimals.Tiger, "img/tiger.png"}
        };

        public CalendarPageWithSelectedDayPainter(CalendarPage calendarPage, int selectedDay)
        {
            this.calendarPage = calendarPage;
            this.selectedDay = selectedDay;
        }
    }
}
