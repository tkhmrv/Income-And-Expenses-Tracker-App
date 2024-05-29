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

namespace Course_Work__WinForms.NET_Framework__C___MS_SQL_
{
    public partial class ExpensesForm : UserControl
    {
        public ExpensesForm()
        {
            InitializeComponent();

            DisplayExpensesCategories();

            DisplayExpensesData();
        }

        public void RefreshData()
        {
            if (InvokeRequired)
            {
                Invoke((MethodInvoker)RefreshData);
                return;
            }

            DisplayExpensesCategories();
            DisplayExpensesData();
        }

            private void DisplayExpensesCategories()
        {
            if (DBConnection.CheckConnection())
            {
                try
                {
                    DBConnection.SqlConnection.Open();

                    string selectData = "SELECT category FROM categories WHERE type = @type AND status = @status";

                    using (SqlCommand cmd = new SqlCommand(selectData, DBConnection.SqlConnection))
                    {
                        cmd.Parameters.AddWithValue("@type", "Расходы");
                        cmd.Parameters.AddWithValue("@status", "Активный");

                        expenses_comboBoxCategory.Items.Clear();

                        SqlDataReader reader = cmd.ExecuteReader();

                        while (reader.Read())
                        {
                            expenses_comboBoxCategory.Items.Add(reader["category"].ToString());
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

        private void DisplayExpensesData()
        {
            ExpensesData expensesData = new ExpensesData();
            List<ExpensesData> listData = expensesData.ExpensesListData();

            dataGridViewExpenses.DataSource = listData;

            // Скрываем колонку с CategoryId
            if (dataGridViewExpenses.Columns["CategoryId"] != null)
            {
                dataGridViewExpenses.Columns["CategoryId"].Visible = false;
            }

            if (dataGridViewExpenses.Columns["ID"] != null)
            {
                dataGridViewExpenses.Columns["ID"].Visible = false;
            }

            // Переименовываем колонку CategoryName для удобства
            if (dataGridViewExpenses.Columns["CategoryName"] != null)
            {
                dataGridViewExpenses.Columns["CategoryName"].HeaderText = "Category";
            }
        }

        private void expenses_buttonAdd_Click(object sender, EventArgs e)
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
                    ExpensesData expensesData = new ExpensesData();
                    int? categoryId = expensesData.GetCategoryIdByName(expenses_comboBoxCategory.SelectedItem.ToString());

                    if (categoryId.HasValue)
                    {
                        DBConnection.SqlConnection.Open();

                        string insertExpensesQuery = "INSERT INTO expenses (category_id, item, amount, [description], expenses_date) VALUES (@categoryId, @item, @amount, @description, @expensesDate)";
                        using (SqlCommand insertCmd = new SqlCommand(insertExpensesQuery, DBConnection.SqlConnection))
                        {
                            insertCmd.Parameters.AddWithValue("@categoryId", categoryId.Value);
                            insertCmd.Parameters.AddWithValue("@item", expenses_textBoxItem.Text);
                            insertCmd.Parameters.AddWithValue("@amount", expenses_textBoxExpenses.Text);
                            insertCmd.Parameters.AddWithValue("@description", expenses_textBoxDescription.Text);
                            insertCmd.Parameters.AddWithValue("@expensesDate", expenses_dateTimePicker.Value);

                            insertCmd.ExecuteNonQuery();

                            MessageBox.Show("Новый источник расходов добавлен успешно!", "Успех", MessageBoxButtons.OK, MessageBoxIcon.Information);

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
                    MessageBox.Show("Ошибка при добавлении расходов: " + ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                finally
                {
                    if (!DBConnection.CheckConnection())
                    {
                        DBConnection.SqlConnection.Close();
                    }
                }

                DisplayExpensesData();
            }
        }

        private void ClearFields()
        {
            expenses_textBoxItem.Text = "";
            expenses_textBoxExpenses.Text = "";
            expenses_textBoxDescription.Text = "";
            expenses_comboBoxCategory.SelectedIndex = -1;
        }

        private bool ValidateInput()
        {
            // Проверка, что выбран элемент в ComboBox
            if (expenses_comboBoxCategory.SelectedItem == null)
            {
                MessageBox.Show("Пожалуйста, выберите категорию.", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

            // Проверка валидности входных данных
            if (string.IsNullOrWhiteSpace(expenses_comboBoxCategory.SelectedItem.ToString()))
            {
                MessageBox.Show("Категория не может быть пустой.", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

            if (string.IsNullOrWhiteSpace(expenses_textBoxItem.Text))
            {
                MessageBox.Show("Поле 'Наименование' не может быть пустым.", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

            if (string.IsNullOrWhiteSpace(expenses_textBoxExpenses.Text))
            {
                MessageBox.Show("Поле 'Сумма' не может быть пустым.", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

            if (string.IsNullOrWhiteSpace(expenses_textBoxDescription.Text))
            {
                MessageBox.Show("Поле 'Описание' не может быть пустым.", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

            // Проверка, что поле 'Сумма' содержит числовое значение
            if (!decimal.TryParse(expenses_textBoxExpenses.Text, out decimal expensesAmount))
            {
                MessageBox.Show("Поле 'Сумма' должно содержать числовое значение.", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

            return true;
        }

        private int getID = 0;
        private void dataGridViewExpenses_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex != -1)
            {
                DataGridViewRow row = dataGridViewExpenses.Rows[e.RowIndex];

                getID = (int)row.Cells["Id"].Value;
                expenses_comboBoxCategory.SelectedItem = row.Cells["CategoryName"].Value;
                expenses_textBoxItem.Text = row.Cells["Item"].Value.ToString();
                expenses_textBoxExpenses.Text = row.Cells["Amount"].Value.ToString();
                expenses_textBoxDescription.Text = row.Cells["Description"].Value.ToString();
                expenses_dateTimePicker.Value = Convert.ToDateTime(row.Cells["ExpensesDate"].Value.ToString());
            }
        }

        private void expenses_buttonUpdate_Click(object sender, EventArgs e)
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
                    ExpensesData expensesData = new ExpensesData();
                    int? categoryId = expensesData.GetCategoryIdByName(expenses_comboBoxCategory.SelectedItem.ToString());

                    if (categoryId.HasValue)
                    {
                        DBConnection.SqlConnection.Open();

                        string updateExpensesQuery = "UPDATE expenses SET category_id = @categoryId, item = @item, amount = @amount, [description] = @description, expenses_date = @expensesDate WHERE id_expenses = @id_expenses";
                        using (SqlCommand insertCmd = new SqlCommand(updateExpensesQuery, DBConnection.SqlConnection))
                        {
                            insertCmd.Parameters.AddWithValue("@categoryId", categoryId.Value);
                            insertCmd.Parameters.AddWithValue("@item", expenses_textBoxItem.Text);
                            insertCmd.Parameters.AddWithValue("@amount", expenses_textBoxExpenses.Text);
                            insertCmd.Parameters.AddWithValue("@description", expenses_textBoxDescription.Text);
                            insertCmd.Parameters.AddWithValue("@expensesDate", expenses_dateTimePicker.Value);
                            insertCmd.Parameters.AddWithValue("@id_expenses", getID);

                            insertCmd.ExecuteNonQuery();

                            MessageBox.Show("Новый источник расходов обновлен успешно!", "Успех", MessageBoxButtons.OK, MessageBoxIcon.Information);

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
                    MessageBox.Show("Ошибка при добавлении расходов: " + ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                finally
                {
                    if (!DBConnection.CheckConnection())
                    {
                        DBConnection.SqlConnection.Close();
                    }
                }
                DisplayExpensesData();
            }
        }

        private void expenses_buttonDelete_Click(object sender, EventArgs e)
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
                    ExpensesData expensesData = new ExpensesData();
                    int? categoryId = expensesData.GetCategoryIdByName(expenses_comboBoxCategory.SelectedItem.ToString());

                    if (categoryId.HasValue)
                    {
                        DBConnection.SqlConnection.Open();

                        string deleteExpensesQuery = "DELETE FROM expenses WHERE id_expenses = @id_expenses";
                        using (SqlCommand insertCmd = new SqlCommand(deleteExpensesQuery, DBConnection.SqlConnection))
                        {
                            insertCmd.Parameters.AddWithValue("@id_expenses", getID);

                            insertCmd.ExecuteNonQuery();

                            MessageBox.Show("Источник расходов удален успешно!", "Успех", MessageBoxButtons.OK, MessageBoxIcon.Information);

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
                    MessageBox.Show("Ошибка при добавлении расходов: " + ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                finally
                {
                    if (!DBConnection.CheckConnection())
                    {
                        DBConnection.SqlConnection.Close();
                    }
                }
                DisplayExpensesData();
            }
        }

        private void expenses_buttonClear_Click(object sender, EventArgs e)
        {
            ClearFields();
        }
    }
}
