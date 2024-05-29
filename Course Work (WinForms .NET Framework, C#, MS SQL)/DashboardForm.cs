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
        public DashboardForm()
        {
            InitializeComponent();

            ShowIncomeToday();
        }

        public void ShowIncomeToday()
        {
            if (DBConnection.CheckConnection())
            {
                try
                {
                    DBConnection.SqlConnection.Open();

                    string query = "SELECT SUM(amount) FROM income_3nf WHERE income_date = @income_date";

                    using (SqlCommand cmd = new SqlCommand(query, DBConnection.SqlConnection))
                    {
                        DateTime today = DateTime.Today;
                        cmd.Parameters.AddWithValue("@income_date", today);

                        object result = cmd.ExecuteScalar();

                        if (result != DBNull.Value)
                        {
                            decimal todayCost = Convert.ToDecimal(result);

                            dash_labelIncomeToday.Text = todayCost.ToString("0.00") + " ₽";
                        }
                        else
                        {
                            dash_labelIncomeToday.Text = "0.00 ₽";
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

        public void IncomeYesterday()
        {
            if (DBConnection.CheckConnection())
            {
                try
                {
                    DBConnection.SqlConnection.Open();

                    string query = "SELECT SUM(amount) FROM income_3nf WHERE CONVERT(DATE, Timestamp) = DATEADD(day, DATEDIFF(day, 0, GETDATE()), -1)";

                    using(SqlCommand cmd = new SqlCommand(query, DBConnection.SqlConnection))
                    {
                        object result = cmd.ExecuteScalar();

                        if(result != DBNull.Value)
                        {

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
