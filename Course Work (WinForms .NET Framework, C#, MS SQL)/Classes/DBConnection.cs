using System.Data.SqlClient;
using System.Data;

namespace Course_Work__WinForms.NET_Framework__C___MS_SQL_
{
    /// <summary>
    /// Класс для управления подключением к базе данных.
    /// </summary>
    internal class DBConnection
    {
        /// <summary>
        /// Экземпляр подключения к базе данных.
        /// </summary>
        static readonly SqlConnection sqlConnection = new SqlConnection(@"Data Source = 192.168.175.168; Initial Catalog = Tracker_DB; Persist Security Info=True;User ID = admin; Password=Sa1234@@;Encrypt=False;TrustServerCertificate=True");

        /// <summary>
        /// Возвращает экземпляр подключения к базе данных.
        /// </summary>
        public static SqlConnection SqlConnection
        {
            get { return sqlConnection; }
        }

        /// <summary>
        /// Проверяет, закрыто ли соединение с базой данных.
        /// </summary>
        /// <returns>Возвращает true, если соединение закрыто; в противном случае возвращает false.</returns>
        public static bool CheckConnection()
        {
            return sqlConnection.State == ConnectionState.Closed;
        }

        /// <summary>
        /// Закрывает соединение с базой данных, если оно открыто.
        /// </summary>
        public static void CloseConnection()
        {
            if (SqlConnection.State == ConnectionState.Open)
            {
                SqlConnection.Close();
            }
        }
    }
}

