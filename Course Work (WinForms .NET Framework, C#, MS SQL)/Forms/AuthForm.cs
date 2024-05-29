using System;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Windows.Forms;

namespace Course_Work__WinForms.NET_Framework__C___MS_SQL_
{
    public partial class AuthForm : Form
    {
        public static string username;

        public AuthForm()
        {
            InitializeComponent();
        }

        private void CreateAccountLabel_MouseHover(object sender, EventArgs e)
        {
            labelCreateAccount.ForeColor = Color.Blue;
        }

        private void CreateAccountLabel_MouseLeave(object sender, EventArgs e)
        {
            labelCreateAccount.ForeColor = SystemColors.ControlText;
        }

        private void LabelCloseApp_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void CheckboxShowAuthPassword_CheckedChanged(object sender, EventArgs e)
        {
            textboxPassword.PasswordChar = checkboxShowAuthPassword.Checked ? '\0' : '*';
        }

        private void LabelCreateAccount_Click(object sender, EventArgs e)
        {
            RegisterForm registerForm = new RegisterForm();
            registerForm.ShowDialog();

            this.Close();
        }

        private void ButtonAuth_Click(object sender, EventArgs e)
        {
            ButtonAuthLogic();
        }

        
        private void TextboxPassword_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
            {
                ButtonAuthLogic();
            }
        }

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
                    MessageBox.Show("Не удалось провести соединие с базой данных, ошибка: " + ex, "Сообщение об ошибке", MessageBoxButtons.OKCancel, MessageBoxIcon.Error);
                }
                finally
                {
                    DBConnection.CloseConnection();
                }
            }
        }
    }
}
