using System.Data.SqlClient;
using System.Data;

namespace Course_Work__WinForms.NET_Framework__C___MS_SQL_
{
    internal class DBConnection
    {
        static readonly SqlConnection sqlConnection = new SqlConnection(@"Data Source = 192.168.31.153; Initial Catalog = Tracker_DB; Persist Security Info=True;User ID = sa; Password=Basisol40@;Encrypt=False;TrustServerCertificate=True");

        public static SqlConnection SqlConnection
        {
            get { return sqlConnection; }
        }

        public static bool CheckConnection()
        {
            return sqlConnection.State == ConnectionState.Closed;
        }

        public static void CloseConnection()
        {
            if (SqlConnection.State == ConnectionState.Open)
            {
                SqlConnection.Close();
            }
        }
    }
}
