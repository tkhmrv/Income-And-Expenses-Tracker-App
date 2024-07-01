using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace Financial.Tracker
{
    /// <summary>
    /// Форма для управления категориями.
    /// </summary>
    public partial class CategoryForm : UserControl
    {
        /// <summary>
        /// Инициализирует новый экземпляр класса <see cref="CategoryForm"/>.
        /// </summary>
        public CategoryForm()
        {
            InitializeComponent();

            Instance = this;

            DisplayCategoryList();
        }

        public static int GetWalletId;

        public static CategoryForm Instance { get; private set; }

        public static void DisplayCategoryListStatic()
        {
            Instance?.DisplayCategoryList();
        }

        /// <summary>
        /// Обновляет данные на форме.
        /// </summary>
        public void RefreshData()
        {
            if (InvokeRequired)
            {
                Invoke((MethodInvoker)RefreshData);
                return;
            }

            DisplayCategoryList();
        }

        /// <summary>
        /// Отображает список категорий.
        /// </summary>
        private void DisplayCategoryList()
        {
            CategoryData categoryData = new CategoryData();
            List<CategoryData> listData = categoryData.CategoryListData();

            if (listData != null && listData.Count > 0)
            {
                dataGridViewCategory.DataSource = listData;

                if (dataGridViewCategory.Columns["ID"] != null)
                {
                    dataGridViewCategory.Columns["ID"].Visible = false;
                    dataGridViewCategory.Columns["UserId"].Visible = false;
                }

                dataGridViewCategory.Columns["Category"].HeaderText = "Категория";
                dataGridViewCategory.Columns["Type"].HeaderText = "Тип";
                dataGridViewCategory.Columns["Status"].HeaderText = "Статус";
                dataGridViewCategory.Columns["Date"].HeaderText = "Дата добавления";
            }
            else
            {
                dataGridViewCategory.DataSource = null;
            }

            dataGridViewCategory.ColumnHeadersDefaultCellStyle.BackColor = Color.FromArgb(49, 121, 74);
            dataGridViewCategory.EnableHeadersVisualStyles = false;
            dataGridViewCategory.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;
            dataGridViewCategory.ColumnHeadersDefaultCellStyle.Font = new Font(dataGridViewCategory.Font, FontStyle.Bold);

            dataGridViewCategory.CellFormatting += dataGridViewCategory_CellFormatting;
        }

        /// <summary>
        /// Обработчик события клика по кнопке добавления категории.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Category_buttonAdd_Click(object sender, EventArgs e)
        {
            if(MainForm.CurrentWalletId == 0)
            {
                MessageBox.Show("Для добавления новой категории выберите кошелек.", "Сообщение об ошибке", MessageBoxButtons.OKCancel, MessageBoxIcon.Error);
                return;
            }

            if (!ValidateCategoryInputs())
                return;

            if (DBConnection.CheckConnection())
            {
                try
                {
                    DBConnection.SqlConnection.Open();

                    CategoryData categoryData = new CategoryData();

                    // Проверка существования категории
                    if (categoryData.CategoryExistsByName(category_textBoxCategory.Text.ToString(), GetWalletId))
                    {
                        MessageBox.Show("Категория для кошелька с таким именем уже существует. Пожалуйста, введите другое название.", "Сообщение об ошибке", MessageBoxButtons.OK, MessageBoxIcon.Error);

                        DBConnection.CloseConnection();

                        return;
                    }

                    string insertData = "INSERT INTO categories (category, [type], [status], creation_date, user_id, wallet_id)" 
                                        + "VALUES (@category, @type, @status, GETDATE(), @userid, @wallet_id)";

                    using (SqlCommand sqlCommand = new SqlCommand(insertData, DBConnection.SqlConnection))
                    {
                        sqlCommand.Parameters.AddWithValue("@category", category_textBoxCategory.Text.Trim());
                        sqlCommand.Parameters.AddWithValue("@type", category_comboBoxType.Text.Trim());
                        sqlCommand.Parameters.AddWithValue("@status", category_comboBoxStatus.Text.Trim());
                        sqlCommand.Parameters.AddWithValue("@userid", AuthForm.CurrentUserId);
                        sqlCommand.Parameters.AddWithValue("@wallet_id", MainForm.CurrentWalletId);

                        sqlCommand.ExecuteNonQuery();

                        MessageBox.Show("Категория успешно добавлена!", "Информационное сообщение", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        ClearFields();
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Не удалось провести соединие, ошибка: " + ex, "Сообщение об ошибке", MessageBoxButtons.OKCancel, MessageBoxIcon.Error);
                }
                finally
                {
                    DBConnection.CloseConnection();
                }
            }
            DisplayCategoryList();
        }

        private int getID = 0;

        /// <summary>
        /// Обработчик события клика по кнопке обновления категории.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Category_buttonUpdate_Click(object sender, EventArgs e)
        {
            if (!ValidateCategoryInputs())
                return;

            if (MessageBox.Show("Вы уверены, что хотите обновить категорию?", "Подтверждение действия", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                if (DBConnection.CheckConnection())
                {
                    try
                    {
                        DBConnection.SqlConnection.Open();

                        CategoryData categoryData = new CategoryData();

                        // Проверка существования категории
                        if (!categoryData.CategoryExistsById(getID))
                        {
                            MessageBox.Show("Категория не существует. Пожалуйста, введите существующую категорию.", "Сообщение об ошибке", MessageBoxButtons.OK, MessageBoxIcon.Error);

                            DBConnection.CloseConnection();

                            return;
                        }

                        string updateData = "UPDATE categories SET category = @category, type = @type, status = @status WHERE id_category = @id";

                        using (SqlCommand sqlCommand = new SqlCommand(updateData, DBConnection.SqlConnection))
                        {
                            sqlCommand.Parameters.AddWithValue("@id", getID);
                            sqlCommand.Parameters.AddWithValue("@category", category_textBoxCategory.Text.Trim());
                            sqlCommand.Parameters.AddWithValue("@type", category_comboBoxType.SelectedItem);
                            sqlCommand.Parameters.AddWithValue("@status", category_comboBoxStatus.SelectedItem);

                            sqlCommand.ExecuteNonQuery();

                            MessageBox.Show("Категория успешно обновлена!", "Информационное сообщение", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            ClearFields();
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Не удалось провести соединие, ошибка: " + ex, "Сообщение об ошибке", MessageBoxButtons.OKCancel, MessageBoxIcon.Error);
                    }
                    finally
                    {
                        DBConnection.CloseConnection();
                    }
                }
            }
            DisplayCategoryList();
        }

        /// <summary>
        /// Очищает поля ввода.
        /// </summary>
        public void ClearFields()
        {
            category_textBoxCategory.Text = "";
            category_comboBoxType.SelectedIndex = -1;
            category_comboBoxStatus.SelectedIndex = -1;
        }

        /// <summary>
        /// Обработчик события клика по кнопке очистки полей.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Category_buttonClear_Click(object sender, EventArgs e)
        {
            ClearFields();
        }

        /// <summary>
        /// Обработчик события клика по кнопке удаления категории.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Category_buttonDelete_Click(object sender, EventArgs e)
        {
            if (!ValidateCategoryInputs())
                return;

            if (MessageBox.Show("Вы уверены, что хотите удалить категорию?", "Подтверждение действия", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                if (DBConnection.CheckConnection())
                {
                    try
                    {
                        DBConnection.SqlConnection.Open();

                        CategoryData categoryData = new CategoryData();
                        // Проверка существования категории
                        if (!categoryData.CategoryExistsById(getID))
                        {
                            MessageBox.Show("Категория не существует. Пожалуйста, введите существующую категорию.", "Сообщение об ошибке", MessageBoxButtons.OK, MessageBoxIcon.Error);

                            DBConnection.CloseConnection();

                            return;
                        }

                        // Проверка наличия доходов или расходов с этой категорией
                        string checkIncomeQuery = "SELECT COUNT(*) FROM income_3nf WHERE category_id = @id";
                        string checkExpensesQuery = "SELECT COUNT(*) FROM expenses WHERE category_id = @id";

                        using (SqlCommand checkIncomeCmd = new SqlCommand(checkIncomeQuery, DBConnection.SqlConnection))
                        using (SqlCommand checkExpensesCmd = new SqlCommand(checkExpensesQuery, DBConnection.SqlConnection))
                        {
                            checkIncomeCmd.Parameters.AddWithValue("@id", getID);
                            checkExpensesCmd.Parameters.AddWithValue("@id", getID);

                            int incomeCount = (int)checkIncomeCmd.ExecuteScalar();
                            int expensesCount = (int)checkExpensesCmd.ExecuteScalar();

                            if (incomeCount > 0 || expensesCount > 0)
                            {
                                MessageBox.Show("Невозможно удалить категорию, так как существуют связанные доходы или расходы.", "Сообщение об ошибке", MessageBoxButtons.OK, MessageBoxIcon.Error);

                                DBConnection.CloseConnection();

                                return;
                            }
                        }

                        string updateData = "DELETE FROM categories WHERE id_category = @id";

                        using (SqlCommand sqlCommand = new SqlCommand(updateData, DBConnection.SqlConnection))
                        {
                            sqlCommand.Parameters.AddWithValue("@id", getID);

                            sqlCommand.ExecuteNonQuery();

                            MessageBox.Show("Категория успешно удалена!", "Информационное сообщение", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            ClearFields();
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Не удалось провести соединие, ошибка:" + ex, "Сообщение об ошибке", MessageBoxButtons.OKCancel, MessageBoxIcon.Error);
                    }
                    finally
                    {
                        DBConnection.CloseConnection();
                    }
                }
            }
            DisplayCategoryList();
        }

        /// <summary>
        /// Проверяет корректность введенных данных для категории.
        /// </summary>
        /// <returns>Возвращает true, если данные корректны; иначе false.</returns>
        private bool ValidateCategoryInputs()
        {
            if (string.IsNullOrEmpty(category_textBoxCategory.Text))

            {
                MessageBox.Show("Введите категорию.", "Сообщение об ошибке", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            else if (category_comboBoxType.SelectedItem == null)
            {
                MessageBox.Show("Выберите тип категории.", "Сообщение об ошибке", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            else if (category_comboBoxStatus.SelectedItem == null)
            {
                MessageBox.Show("Выберите статус.", "Сообщение об ошибке", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

            return true;
        }

        /// <summary>
        /// Обработчик события клика по ячейке в DataGridView.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void DataGridViewCategory_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex != -1)
            {
                DataGridViewRow row = dataGridViewCategory.Rows[e.RowIndex];

                getID = Convert.ToInt32(row.Cells["ID"].Value);
                GetWalletId = Convert.ToInt32(row.Cells["walletid"].Value);
                category_textBoxCategory.Text = row.Cells["category"].Value.ToString();
                category_comboBoxType.SelectedItem = row.Cells["type"].Value.ToString();
                category_comboBoxStatus.SelectedItem = row.Cells["status"].Value.ToString();
            }
        }

        /// <summary>
        /// Красит строки в разные цвета, в зависимости от типа категории.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void dataGridViewCategory_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            // Проверка, что это не строка заголовков
            if (e.RowIndex >= 0)
            {
                // Получение типа категории из текущей строки
                string categoryType = dataGridViewCategory.Rows[e.RowIndex].Cells["Type"].Value.ToString();

                // Установка цвета фона в зависимости от типа категории
                if (categoryType == "Расходы")
                {
                    dataGridViewCategory.Rows[e.RowIndex].DefaultCellStyle.BackColor = Color.LightSalmon;
                }
                else if (categoryType == "Доходы")
                {
                    dataGridViewCategory.Rows[e.RowIndex].DefaultCellStyle.BackColor = Color.LightGreen;
                }
            }
        }
    }
}
