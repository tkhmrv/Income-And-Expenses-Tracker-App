using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Diagnostics.Eventing.Reader;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Financial.Tracker
{
    /// <summary>
    /// Пользовательский интерфейс для управлениями кошельками.
    /// </summary>
    public partial class WalletUserControl : UserControl
    {


        public WalletUserControl()
        {
            InitializeComponent();

            DisplayWalletsList();
        }

        private int getID = 0;

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
                //dataGridViewWallet.Columns["MoneyAmount"].HeaderText = "Отстаток";
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
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void wallet_buttonAdd_Click(object sender, EventArgs e)
        {
            if (!ValidateWalletInputs())
                return;

            if (DBConnection.CheckConnection())
            {
                try
                {
                    DBConnection.SqlConnection.Open();

                    string insertData = "INSERT INTO wallets (user_id, wallet_name, [type], [status], [description], creation_date)" +
                        "VALUES (@user_id, @wallet_name, @type, @status, @description, GETDATE())";

                    using (SqlCommand sqlCommand = new SqlCommand(insertData, DBConnection.SqlConnection))
                    {
                        sqlCommand.Parameters.AddWithValue("@user_id", AuthForm.CurrentUserId);
                        sqlCommand.Parameters.AddWithValue("@wallet_name", wallet_textBoxWallet.Text.Trim());
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
                    MessageBox.Show("Не удалось провести соединие, ошибка: " + ex, "Сообщение об ошибке", MessageBoxButtons.OKCancel, MessageBoxIcon.Error);
                }
                finally
                {
                    DBConnection.CloseConnection();
                }
            }
            DisplayWalletsList();

            MainForm.LoadWalletsToComboBoxStatic();
        }

        private void wallet_buttonUpdate_Click(object sender, EventArgs e)
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

                        string updateData = "UPDATE wallets SET wallet_name = @wallet_name, type = @type, status = @status, description = @description WHERE id_wallet = @id_wallet";

                        using (SqlCommand sqlCommand = new SqlCommand(updateData, DBConnection.SqlConnection))
                        {
                            //sqlCommand.Parameters.AddWithValue("@user_id", AuthForm.userid);
                            sqlCommand.Parameters.AddWithValue("@id_wallet", getID);
                            sqlCommand.Parameters.AddWithValue("@wallet_name", wallet_textBoxWallet.Text.Trim());
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
                        MessageBox.Show("Не удалось провести соединие, ошибка: " + ex, "Сообщение об ошибке", MessageBoxButtons.OKCancel, MessageBoxIcon.Error);
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


        private void DataGridViewWallet_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex != -1)
            {
                DataGridViewRow row = dataGridViewWallet.Rows[e.RowIndex];

                getID = Convert.ToInt32(row.Cells["ID"].Value);
                wallet_textBoxWallet.Text = row.Cells["WalletName"].Value.ToString();
                wallet_textBoxType.Text = row.Cells["Type"].Value.ToString();
                wallet_comboBoxStatus.SelectedItem = row.Cells["Status"].Value.ToString();
                wallet_textBoxDescription.Text = row.Cells["Description"].Value.ToString();
            }
        }

        private void wallet_buttonDelete_Click(object sender, EventArgs e)
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

                        WalletData walletData = new WalletData();

                        // Проверка существования категории
                        if (!walletData.WalletExists(wallet_textBoxWallet))
                        {
                            MessageBox.Show("Кошелек не существует. Пожалуйста, введите существующий кошелек.", "Сообщение об ошибке", MessageBoxButtons.OK, MessageBoxIcon.Error);

                            DBConnection.CloseConnection();

                            return;
                        }

                        // Проверка наличия доходов или расходов с этой категорией
                        string checkCategoriesQuery = "SELECT COUNT(*) FROM categories WHERE wallet_id = @id";
                        string checkIncomeQuery = "SELECT COUNT(*) FROM income_3nf WHERE wallet_id = @id";
                        string checkExpensesQuery = "SELECT COUNT(*) FROM expenses WHERE wallet_id = @id";

                        using (SqlCommand checkCategoriesCmd = new SqlCommand(checkCategoriesQuery, DBConnection.SqlConnection))
                        using (SqlCommand checkIncomeCmd = new SqlCommand(checkIncomeQuery, DBConnection.SqlConnection))
                        using (SqlCommand checkExpensesCmd = new SqlCommand(checkExpensesQuery, DBConnection.SqlConnection))
                        {
                            checkCategoriesCmd.Parameters.AddWithValue("@id", getID);
                            checkIncomeCmd.Parameters.AddWithValue("@id", getID);
                            checkExpensesCmd.Parameters.AddWithValue("@id", getID);

                            int categoriesCount = (int)checkCategoriesCmd.ExecuteScalar();
                            int incomeCount = (int)checkIncomeCmd.ExecuteScalar();
                            int expensesCount = (int)checkExpensesCmd.ExecuteScalar();

                            if (categoriesCount > 0 || incomeCount > 0 || expensesCount > 0)
                            {
                                DBConnection.CloseConnection();

                                if (MessageBox.Show("Невозможно удалить кошелек, так как есть привязанные к нему категории, доходы и расходы. Вы уверены, что хотите удалить кошелек со всеми записями? (Это действие нельзя отменить)", "Сообщение об ошибке", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes);
                                {
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
                                                    using (SqlCommand incomeCommand = new SqlCommand("DELETE FROM income_3nf WHERE wallet_id = @id", DBConnection.SqlConnection, transaction))
                                                    {
                                                        incomeCommand.Parameters.AddWithValue("@id", getID);
                                                        incomeCommand.ExecuteNonQuery();
                                                    }

                                                    // Удалить все расходы, связанные с кошельком
                                                    using (SqlCommand expensesCommand = new SqlCommand("DELETE FROM expenses WHERE wallet_id = @id", DBConnection.SqlConnection, transaction))
                                                    {
                                                        expensesCommand.Parameters.AddWithValue("@id", getID);
                                                        expensesCommand.ExecuteNonQuery();
                                                    }

                                                    // Удалить все категории, связанные с кошельком
                                                    using (SqlCommand categoriesCommand = new SqlCommand("DELETE FROM categories WHERE wallet_id = @id", DBConnection.SqlConnection, transaction))
                                                    {
                                                        categoriesCommand.Parameters.AddWithValue("@id", getID);
                                                        categoriesCommand.ExecuteNonQuery();
                                                    }

                                                    // Удалить сам кошелек
                                                    using (SqlCommand walletCommand = new SqlCommand("DELETE FROM wallets WHERE id_wallet = @id", DBConnection.SqlConnection, transaction))
                                                    {
                                                        walletCommand.Parameters.AddWithValue("@id", getID);
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
                                            MessageBox.Show("Не удалось провести соединение, ошибка: " + ex.Message, "Сообщение об ошибке", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                        }
                                        finally
                                        {
                                            DBConnection.CloseConnection();
                                        }
                                    }
                                }
                            }
                        }

                        string updateData = "DELETE FROM wallets WHERE id_wallet = @id";

                        using (SqlCommand sqlCommand = new SqlCommand(updateData, DBConnection.SqlConnection))
                        {
                            sqlCommand.Parameters.AddWithValue("@id", getID);

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

        private void wallet_buttonClear_Click(object sender, EventArgs e)
        {
            ClearFields();
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
