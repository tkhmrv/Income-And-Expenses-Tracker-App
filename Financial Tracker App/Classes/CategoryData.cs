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

                    string selectData = "SELECT * FROM categories WHERE user_id = @userid";
                    if (MainForm.CurrentWalletId != 0)
                        selectData += " AND wallet_id = @walletId";

                    using (SqlCommand sqlCommand = new SqlCommand(selectData, DBConnection.SqlConnection))
                    {
                        sqlCommand.Parameters.AddWithValue("@userid", AuthForm.CurrentUserId);
                        if (MainForm.CurrentWalletId != 0)
                            sqlCommand.Parameters.AddWithValue("@walletId", MainForm.CurrentWalletId);

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
                                UserId = AuthForm.CurrentUserId,
                                WalletId = (int)sqlDataReader["wallet_id"]
                            };

                            listData.Add(categoryData);
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
        /// Проверяет, существует ли категория в базе данных.
        /// </summary>
        /// <param name="textBoxName">TextBox с названием категории для проверки.</param>
        /// <returns>Возвращает true, если категория существует; иначе false.</returns>
        public bool CategoryExistsById (int categoryId)
        {
            string checkCategoryQuery = "SELECT COUNT(*) FROM categories WHERE id_category = @id";
            using (SqlCommand sqlCommand = new SqlCommand(checkCategoryQuery, DBConnection.SqlConnection))
            {
                sqlCommand.Parameters.AddWithValue("@id", categoryId);
                int count = Convert.ToInt32(sqlCommand.ExecuteScalar());
                return count > 0;
            }
        }

        public bool CategoryExistsByName (string categoryName, int walletId)
        {
            string checkCategoryQuery = "SELECT * FROM categories WHERE category = @category AND wallet_id = @walletid";
            using (SqlCommand sqlCommand = new SqlCommand(checkCategoryQuery, DBConnection.SqlConnection))
            {
                sqlCommand.Parameters.AddWithValue("@category", categoryName);
                sqlCommand.Parameters.AddWithValue("@walletid", walletId);
                int count = Convert.ToInt32(sqlCommand.ExecuteScalar());
                return count > 0;
            }
        }
    }
}
