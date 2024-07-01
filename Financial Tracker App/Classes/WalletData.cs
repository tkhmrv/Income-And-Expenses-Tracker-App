using System.Collections.Generic;
using System.Data.SqlClient;
using System.Windows.Forms;
using System;

namespace Financial.Tracker
{
    /// <summary>
    /// Класс для работы с данными категорий.
    /// </summary>
    internal class WalletData
    {
        /// <summary>
        /// Идентификатор кошелька.
        /// </summary>
        public int ID { get; set; }

        /// <summary>
        /// Идентификатор пользователя.
        /// </summary>
        public int UserId { get; set; }

        /// <summary>
        /// Название кошелька.
        /// </summary>
        public string WalletName { get; set; }

        /// <summary>
        /// Тип кошелька.
        /// </summary>
        public string Type { get; set; }

        /// <summary>
        /// Статус кошелька.
        /// </summary>
        public string Status { get; set; }

        /// <summary>
        /// Описание кошелька.
        /// </summary>
        public string Description { get; set; }

        /// <summary>
        /// Дата создания кошелька.
        /// </summary>
        public string Date { get; set; }

        /// <summary>
        /// Идентификатор текущего пользователя.
        /// </summary>
        private int currentUserId => AuthForm.CurrentUserId;

        /// <summary>
        /// Получает список всех кошельков из базы данных.
        /// </summary>
        /// <returns>Список с данными кошельков.</returns>
        public List<WalletData> WalletListData()
        {
            List<WalletData> listData = new List<WalletData>();

            try
            {
                if (DBConnection.CheckConnection())
                {
                    DBConnection.SqlConnection.Open();

                    string selectData = "SELECT * FROM wallets WHERE user_id = @userId";

                    using (SqlCommand sqlCommand = new SqlCommand(selectData, DBConnection.SqlConnection))
                    {
                        sqlCommand.Parameters.AddWithValue("@userId", currentUserId);
                        SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();
                    
                        while (sqlDataReader.Read())
                        {
                            WalletData walletData = new WalletData
                            {
                                ID = (int)sqlDataReader["id_wallet"],
                                UserId = currentUserId,
                                WalletName = sqlDataReader["wallet_name"].ToString(),
                                Type = sqlDataReader["type"].ToString(),
                                Status = sqlDataReader["status"].ToString(),
                                Description = sqlDataReader["description"].ToString(),
                                Date = ((DateTime)sqlDataReader["creation_date"]).ToString("MM-dd-yyyy"),
                            };

                            listData.Add(walletData);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ошибка при загрузке данных в классе WalletData: " + ex.Message, "Сообщение об ошибке", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                DBConnection.CloseConnection();
            }

            return listData;
        }

        /// <summary>
        /// Метод для проверки существования кошелька по имени и идентификатору пользователя.
        /// </summary>
        /// <param name="walletName">Имя кошелька.</param>
        /// <param name="userId">Идентификатор пользователя.</param>
        /// <returns>Возвращает true, если кошелек существует; иначе false.</returns>
        public static bool WalletExistsByName(string walletName, int userId)
        {
            string checkCategoryQuery = "SELECT * FROM wallets WHERE wallet_name = @walletName AND user_id = @userId";
            using (SqlCommand sqlCommand = new SqlCommand(checkCategoryQuery, DBConnection.SqlConnection))
            {
                sqlCommand.Parameters.AddWithValue("@walletName", walletName);
                sqlCommand.Parameters.AddWithValue("@userId", userId);
                int count = Convert.ToInt32(sqlCommand.ExecuteScalar());
                return count > 0;
            }
        }

        /// <summary>
        /// Проверяет, существует ли кошелек в базе данных.
        /// </summary>
        /// <param name="textBoxName">TextBox с названием категории для проверки.</param>
        /// <returns>Возвращает true, если категория существует; иначе false.</returns>
        public static bool WalletExistsById(int idWallet)
        {
            string checkCategoryQuery = "SELECT COUNT(*) FROM wallets WHERE id_wallet = @idWallet";
            using (SqlCommand sqlCommand = new SqlCommand(checkCategoryQuery, DBConnection.SqlConnection))
            {
                sqlCommand.Parameters.AddWithValue("@idWallet", idWallet);
                int count = Convert.ToInt32(sqlCommand.ExecuteScalar());
                return count > 0;
            }
        }
    }
}
