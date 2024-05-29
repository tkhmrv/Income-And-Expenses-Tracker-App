using System;
using System.Drawing;
using System.Windows.Forms;

namespace Course_Work__WinForms.NET_Framework__C___MS_SQL_
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();

            InitializeDash();
            DisplayUsername();
        }

        public void DisplayUsername()
        {
            string getUsername = AuthForm.username;

            labelDisplayUsername.Text += getUsername.Substring(0, 1).ToUpper() + getUsername.Substring(1);
        }

        private void InitializeDash()
        {
            DBConnection.CloseConnection();

            dashboardForm.Visible = true;
            categoryForm.Visible = false;
            incomeForm.Visible = false;
            expensesForm.Visible = false;


            if (dashboardForm is DashboardForm dForm)
            {
                dForm.RefreshData();
            }
        }

        private void LabelCloseApp_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Вы уверены, что хотите закрыть программу?", "Сообщение подтверждения", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                Application.Exit();
            }
        }

        private void ButtonLogout_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Вы уверены, что хотите выйти?", "Сообщение подтверждения", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                AuthForm authForm = new AuthForm();
                authForm.Show();

                this.Hide();
            }
        }

        private void ButtonDashboard_Click(object sender, EventArgs e)
        {
            InitializeDash();
        }

        private void ButtonAddCategory_Click(object sender, EventArgs e)
        {
            DBConnection.CloseConnection();

            dashboardForm.Visible = false;
            categoryForm.Visible = true;
            incomeForm.Visible = false;
            expensesForm.Visible = false;


            if (categoryForm is CategoryForm cForm)
            {
                cForm.RefreshData();
            }
        }

        private void ButtonIncome_Click(object sender, EventArgs e)
        {
            DBConnection.CloseConnection();

            dashboardForm.Visible = false;
            categoryForm.Visible = false;
            incomeForm.Visible = true;
            expensesForm.Visible = false;


            if (incomeForm is IncomeForm iForm)
            {
                iForm.RefreshData();
            }
        }

        private void ButtonExpenses_Click(object sender, EventArgs e)
        {
            DBConnection.CloseConnection();

            dashboardForm.Visible = false;
            categoryForm.Visible = false;
            incomeForm.Visible = false;
            expensesForm.Visible = true;


            if (expensesForm is ExpensesForm eForm)
            {
                eForm.RefreshData();
            }
        }

    }
}
