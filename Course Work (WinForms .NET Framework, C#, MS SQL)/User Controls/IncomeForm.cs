using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Drawing;
using System.Windows.Forms;

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

            dataGridViewIncome.ColumnHeadersDefaultCellStyle.BackColor = Color.FromArgb(49, 121, 74);
            dataGridViewIncome.EnableHeadersVisualStyles = false;
            dataGridViewIncome.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;
            dataGridViewIncome.ColumnHeadersDefaultCellStyle.Font = new Font(dataGridViewIncome.Font, FontStyle.Bold);
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
                dataGridViewIncome.Columns["CategoryName"].HeaderText = "Категория";
            }

            dataGridViewIncome.Columns["Item"].HeaderText = "Событие";
            dataGridViewIncome.Columns["Amount"].HeaderText = "Количество";
            dataGridViewIncome.Columns["Description"].HeaderText = "Описание";
            dataGridViewIncome.Columns["IncomeDate"].HeaderText = "Дата добавления";
        }


        private void DisplayIncomeCategories()
        {
            if (DBConnection.CheckConnection())
            {
                try
                {
                    DBConnection.SqlConnection.Open();

                    string selectData = "SELECT category FROM categories WHERE type = @type AND status = @status";

                    using (SqlCommand sqlCommand = new SqlCommand(selectData, DBConnection.SqlConnection))
                    {
                        sqlCommand.Parameters.AddWithValue("@type", "Доходы");
                        sqlCommand.Parameters.AddWithValue("@status", "Активный");

                        income_comboBoxCategory.Items.Clear();

                        SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();

                        while (sqlDataReader.Read())
                        {
                            income_comboBoxCategory.Items.Add(sqlDataReader["category"].ToString());
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
            }
        }

        private void Income_buttonAdd_Click(object sender, EventArgs e)
        {
            if (!ValidateInput())
                return;

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
                        using (SqlCommand sqlCommand = new SqlCommand(insertIncomeQuery, DBConnection.SqlConnection))
                        {
                            sqlCommand.Parameters.AddWithValue("@categoryId", categoryId.Value);
                            sqlCommand.Parameters.AddWithValue("@item", income_textBoxItem.Text);
                            sqlCommand.Parameters.AddWithValue("@amount", income_textBoxIncome.Text);
                            sqlCommand.Parameters.AddWithValue("@description", income_textBoxDescription.Text);
                            sqlCommand.Parameters.AddWithValue("@incomeDate", income_dateTimePicker.Value);

                            sqlCommand.ExecuteNonQuery();

                            MessageBox.Show("Новый источник дохода добавлен успешно!", "Информационное сообщение", MessageBoxButtons.OK, MessageBoxIcon.Information);

                            ClearFields();
                        }
                    }
                    else
                    {
                        MessageBox.Show("Категория не найдена.", "Сообщение об ошибке", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Ошибка при добавлении дохода: " + ex.Message, "Сообщение об ошибке", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                finally
                {
                    DBConnection.CloseConnection();
                }
            }
            DisplayIncomeData();
        }

        private void Income_buttonUpdate_Click(object sender, EventArgs e)
        {
            if (!ValidateInput())
                return;

            if (DBConnection.CheckConnection())
            {
                try
                {
                    IncomeData incomeData = new IncomeData();
                    int? categoryId = incomeData.GetCategoryIdByName(income_comboBoxCategory.SelectedItem.ToString());

                    DBConnection.SqlConnection.Open();

                    /*// Проверка существования категории
                    if (!incomeData.ItemExists(income_textBoxItem))
                    {
                        MessageBox.Show("Категория не существует. Пожалуйста, введите существующую категорию.", "Сообщение об ошибке", MessageBoxButtons.OK, MessageBoxIcon.Error);

                        DBConnection.CloseConnection();

                        return;
                    }*/

                    if (categoryId.HasValue)
                    {
                        // Запрос для добавления нового дохода
                        string updateIncomeQuery = "UPDATE income_3nf SET category_id = @categoryId, item = @item, amount = @amount, [description] = @description, income_date = @incomeDate WHERE id_income = @id_income";
                        using (SqlCommand sqlCommand = new SqlCommand(updateIncomeQuery, DBConnection.SqlConnection))
                        {
                            sqlCommand.Parameters.AddWithValue("@categoryId", categoryId.Value);
                            sqlCommand.Parameters.AddWithValue("@item", income_textBoxItem.Text);
                            sqlCommand.Parameters.AddWithValue("@amount", income_textBoxIncome.Text);
                            sqlCommand.Parameters.AddWithValue("@description", income_textBoxDescription.Text);
                            sqlCommand.Parameters.AddWithValue("@incomeDate", income_dateTimePicker.Value);
                            sqlCommand.Parameters.AddWithValue("@id_income", getID);

                            sqlCommand.ExecuteNonQuery();

                            MessageBox.Show("Источник дохода обновлен успешно!", "Информационное сообщение", MessageBoxButtons.OK, MessageBoxIcon.Information);

                            ClearFields();
                        }
                    }
                    else
                    {
                        MessageBox.Show("Категория не найдена: " + categoryId, "Сообщение об ошибке", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Ошибка при обновлении дохода: " + ex.Message, "Сообщение об ошибке", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                finally
                {
                    DBConnection.CloseConnection();
                }
            }
            DisplayIncomeData();
        }

        private void Income_buttonDelete_Click(object sender, EventArgs e)
        {
            if (!ValidateInput())
                return;

            if (DBConnection.CheckConnection())
            {
                try
                {
                    DBConnection.SqlConnection.Open();

                    IncomeData incomeData = new IncomeData();

                    // Проверка существования категории
                    if (!incomeData.ItemExists(income_textBoxItem))
                    {
                        MessageBox.Show("Категория не существует. Пожалуйста, введите существующую категорию.", "Сообщение об ошибке", MessageBoxButtons.OK, MessageBoxIcon.Error);

                        DBConnection.CloseConnection();

                        return;
                    }

                    // Запрос для добавления нового дохода
                    string deleteIncomeQuery = "DELETE FROM income_3nf WHERE id_income = @id_income";
                    using (SqlCommand sqlCommand = new SqlCommand(deleteIncomeQuery, DBConnection.SqlConnection))
                    {
                        sqlCommand.Parameters.AddWithValue("@id_income", getID);

                        sqlCommand.ExecuteNonQuery();

                        MessageBox.Show("Источник дохода удален успешно!", "Информационное сообщение", MessageBoxButtons.OK, MessageBoxIcon.Information);

                        ClearFields();
                    }

                }
                catch (Exception ex)
                {
                    MessageBox.Show("Ошибка при удалении дохода: " + ex.Message, "Сообщение об ошибке", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                finally
                {
                    DBConnection.CloseConnection();
                }
            }
        }

        private void Income_buttonClear_Click(object sender, EventArgs e)
        {
            ClearFields();
        }

        private void ClearFields()
        {
            income_textBoxItem.Text = "";
            income_textBoxIncome.Text = "";
            income_textBoxDescription.Text = "";
            income_comboBoxCategory.SelectedIndex = -1;
            income_dateTimePicker.Value = DateTime.Now;
        }

        private bool ValidateInput()
        {
            if (income_comboBoxCategory.SelectedItem == null)
            {
                MessageBox.Show("Пожалуйста, выберите категорию.", "Сообщение об ошибке", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

            if (string.IsNullOrWhiteSpace(income_textBoxItem.Text))
            {
                MessageBox.Show("Поле 'Наименование' не может быть пустым.", "Сообщение об ошибке", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

            if (string.IsNullOrWhiteSpace(income_textBoxIncome.Text))
            {
                MessageBox.Show("Поле 'Сумма' не может быть пустым.", "Сообщение об ошибке", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

            if (string.IsNullOrWhiteSpace(income_textBoxDescription.Text))
            {
                MessageBox.Show("Поле 'Описание' не может быть пустым.", "Сообщение об ошибке", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

            if (!decimal.TryParse(income_textBoxIncome.Text, out decimal expensesAmount))
            {
                MessageBox.Show("Поле 'Сумма' должно содержать числовое значение.", "Сообщение об ошибке", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

            return true;
        }

        private int getID = 0;
        private void DataGridViewIncome_CellClick(object sender, DataGridViewCellEventArgs e)
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
    }
}
