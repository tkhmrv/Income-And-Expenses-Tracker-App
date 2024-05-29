using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Course_Work__WinForms.NET_Framework__C___MS_SQL_
{
    public partial class FeedBackForm : Form
    {
        public FeedBackForm(string message)
        {
            InitializeComponent();
            this.Text = ""; // Убираем заголовок окна
            this.FormBorderStyle = FormBorderStyle.None; // Убираем рамку вокруг окна

            // Устанавливаем цвет фона и ключ прозрачности
            this.BackColor = SystemColors.Control; // Выбираем цвет, который будет прозрачным (например, Лайм)
            this.TransparencyKey = SystemColors.Control; // Устанавливаем ключ прозрачности на тот же цвет

            labelMessage.Text = message;

            // Устанавливаем стартовую позицию формы на ручную
            this.StartPosition = FormStartPosition.Manual;
        }

        private void FeedBackForm_Load(object sender, EventArgs e)
        {
            // Вычисляем положение для формы чуть выше центра экрана
            int screenWidth = Screen.PrimaryScreen.WorkingArea.Width;
            int screenHeight = Screen.PrimaryScreen.WorkingArea.Height;
            int formWidth = this.Width;
            int formHeight = this.Height;
            int x = (screenWidth - formWidth) / 2;
            int y = (screenHeight - formHeight) / 2 - 300; // Сдвиг на 50 пикселей выше центра

            this.Location = new Point(x, y);

            Timer timer = new Timer
            {
                Interval = 3000 // Задержка в 3 секунды
            };
            timer.Tick += (s, args) =>
            {
                this.Close(); // Закрывает форму при истечении времени
            };
            timer.Start(); // Запускает таймер
        }
    }
}
