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
        /// Название кошелька.
        /// </summary>
        public string WalletName { get; set; }

        /// <summary>
        /// Идентификатор текущего пользователя.
        /// </summary>
        private int currentUserId => AuthForm.CurrentUserId;

        /// <summary>
        /// Идентификатор текущего кошелька.
        /// </summary>
        private int currentWalletId => MainForm.CurrentWalletId;

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

                    string selectData = @"SELECT i.id_income, i.category_id, c.category AS category_name, 
                                      i.item, i.amount, i.description, i.income_date, i.user_id, i.wallet_id, w.wallet_name
                                      FROM income_3nf i
                                      INNER JOIN categories c ON i.category_id = c.id_category
                                      INNER JOIN wallets w ON i.wallet_id = w.id_wallet
                                      WHERE i.user_id = @userId AND (@walletId = 0 OR i.wallet_id = @walletId)";

                    using (SqlCommand sqlCommand = new SqlCommand(selectData, DBConnection.SqlConnection))
                    {
                        sqlCommand.Parameters.AddWithValue("@userId", currentUserId);
                        sqlCommand.Parameters.AddWithValue("@walletId", currentWalletId);
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
                                UserId = currentUserId,
                                WalletId = (int)sqlDataReader["wallet_id"],
                                WalletName = sqlDataReader["wallet_name"].ToString()
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
        /// Получает идентификатор категории по её названию и идентификатору кошелька.
        /// </summary>
        /// <param name="categoryName">Название категории.</param>
        /// <param name="walletId">Идентификатор кошелька.</param>
        /// <returns>Идентификатор категории или null, если категория не найдена.</returns>
        public static int? GetCategoryIdByName(string categoryName, int walletId)
        {
            try
            {
                if (DBConnection.CheckConnection())
                {
                    DBConnection.SqlConnection.Open();
                }

                string getCategoryIdQuery = "SELECT id_category FROM categories WHERE category = @category AND wallet_id = @walletId";
                using (SqlCommand getCategoryCmd = new SqlCommand(getCategoryIdQuery, DBConnection.SqlConnection))
                {
                    getCategoryCmd.Parameters.AddWithValue("@category", categoryName);
                    getCategoryCmd.Parameters.AddWithValue("@walletId", walletId);

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
        /// <param name="idIncome">Идентификатор элемента дохода.</param>
        /// <returns>Возвращает true, если элемент существует; иначе false.</returns>
        public static bool ItemExistsById(int idIncome)
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
