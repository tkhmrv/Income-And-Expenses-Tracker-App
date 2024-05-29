using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Windows.Forms;
using System;

internal class CategoryData
{
    private static readonly SqlConnection sqlConnection = new SqlConnection(@"Data Source = 192.168.31.153; Initial Catalog = Tracker_DB; Persist Security Info=True;User ID = sa; Password=Basisol40@;Encrypt=False;TrustServerCertificate=True");

    public bool CheckConnection()
    {
        return sqlConnection.State == ConnectionState.Closed;
    }

    public int ID { get; set; }
    public string Category { get; set; }
    public string Type { get; set; }
    public string Status { get; set; }
    public string Date { get; set; }

    public List<CategoryData> categoryListData()
    {
        List<CategoryData> listData = new List<CategoryData>();

        try
        {
            if (CheckConnection())
            {
                sqlConnection.Open();

                string selectData = "SELECT * FROM categories";

                using (SqlCommand cmd = new SqlCommand(selectData, sqlConnection))
                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        CategoryData categoryData = new CategoryData
                        {
                            ID = (int)reader["id_category"],
                            Category = reader["category"].ToString(),
                            Type = reader["type"].ToString(),
                            Status = reader["status"].ToString(),
                            Date = ((DateTime)reader["creation_date"]).ToString("MM-dd-yyyy")
                        };

                        listData.Add(categoryData);
                    }
                }
            }
        }
        catch (Exception ex)
        {
            MessageBox.Show("Ошибка при загрузке данных: " + ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
        finally
        {
            if (sqlConnection.State == ConnectionState.Open)
            {
                sqlConnection.Close();
            }
        }

        return listData;
    }
}
