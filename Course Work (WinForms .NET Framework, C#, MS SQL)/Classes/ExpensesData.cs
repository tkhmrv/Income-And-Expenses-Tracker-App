using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace Course_Work__WinForms.NET_Framework__C___MS_SQL_
{
    /// <summary>
    /// Класс для работы с данными расходов.
    /// </summary>
    internal class ExpensesData
    {
        /// <summary>
        /// Идентификатор расхода.
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Идентификатор категории.
        /// </summary>
        public int CategoryId { get; set; }

        /// <summary>
        /// Название категории.
        /// </summary>
        public string CategoryName { get; set; }

        /// <summary>
        /// Наименование расхода.
        /// </summary>
        public string Item { get; set; }

        /// <summary>
        /// Сумма расхода.
        /// </summary>
        public string Amount { get; set; }

        /// <summary>
        /// Описание расхода.
        /// </summary>
        public string Description { get; set; }

        /// <summary>
        /// Дата расхода.
        /// </summary>
        public string ExpensesDate { get; set; }

        /// <summary>
        /// Получает список всех расходов из базы данных.
        /// </summary>
        /// <returns>Список данных расходов.</returns>
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

                    using (SqlCommand sqlCommand = new SqlCommand(selectData, DBConnection.SqlConnection))
                    {
                        SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();

                        while (sqlDataReader.Read())
                        {
                            ExpensesData expensesData = new ExpensesData
                            {
                                Id = (int)sqlDataReader["id_expenses"],
                                CategoryId = (int)sqlDataReader["category_id"],
                                CategoryName = sqlDataReader["CategoryName"].ToString(),
                                Item = sqlDataReader["item"].ToString(),
                                Amount = sqlDataReader["amount"].ToString(),
                                Description = sqlDataReader["description"].ToString(),
                                ExpensesDate = ((DateTime)sqlDataReader["expenses_date"]).ToString("MM-dd-yyyy")
                            };

                            listData.Add(expensesData);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ошибка при загрузке данных: " + ex.Message, "", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                DBConnection.CloseConnection();
            }

            return listData;
        }

        /// <summary>
        /// Получает идентификатор категории по её названию.
        /// </summary>
        /// <param name="categoryName">Название категории.</param>
        /// <returns>Идентификатор категории или null, если категория не найдена.</returns>
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
                            MessageBox.Show("Категория " + categoryName + " не найдена.", "Сообщение об ошибке", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                    return categoryId;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ошибка при получении categoryId: " + ex.Message, "Сообщение об ошибке", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return null;
            }
            finally
            {
                DBConnection.CloseConnection();
            }
        }

        /// <summary>
        /// Проверяет, существует ли элемент в базе данных.
        /// </summary>
        /// <param name="textBoxName">TextBox с названием элемента для проверки.</param>
        /// <returns>Возвращает true, если элемент существует; иначе false.</returns>
        public bool ItemExists(TextBox textBoxName)
        {
            string query = "SELECT COUNT(*) FROM expenses WHERE item = @item";
            using (SqlCommand sqlCommand = new SqlCommand(query, DBConnection.SqlConnection))
            {
                sqlCommand.Parameters.AddWithValue("@item", textBoxName.Text.Trim());

                DBConnection.SqlConnection.Open();
                int count = (int)sqlCommand.ExecuteScalar();
                DBConnection.SqlConnection.Close();

                return count > 0;
            }
        }
    }
}
