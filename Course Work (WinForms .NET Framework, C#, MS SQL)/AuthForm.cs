using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Course_Work__WinForms.NET_Framework__C___MS_SQL_
{
    public partial class AuthForm : Form
    {
        private static readonly SqlConnection sqlConnection = new SqlConnection(@"Data Source = 192.168.31.153; Initial Catalog = Tracker_DB; Persist Security Info=True;User ID = sa; Password=Basisol40@;Encrypt=False;TrustServerCertificate=True");
        //private static readonly string stringConnection = @"Data Source = 192.168.31.153; Initial Catalog = Tracker_DB; Persist Security Info=True;User ID = sa; Password=Basisol40@;Encrypt=False;TrustServerCertificate=True";

        public AuthForm()
        {
            InitializeComponent();
        }

        // hover for register link
        private void createAccountLabel_MouseHover(object sender, EventArgs e)
        {
            labelCreateAccount.ForeColor = Color.Blue;
        }

        private void createAccountLabel_MouseLeave(object sender, EventArgs e)
        {
            labelCreateAccount.ForeColor = SystemColors.ControlText;
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void labelCloseApp_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        public bool CheckConnection()
        {
            return sqlConnection.State == ConnectionState.Closed;
        }

        private void checkboxShowAuthPassword_CheckedChanged(object sender, EventArgs e)
        {
            textboxPassword.PasswordChar = checkboxShowAuthPassword.Checked ? '\0' : '*';
        }

        private void labelCreateAccount_Click(object sender, EventArgs e)
        {
            RegisterForm registerForm = new RegisterForm();
            registerForm.ShowDialog();

            /*RegisterForm test = new RegisterForm();
            test.ShowDialog();*/

            this.Close();
        }

        private void buttonAuth_Click(object sender, EventArgs e)
        {
            buttonAuthLogic();
        }

        private void textboxPassword_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
            {
                buttonAuthLogic();
            }
        }

        private void buttonAuthLogic()
        {
            if (CheckConnection())
            {
                sqlConnection.Open();

                string selectData = "SELECT * FROM users WHERE username = @usern AND password = @pass";

                using (SqlCommand cmd = new SqlCommand(selectData, sqlConnection))
                {
                    cmd.Parameters.AddWithValue("@usern", textboxAuthUser.Text.Trim());
                    cmd.Parameters.AddWithValue("@pass", textboxPassword.Text.Trim());

                    SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                    DataTable dt = new DataTable();

                    adapter.Fill(dt);

                    if (dt.Rows.Count > 0)
                    {
                        MessageBox.Show("Вы успешно вошли!", "Информационное сообщение", MessageBoxButtons.OKCancel, MessageBoxIcon.Information);

                        MainForm mainForm = new MainForm();
                        mainForm.Show();

                        this.Hide();
                    }
                    else
                    {
                        MessageBox.Show("Неправильное имя пользователя или пароль!", "Сообщение об ошибке", MessageBoxButtons.OKCancel, MessageBoxIcon.Error);
                    }
                }
            }
        }
    }
}
