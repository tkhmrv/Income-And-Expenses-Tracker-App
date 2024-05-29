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
    public partial class DashboardForm : UserControl
    {
        private readonly string dailyIncomeQuery = "SELECT SUM(amount) FROM income_3nf WHERE income_date = @income_date";
        private readonly string dailyExpensesQuery = "SELECT SUM(amount) FROM expenses WHERE expenses_date = @expenses_date";
        
        private readonly string yesterdayIncomeQuery = "SELECT SUM(amount) FROM income_3nf WHERE CONVERT(DATE, income_date) = DATEADD(day, DATEDIFF(day, 0, GETDATE()), -1)";
        private readonly string yesterdayExpensesQuery = "SELECT SUM(amount) FROM expenses WHERE CONVERT(DATE, expenses_date) = DATEADD(day, DATEDIFF(day, 0, GETDATE()), -1)";
        
        private readonly string monthlyIncomeQuery = "SELECT SUM(amount) FROM income_3nf WHERE income_date >= @startMonth AND income_date <= @endMonth";
        private readonly string monthlyExpensesQuery = "SELECT SUM(amount) FROM expenses WHERE expenses_date >= @startMonth AND expenses_date <= @endMonth";

        private readonly string yearlyIncomeQuery = "SELECT SUM(amount) FROM income_3nf WHERE income_date >= @startYear AND income_date <= @endYear";
        private readonly string yearlyExpensesQuery = "SELECT SUM(amount) FROM expenses WHERE expenses_date >= @startYear AND expenses_date <= @endYear";

        private readonly string totalIncomeQuery = "SELECT SUM(amount) FROM income_3nf";
        private readonly string totalExpensesQuery = "SELECT SUM(amount) FROM expenses";

        public DashboardForm()
        {
            InitializeComponent();

            RefreshData();
        }

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

        public void ShowTodayUniversal(string query, string columnName, Label labelName)
        {
            if (DBConnection.CheckConnection())
            {
                try
                {
                    DBConnection.SqlConnection.Open();

                    using (SqlCommand cmd = new SqlCommand(query, DBConnection.SqlConnection))
                    {
                        DateTime today = DateTime.Today;
                        cmd.Parameters.AddWithValue(columnName, today);

                        object result = cmd.ExecuteScalar();

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
                    MessageBox.Show("Ошибка: " + ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
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

        public void ShowYesterdayUniversal(string query, Label labelName)
        {
            if (DBConnection.CheckConnection())
            {
                try
                {
                    DBConnection.SqlConnection.Open();

                    using(SqlCommand cmd = new SqlCommand(query, DBConnection.SqlConnection))
                    {
                        object result = cmd.ExecuteScalar();

                        if(result != DBNull.Value)
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
                    MessageBox.Show("Ошибка: " + ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
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

        public void ShowMonthUniversal(string query, Label labelName)
        {
            if (DBConnection.CheckConnection())
            {
                try
                {
                    DBConnection.SqlConnection.Open();

                    DateTime today = DateTime.Now.Date;
                    DateTime startMonth = new DateTime(today.Year, today.Month, 1);
                    DateTime endMonth = startMonth.AddMonths(1).AddDays(-1);

                    using (SqlCommand cmd = new SqlCommand(query, DBConnection.SqlConnection))
                    {
                        cmd.Parameters.AddWithValue("@startMonth", startMonth);
                        cmd.Parameters.AddWithValue("@endMonth", endMonth);

                        object result = cmd.ExecuteScalar();

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
                    MessageBox.Show("Ошибка: " + ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
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

        public void ShowYearUniversal(string query, Label labelName)
        {
            if (DBConnection.CheckConnection())
            {
                try
                {
                    DBConnection.SqlConnection.Open();

                    DateTime today = DateTime.Now.Date;
                    DateTime startYear = new DateTime(today.Year, 1, 1);
                    DateTime endYear = startYear.AddMonths(1).AddDays(-1);

                    using (SqlCommand cmd = new SqlCommand(query, DBConnection.SqlConnection))
                    {
                        cmd.Parameters.AddWithValue("@startYear", startYear);
                        cmd.Parameters.AddWithValue("@endYear", endYear);

                        object result = cmd.ExecuteScalar();

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
                    MessageBox.Show("Ошибка: " + ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
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

        private void ShowTotalUniversal(string query, Label labelName)
        {
            if (DBConnection.CheckConnection())
            {
                try
                {
                    DBConnection.SqlConnection.Open();

                    using (SqlCommand cmd = new SqlCommand(query, DBConnection.SqlConnection))
                    {
                        object result = cmd.ExecuteScalar();

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
                    MessageBox.Show("Ошибка: " + ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
