using System.Collections.Generic;
using System.Data.SqlClient;
using System.Windows.Forms;
using System;

namespace Financial.Tracker
{
    /// <summary>
    /// Класс для работы с данными категорий.
    /// </summary>
    internal class CategoryData
    {
        /// <summary>
        /// Идентификатор категории.
        /// </summary>
        public int ID { get; set; }

        /// <summary>
        /// Название категории.
        /// </summary>
        public string Category { get; set; }

        /// <summary>
        /// Тип категории.
        /// </summary>
        public string Type { get; set; }

        /// <summary>
        /// Статус категории.
        /// </summary>
        public string Status { get; set; }

        /// <summary>
        /// Дата создания категории.
        /// </summary>
        public string Date { get; set; }

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
        /// Получает список всех категорий из базы данных.
        /// </summary>
        /// <returns>Список данных категорий.</returns>
        public List<CategoryData> CategoryListData()
        {
            List<CategoryData> listData = new List<CategoryData>();

            try
            {
                if (DBConnection.CheckConnection())
                {
                    DBConnection.SqlConnection.Open();

                    string selectData = "SELECT c.id_category, c.category, c.type, c.status, c.creation_date, c.user_id, c.wallet_id, w.wallet_name " +
                                        "FROM categories c " + 
                                        "INNER JOIN wallets w ON c.wallet_id = w.id_wallet " +
                                        "WHERE (@walletId = 0 OR c.wallet_id = @walletId) AND c.user_id = @userId";

                    using (SqlCommand sqlCommand = new SqlCommand(selectData, DBConnection.SqlConnection))
                    {
                        sqlCommand.Parameters.AddWithValue("@userId", currentUserId);
                        sqlCommand.Parameters.AddWithValue("@walletId", currentWalletId);

                        SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();

                        while (sqlDataReader.Read())
                        {
                            CategoryData categoryData = new CategoryData
                            {
                                ID = (int)sqlDataReader["id_category"],
                                Category = sqlDataReader["category"].ToString(),
                                Type = sqlDataReader["type"].ToString(),
                                Status = sqlDataReader["status"].ToString(),
                                Date = ((DateTime)sqlDataReader["creation_date"]).ToString("MM-dd-yyyy"),
                                UserId = currentUserId,
                                WalletId = (int)sqlDataReader["wallet_id"],
                                WalletName = sqlDataReader["wallet_name"].ToString()
                            };

                            listData.Add(categoryData);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ошибка при загрузке данных в классе CategoryData: " + ex.Message, "Сообщение об ошибке", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                DBConnection.CloseConnection();
            }

            return listData;
        }

        /// <summary>
        /// Проверяет, существует ли категория в базе данных по имени и идентификатору кошелька.
        /// </summary>
        /// <param name="categoryName">Имя категории.</param>
        /// <param name="walletId">Идентификатор кошелька.</param>
        /// <returns>Возвращает true, если категория существует; иначе false.</returns>
        public static bool CategoryExistsByName(string categoryName, int walletId)
        {
            string checkCategoryQuery = "SELECT * FROM categories WHERE category = @category AND wallet_id = @walletId";
            using (SqlCommand sqlCommand = new SqlCommand(checkCategoryQuery, DBConnection.SqlConnection))
            {
                sqlCommand.Parameters.AddWithValue("@category", categoryName);
                sqlCommand.Parameters.AddWithValue("@walletId", walletId);
                int count = Convert.ToInt32(sqlCommand.ExecuteScalar());
                return count > 0;
            }
        }

        /// <summary>
        /// Проверяет, существует ли категория в базе данных по ее идентификатору.
        /// </summary>
        /// <param name="categoryId">Идентификатор категории.</param>
        /// <returns>Возвращает true, если категория существует; иначе false.</returns>
        public static bool CategoryExistsById(int categoryId)
        {
            string checkCategoryQuery = "SELECT COUNT(*) FROM categories WHERE id_category = @id";
            using (SqlCommand sqlCommand = new SqlCommand(checkCategoryQuery, DBConnection.SqlConnection))
            {
                sqlCommand.Parameters.AddWithValue("@id", categoryId);
                int count = Convert.ToInt32(sqlCommand.ExecuteScalar());
                return count > 0;
            }
        }
    }
}
