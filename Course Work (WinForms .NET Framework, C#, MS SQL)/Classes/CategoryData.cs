using System.Collections.Generic;
using System.Data.SqlClient;
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

        public List<CategoryData> CategoryListData()
        {
            List<CategoryData> listData = new List<CategoryData>();

            try
            {
                if (DBConnection.CheckConnection())
                {
                    DBConnection.SqlConnection.Open();

                    string selectData = "SELECT * FROM categories";

                    using (SqlCommand sqlCommand = new SqlCommand(selectData, DBConnection.SqlConnection))
                    using (SqlDataReader sqlDataReader = sqlCommand.ExecuteReader())
                    {
                        while (sqlDataReader.Read())
                        {
                            CategoryData categoryData = new CategoryData
                            {
                                ID = (int)sqlDataReader["id_category"],
                                Category = sqlDataReader["category"].ToString(),
                                Type = sqlDataReader["type"].ToString(),
                                Status = sqlDataReader["status"].ToString(),
                                Date = ((DateTime)sqlDataReader["creation_date"]).ToString("MM-dd-yyyy")
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

        public bool CategoryExists(TextBox textBoxName)
        {
            string checkCategoryQuery = "SELECT COUNT(*) FROM categories WHERE category = @category";
            using (SqlCommand sqlCommand = new SqlCommand(checkCategoryQuery, DBConnection.SqlConnection))
            {
                sqlCommand.Parameters.AddWithValue("@category", textBoxName.Text.Trim());
                int count = Convert.ToInt32(sqlCommand.ExecuteScalar());
                return count > 0;
            }
        }
    }
}
