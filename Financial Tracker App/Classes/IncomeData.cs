using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace Financial.Tracker
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
        /// Идентификатор пользователя
        /// </summary>
        public int UserId { get; set; }

        /// <summary>
        /// Идентификатор кошелька.
        /// </summary>
        public int WalletId { get; set; }

        /// <summary>
        /// Получает список всех доходов из базы данных.
        /// </summary>
        /// <returns>Список данных доходов.</returns>
        /// 
        public List<IncomeData> IncomeListData()
        {
            List<IncomeData> listData = new List<IncomeData>();

            try
            {
                if (DBConnection.CheckConnection())
                {
                    DBConnection.SqlConnection.Open();

                    string selectData = @"SELECT income_3nf.id_income, income_3nf.category_id, categories.category AS category_name, 
                                      income_3nf.item, income_3nf.amount, income_3nf.description, income_3nf.income_date, income_3nf.user_id,
                                      income_3nf.wallet_id
                                      FROM income_3nf 
                                      INNER JOIN categories ON income_3nf.category_id = categories.id_category
                                      WHERE income_3nf.user_id = @userId";
                    if (MainForm.CurrentWalletId != 0)
                        selectData += " AND income_3nf.wallet_id = @wallet_id";

                    using (SqlCommand sqlCommand = new SqlCommand(selectData, DBConnection.SqlConnection))
                    {
                        sqlCommand.Parameters.AddWithValue("@userId", AuthForm.CurrentUserId);
                        if (MainForm.CurrentWalletId != 0)
                            sqlCommand.Parameters.AddWithValue("@wallet_id", MainForm.CurrentWalletId);
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
                                IncomeDate = ((DateTime)sqlDataReader["income_date"]).ToString("MM-dd-yyyy"),
                                UserId = AuthForm.CurrentUserId,
                                WalletId = (int)sqlDataReader["wallet_id"]
                            };

                            listData.Add(incomeData);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ошибка при загрузке данных в классе IncomeData: " + ex.Message, "Сообщение об ошибке", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
        public int? GetCategoryIdByName(string categoryName, int walletId)
        {
            try
            {
                if (DBConnection.CheckConnection())
                {
                    DBConnection.SqlConnection.Open();
                }

                string getCategoryIdQuery = "SELECT id_category FROM categories WHERE category = @category AND wallet_id = @walletid";
                using (SqlCommand getCategoryCmd = new SqlCommand(getCategoryIdQuery, DBConnection.SqlConnection))
                {
                    getCategoryCmd.Parameters.AddWithValue("@category", categoryName);
                    getCategoryCmd.Parameters.AddWithValue("@walletid", walletId);

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
        public bool ItemExists(int idIncome)
        {
            string query = "SELECT COUNT(*) FROM income_3nf WHERE id_income = @idIncome";
            using (SqlCommand sqlCommand = new SqlCommand(query, DBConnection.SqlConnection))
            {
                sqlCommand.Parameters.AddWithValue("@idIncome", idIncome);

                int count = (int)sqlCommand.ExecuteScalar();

                return count > 0;
            }
        }
    }
}
