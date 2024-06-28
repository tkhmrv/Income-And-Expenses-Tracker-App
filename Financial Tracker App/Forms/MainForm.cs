using System;
using System.Windows.Forms;

namespace Financial.Tracker
{
    /// <summary>
    /// Основная форма приложения.
    /// </summary>
    public partial class MainForm : Form
    {
        /// <summary>
        /// Инициализирует новый экземпляр класса <see cref="MainForm"/>.
        /// </summary>
        public MainForm()
        {
            InitializeComponent();

            InitializeDash();
            DisplayUsername();
        }

        /// <summary>
        /// Отображает имя пользователя, вошедшего в систему.
        /// </summary>
        public void DisplayUsername()
        {
            string getUsername = AuthForm.username;
            labelDisplayUsername.Text += getUsername.Substring(0, 1).ToUpper() + getUsername.Substring(1);
        }

        /// <summary>
        /// Инициализирует панель приборов (dashboard).
        /// </summary>
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

        /// <summary>
        /// Обработчик события клика на метку закрытия приложения.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void LabelCloseApp_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Вы уверены, что хотите закрыть программу?", "Сообщение подтверждения", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                Application.Exit();
            }
        }

        /// <summary>
        /// Обработчик события клика на кнопку выхода из системы.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ButtonLogout_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Вы уверены, что хотите выйти?", "Сообщение подтверждения", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                AuthForm authForm = new AuthForm();
                authForm.Show();

                this.Hide();
            }
        }

        /// <summary>
        /// Обработчик события клика на кнопку панели приборов (dashboard).
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ButtonDashboard_Click(object sender, EventArgs e)
        {
            InitializeDash();
        }

        /// <summary>
        /// Обработчик события клика на кнопку добавления категории.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
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

        /// <summary>
        /// Обработчик события клика на кнопку доходов.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
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

            //DBConnection.CloseConnection();
        }

        /// <summary>
        /// Обработчик события клика на кнопку расходов.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
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
