using System;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Windows.Forms;

namespace Financial.Tracker
{
    /// <summary>
    /// Форма авторизации пользователя.
    /// </summary>
    public partial class AuthForm : Form
    {
        /// <summary>
        /// Имя пользователя, авторизованного в системе.
        /// </summary>
        public static string username;

        /// <summary>
        /// Инициализирует новый экземпляр класса <see cref="AuthForm"/>.
        /// </summary>
        public AuthForm()
        {
            InitializeComponent();
        }

        /// <summary>
        ///  Изменяет цвет текста при наведении мыши на метку создания аккаунта.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void CreateAccountLabel_MouseHover(object sender, EventArgs e)
        {
            labelCreateAccount.ForeColor = Color.Blue;
        }

        /// <summary>
        /// Восстанавливает цвет текста при уходе мыши с метки создания аккаунта.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void CreateAccountLabel_MouseLeave(object sender, EventArgs e)
        {
            labelCreateAccount.ForeColor = SystemColors.ControlText;
        }

        /// <summary>
        /// Закрывает приложение при нажатии на метку закрытия приложения.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void LabelCloseApp_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        /// <summary>
        /// Показывает или скрывает пароль в зависимости от состояния чекбокса.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void CheckboxShowAuthPassword_CheckedChanged(object sender, EventArgs e)
        {
            textboxPassword.PasswordChar = checkboxShowAuthPassword.Checked ? '\0' : '*';
        }

        /// <summary>
        /// Открывает форму регистрации при нажатии на метку создания аккаунта.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void LabelCreateAccount_Click(object sender, EventArgs e)
        {
            RegisterForm registerForm = new RegisterForm();
            registerForm.ShowDialog();
        }

        /// <summary>
        /// Логика авторизации при нажатии на кнопку авторизации.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ButtonAuth_Click(object sender, EventArgs e)
        {
            ButtonAuthLogic();
        }

        /// <summary>
        /// Обрабатывает нажатие клавиши Enter в поле пароля для вызова логики авторизации.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void TextboxPassword_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
            {
                ButtonAuthLogic();
            }
        }

        /// <summary>
        /// Логика авторизации пользователя.
        /// </summary>
        private void ButtonAuthLogic()
        {
            if (DBConnection.CheckConnection())
            {
                try
                {
                    DBConnection.SqlConnection.Open();

                    string selectUserData = "SELECT * FROM users WHERE username = @username AND password = @password";

                    using (SqlCommand sqlCommand = new SqlCommand(selectUserData, DBConnection.SqlConnection))
                    {
                        sqlCommand.Parameters.AddWithValue("@username", textboxAuthUser.Text.Trim());
                        sqlCommand.Parameters.AddWithValue("@password", textboxPassword.Text.Trim());

                        SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(sqlCommand);
                        DataTable dataTable = new DataTable();

                        sqlDataAdapter.Fill(dataTable);

                        if (dataTable.Rows.Count > 0)
                        {
                            username = dataTable.Rows[0]["username"].ToString();

                            DBConnection.SqlConnection.Close();

                            MessageBox.Show("Вы успешно вошли!", "Информационное сообщение", MessageBoxButtons.OK, MessageBoxIcon.Information);

                            MainForm mainForm = new MainForm();
                            mainForm.Show();

                            this.Hide();
                        }
                        else
                        {
                            MessageBox.Show("Неправильное имя пользователя или пароль.", "Сообщение об ошибке", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Не удалось провести соединение с базой данных, ошибка: " + ex, "Сообщение об ошибке", MessageBoxButtons.OKCancel, MessageBoxIcon.Error);
                }
                finally
                {
                    DBConnection.CloseConnection();
                }
            }
        }
    }
}
