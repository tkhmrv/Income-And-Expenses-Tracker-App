using System;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace Financial.Tracker
{
    /// <summary>
    /// Форма для отображения данных на панели управления.
    /// </summary>
    public partial class DashboardUserControl : UserControl
    {
        private readonly string dailyIncomeQuery = "SELECT SUM(amount) FROM income_3nf WHERE income_date = @income_date AND user_id = @userId AND (@walletId = 0 OR wallet_id = @walletId)";
        private readonly string dailyExpensesQuery = "SELECT SUM(amount) FROM expenses WHERE expenses_date = @expenses_date AND user_id = @userId AND (@walletId = 0 OR wallet_id = @walletId)";

        private readonly string yesterdayIncomeQuery = "SELECT SUM(amount) FROM income_3nf WHERE CONVERT(DATE, income_date) = DATEADD(day, DATEDIFF(day, 0, GETDATE()), -1) AND user_id = @userId AND (@walletId = 0 OR wallet_id = @walletId)";
        private readonly string yesterdayExpensesQuery = "SELECT SUM(amount) FROM expenses WHERE CONVERT(DATE, expenses_date) = DATEADD(day, DATEDIFF(day, 0, GETDATE()), -1) AND user_id = @userId AND (@walletId = 0 OR wallet_id = @walletId)";

        private readonly string monthlyIncomeQuery = "SELECT SUM(amount) FROM income_3nf WHERE income_date >= @startMonth AND income_date <= @endMonth AND user_id = @userId AND (@walletId = 0 OR wallet_id = @walletId)";
        private readonly string monthlyExpensesQuery = "SELECT SUM(amount) FROM expenses WHERE expenses_date >= @startMonth AND expenses_date <= @endMonth AND user_id = @userId AND (@walletId = 0 OR wallet_id = @walletId)";

        private readonly string yearlyIncomeQuery = "SELECT SUM(amount) FROM income_3nf WHERE income_date >= @startYear AND income_date <= @endYear AND user_id = @userId AND (@walletId = 0 OR wallet_id = @walletId)";
        private readonly string yearlyExpensesQuery = "SELECT SUM(amount) FROM expenses WHERE expenses_date >= @startYear AND expenses_date <= @endYear AND user_id = @userId AND (@walletId = 0 OR wallet_id = @walletId)";

        private readonly string totalIncomeQuery = "SELECT SUM(amount) FROM income_3nf WHERE user_id = @userId AND (@walletId = 0 OR wallet_id = @walletId)";
        private readonly string totalExpensesQuery = "SELECT SUM(amount) FROM expenses WHERE user_id = @userId AND (@walletId = 0 OR wallet_id = @walletId)";


        /// <summary>
        /// Идентификатор текущего пользователя.
        /// </summary>
        private readonly int currentUserId = AuthForm.CurrentUserId;

        /// <summary>
        /// Идентификатор текущего кошелька.
        /// </summary>
        private readonly int currentWalletId = MainForm.CurrentWalletId;

        /// <summary>
        /// Статический экземпляр пользовательского интерфейса статистики.
        /// </summary>
        public static DashboardUserControl Instance { get; private set; }

        /// <summary>
        /// Инициализирует новый экземпляр класса <see cref="DashboardUserControl"/>.
        /// </summary>
        public DashboardUserControl()
        {
            InitializeComponent();

            Instance = this;

            RefreshData();
        }

        /// <summary>
        /// Обновляет данные на панели управления, используя статический экземпляр пользовательского интерфейса..
        /// </summary>
        public static void RefreshDataStatic()
        {
            Instance?.RefreshData();
        }

        /// <summary>
        /// Обновляет данные на панели управления.
        /// </summary>
        public void RefreshData()
        {
            if (InvokeRequired)
            {
                Invoke((MethodInvoker)RefreshData);
                return;
            }

            ShowTodayUniversal(dailyIncomeQuery, "@income_date", dash_labelIncomeToday);
            ShowTodayUniversal(dailyExpensesQuery, "@expenses_date", dash_labelExpensesToday);

            ShowYesterdayUniversal(yesterdayIncomeQuery, dash_labelIncomeYesterday);
            ShowYesterdayUniversal(yesterdayExpensesQuery, dash_labelExpensesYesterday);

            ShowMonthUniversal(monthlyIncomeQuery, dash_labelMonthlyIncome);
            ShowMonthUniversal(monthlyExpensesQuery, dash_labelMonthlyExpenses);

            ShowYearUniversal(yearlyIncomeQuery, dash_labelYearlyIncome);
            ShowYearUniversal(yearlyExpensesQuery, dash_labelYearlyExpenses);

            ShowTotalUniversal(totalIncomeQuery, dash_labelTotalIncome);
            ShowTotalUniversal(totalExpensesQuery, dash_labelTotalExpenses);
        }

        /// <summary>
        /// Показывает данные за текущий день.
        /// </summary>
        /// <param name="query">SQL-запрос для получения данных.</param>
        /// <param name="dateColumnName">Имя колонки для параметра даты.</param>
        /// <param name="labelName">Имя метки для отображения результата.</param>
        private void ShowTodayUniversal(string query, string dateColumnName, Label labelName)
        {
            if (DBConnection.CheckConnection())
            {
                try
                {
                    DBConnection.SqlConnection.Open();

                    using (SqlCommand sqlCommand = new SqlCommand(query, DBConnection.SqlConnection))
                    {
                        DateTime today = DateTime.Today;
                        sqlCommand.Parameters.AddWithValue(dateColumnName, today);
                        sqlCommand.Parameters.AddWithValue("@userId", AuthForm.CurrentUserId);
                        sqlCommand.Parameters.AddWithValue("@walletId", MainForm.CurrentWalletId);

                        object result = sqlCommand.ExecuteScalar();

                        if (result != DBNull.Value)
                        {
                            decimal todayAmount = Convert.ToDecimal(result);

                            labelName.Text = todayAmount.ToString("0.00") + " ₽";
                        }
                        else
                        {
                            labelName.Text = "0.00 ₽";
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Не удалось провести соединие, ошибка в DashboardUserControl: " + ex.Message, "Сообщение об ошибке", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                finally
                {
                    DBConnection.CloseConnection();
                }
            }
        }

        /// <summary>
        /// Показывает данные за вчерашний день.
        /// </summary>
        /// <param name="query">SQL-запрос для получения данных.</param>
        /// <param name="labelName">Имя метки для отображения результата.</param>
        private void ShowYesterdayUniversal(string query, Label labelName)
        {
            if (DBConnection.CheckConnection())
            {
                try
                {
                    DBConnection.SqlConnection.Open();

                    using (SqlCommand sqlCommand = new SqlCommand(query, DBConnection.SqlConnection))
                    {
                        sqlCommand.Parameters.AddWithValue("@userId", AuthForm.CurrentUserId);
                        sqlCommand.Parameters.AddWithValue("@walletId", MainForm.CurrentWalletId);

                        object result = sqlCommand.ExecuteScalar();

                        if (result != DBNull.Value)
                        {
                            decimal yesterdayAmount = Convert.ToDecimal(result);

                            labelName.Text = yesterdayAmount.ToString("0.00") + " ₽";
                        }
                        else
                        {
                            labelName.Text = "0.00 ₽";
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Не удалось провести соединие, ошибка в DashboardUserControl: " + ex.Message, "Сообщение об ошибке", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                finally
                {
                    DBConnection.CloseConnection();
                }
            }
        }

        /// <summary>
        /// Показывает данные за текущий месяц.
        /// </summary>
        /// <param name="query">SQL-запрос для получения данных.</param>
        /// <param name="labelName">Имя метки для отображения результата.</param>
        private void ShowMonthUniversal(string query, Label labelName)
        {
            if (DBConnection.CheckConnection())
            {
                try
                {
                    DBConnection.SqlConnection.Open();

                    DateTime today = DateTime.Now.Date;
                    DateTime startMonth = new DateTime(today.Year, today.Month, 1);
                    DateTime endMonth = startMonth.AddMonths(1).AddDays(-1);

                    using (SqlCommand sqlCommand = new SqlCommand(query, DBConnection.SqlConnection))
                    {
                        sqlCommand.Parameters.AddWithValue("@startMonth", startMonth);
                        sqlCommand.Parameters.AddWithValue("@endMonth", endMonth);
                        sqlCommand.Parameters.AddWithValue("@userId", AuthForm.CurrentUserId);
                        sqlCommand.Parameters.AddWithValue("@walletId", MainForm.CurrentWalletId);

                        object result = sqlCommand.ExecuteScalar();

                        if (result != DBNull.Value)
                        {
                            decimal monthlyAmount = Convert.ToDecimal(result);

                            labelName.Text = monthlyAmount.ToString("0.00") + "₽";
                        }
                        else
                        {
                            labelName.Text = "0.00 ₽";
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Не удалось провести соединие, ошибка в DashboardUserControl: " + ex.Message, "Сообщение об ошибке", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                finally
                {
                    DBConnection.CloseConnection();
                }
            }
        }

        /// <summary>
        /// Показывает данные за текущий год.
        /// </summary>
        /// <param name="query">SQL-запрос для получения данных.</param>
        /// <param name="labelName">Имя метки для отображения результата.</param>
        private void ShowYearUniversal(string query, Label labelName)
        {
            if (DBConnection.CheckConnection())
            {
                try
                {
                    DBConnection.SqlConnection.Open();

                    DateTime today = DateTime.Now.Date;
                    DateTime startYear = new DateTime(today.Year, 1, 1);
                    DateTime endYear = startYear.AddMonths(12).AddDays(-1);

                    using (SqlCommand sqlCommand = new SqlCommand(query, DBConnection.SqlConnection))
                    {
                        sqlCommand.Parameters.AddWithValue("@startYear", startYear);
                        sqlCommand.Parameters.AddWithValue("@endYear", endYear);
                        sqlCommand.Parameters.AddWithValue("@userId", AuthForm.CurrentUserId);
                        sqlCommand.Parameters.AddWithValue("@walletId", MainForm.CurrentWalletId);

                        object result = sqlCommand.ExecuteScalar();

                        if (result != DBNull.Value)
                        {
                            decimal yearAmount = Convert.ToDecimal(result);

                            labelName.Text = yearAmount.ToString("0.00") + " ₽";
                        }
                        else
                        {
                            labelName.Text = "0.00 ₽";
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Не удалось провести соединие, ошибка в DashboardUserControl: " + ex.Message, "Сообщение об ошибке", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                finally
                {
                    DBConnection.CloseConnection();
                }
            }
        }

        /// <summary>
        /// Показывает общие данные.
        /// </summary>
        /// <param name="query">SQL-запрос для получения данных.</param>
        /// <param name="labelName">Имя метки для отображения результата.</param>
        private void ShowTotalUniversal(string query, Label labelName)
        {
            if (DBConnection.CheckConnection())
            {
                try
                {
                    DBConnection.SqlConnection.Open();

                    using (SqlCommand sqlCommand = new SqlCommand(query, DBConnection.SqlConnection))
                    {
                        sqlCommand.Parameters.AddWithValue("@userId", AuthForm.CurrentUserId);
                        sqlCommand.Parameters.AddWithValue("@walletId", MainForm.CurrentWalletId);

                        object result = sqlCommand.ExecuteScalar();

                        if (result != DBNull.Value)
                        {
                            decimal totalAmount = Convert.ToDecimal(result);

                            labelName.Text = totalAmount.ToString("0.00") + " ₽";
                        }
                        else
                        {
                            labelName.Text = "0.00 ₽";
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Не удалось провести соединие, ошибка в DashboardUserControl: " + ex.Message, "Сообщение об ошибке", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                finally
                {
                    DBConnection.CloseConnection();
                }
            }
        }
    }
}
