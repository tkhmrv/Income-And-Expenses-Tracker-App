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
        /// Отстаток на кошелке в фиате.
        /// </summary>
        //public string MoneyAmount { get; set; }

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
        /// Получает список всех кошельков из базы данных.
        /// </summary>
        /// <returns>Список данных кошельков.</returns>
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
                        sqlCommand.Parameters.AddWithValue("@userId", AuthForm.CurrentUserId);
                        SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();
                    
                        while (sqlDataReader.Read())
                        {
                            WalletData walletData = new WalletData
                            {
                                ID = (int)sqlDataReader["id_wallet"],
                                UserId = AuthForm.CurrentUserId,
                                WalletName = sqlDataReader["wallet_name"].ToString(),
                                //MoneyAmount = sqlDataReader["money_amount"].ToString(),
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
        public bool WalletExists(TextBox textBoxName)
        {
            string checkCategoryQuery = "SELECT COUNT(*) FROM wallets WHERE wallet_name = @wallet_name";
            using (SqlCommand sqlCommand = new SqlCommand(checkCategoryQuery, DBConnection.SqlConnection))
            {
                sqlCommand.Parameters.AddWithValue("@wallet_name", textBoxName.Text.Trim());
                int count = Convert.ToInt32(sqlCommand.ExecuteScalar());
                return count > 0;
            }
        }
    }
}
