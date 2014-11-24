namespace WindowsFormsApplication1
{
    partial class CalendarPageWithSelectedDayPainter
    {
        /// <summary>
        /// Требуется переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором форм Windows

        /// <summary>
        /// Обязательный метод для поддержки конструктора - не изменяйте
        /// содержимое данного метода при помощи редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            this.calendarBox = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.calendarBox)).BeginInit();
            this.SuspendLayout();
            // 
            // calendarBox
            // 
            this.calendarBox.Location = new System.Drawing.Point(0, 0);
            this.calendarBox.Name = "calendarBox";
            this.calendarBox.Size = new System.Drawing.Size(100, 50);
            this.calendarBox.TabIndex = 0;
            this.calendarBox.TabStop = false;
            // 
            // CalendarPageWithSelectedDayPainter
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 500);
            this.Controls.Add(this.calendarBox);
            this.Name = "CalendarPageWithSelectedDayPainter";
            this.Text = "CalendarPageWithSelectedDayPainter";
            ((System.ComponentModel.ISupportInitialize)(this.calendarBox)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.PictureBox calendarBox;
    }
}

