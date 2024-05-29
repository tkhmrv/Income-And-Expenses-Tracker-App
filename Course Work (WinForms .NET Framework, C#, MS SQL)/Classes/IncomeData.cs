using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace Course_Work__WinForms.NET_Framework__C___MS_SQL_
{
    /// <summary>
    /// Класс для работы с данными доходов.
    /// </summary>
    internal class IncomeData
    {
        /// <summary>
        /// Идентификатор дохода.
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
        /// Наименование дохода.
        /// </summary>
        public string Item { get; set; }

        /// <summary>
        /// Сумма дохода.
        /// </summary>
        public string Amount { get; set; }

        /// <summary>
        /// Описание дохода.
        /// </summary>
        public string Description { get; set; }

        /// <summary>
        /// Дата дохода.
        /// </summary>
        public string IncomeDate { get; set; }

        /// <summary>
        /// Получает список всех доходов из базы данных.
        /// </summary>
        /// <returns>Список данных доходов.</returns>
        public List<IncomeData> IncomeListData()
        {
            List<IncomeData> listData = new List<IncomeData>();

            try
            {
                if (DBConnection.CheckConnection())
                {
                    DBConnection.SqlConnection.Open();

                    string selectData = @"SELECT income_3nf.id_income, income_3nf.category_id, categories.category AS category_name, 
                                      income_3nf.item, income_3nf.amount, income_3nf.description, income_3nf.income_date 
                                      FROM income_3nf 
                                      INNER JOIN categories ON income_3nf.category_id = categories.id_category";

                    using (SqlCommand sqlCommand = new SqlCommand(selectData, DBConnection.SqlConnection))
                    {
                        SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();

                        while (sqlDataReader.Read())
                        {
                            IncomeData incomeData = new IncomeData
                            {
                                Id = (int)sqlDataReader["id_income"],
                                CategoryId = (int)sqlDataReader["category_id"],
                                CategoryName = sqlDataReader["category_name"].ToString(),
                                Item = sqlDataReader["item"].ToString(),
                                Amount = sqlDataReader["amount"].ToString(),
                                Description = sqlDataReader["description"].ToString(),
                                IncomeDate = ((DateTime)sqlDataReader["income_date"]).ToString("MM-dd-yyyy")
                            };

                            listData.Add(incomeData);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ошибка при загрузке данных: " + ex.Message, "Сообщение об ошибке", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
                    using (SqlDataReader sqlDataReader = getCategoryCmd.ExecuteReader())
                    {
                        if (sqlDataReader.HasRows && sqlDataReader.Read())
                        {
                            categoryId = sqlDataReader.GetInt32(0);
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
            string query = "SELECT COUNT(*) FROM income_3nf WHERE item = @item";
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
