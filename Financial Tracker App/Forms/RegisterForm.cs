using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace Financial.Tracker
{
    /// <summary>
    /// Форма для регистрации нового пользователя.
    /// </summary>
    public partial class RegisterForm : Form
    {
        /// <summary>
        /// Инициализирует новый экземпляр класса <see cref="RegisterForm"/>.
        /// </summary>
        public RegisterForm()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Обработчик события клика на метку закрытия приложения.
        /// </summary>
        private void LabelCloseApp_Click(object sender, EventArgs e)
        {
            AuthForm authForm = new AuthForm();
            authForm.ShowDialog();

            this.Close();
        }

        /// <summary>
        /// Обработчик события клика на кнопку возврата к форме авторизации.
        /// </summary>
        private void ButtonBackToAuth_Click(object sender, EventArgs e)
        {
            AuthForm authForm = new AuthForm();
            authForm.Show();

            this.Close();
        }

        /// <summary>
        /// Обработчик изменения состояния чекбокса для показа/скрытия пароля.
        /// </summary>
        private void CheckboxShowRegPassword_CheckedChanged(object sender, EventArgs e)
        {
            textboxRegPassword.PasswordChar = checkboxShowRegPassword.Checked ? '\0' : '*';
            textboxConfirmPassword.PasswordChar = checkboxShowRegPassword.Checked ? '\0' : '*';
        }

        /// <summary>
        /// Обработчик клика на кнопку регистрации.
        /// </summary>
        private void ButtonRegistration_Click(object sender, EventArgs e)
        {
            if (!ValidateRegistrationInputs())
                return;

            if (DBConnection.CheckConnection())
            {
                try
                {
                    DBConnection.SqlConnection.Open();

                    string selectUsername = "SELECT * FROM users WHERE username = @username";
                    using (SqlCommand checkUser = new SqlCommand(selectUsername, DBConnection.SqlConnection))
                    {
                        checkUser.Parameters.AddWithValue("@username", textboxRegisterUsername.Text.Trim());

                        SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(checkUser);
                        DataTable dataTable = new DataTable();

                        sqlDataAdapter.Fill(dataTable);

                        if (dataTable.Rows.Count != 0)
                        {
                            string tempUsername = textboxRegisterUsername.Text.Substring(0, 1).ToUpper() + textboxRegisterUsername.Text.Substring(1);
                            MessageBox.Show("Пользователь с именем " + tempUsername + " уже существует.", "Сообщение об ошибке", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                        else
                        {
                            string insertData = "INSERT INTO users (username, password, register_date) VALUES(@username, @password, GETDATE())";
                            using (SqlCommand insertUser = new SqlCommand(insertData, DBConnection.SqlConnection))
                            {
                                insertUser.Parameters.AddWithValue("@username", textboxRegisterUsername.Text.Trim());
                                insertUser.Parameters.AddWithValue("@password", textboxRegPassword.Text.Trim());

                                insertUser.ExecuteNonQuery();

                                MessageBox.Show("Пользователь успешно добавлен!", "Информационное сообщение", MessageBoxButtons.OK, MessageBoxIcon.Information);

                                AuthForm authForm = new AuthForm();
                                authForm.Show();

                                this.Hide();
                            }
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Не удалось провести соединение, ошибка: " + ex.Message, "Сообщение об ошибке", MessageBoxButtons.OKCancel, MessageBoxIcon.Error);
                }
                finally
                {
                    DBConnection.CloseConnection();
                }
            }
        }

        /// <summary>
        /// Валидирует входные данные для регистрации.
        /// </summary>
        /// <returns>Возвращает true, если все входные данные валидны; в противном случае false.</returns>
        private bool ValidateRegistrationInputs()
        {
            if (string.IsNullOrEmpty(textboxRegisterUsername.Text))
            {
                MessageBox.Show("Введите имя пользователя.", "Сообщение об ошибке", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            else if (string.IsNullOrEmpty(textboxRegPassword.Text))
            {
                MessageBox.Show("Введите пароль.", "Сообщение об ошибке", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            else if (textboxRegPassword.Text.Length < 8)
            {
                MessageBox.Show("Пароль ненадежный, введите не менее 8 символов.", "Сообщение об ошибке", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            if (!System.Text.RegularExpressions.Regex.IsMatch(textboxRegPassword.Text, @"(?=.*[A-Z])"))
            {
                MessageBox.Show("Пароль должен содержать хотя бы одну заглавную букву.", "Сообщение об ошибке", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            if (!System.Text.RegularExpressions.Regex.IsMatch(textboxRegPassword.Text, @"(?=.*\d)"))
            {
                MessageBox.Show("Пароль должен содержать хотя бы одну цифру.", "Сообщение об ошибке", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            if (!System.Text.RegularExpressions.Regex.IsMatch(textboxRegPassword.Text, @"(?=.*[\W])"))
            {
                MessageBox.Show("Пароль должен содержать хотя бы один специальный символ.", "Сообщение об ошибке", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            if (textboxConfirmPassword.Text != textboxRegPassword.Text)
            {
                MessageBox.Show("Пароли не совпадают, повторите ввод.", "Сообщение об ошибке", MessageBoxButtons.OKCancel, MessageBoxIcon.Error);
                return false;
            }
            return true;
        }
    }
}
