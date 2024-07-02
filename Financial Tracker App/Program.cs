using System;
using System.Windows.Forms;

namespace Financial.Tracker
{
    /// <summary>
    /// Основной класс входа в программу.
    /// </summary>
    internal static class Program
    {
        /// <summary>
        /// Главная точка входа в программу.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new AuthForm());
        }
    }
}
