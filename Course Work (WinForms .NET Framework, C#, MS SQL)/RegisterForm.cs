using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Runtime.Remoting.Contexts;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.StartPanel;

namespace Course_Work__WinForms.NET_Framework__C___MS_SQL_
{
    public partial class RegisterForm : Form
    {
        public RegisterForm()
        {
            InitializeComponent();
        }

        private void labelCloseApp_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void buttonBackToAuth_Click(object sender, EventArgs e)
        {
            AuthForm authForm = new AuthForm();
            authForm.ShowDialog();

            this.Close();
        }

        private void checkboxShowRegPassword_CheckedChanged(object sender, EventArgs e)
        {
            textboxRegPassword.PasswordChar = checkboxShowRegPassword.Checked ? '\0' : '*';
            textboxConfirmPassword.PasswordChar = checkboxShowRegPassword.Checked ? '\0' : '*';
        }

        private void buttonRegistration_Click(object sender, EventArgs e)
        {
            if (textboxRegisterUsername.Text == "" || textboxRegPassword.Text == "" || textboxConfirmPassword.Text == "")
            {
                MessageBox.Show("Пожалуйста, заполните все поля!", "Сообщение об ошибке", MessageBoxButtons.OKCancel, MessageBoxIcon.Error);
            }
            else
            {
                if (DBConnection.CheckConnection())
                {
                    try
                    {
                        DBConnection.SqlConnection.Open();

                        // проверка на существование введенного юзернейма
                        string selectUsername = "SELECT * FROM users WHERE username = @usern";

                        using (SqlCommand checkUser = new SqlCommand(selectUsername, DBConnection.SqlConnection))
                        {
                            checkUser.Parameters.AddWithValue("@usern", textboxRegisterUsername.Text.Trim());

                            SqlDataAdapter adapter = new SqlDataAdapter(checkUser);
                            DataTable dataTable = new DataTable();

                            adapter.Fill(dataTable);

                            if (dataTable.Rows.Count != 0)
                            {

                                string tempUsername = textboxRegisterUsername.Text.Substring(0, 1).ToUpper() + textboxRegisterUsername.Text.Substring(1);
                                MessageBox.Show("Пользователь с именем " + tempUsername + " уже существует!", "Сообщение об ошибке", MessageBoxButtons.OKCancel, MessageBoxIcon.Error);
                            }
                            else if(textboxRegPassword.Text.Length < 8)
                            {
                                MessageBox.Show("Пароль ненадежный, введите не менее 8 символов", "Сообщение об ошибке", MessageBoxButtons.OKCancel, MessageBoxIcon.Error);
                            }
                            else if(textboxConfirmPassword.Text != textboxRegPassword.Text)
                            {
                                MessageBox.Show("Пароли не совпадают, повторите ввод", "Сообщение об ошибке", MessageBoxButtons.OKCancel, MessageBoxIcon.Error);
                            }

                            else
                            {
                                string insertData = "INSERT INTO users (username, password, register_date) VALUES(@usern, @pass, GETDATE())";

                                using (SqlCommand insertUser = new SqlCommand(insertData, DBConnection.SqlConnection))
                                {
                                    insertUser.Parameters.AddWithValue("@usern", textboxRegisterUsername.Text.Trim());
                                    insertUser.Parameters.AddWithValue("@pass", textboxRegPassword.Text.Trim());

                                    insertUser.ExecuteNonQuery();

                                    MessageBox.Show("Пользователь успешно добавлен!", "Информационное сообщение", MessageBoxButtons.OKCancel, MessageBoxIcon.Information);

                                    AuthForm authForm = new AuthForm();
                                    authForm.Show();

                                    this.Hide();
                                }
                            }
                        }

                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Не удалось провести соединие, ошибка:" + ex, "Сообщение об ошибке!", MessageBoxButtons.OKCancel, MessageBoxIcon.Error);
                    }
                    finally
                    {
                        if (!DBConnection.CheckConnection())
                        {
                            DBConnection.SqlConnection.Close();
                        }
                    }
                }
            }
        }
    }
}
