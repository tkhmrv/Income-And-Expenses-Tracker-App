using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Windows.Forms;
using System;

namespace Course_Work__WinForms.NET_Framework__C___MS_SQL_
{
    internal class CategoryData
    {
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
                if (DBConnection.CheckConnection())
                {
                    DBConnection.SqlConnection.Open();

                    string selectData = "SELECT * FROM categories";

                    using (SqlCommand cmd = new SqlCommand(selectData, DBConnection.SqlConnection))
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
                if (DBConnection.CheckConnection())
                {
                    DBConnection.SqlConnection.Close();
                }
            }

            return listData;
        }
    }
}
