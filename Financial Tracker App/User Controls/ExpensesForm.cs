using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Drawing;
using System.Windows.Forms;

namespace Financial.Tracker
{
    /// <summary>
    /// Форма для управления расходами.
    /// </summary>
    public partial class ExpensesForm : UserControl
    {
        /// <summary>
        /// Переменная, в которую записывается ID расходов.
        /// </summary>
        private int getID = 0;

        public static int GetWalletId = 0;

        /// <summary>
        /// Инициализирует новый экземпляр класса <see cref="ExpensesForm"/>.
        /// </summary>
        public ExpensesForm()
        {
            InitializeComponent();

            Instance = this;

            DisplayExpensesCategories();
            DisplayExpensesData();
        }

        public static ExpensesForm Instance { get; private set; }

        public static void DisplayExpensesDataStatic()
        {
            Instance.DisplayExpensesData();
        }

        public static void DisplayExpensesCategoriesStatic()
        {
            Instance.DisplayExpensesCategories();
        }

        /// <summary>
        /// Обновляет данные на форме расходов.
        /// </summary>
        public void RefreshData()
        {
            if (InvokeRequired)
            {
                Invoke((MethodInvoker)RefreshData);
                return;
            }

            DisplayExpensesCategories();
            DisplayExpensesData();

            dataGridViewExpenses.ColumnHeadersDefaultCellStyle.BackColor = Color.FromArgb(49, 121, 74);
            dataGridViewExpenses.EnableHeadersVisualStyles = false;
            dataGridViewExpenses.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;
            dataGridViewExpenses.ColumnHeadersDefaultCellStyle.Font = new Font(dataGridViewExpenses.Font, FontStyle.Bold);
        }

        /// <summary>
        /// Отображает категории расходов.
        /// </summary>
        private void DisplayExpensesCategories()
        {
            if (DBConnection.CheckConnection())
            {
                try
                {
                    DBConnection.SqlConnection.Open();

                    string selectData = "SELECT category FROM categories WHERE type = @type AND status = @status AND user_id = @userid";
                    if (MainForm.CurrentWalletId != 0)
                        selectData += " AND wallet_id = @walletid";

                    using (SqlCommand sqlCommand = new SqlCommand(selectData, DBConnection.SqlConnection))
                    {
                        sqlCommand.Parameters.AddWithValue("@type", "Расходы");
                        sqlCommand.Parameters.AddWithValue("@status", "Активный");
                        sqlCommand.Parameters.AddWithValue("@userid", AuthForm.CurrentUserId);

                        if (MainForm.CurrentWalletId != 0)
                            sqlCommand.Parameters.AddWithValue("@walletid", MainForm.CurrentWalletId);

                        expenses_comboBoxCategory.Items.Clear();

                        SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();

                        while (sqlDataReader.Read())
                        {
                            expenses_comboBoxCategory.Items.Add(sqlDataReader["category"].ToString());
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

        /// <summary>
        /// Отображает данные о расходах.
        /// </summary>
        private void DisplayExpensesData()
        {
            ExpensesData expensesData = new ExpensesData();
            List<ExpensesData> listData = expensesData.ExpensesListData();

            dataGridViewExpenses.DataSource = listData;

            if (dataGridViewExpenses.Columns["ID"] != null)
            {
                dataGridViewExpenses.Columns["ID"].Visible = false;
                dataGridViewExpenses.Columns["CategoryId"].Visible = false;
                dataGridViewExpenses.Columns["UserId"].Visible = false;
            }

            // Переименовываем колонку CategoryName для удобства
            if (dataGridViewExpenses.Columns["CategoryName"] != null)
            {
                dataGridViewExpenses.Columns["CategoryName"].HeaderText = "Категория";
            }

            dataGridViewExpenses.Columns["Item"].HeaderText = "Наименование";
            dataGridViewExpenses.Columns["Amount"].HeaderText = "Сумма";
            dataGridViewExpenses.Columns["Description"].HeaderText = "Описание";
            dataGridViewExpenses.Columns["ExpensesDate"].HeaderText = "Дата добавления";
        }

        /// <summary>
        /// Обработчик события для добавления нового расхода.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Expenses_buttonAdd_Click(object sender, EventArgs e)
        {
            if (MainForm.CurrentWalletId == 0)
            {
                MessageBox.Show("Для добавления нового источника расходов выберите кошелек.", "Сообщение об ошибке", MessageBoxButtons.OKCancel, MessageBoxIcon.Error);
                return;
            }

            if (!ValidateInput())
                return;

            if (DBConnection.CheckConnection())
            {
                try
                {
                    ExpensesData expensesData = new ExpensesData();
                    int? categoryId = expensesData.GetCategoryIdByName(expenses_comboBoxCategory.SelectedItem.ToString(), MainForm.CurrentWalletId);

                    if (categoryId.HasValue)
                    {
                        DBConnection.SqlConnection.Open();

                        string insertExpensesQuery = "INSERT INTO expenses (category_id, item, amount, [description], expenses_date, user_id, wallet_id) " +
                                                     "VALUES (@categoryId, @item, @amount, @description, @expensesDate, @userid, @walletid)";
                        using (SqlCommand sqlCommand = new SqlCommand(insertExpensesQuery, DBConnection.SqlConnection))
                        {
                            sqlCommand.Parameters.AddWithValue("@categoryId", categoryId.Value);
                            sqlCommand.Parameters.AddWithValue("@item", expenses_textBoxItem.Text);
                            sqlCommand.Parameters.AddWithValue("@amount", expenses_textBoxExpenses.Text);
                            sqlCommand.Parameters.AddWithValue("@description", expenses_textBoxDescription.Text);
                            sqlCommand.Parameters.AddWithValue("@expensesDate", expenses_dateTimePicker.Value);
                            sqlCommand.Parameters.AddWithValue("@userid", AuthForm.CurrentUserId);
                            sqlCommand.Parameters.AddWithValue("@walletid", MainForm.CurrentWalletId);

                            sqlCommand.ExecuteNonQuery();

                            MessageBox.Show("Новый источник расходов добавлен успешно!", "Информационное сообщение", MessageBoxButtons.OK, MessageBoxIcon.Information);

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
                    MessageBox.Show("Ошибка при добавлении расходов: " + ex.Message, "Сообщение об ошибке", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                finally
                {
                    DBConnection.CloseConnection();
                }
            }
            DisplayExpensesData();
        }

        /// <summary>
        /// Обработчик события для обновления существующего расхода.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Expenses_buttonUpdate_Click(object sender, EventArgs e)
        {
            if (!ValidateInput())
                return;

            if (DBConnection.CheckConnection())
            {
                try
                {
                    ExpensesData expensesData = new ExpensesData();
                    int? categoryId = expensesData.GetCategoryIdByName(expenses_comboBoxCategory.SelectedItem.ToString(), GetWalletId);

                    if (categoryId.HasValue)
                    {
                        DBConnection.SqlConnection.Open();

                        string updateExpensesQuery = "UPDATE expenses SET category_id = @categoryId, item = @item, amount = @amount, [description] = @description, expenses_date = @expensesDate WHERE id_expenses = @id_expenses";
                        using (SqlCommand sqlCommand = new SqlCommand(updateExpensesQuery, DBConnection.SqlConnection))
                        {
                            sqlCommand.Parameters.AddWithValue("@categoryId", categoryId.Value);
                            sqlCommand.Parameters.AddWithValue("@item", expenses_textBoxItem.Text);
                            sqlCommand.Parameters.AddWithValue("@amount", expenses_textBoxExpenses.Text);
                            sqlCommand.Parameters.AddWithValue("@description", expenses_textBoxDescription.Text);
                            sqlCommand.Parameters.AddWithValue("@expensesDate", expenses_dateTimePicker.Value);
                            sqlCommand.Parameters.AddWithValue("@id_expenses", getID);

                            sqlCommand.ExecuteNonQuery();

                            MessageBox.Show("Новый источник расходов обновлен успешно!", "Информационное сообщение", MessageBoxButtons.OK, MessageBoxIcon.Information);

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
                    MessageBox.Show("Ошибка при добавлении расходов: " + ex.Message, "Сообщение об ошибке", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                finally
                {
                    DBConnection.CloseConnection();
                }
            }
            DisplayExpensesData();
        }

        /// <summary>
        /// Обработчик события для удаления существующего расхода.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Expenses_buttonDelete_Click(object sender, EventArgs e)
        {
            if (!ValidateInput())
                return;

            if (DBConnection.CheckConnection())
            {
                try
                {
                    ExpensesData expensesData = new ExpensesData();

                    DBConnection.SqlConnection.Open();

                    // Проверка существования расходов
                    if (!expensesData.ItemExists(getID))
                    {
                        MessageBox.Show("Категория не существует. Пожалуйста, введите существующую категорию.", "Сообщение об ошибке", MessageBoxButtons.OK, MessageBoxIcon.Error);

                        DBConnection.CloseConnection();

                        return;
                    }

                    string deleteExpensesQuery = "DELETE FROM expenses WHERE id_expenses = @id_expenses";

                    using (SqlCommand sqlCommand = new SqlCommand(deleteExpensesQuery, DBConnection.SqlConnection))
                    {
                        sqlCommand.Parameters.AddWithValue("@id_expenses", getID);
                        sqlCommand.ExecuteNonQuery();

                        MessageBox.Show("Источник расходов удален успешно!", "Информационное сообщение", MessageBoxButtons.OK, MessageBoxIcon.Information);

                        ClearFields();
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Ошибка при добавлении расходов: " + ex.Message, "Сообщение об ошибке", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                finally
                {
                    DBConnection.CloseConnection();
                }
            }
            DisplayExpensesData();
        }

        /// <summary>
        /// Обработчик события для очистки полей ввода.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Expenses_buttonClear_Click(object sender, EventArgs e)
        {
            ClearFields();
        }

        /// <summary>
        /// Очищает все поля ввода.
        /// </summary>
        private void ClearFields()
        {
            expenses_textBoxItem.Text = "";
            expenses_textBoxExpenses.Text = "";
            expenses_textBoxDescription.Text = "";
            expenses_comboBoxCategory.SelectedIndex = -1;
            expenses_dateTimePicker.Value = DateTime.Now;
        }

        /// <summary>
        /// Проверяет корректность введенных данных.
        /// </summary>
        /// <returns>Возвращает true, если все данные корректны, иначе false.</returns>
        private bool ValidateInput()
        {
            if (expenses_comboBoxCategory.SelectedItem == null)
            {
                MessageBox.Show("Пожалуйста, выберите категорию.", "Сообщение об ошибке", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

            if (string.IsNullOrWhiteSpace(expenses_textBoxItem.Text))
            {
                MessageBox.Show("Поле 'Наименование' не может быть пустым.", "Сообщение об ошибке", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

            if (string.IsNullOrWhiteSpace(expenses_textBoxExpenses.Text))
            {
                MessageBox.Show("Поле 'Сумма' не может быть пустым.", "Сообщение об ошибке", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

            if (string.IsNullOrWhiteSpace(expenses_textBoxDescription.Text))
            {
                MessageBox.Show("Поле 'Описание' не может быть пустым.", "Сообщение об ошибке", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

            if (!decimal.TryParse(expenses_textBoxExpenses.Text, out decimal expensesAmount))
            {
                MessageBox.Show("Поле 'Сумма' должно содержать числовое значение.", "Сообщение об ошибке", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

            return true;
        }

        /// <summary>
        /// Обработчик события для выбора строки в таблице расходов.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void DataGridViewExpenses_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex != -1)
            {
                DataGridViewRow row = dataGridViewExpenses.Rows[e.RowIndex];

                getID = Convert.ToInt32(row.Cells["Id"].Value);
                GetWalletId = Convert.ToInt32(row.Cells["WalletId"].Value);
                expenses_comboBoxCategory.SelectedItem = row.Cells["CategoryName"].Value;
                expenses_textBoxItem.Text = row.Cells["Item"].Value.ToString();
                expenses_textBoxExpenses.Text = row.Cells["Amount"].Value.ToString();
                expenses_textBoxDescription.Text = row.Cells["Description"].Value.ToString();
                expenses_dateTimePicker.Value = Convert.ToDateTime(row.Cells["ExpensesDate"].Value.ToString());
            }
        }
    }
}
