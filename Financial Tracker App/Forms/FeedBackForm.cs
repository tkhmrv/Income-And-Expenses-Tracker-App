using System;
using System.Drawing;
using System.Windows.Forms;

namespace Financial.Tracker
{
    /// <summary>
    /// Форма для отображения сообщения обратной связи.
    /// </summary>
    public partial class FeedBackForm : Form
    {
        /// <summary>
        /// Инициализирует новый экземпляр класса <see cref="FeedBackForm"/> с указанным сообщением.
        /// </summary>
        /// <param name="message">Сообщение для отображения на форме.</param>
        public FeedBackForm(string message)
        {
            InitializeComponent();
            this.Text = ""; // Убираем заголовок окна
            this.FormBorderStyle = FormBorderStyle.None; // Убираем рамку вокруг окна

            // Устанавливаем цвет фона и ключ прозрачности
            this.BackColor = SystemColors.Control; // Выбираем цвет, который будет прозрачным
            this.TransparencyKey = SystemColors.Control; // Устанавливаем ключ прозрачности на тот же цвет

            labelMessage.Text = message;

            // Устанавливаем стартовую позицию формы на ручную
            this.StartPosition = FormStartPosition.Manual;
        }

        /// <summary>
        /// Обрабатывает событие загрузки формы.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void FeedBackForm_Load(object sender, EventArgs e)
        {
            // Вычисляем положение для формы чуть выше центра экрана
            int screenWidth = Screen.PrimaryScreen.WorkingArea.Width;
            int screenHeight = Screen.PrimaryScreen.WorkingArea.Height;
            int formWidth = this.Width;
            int formHeight = this.Height;
            int x = (screenWidth - formWidth) / 2;
            int y = (screenHeight - formHeight) / 2 - 300; // Сдвиг на 300 пикселей выше центра

            this.Location = new Point(x, y);

            // Создаем и запускаем таймер для закрытия формы через 3 секунды
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
