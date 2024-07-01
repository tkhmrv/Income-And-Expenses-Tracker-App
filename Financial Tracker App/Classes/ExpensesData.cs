using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace Financial.Tracker
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

                    string selectData = @"SELECT e.id_expenses, e.category_id, c.category AS category_name, e.item, 
                                        e.amount, e.description, e.expenses_date, e.user_id, e.wallet_id, w.wallet_name
                                        FROM expenses e
                                        INNER JOIN categories c ON e.category_id = c.id_category
                                        INNER JOIN wallets w ON e.wallet_id = w.id_wallet
                                        WHERE e.user_id = @userId AND (@walletId = 0 OR e.wallet_id = @walletId)";

                    using (SqlCommand sqlCommand = new SqlCommand(selectData, DBConnection.SqlConnection))
                    {
                        sqlCommand.Parameters.AddWithValue("@userId", currentUserId);
                        sqlCommand.Parameters.AddWithValue("@walletId", currentWalletId);
                        SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();

                        while (sqlDataReader.Read())
                        {
                            ExpensesData expensesData = new ExpensesData
                            {
                                Id = (int)sqlDataReader["id_expenses"],
                                CategoryId = (int)sqlDataReader["category_id"],
                                CategoryName = sqlDataReader["category_name"].ToString(),
                                Item = sqlDataReader["item"].ToString(),
                                Amount = sqlDataReader["amount"].ToString(),
                                Description = sqlDataReader["description"].ToString(),
                                ExpensesDate = ((DateTime)sqlDataReader["expenses_date"]).ToString("MM-dd-yyyy"),
                                UserId = currentUserId,
                                WalletId = (int)sqlDataReader["wallet_id"],
                                WalletName = sqlDataReader["wallet_name"].ToString()
                            };

                            listData.Add(expensesData);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ошибка при загрузке данных в классе ExpensesData: " + ex.Message, "", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
        /// <param name="idExpenses">Идентификатор элемента расходов.</param>
        /// <returns>Возвращает true, если элемент существует; иначе false.</returns>
        public static bool ItemExistsById(int idExpenses)
        {
            string query = "SELECT COUNT(*) FROM expenses WHERE id_expenses = @idExpenses";
            using (SqlCommand sqlCommand = new SqlCommand(query, DBConnection.SqlConnection))
            {
                sqlCommand.Parameters.AddWithValue("@idExpenses", idExpenses);

                int count = (int)sqlCommand.ExecuteScalar();

                return count > 0;
            }
        }
    }
}
