using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Course_Work__WinForms.NET_Framework__C___MS_SQL_
{
    internal class ExpensesData
    {
        private static readonly SqlConnection sqlConnection = new SqlConnection(@"Data Source = 192.168.31.153; Initial Catalog = Tracker_DB; Persist Security Info=True;User ID = sa; Password=Basisol40@;Encrypt=False;TrustServerCertificate=True");

        public int Id { get; set; }
        public int CategoryId { get; set; }
        public string CategoryName { get; set; }
        public string Item { get; set; }
        public string Amount { get; set; }
        public string Description { get; set; }
        public string ExpensesDate { get; set; }

        public bool CheckConnection()
        {
            return sqlConnection.State == ConnectionState.Closed;
        }

        public List<ExpensesData> ExpensesListData()
        {
            List<ExpensesData> listData = new List<ExpensesData>();

            try
            {
                if (CheckConnection())
                {
                    sqlConnection.Open();

                    string selectData = @"SELECT expenses.id_expenses, expenses.category_id, categories.category AS category_name, 
                                      expenses.item, expenses.amount, expenses.description, expenses.expenses_date 
                                      FROM expenses 
                                      INNER JOIN categories ON expenses.category_id = categories.id_category";

                    using (SqlCommand cmd = new SqlCommand(selectData, sqlConnection))
                    {
                        SqlDataReader reader = cmd.ExecuteReader();

                        while (reader.Read())
                        {
                            ExpensesData expensesData = new ExpensesData
                            {
                                Id = (int)reader["id_expenses"],
                                CategoryId = (int)reader["category_id"],
                                CategoryName = reader["category_name"].ToString(),
                                Item = reader["item"].ToString(),
                                Amount = reader["amount"].ToString(),
                                Description = reader["description"].ToString(),
                                ExpensesDate = ((DateTime)reader["expenses_date"]).ToString("MM-dd-yyyy")
                            };

                            listData.Add(expensesData);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ошибка при загрузке данных: " + ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                if (sqlConnection.State == ConnectionState.Open)
                {
                    sqlConnection.Close();
                }
            }

            return listData;
        }

        public int? GetCategoryIdByName(string categoryName)
        {
            try
            {
                if (CheckConnection())
                {
                    sqlConnection.Open();
                }

                string getCategoryIdQuery = "SELECT id_category FROM categories WHERE category = @category";
                using (SqlCommand getCategoryCmd = new SqlCommand(getCategoryIdQuery, sqlConnection))
                {
                    getCategoryCmd.Parameters.AddWithValue("@category", categoryName);

                    int? categoryId = null;
                    using (SqlDataReader reader = getCategoryCmd.ExecuteReader())
                    {
                        if (reader.HasRows && reader.Read())
                        {
                            categoryId = reader.GetInt32(0);
                        }
                        else
                        {
                            MessageBox.Show("Категория " + categoryName + " не найдена.", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }

                    return categoryId;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ошибка при получении categoryId: " + ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return null;
            }
            finally
            {
                if (sqlConnection.State == ConnectionState.Open)
                {
                    sqlConnection.Close();
                }
            }
        }
    }
}
