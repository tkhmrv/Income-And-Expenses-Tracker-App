using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Serialization;

namespace Course_Work__WinForms.NET_Framework__C___MS_SQL_
{
    public partial class IncomeForm : UserControl
    {
        private static readonly SqlConnection sqlConnection = new SqlConnection(@"Data Source = 192.168.31.153; Initial Catalog = Tracker_DB; Persist Security Info=True;User ID = sa; Password=Basisol40@;Encrypt=False;TrustServerCertificate=True");

        public IncomeForm()
        {
            InitializeComponent();

            DisplayIncomeCategories();
        }
        public bool CheckConnection()
        {
            return sqlConnection.State == ConnectionState.Closed;
        }

        private void DisplayIncomeCategories()
        {
            if (CheckConnection())
            {
                try
                {
                    sqlConnection.Open();

                    string selectData = "SELECT category FROM categories WHERE type = @type AND status = @status";

                    using (SqlCommand cmd = new SqlCommand(selectData, sqlConnection))
                    {
                        cmd.Parameters.AddWithValue("@type", "Доходы");
                        cmd.Parameters.AddWithValue("@status", "Активный");

                        income_comboBoxCategory.Items.Clear();

                        SqlDataReader reader = cmd.ExecuteReader();

                        while (reader.Read())
                        {
                            income_comboBoxCategory.Items.Add(reader["category"].ToString());
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Ошибка при загрузке данных: " + ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                finally
                {
                    if (!CheckConnection())
                    {
                        sqlConnection.Close();
                    }
                }
            }
        }

        private void income_buttonAdd_Click(object sender, EventArgs e)
        {
            if (!ValidateInput())
            {
                MessageBox.Show("Пожалуйста, заполните все поля!", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);

                return;
            }

            if (CheckConnection())
            {
                try
                {
                    int? categoryId = GetCategoryId(income_comboBoxCategory.SelectedItem.ToString());

                    sqlConnection.Open();

                    if (categoryId.HasValue)
                    {
                        // Запрос для добавления нового дохода
                        string insertIncomeQuery = "INSERT INTO income_3nf (category_id, item, amount, [description], income_date) VALUES (@categoryId, @item, @amount, @description, @incomeDate)";
                        using (SqlCommand insertCmd = new SqlCommand(insertIncomeQuery, sqlConnection))
                        {
                            insertCmd.Parameters.AddWithValue("@categoryId", categoryId.Value);
                            insertCmd.Parameters.AddWithValue("@item", income_textBoxItem.Text);
                            insertCmd.Parameters.AddWithValue("@amount", income_textBoxIncome.Text);
                            insertCmd.Parameters.AddWithValue("@description", income_textBoxDescription.Text);
                            insertCmd.Parameters.AddWithValue("@incomeDate", income_dateTimePicker.Value);

                            insertCmd.ExecuteNonQuery();

                            MessageBox.Show("Новый источник дохода добавлен успешно!", "Успех", MessageBoxButtons.OK, MessageBoxIcon.Information);

                            ClearFields();
                        }
                    }
                    else
                    {
                        MessageBox.Show("Категория не найдена:" + categoryId, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }

                }
                catch (Exception ex)
                {
                    MessageBox.Show("Ошибка при добавлении дохода: " + ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                finally
                {
                    if (!CheckConnection())
                    {
                        sqlConnection.Close();
                    }
                }
            }
        }

        private void income_buttonUpdate_Click(object sender, EventArgs e)
        {
            if (!ValidateInput())
            {
                MessageBox.Show("Пожалуйста, заполните все поля!", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);

                return;
            }

            if (CheckConnection())
            {
                try
                {
                    int? categoryId = GetCategoryId(income_comboBoxCategory.SelectedItem.ToString());

                    sqlConnection.Open();

                    if (categoryId.HasValue)
                    {
                        // Запрос для добавления нового дохода
                        string updateIncomeQuery = "UPDATE income_3nf SET category_id = @categoryId, item = @item, amount = @amount, [description] = @description, income_date = @incomeDate WHERE id_income = @id_income";
                        using (SqlCommand insertCmd = new SqlCommand(updateIncomeQuery, sqlConnection))
                        {
                            insertCmd.Parameters.AddWithValue("@categoryId", categoryId.Value);
                            insertCmd.Parameters.AddWithValue("@item", income_textBoxItem.Text);
                            insertCmd.Parameters.AddWithValue("@amount", income_textBoxIncome.Text);
                            insertCmd.Parameters.AddWithValue("@description", income_textBoxDescription.Text);
                            insertCmd.Parameters.AddWithValue("@incomeDate", income_dateTimePicker.Value);

                            insertCmd.ExecuteNonQuery();

                            MessageBox.Show("Источник дохода обновлен успешно!", "Успех", MessageBoxButtons.OK, MessageBoxIcon.Information);

                            ClearFields();
                        }
                    }
                    else
                    {
                        MessageBox.Show("Категория не найдена: " + categoryId, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }

                }
                catch (Exception ex)
                {
                    MessageBox.Show("Ошибка при добавлении дохода: " + ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                finally
                {
                    if (!CheckConnection())
                    {
                        sqlConnection.Close();
                    }
                }
            }
        }

        /// <summary>
        /// Функция, соединяющая таблицы для получения категории в текстовом виде (3нф)
        /// </summary>
        /// <param name="categoryName"></param>
        /// <returns>айдишник категории для записи в бд</returns>
        public int? GetCategoryId(string categoryName)
        {
            try
            {
                sqlConnection.Open();

                // Запрос для получения id_category по выбранной категории
                string getCategoryIdQuery = "SELECT c.id_category FROM categories c INNER JOIN income_3nf i ON c.id_category = i.category_id WHERE c.category = @category";
                using (SqlCommand getCategoryCmd = new SqlCommand(getCategoryIdQuery, sqlConnection))
                {
                    getCategoryCmd.Parameters.AddWithValue("@category", categoryName);

                    int? categoryId = null;
                    using (SqlDataReader reader = getCategoryCmd.ExecuteReader())
                    {
                        if (reader.HasRows)
                        {
                            if (reader.Read())
                            {
                                categoryId = reader.GetInt32(0);
                            }
                        }
                        else
                        {
                            MessageBox.Show("Запрос не вернул строк. Категория" + categoryName + "не найдена.", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }

                    return categoryId;
                }
            }
            catch (Exception ex)
            {
                // Обработка исключений, например, логирование ошибки
                Console.WriteLine($"Ошибка при получении categoryId: {ex.Message}");
                return null;
            }
            finally
            {
                if (!CheckConnection())
                {
                    sqlConnection.Close();
                }
            }
        }

        private void ClearFields()
        {
            income_textBoxItem.Text = "";
            income_textBoxIncome.Text = "";
            income_textBoxDescription.Text = "";
            income_comboBoxCategory.SelectedIndex = -1;
        }

        private bool ValidateInput()
        {
            // Проверка валидности входных данных
            return !string.IsNullOrEmpty(income_comboBoxCategory.SelectedItem.ToString()) &&
                  !string.IsNullOrEmpty(income_textBoxItem.Text) &&
                  !string.IsNullOrEmpty(income_textBoxIncome.Text) &&
                  !string.IsNullOrEmpty(income_textBoxDescription.Text);
        }

        private void dataGridViewIncome_CellClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
