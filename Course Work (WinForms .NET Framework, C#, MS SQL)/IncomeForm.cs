using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Diagnostics.CodeAnalysis;
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
        public IncomeForm()
        {
            InitializeComponent();

            DisplayIncomeCategories();
            DisplayIncomeData();
        }

        public void RefreshData()
        {
            if (InvokeRequired)
            {
                Invoke((MethodInvoker)RefreshData);
                return;
            }

            DisplayIncomeCategories();
            DisplayIncomeData();
        }

        private void DisplayIncomeData()
        {
            IncomeData incomeData = new IncomeData();
            List<IncomeData> listData = incomeData.IncomeListData();

            dataGridViewIncome.DataSource = listData;

            // Скрываем колонку с CategoryId
            if (dataGridViewIncome.Columns["CategoryId"] != null)
            {
                dataGridViewIncome.Columns["CategoryId"].Visible = false;
            }

            if (dataGridViewIncome.Columns["ID"] != null)
            {
                dataGridViewIncome.Columns["ID"].Visible = false;
            }

            // Переименовываем колонку CategoryName для удобства
            if (dataGridViewIncome.Columns["CategoryName"] != null)
            {
                dataGridViewIncome.Columns["CategoryName"].HeaderText = "Category";
            }
        }


        private void DisplayIncomeCategories()
        {
            if (DBConnection.CheckConnection())
            {
                try
                {
                    DBConnection.SqlConnection.Open();

                    string selectData = "SELECT category FROM categories WHERE type = @type AND status = @status";

                    using (SqlCommand cmd = new SqlCommand(selectData, DBConnection.SqlConnection))
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
                    if (!DBConnection.CheckConnection())
                    {
                        DBConnection.SqlConnection.Close();
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

            if (DBConnection.CheckConnection())
            {
                try
                {
                    IncomeData incomeData = new IncomeData();
                    int? categoryId = incomeData.GetCategoryIdByName(income_comboBoxCategory.SelectedItem.ToString());

                    if (categoryId.HasValue)
                    {
                        DBConnection.SqlConnection.Open();

                        string insertIncomeQuery = "INSERT INTO income_3nf (category_id, item, amount, [description], income_date) VALUES (@categoryId, @item, @amount, @description, @incomeDate)";
                        using (SqlCommand insertCmd = new SqlCommand(insertIncomeQuery, DBConnection.SqlConnection))
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
                        MessageBox.Show("Категория не найдена.", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Ошибка при добавлении дохода: " + ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                finally
                {
                    if (!DBConnection.CheckConnection())
                    {
                        DBConnection.SqlConnection.Close();
                    }
                }
                DisplayIncomeData();
            }
        }

        private void income_buttonUpdate_Click(object sender, EventArgs e)
        {
            if (!ValidateInput())
            {
                MessageBox.Show("Пожалуйста, заполните все поля!", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);

                return;
            }

            if (DBConnection.CheckConnection())
            {
                try
                {
                    IncomeData incomeData = new IncomeData();
                    int? categoryId = incomeData.GetCategoryIdByName(income_comboBoxCategory.SelectedItem.ToString());

                    DBConnection.SqlConnection.Open();

                    if (categoryId.HasValue)
                    {
                        // Запрос для добавления нового дохода
                        string updateIncomeQuery = "UPDATE income_3nf SET category_id = @categoryId, item = @item, amount = @amount, [description] = @description, income_date = @incomeDate WHERE id_income = @id_income";
                        using (SqlCommand insertCmd = new SqlCommand(updateIncomeQuery, DBConnection.SqlConnection))
                        {
                            insertCmd.Parameters.AddWithValue("@categoryId", categoryId.Value);
                            insertCmd.Parameters.AddWithValue("@item", income_textBoxItem.Text);
                            insertCmd.Parameters.AddWithValue("@amount", income_textBoxIncome.Text);
                            insertCmd.Parameters.AddWithValue("@description", income_textBoxDescription.Text);
                            insertCmd.Parameters.AddWithValue("@incomeDate", income_dateTimePicker.Value);
                            insertCmd.Parameters.AddWithValue("@id_income", getID);

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
                    if (!DBConnection.CheckConnection())
                    {
                        DBConnection.SqlConnection.Close();
                    }
                }
                DisplayIncomeData();
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
            // Проверка, что выбран элемент в ComboBox
            if (income_comboBoxCategory.SelectedItem == null)
            {
                MessageBox.Show("Пожалуйста, выберите категорию.", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

            // Проверка валидности входных данных
            if (string.IsNullOrWhiteSpace(income_comboBoxCategory.SelectedItem.ToString()))
            {
                MessageBox.Show("Категория не может быть пустой.", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

            if (string.IsNullOrWhiteSpace(income_textBoxItem.Text))
            {
                MessageBox.Show("Поле 'Наименование' не может быть пустым.", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

            if (string.IsNullOrWhiteSpace(income_textBoxIncome.Text))
            {
                MessageBox.Show("Поле 'Сумма' не может быть пустым.", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

            if (string.IsNullOrWhiteSpace(income_textBoxDescription.Text))
            {
                MessageBox.Show("Поле 'Описание' не может быть пустым.", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

            // Проверка, что поле 'Сумма' содержит числовое значение
            if (!decimal.TryParse(income_textBoxIncome.Text, out decimal incomeAmount))
            {
                MessageBox.Show("Поле 'Сумма' должно содержать числовое значение.", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

            return true;
        }

        private int getID = 0;
        private void dataGridViewIncome_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex != -1)
            {
                DataGridViewRow row = dataGridViewIncome.Rows[e.RowIndex];

                getID = (int)row.Cells["Id"].Value;
                income_comboBoxCategory.SelectedItem = row.Cells["CategoryName"].Value;
                income_textBoxItem.Text = row.Cells["Item"].Value.ToString();
                income_textBoxIncome.Text = row.Cells["Amount"].Value.ToString();
                income_textBoxDescription.Text = row.Cells["Description"].Value.ToString();
                income_dateTimePicker.Value = Convert.ToDateTime(row.Cells["IncomeDate"].Value.ToString());
            }
        }

        private void income_buttonDelete_Click(object sender, EventArgs e)
        {
            if (!ValidateInput())
            {
                MessageBox.Show("Пожалуйста, выберите сначала источник дохода!", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);

                return;
            }

            if (DBConnection.CheckConnection())
            {
                try
                {
                    DBConnection.SqlConnection.Open();

                    // Запрос для добавления нового дохода
                    string deleteIncomeQuery = "DELETE FROM income_3nf WHERE id_income = @id_income";
                    using (SqlCommand insertCmd = new SqlCommand(deleteIncomeQuery, DBConnection.SqlConnection))
                    {
                        insertCmd.Parameters.AddWithValue("@id_income", getID);

                        insertCmd.ExecuteNonQuery();

                        MessageBox.Show("Источник дохода удален успешно!", "Успех", MessageBoxButtons.OK, MessageBoxIcon.Information);

                        ClearFields();
                    }

                }
                catch (Exception ex)
                {
                    MessageBox.Show("Ошибка при добавлении дохода: " + ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                finally
                {
                    if (!DBConnection.CheckConnection())
                    {
                        DBConnection.SqlConnection.Close();
                    }
                }
                DisplayIncomeData();
            }
        }

        private void income_buttonClear_Click(object sender, EventArgs e)
        {
            ClearFields();
        }
    }
}
