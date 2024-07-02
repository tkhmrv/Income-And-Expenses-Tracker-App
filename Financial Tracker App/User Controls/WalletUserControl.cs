using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Drawing;
using System.Windows.Forms;

namespace Financial.Tracker
{
    /// <summary>
    /// Пользовательский интерфейс для управлениями кошельками.
    /// </summary>
    public partial class WalletUserControl : UserControl
    {
        /// <summary>
        /// Индентификатор кошелька, выбранного пользователем из DataGridView.
        /// </summary>
        private int walletIdFromDGV = 0;

        /// <summary>
        /// Идентификатор текущего пользователя.
        /// </summary>
        private int currentUserId => AuthForm.CurrentUserId;

        /// <summary>
        /// Инициализирует новый экземпляр класса <see cref="WalletUserControl"/>.
        /// </summary>
        public WalletUserControl()
        {
            InitializeComponent();

            DisplayWalletsList();
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

            DisplayWalletsList();
        }

        /// <summary>
        /// Отображает список кошельков.
        /// </summary>
        private void DisplayWalletsList()
        {
            WalletData walletData = new WalletData();
            List<WalletData> listData = walletData.WalletListData();

            if (listData != null && listData.Count > 0)
            {
                dataGridViewWallet.DataSource = listData;

                if (dataGridViewWallet.Columns["ID"] != null)
                {
                    dataGridViewWallet.Columns["ID"].Visible = false;
                    dataGridViewWallet.Columns["UserId"].Visible = false;
                }

                dataGridViewWallet.Columns["WalletName"].HeaderText = "Название кошелька";
                dataGridViewWallet.Columns["Type"].HeaderText = "Тип";
                dataGridViewWallet.Columns["Status"].HeaderText = "Статус";
                dataGridViewWallet.Columns["Description"].HeaderText = "Описание";
                dataGridViewWallet.Columns["Date"].HeaderText = "Дата добавления";
            }
            else
            {
                dataGridViewWallet.DataSource = null;
            }

            dataGridViewWallet.ColumnHeadersDefaultCellStyle.BackColor = Color.FromArgb(49, 121, 74);
            dataGridViewWallet.EnableHeadersVisualStyles = false;
            dataGridViewWallet.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;
            dataGridViewWallet.ColumnHeadersDefaultCellStyle.Font = new Font(dataGridViewWallet.Font, FontStyle.Bold);
        }

        /// <summary>
        /// Обработчик события клика по кнопке добавления нового кошелька.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Wallet_buttonAdd_Click(object sender, EventArgs e)
        {
            if (!ValidateWalletInputs())
                return;

            if (DBConnection.CheckConnection())
            {
                try
                {
                    DBConnection.SqlConnection.Open();

                    // Проверка существования кошелька
                    if (WalletData.WalletExistsByName(wallet_textBoxWallet.Text.ToString().Trim(), currentUserId))
                    {
                        MessageBox.Show("Кошелек с таким именем уже существует. Пожалуйста, введите другое название.", "Сообщение об ошибке", MessageBoxButtons.OK, MessageBoxIcon.Error);

                        DBConnection.CloseConnection();

                        return;
                    }

                    string insertData = "INSERT INTO wallets (user_id, wallet_name, [type], [status], [description], creation_date)" +
                        "VALUES (@userId, @walletName, @type, @status, @description, GETDATE())";

                    using (SqlCommand sqlCommand = new SqlCommand(insertData, DBConnection.SqlConnection))
                    {
                        sqlCommand.Parameters.AddWithValue("@userId", currentUserId);
                        sqlCommand.Parameters.AddWithValue("@walletName", wallet_textBoxWallet.Text.Trim());
                        sqlCommand.Parameters.AddWithValue("@type", wallet_textBoxType.Text.Trim());
                        sqlCommand.Parameters.AddWithValue("@status", wallet_comboBoxStatus.Text.Trim());
                        sqlCommand.Parameters.AddWithValue("@description", wallet_textBoxDescription.Text.Trim());

                        sqlCommand.ExecuteNonQuery();

                        MessageBox.Show("Кошелек успешно добавлен!", "Информационное сообщение", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        ClearFields();
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Не удалось провести соединие, ошибка в WalletUserControl: " + ex, "Сообщение об ошибке", MessageBoxButtons.OKCancel, MessageBoxIcon.Error);
                }
                finally
                {
                    DBConnection.CloseConnection();
                }
            }
            DisplayWalletsList();

            MainForm.LoadWalletsToComboBoxStatic();
        }

        /// <summary>
        /// Обработчик события клика по кнопке обновления кошелька.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Wallet_buttonUpdate_Click(object sender, EventArgs e)
        {
            if (!ValidateWalletInputs())
                return;

            if (MessageBox.Show("Вы уверены, что хотите обновить кошелек?", "Подтверждение действия", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                if (DBConnection.CheckConnection())
                {
                    try
                    {
                        DBConnection.SqlConnection.Open();

                        // Проверка существования категории
                        if (!WalletData.WalletExistsById(walletIdFromDGV))
                        {
                            MessageBox.Show("Кошелек не существует. Пожалуйста, введите существующий кошелек.", "Сообщение об ошибке", MessageBoxButtons.OK, MessageBoxIcon.Error);

                            DBConnection.CloseConnection();

                            return;
                        }

                        string updateData = "UPDATE wallets SET wallet_name = @walletName, type = @type, status = @status, description = @description WHERE id_wallet = @idWallet";

                        using (SqlCommand sqlCommand = new SqlCommand(updateData, DBConnection.SqlConnection))
                        {
                            //sqlCommand.Parameters.AddWithValue("@userId", AuthForm.userid);
                            sqlCommand.Parameters.AddWithValue("@idWallet", walletIdFromDGV);
                            sqlCommand.Parameters.AddWithValue("@walletName", wallet_textBoxWallet.Text.Trim());
                            sqlCommand.Parameters.AddWithValue("@type", wallet_textBoxType.Text.Trim());
                            sqlCommand.Parameters.AddWithValue("@status", wallet_comboBoxStatus.Text.Trim());
                            sqlCommand.Parameters.AddWithValue("@description", wallet_textBoxDescription.Text.Trim());

                            sqlCommand.ExecuteNonQuery();

                            MessageBox.Show("Кошелек успешно обновлен!", "Информационное сообщение", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            ClearFields();
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Не удалось провести соединие, ошибка в WalletUserControl: " + ex, "Сообщение об ошибке", MessageBoxButtons.OKCancel, MessageBoxIcon.Error);
                    }
                    finally
                    {
                        DBConnection.CloseConnection();
                    }
                }
            }
            DisplayWalletsList();

            MainForm.LoadWalletsToComboBoxStatic();
        }

        /// <summary>
        /// Обработчик события клика по кнопке удаления кошелька.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Wallet_buttonDelete_Click(object sender, EventArgs e)
        {
            if (!ValidateWalletInputs())
                return;

            if (MessageBox.Show("Вы уверены, что хотите удалить кошелек?", "Подтверждение действия", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                if (DBConnection.CheckConnection())
                {
                    try
                    {
                        DBConnection.SqlConnection.Open();

                        // Проверка существования кошелька
                        if (!WalletData.WalletExistsById(walletIdFromDGV))
                        {
                            MessageBox.Show("Кошелек не существует. Пожалуйста, введите существующий кошелек.", "Сообщение об ошибке", MessageBoxButtons.OK, MessageBoxIcon.Error);

                            DBConnection.CloseConnection();

                            return;
                        }

                        string checkCategoriesQuery = "SELECT COUNT(*) FROM categories WHERE wallet_id = @walletId";
                        string checkIncomeQuery = "SELECT COUNT(*) FROM income_3nf WHERE wallet_id = @walletId";
                        string checkExpensesQuery = "SELECT COUNT(*) FROM expenses WHERE wallet_id = @walletId";

                        using (SqlCommand checkCategoriesCmd = new SqlCommand(checkCategoriesQuery, DBConnection.SqlConnection))
                        using (SqlCommand checkIncomeCmd = new SqlCommand(checkIncomeQuery, DBConnection.SqlConnection))
                        using (SqlCommand checkExpensesCmd = new SqlCommand(checkExpensesQuery, DBConnection.SqlConnection))
                        {
                            checkCategoriesCmd.Parameters.AddWithValue("@walletId", walletIdFromDGV);
                            checkIncomeCmd.Parameters.AddWithValue("@walletId", walletIdFromDGV);
                            checkExpensesCmd.Parameters.AddWithValue("@walletId", walletIdFromDGV);

                            int categoriesCount = (int)checkCategoriesCmd.ExecuteScalar();
                            int incomeCount = (int)checkIncomeCmd.ExecuteScalar();
                            int expensesCount = (int)checkExpensesCmd.ExecuteScalar();

                            if (categoriesCount > 0 || incomeCount > 0 || expensesCount > 0)
                            {

                                if (MessageBox.Show("Невозможно удалить кошелек, так как есть привязанные к нему категории, доходы и расходы. Вы уверены, что хотите удалить кошелек со всеми записями? (Это действие нельзя отменить).", "Сообщение об ошибке", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                                {
                                    DBConnection.CloseConnection();

                                    if (DBConnection.CheckConnection())
                                    {
                                        try
                                        {
                                            DBConnection.SqlConnection.Open();

                                            using (SqlTransaction transaction = DBConnection.SqlConnection.BeginTransaction())
                                            {
                                                try
                                                {
                                                    // Удалить все доходы, связанные с кошельком
                                                    using (SqlCommand incomeCommand = new SqlCommand("DELETE FROM income_3nf WHERE wallet_id = @walletId", DBConnection.SqlConnection, transaction))
                                                    {
                                                        incomeCommand.Parameters.AddWithValue("@walletId", walletIdFromDGV);
                                                        incomeCommand.ExecuteNonQuery();
                                                    }

                                                    // Удалить все расходы, связанные с кошельком
                                                    using (SqlCommand expensesCommand = new SqlCommand("DELETE FROM expenses WHERE wallet_id = @walletId", DBConnection.SqlConnection, transaction))
                                                    {
                                                        expensesCommand.Parameters.AddWithValue("@walletId", walletIdFromDGV);
                                                        expensesCommand.ExecuteNonQuery();
                                                    }

                                                    // Удалить все категории, связанные с кошельком
                                                    using (SqlCommand categoriesCommand = new SqlCommand("DELETE FROM categories WHERE wallet_id = @walletId", DBConnection.SqlConnection, transaction))
                                                    {
                                                        categoriesCommand.Parameters.AddWithValue("@walletId", walletIdFromDGV);
                                                        categoriesCommand.ExecuteNonQuery();
                                                    }

                                                    // Удалить сам кошелек
                                                    using (SqlCommand walletCommand = new SqlCommand("DELETE FROM wallets WHERE id_wallet = @walletId", DBConnection.SqlConnection, transaction))
                                                    {
                                                        walletCommand.Parameters.AddWithValue("@walletId", walletIdFromDGV);
                                                        walletCommand.ExecuteNonQuery();
                                                    }

                                                    // Коммит транзакции
                                                    transaction.Commit();
                                                    MessageBox.Show("Кошелек и все связанные с ним записи успешно удалены.", "Информация", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                                }
                                                catch (Exception ex)
                                                {
                                                    // Откат транзакции в случае ошибки
                                                    transaction.Rollback();
                                                    MessageBox.Show("Ошибка при удалении кошелька и связанных с ним записей: " + ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                                }
                                            }
                                        }
                                        catch (Exception ex)
                                        {
                                            MessageBox.Show("Не удалось провести соединение, ошибка в WalletUserControl: " + ex.Message, "Сообщение об ошибке", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                        }
                                        finally
                                        {
                                            DBConnection.CloseConnection();
                                        }
                                    }
                                }
                                else
                                    return;
                            }
                        }

                        string deleteData = "DELETE FROM wallets WHERE id_wallet = @walletId";

                        using (SqlCommand sqlCommand = new SqlCommand(deleteData, DBConnection.SqlConnection))
                        {
                            sqlCommand.Parameters.AddWithValue("@walletId", walletIdFromDGV);

                            sqlCommand.ExecuteNonQuery();

                            MessageBox.Show("Кошелек успешно удален!", "Информационное сообщение", MessageBoxButtons.OK, MessageBoxIcon.Information);
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
            DisplayWalletsList();

            MainForm.LoadWalletsToComboBoxStatic();
        }

        /// <summary>
        /// Обработчик события клика по кнопке очистки полей для ввода.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Wallet_buttonClear_Click(object sender, EventArgs e)
        {
            ClearFields();
        }

        /// <summary>
        /// Обработчик события клика по ячейке в DataGridView.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void DataGridViewWallet_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex != -1)
            {
                DataGridViewRow row = dataGridViewWallet.Rows[e.RowIndex];

                walletIdFromDGV = Convert.ToInt32(row.Cells["ID"].Value);
                wallet_textBoxWallet.Text = row.Cells["WalletName"].Value.ToString();
                wallet_textBoxType.Text = row.Cells["Type"].Value.ToString();
                wallet_comboBoxStatus.SelectedItem = row.Cells["Status"].Value.ToString();
                wallet_textBoxDescription.Text = row.Cells["Description"].Value.ToString();
            }
        }

        /// <summary>
        /// Очищает поля ввода.
        /// </summary>
        private void ClearFields()
        {
            wallet_textBoxWallet.Text = "";
            wallet_textBoxType.Text = "";
            wallet_comboBoxStatus.SelectedIndex = -1;
            wallet_textBoxDescription.Text = "";
        }

        /// <summary>
        /// Проверяет корректность введенных данных для кошелька.
        /// </summary>
        /// <returns>Возвращает true, если данные корректны; иначе false.</returns>
        private bool ValidateWalletInputs()
        {
            if (string.IsNullOrEmpty(wallet_textBoxWallet.Text))

            {
                MessageBox.Show("Введите название кошелька.", "Сообщение об ошибке", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            else if (string.IsNullOrEmpty(wallet_textBoxType.Text))

            {
                MessageBox.Show("Введите тип кошелька.", "Сообщение об ошибке", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            else if (wallet_comboBoxStatus.SelectedItem == null)
            {
                MessageBox.Show("Выберите статус кошелька.", "Сообщение об ошибке", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            else if (string.IsNullOrEmpty(wallet_textBoxDescription.Text))

            {
                MessageBox.Show("Введите описание.", "Сообщение об ошибке", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

            return true;
        }
    }
}
