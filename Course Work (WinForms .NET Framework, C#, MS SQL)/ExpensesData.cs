using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Course_Work__WinForms.NET_Framework__C___MS_SQL_
{
    internal class ExpensesData
    {
        public int Id { get; set; }
        public int CategoryId { get; set; }
        public string CategoryName { get; set; }
        public string Item { get; set; }
        public string Amount { get; set; }
        public string Description { get; set; }
        public string ExpensesDate { get; set; }


        public List<ExpensesData> ExpensesListData()
        {
            List<ExpensesData> listData = new List<ExpensesData>();

            try
            {
                if (DBConnection.CheckConnection())
                {
                    DBConnection.SqlConnection.Open();

                    string selectData = @"SELECT e.id_expenses, e.category_id, c.category AS CategoryName, e.item, e.amount, e.description, e.expenses_date
                                          FROM expenses e
                                          JOIN categories c ON e.category_id = c.id_category";

                    using (SqlCommand cmd = new SqlCommand(selectData, DBConnection.SqlConnection))
                    {
                        SqlDataReader reader = cmd.ExecuteReader();

                        while (reader.Read())
                        {
                            ExpensesData expensesData = new ExpensesData
                            {
                                Id = (int)reader["id_expenses"],
                                CategoryId = (int)reader["category_id"],
                                CategoryName = reader["CategoryName"].ToString(),
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
                if (!DBConnection.CheckConnection())
                {
                    DBConnection.SqlConnection.Close();
                }
            }

            return listData;
        }


        public int? GetCategoryIdByName(string categoryName)
        {
            try
            {
                if (DBConnection.CheckConnection())
                {
                    DBConnection.SqlConnection.Open();
                }

                string getCategoryIdQuery = "SELECT id_category FROM categories WHERE category = @category";
                using (SqlCommand getCategoryCmd = new SqlCommand(getCategoryIdQuery, DBConnection.SqlConnection))
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
                if (!DBConnection.CheckConnection())
                {
                    DBConnection.SqlConnection.Close();
                }
            }
        }
    }
}
