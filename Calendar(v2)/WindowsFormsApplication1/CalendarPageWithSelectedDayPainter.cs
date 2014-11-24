using System;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Windows.Forms;

namespace WindowsFormsApplication1
{
    public partial class CalendarPageWithSelectedDayPainter : Form
    {
        private readonly CalendarPage calendarPage;
        private readonly int selectedDay;
        private const int CalendarPageWidth = 800;
        private const int CalendarPageHeight = 500;
        private readonly Color calendarBackColor = Color.Lavender;
        private readonly Color selectionColor = Color.HotPink;
        private const int StartX = 50;
        private const int StartY = 100;
        private const int CellWidth = 100;
        private const int CellHeight = 50;
        private const int SelectionWidth = 45;
        private const int SelectionHeight = 40;
        private readonly Font textFont = new Font("Arial", 20);
        private readonly Brush textBrush = new SolidBrush(Color.Black);
        private readonly Pen boundaryPen = Pens.Black;
        private readonly Color holidayColor = Color.Red;
        private readonly Color weekdayColor = Color.Blue;

        public CalendarPageWithSelectedDayPainter(CalendarPage calendarPage, int selectedDay)
        {
            this.calendarPage = calendarPage;
            this.selectedDay = selectedDay;

            InitializeComponent();
            calendarBox.Size = new Size(CalendarPageWidth, CalendarPageHeight);
            Draw();
        }

        private void Draw()
        {
            var calendarImage = new Bitmap(CalendarPageWidth, CalendarPageHeight);
            var graphics = Graphics.FromImage(calendarImage);
            graphics.Clear(calendarBackColor);

            DrawHeader(graphics);
            DrawWeekDays(graphics);
            DrawCalendarPageLines(graphics);

            ShowCalendarImage(calendarImage);
        }

        private void DrawHeader(Graphics gr)
        {
            gr.DrawRectangle(boundaryPen, StartX, StartY - CellHeight, 7 * CellWidth, CellHeight);
            
            gr.DrawString(Months.GetMonthName(calendarPage.Month) + " " + calendarPage.Year,
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

        private void DrawCalendarPageLines(Graphics gr)
        {
            var lines = calendarPage.GetCalendarPageLines().ToList();
            for (var i = 0; i < lines.Count; ++i)
                DrawCalendarPageLine(lines[i], i + 1, gr);

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

        private void ShowCalendarImage(Image calendar)
        {
            calendarBox.Image = calendar;
        }
    }
}
