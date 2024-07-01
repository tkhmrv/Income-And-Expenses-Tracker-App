using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Drawing;
using System.Windows.Forms;

namespace Financial.Tracker
{
    /// <summary>
    /// Форма для управления доходами.
    /// </summary>
    public partial class IncomeUserControl : UserControl
    {
        /// <summary>
        /// Индентификатор кошелька, выбранного пользователем из DataGridView.
        /// </summary>
        public static int walletIdFromDGV = 0;

        /// <summary>
        /// Идентификатор дохода, выбранный пользователем из DataGridView.
        /// </summary>
        private int incomeIdFromDGV = 0;

        /// <summary>
        /// Идентификатор текущего пользователя.
        /// </summary>
        private int currentUserId => AuthForm.CurrentUserId;

        /// <summary>
        /// Идентификатор текущего кошелька.
        /// </summary>
        private int currentWalletId => MainForm.CurrentWalletId;

        /// <summary>
        /// Статический экземпляр пользовательского интерфейса доходов.
        /// </summary>
        public static IncomeUserControl Instance { get; private set; }

        /// <summary>
        /// Инициализирует новый экземпляр класса <see cref="IncomeUserControl"/>.
        /// </summary>
        public IncomeUserControl()
        {
            InitializeComponent();

            Instance = this;

            DisplayIncomeCategories();
            DisplayIncomeData();
        }


        /// <summary>
        /// Отображает данные доходов, используя статический экземпляр пользовательского интерфейса.
        /// </summary>
        public static void DisplayIncomeDataStatic()
        {
            Instance.DisplayIncomeData();
        }

        /// <summary>
        /// Отображает данные категорий в ComboBox, используя статический экземпляр пользовательского интерфейса.
        /// </summary>
        public static void DisplayIncomeCategoriesStatic()
        {
            Instance.DisplayIncomeCategories();
        }

        /// <summary>
        /// Обновляет данные на форме доходов.
        /// </summary>
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

        /// <summary>
        /// Отображает категории доходов.
        /// </summary>
        private void DisplayIncomeData()
        {
            IncomeData incomeData = new IncomeData();
            List<IncomeData> listData = incomeData.IncomeListData();

            dataGridViewIncome.DataSource = listData;

            if (dataGridViewIncome.Columns["ID"] != null)
            {
                dataGridViewIncome.Columns["ID"].Visible = false;
                dataGridViewIncome.Columns["CategoryId"].Visible = false;
                dataGridViewIncome.Columns["UserId"].Visible = false;
                dataGridViewIncome.Columns["WalletId"].Visible = false;
            }

            // Переименовываем колонку CategoryName для удобства
            if (dataGridViewIncome.Columns["CategoryName"] != null)
                dataGridViewIncome.Columns["CategoryName"].HeaderText = "Категория";

            if (dataGridViewIncome.Columns["WalletNAme"] != null)
                dataGridViewIncome.Columns["WalletNAme"].HeaderText = "Кошелек";

            dataGridViewIncome.Columns["Item"].HeaderText = "Наименование";
            dataGridViewIncome.Columns["Amount"].HeaderText = "Сумма";
            dataGridViewIncome.Columns["Description"].HeaderText = "Описание";
            dataGridViewIncome.Columns["IncomeDate"].HeaderText = "Дата добавления";
        }

        /// <summary>
        /// Отображает данные о доходах.
        /// </summary>
        private void DisplayIncomeCategories()
        {
            if (DBConnection.CheckConnection())
            {
                try
                {
                    DBConnection.SqlConnection.Open();

                    string selectData = "SELECT category FROM categories WHERE type = @type AND status = @status AND user_id = @userId AND (@walletId = 0 OR wallet_id = @walletId)";

                    using (SqlCommand sqlCommand = new SqlCommand(selectData, DBConnection.SqlConnection))
                    {
                        sqlCommand.Parameters.AddWithValue("@type", "Доходы");
                        sqlCommand.Parameters.AddWithValue("@status", "Активный");
                        sqlCommand.Parameters.AddWithValue("@userId", currentUserId);
                        sqlCommand.Parameters.AddWithValue("@walletId", currentWalletId);

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
                    MessageBox.Show("Ошибка при загрузке данных в IncomeUserControl: " + ex.Message, "Сообщение об ошибке", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                finally
                {
                    DBConnection.CloseConnection();
                }
            }
        }

        /// <summary>
        /// Обработчик события для добавления нового дохода.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Income_buttonAdd_Click(object sender, EventArgs e)
        {
            if (currentWalletId == 0)
            {
                MessageBox.Show("Для добавления нового источника дохода выберите кошелек.", "Сообщение об ошибке", MessageBoxButtons.OKCancel, MessageBoxIcon.Error);
                return;
            }

            if (!ValidateInput())
                return;

            if (DBConnection.CheckConnection())
            {
                try
                {
                    int? categoryId = IncomeData.GetCategoryIdByName(income_comboBoxCategory.SelectedItem.ToString(), currentWalletId);

                    if (categoryId.HasValue)
                    {
                        DBConnection.SqlConnection.Open();

                        string insertIncomeQuery = "INSERT INTO income_3nf (category_id, item, amount, [description], income_date, user_id, wallet_id)" +
                                                   "VALUES (@categoryId, @item, @amount, @description, @incomeDate, @userId, @walletId)";
                        using (SqlCommand sqlCommand = new SqlCommand(insertIncomeQuery, DBConnection.SqlConnection))
                        {
                            sqlCommand.Parameters.AddWithValue("@categoryId", categoryId.Value);
                            sqlCommand.Parameters.AddWithValue("@item", income_textBoxItem.Text);
                            sqlCommand.Parameters.AddWithValue("@amount", income_textBoxIncome.Text);
                            sqlCommand.Parameters.AddWithValue("@description", income_textBoxDescription.Text);
                            sqlCommand.Parameters.AddWithValue("@incomeDate", income_dateTimePicker.Value);
                            sqlCommand.Parameters.AddWithValue("@userId", currentUserId);
                            sqlCommand.Parameters.AddWithValue("@walletId", currentWalletId);

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
                    MessageBox.Show("Ошибка при добавлении дохода в IncomeUserControl: " + ex.Message, "Сообщение об ошибке", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                finally
                {
                    DBConnection.CloseConnection();
                }
            }
            DisplayIncomeData();
        }

        /// <summary>
        /// Обработчик события для обновления существующего дохода.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Income_buttonUpdate_Click(object sender, EventArgs e)
        {
            if (!ValidateInput())
                return;

            if (DBConnection.CheckConnection())
            {
                try
                {
                    int? categoryId = IncomeData.GetCategoryIdByName(income_comboBoxCategory.SelectedItem.ToString(), walletIdFromDGV);

                    DBConnection.SqlConnection.Open();

                    if (categoryId.HasValue)
                    {
                        // Запрос для обновления дохода
                        string updateIncomeQuery = "UPDATE income_3nf SET category_id = @categoryId, item = @item, amount = @amount, [description] = @description, income_date = @incomeDate WHERE id_income = @idIncome";
                        using (SqlCommand sqlCommand = new SqlCommand(updateIncomeQuery, DBConnection.SqlConnection))
                        {
                            sqlCommand.Parameters.AddWithValue("@categoryId", categoryId.Value);
                            sqlCommand.Parameters.AddWithValue("@item", income_textBoxItem.Text);
                            sqlCommand.Parameters.AddWithValue("@amount", income_textBoxIncome.Text);
                            sqlCommand.Parameters.AddWithValue("@description", income_textBoxDescription.Text);
                            sqlCommand.Parameters.AddWithValue("@incomeDate", income_dateTimePicker.Value);
                            sqlCommand.Parameters.AddWithValue("@idIncome", incomeIdFromDGV);

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
                    MessageBox.Show("Ошибка при обновлении дохода в IncomeUserControl: " + ex.Message, "Сообщение об ошибке", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                finally
                {
                    DBConnection.CloseConnection();
                }
            }
            DisplayIncomeData();
        }

        /// <summary>
        /// Обработчик события для удаления существующего дохода.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Income_buttonDelete_Click(object sender, EventArgs e)
        {
            if (!ValidateInput())
                return;

            if (DBConnection.CheckConnection())
            {
                try
                {
                    DBConnection.SqlConnection.Open();

                    // Проверка существования расходов
                    if (!IncomeData.ItemExistsById(incomeIdFromDGV))
                    {
                        MessageBox.Show("Доходов с таким названием не существует. Пожалуйста, введите существующее название.", "Сообщение об ошибке", MessageBoxButtons.OK, MessageBoxIcon.Error);

                        DBConnection.CloseConnection();

                        return;
                    }

                    // Запрос для добавления нового дохода
                    string deleteIncomeQuery = "DELETE FROM income_3nf WHERE id_income = @idIncome";
                    using (SqlCommand sqlCommand = new SqlCommand(deleteIncomeQuery, DBConnection.SqlConnection))
                    {
                        sqlCommand.Parameters.AddWithValue("@idIncome", incomeIdFromDGV);

                        sqlCommand.ExecuteNonQuery();

                        MessageBox.Show("Источник дохода удален успешно!", "Информационное сообщение", MessageBoxButtons.OK, MessageBoxIcon.Information);

                        ClearFields();
                    }

                }
                catch (Exception ex)
                {
                    MessageBox.Show("Ошибка при удалении дохода в IncomeUserControl: " + ex.Message, "Сообщение об ошибке", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                finally
                {
                    DBConnection.CloseConnection();
                }
            }
            DisplayIncomeData();
        }

        /// <summary>
        /// Обработчик события для очистки полей ввода.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Income_buttonClear_Click(object sender, EventArgs e)
        {
            ClearFields();
        }

        /// <summary>
        /// Очищает все поля ввода.
        /// </summary>
        private void ClearFields()
        {
            income_textBoxItem.Text = "";
            income_textBoxIncome.Text = "";
            income_textBoxDescription.Text = "";
            income_comboBoxCategory.SelectedIndex = -1;
            income_dateTimePicker.Value = DateTime.Now;
        }

        /// <summary>
        /// Проверяет корректность введенных данных.
        /// </summary>
        /// <returns>Возвращает true, если все данные корректны, иначе false.</returns>
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

        /// <summary>
        /// Обработчик события для выбора строки в таблице доходов.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void DataGridViewIncome_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex != -1)
            {
                DataGridViewRow row = dataGridViewIncome.Rows[e.RowIndex];

                incomeIdFromDGV = Convert.ToInt32(row.Cells["Id"].Value);
                walletIdFromDGV = Convert.ToInt32(row.Cells["WalletId"].Value);
                income_comboBoxCategory.SelectedItem = row.Cells["CategoryName"].Value;
                income_textBoxItem.Text = row.Cells["Item"].Value.ToString();
                income_textBoxIncome.Text = row.Cells["Amount"].Value.ToString();
                income_textBoxDescription.Text = row.Cells["Description"].Value.ToString();
                income_dateTimePicker.Value = Convert.ToDateTime(row.Cells["IncomeDate"].Value.ToString());
            }
        }
    }
}
