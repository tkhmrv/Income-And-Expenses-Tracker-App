using System;
using System.Windows.Forms;

namespace Course_Work__WinForms.NET_Framework__C___MS_SQL_
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();

            initDash();
        }

        private void labelCloseApp_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Вы уверены, что хотите закрыть программу?", "Сообщение подтверждения", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                Application.Exit();
            }
        }

        private void buttonLogout_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Вы уверены, что хотите выйти?", "Сообщение подтверждения", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                AuthForm authForm = new AuthForm();
                authForm.Show();

                this.Hide();
            }
        }

        private void initDash()
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

        private void buttonDashboard_Click(object sender, EventArgs e)
        {
            initDash();
        }

        private void buttonAddCategory_Click(object sender, EventArgs e)
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

        private void buttonIncome_Click(object sender, EventArgs e)
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

        private void buttonExpenses_Click(object sender, EventArgs e)
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
