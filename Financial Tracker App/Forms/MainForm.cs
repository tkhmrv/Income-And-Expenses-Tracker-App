using System;
using System.Data.SqlClient;
using System.Data;
using System.Windows.Forms;

namespace Financial.Tracker
{
    /// <summary>
    /// Основная форма приложения.
    /// </summary>
    public partial class MainForm : Form
    {
        /// <summary>
        /// Идентификатор кошелька, выбранного пользователем в данный момент.
        /// </summary>
        public static int CurrentWalletId = 0;

        /// <summary>
        /// Статический экземпляр главного окна приложения.
        /// </summary>
        /// <value>Возвращает экземпляр главного окна приложения.</value>
        public static MainForm Instance { get; private set; }

        /// <summary>
        /// Инициализирует новый экземпляр класса <see cref="MainForm"/>.
        /// </summary>
        public MainForm()
        {
            InitializeComponent();

            Instance = this;

            InitializeDash();
            DisplayUsername();
            LoadWalletsToComboBox();
            DisplayWalletBalance();

            comboBoxAllWallets.SelectedIndexChanged += ComboBoxAllWallets_SelectedIndexChanged;
        }

        /// <summary>
        /// Загружает кошельки в ComboBox, используя статический экземпляр класса.
        /// </summary>
        public static void LoadWalletsToComboBoxStatic()
        {
            Instance?.LoadWalletsToComboBox();
        }

        /// <summary>
        /// Отображает имя пользователя, вошедшего в систему.
        /// </summary>
        public void DisplayUsername()
        {
            string getUsername = AuthForm.Username;
            labelDisplayUsername.Text += getUsername.Substring(0, 1).ToUpper() + getUsername.Substring(1);
        }

        /// <summary>
        /// Инициализирует панель приборов (dashboard).
        /// </summary>
        private void InitializeDash()
        {
            DBConnection.CloseConnection();

            dashboardForm.Visible = true;
            categoryForm.Visible = false;
            incomeForm.Visible = false;
            expensesForm.Visible = false;
            walletUserControl.Visible = false;

            LoadWalletsToComboBox();

            if (dashboardForm is DashboardForm dForm)
            {
                dForm.RefreshData();
            }
        }

        /// <summary>
        /// Обработчик события клика на метку закрытия приложения.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void LabelCloseApp_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Вы уверены, что хотите закрыть программу?", "Сообщение подтверждения", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                Application.Exit();
            }
        }

        /// <summary>
        /// Обработчик события клика на кнопку выхода из системы.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ButtonLogout_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Вы уверены, что хотите выйти?", "Сообщение подтверждения", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                AuthForm authForm = new AuthForm();
                authForm.Show();

                this.Hide();
            }
        }

        /// <summary>
        /// Обработчик события клика на кнопку панели приборов (dashboard).
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ButtonDashboard_Click(object sender, EventArgs e)
        {
            InitializeDash();
        }

        /// <summary>
        /// Обработчик события клика на кнопку добавления категории.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ButtonAddCategory_Click(object sender, EventArgs e)
        {
            DBConnection.CloseConnection();

            dashboardForm.Visible = false;
            categoryForm.Visible = true;
            incomeForm.Visible = false;
            expensesForm.Visible = false;
            walletUserControl.Visible = false;

            LoadWalletsToComboBox();

            if (categoryForm is CategoryForm cForm)
            {
                cForm.RefreshData();
            }
        }

        /// <summary>
        /// Обработчик события клика на кнопку доходов.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ButtonIncome_Click(object sender, EventArgs e)
        {
            DBConnection.CloseConnection();

            dashboardForm.Visible = false;
            categoryForm.Visible = false;
            incomeForm.Visible = true;
            expensesForm.Visible = false;
            walletUserControl.Visible = false;

            LoadWalletsToComboBox();

            if (incomeForm is IncomeForm iForm)
            {
                iForm.RefreshData();
            }

            //DBConnection.CloseConnection();
        }

        /// <summary>
        /// Обработчик события клика на кнопку расходов.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ButtonExpenses_Click(object sender, EventArgs e)
        {
            DBConnection.CloseConnection();

            dashboardForm.Visible = false;
            categoryForm.Visible = false;
            incomeForm.Visible = false;
            expensesForm.Visible = true;
            walletUserControl.Visible = false;

            LoadWalletsToComboBox();

            if (expensesForm is ExpensesForm eForm)
            {
                eForm.RefreshData();
            }
        }

        private void buttonWallets_Click(object sender, EventArgs e)
        {
            DBConnection.CloseConnection();

            dashboardForm.Visible = false;
            categoryForm.Visible = false;
            incomeForm.Visible = false;
            expensesForm.Visible = false;
            walletUserControl.Visible = true;

            LoadWalletsToComboBox();

            if (walletUserControl is WalletUserControl walletUC)
            {
                walletUC.RefreshData();
            }
        }

        private bool isLoadingWallets = false;

        public void LoadWalletsToComboBox()
        {
            if (DBConnection.CheckConnection())
            {
                try
                {
                    DBConnection.SqlConnection.Open();

                    string loadQuery = "SELECT id_wallet, wallet_name FROM wallets WHERE user_id = @userId";
                    using (SqlCommand sqlCommand = new SqlCommand(loadQuery, DBConnection.SqlConnection))
                    {
                        sqlCommand.Parameters.AddWithValue("@userId", AuthForm.CurrentUserId);

                        using (SqlDataReader sqlDataReader = sqlCommand.ExecuteReader())
                        {
                            DataTable dataTable = new DataTable();
                            dataTable.Load(sqlDataReader);

                            // Добавляем строку "Все кошельки"
                            DataRow allWalletsRow = dataTable.NewRow();
                            allWalletsRow["id_wallet"] = 0;
                            allWalletsRow["wallet_name"] = "Все кошельки";
                            dataTable.Rows.InsertAt(allWalletsRow, 0);

                            isLoadingWallets = true;

                            comboBoxAllWallets.DisplayMember = "wallet_name";
                            comboBoxAllWallets.ValueMember = "id_wallet";
                            comboBoxAllWallets.DataSource = dataTable;

                            // Устанавливаем выбранное значение обратно
                            if (CurrentWalletId != 0)
                            {
                                comboBoxAllWallets.SelectedValue = CurrentWalletId;
                            }
                            else
                            {
                                comboBoxAllWallets.SelectedIndex = 0;
                            }

                            isLoadingWallets = false;
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Ошибка при загрузке кошельков: " + ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                finally
                {
                    DBConnection.CloseConnection();
                }
            }
        }

        public void DisplayWalletBalance()
        {
            decimal incomeSum = 0;
            decimal expensesSum = 0;

            if (DBConnection.CheckConnection())
            {
                try
                {
                    DBConnection.SqlConnection.Open();

                    // Запрос для получения суммы доходов
                    string incomeQuery = "SELECT SUM(amount) FROM income_3nf WHERE user_id = @userId AND (@walletId = 0 OR wallet_id = @walletId)";
                    using (SqlCommand incomeCommand = new SqlCommand(incomeQuery, DBConnection.SqlConnection))
                    {
                        incomeCommand.Parameters.AddWithValue("@userId", AuthForm.CurrentUserId);
                        incomeCommand.Parameters.AddWithValue("@walletId", MainForm.CurrentWalletId);

                        object incomeResult = incomeCommand.ExecuteScalar();
                        if (incomeResult != DBNull.Value)
                        {
                            incomeSum = Convert.ToDecimal(incomeResult);
                        }
                    }

                    // Запрос для получения суммы расходов
                    string expensesQuery = "SELECT SUM(amount) FROM expenses WHERE user_id = @userId AND (@walletId = 0 OR wallet_id = @walletId)";
                    using (SqlCommand expensesCommand = new SqlCommand(expensesQuery, DBConnection.SqlConnection))
                    {
                        expensesCommand.Parameters.AddWithValue("@userId", AuthForm.CurrentUserId);
                        expensesCommand.Parameters.AddWithValue("@walletId", MainForm.CurrentWalletId);

                        object expensesResult = expensesCommand.ExecuteScalar();
                        if (expensesResult != DBNull.Value)
                        {
                            expensesSum = Convert.ToDecimal(expensesResult);
                        }
                    }

                    labelCurrentBalance.Text = (incomeSum - expensesSum).ToString("0.00") + " ₽";
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


        private void ComboBoxAllWallets_SelectedIndexChanged(object sender, EventArgs e)
        {
            // Обработчик события выполнится только если isLoadingWallets == false
            if (!isLoadingWallets && comboBoxAllWallets.SelectedValue != null)
            {
                CurrentWalletId = Convert.ToInt32(comboBoxAllWallets.SelectedValue);

                DisplayWalletBalance();

                if (dashboardForm.Visible == true)
                    DashboardForm.RefreshDataStatic();

                if (categoryForm.Visible == true)
                    CategoryForm.DisplayCategoryListStatic();

                if (incomeForm.Visible == true)
                {
                    IncomeForm.DisplayIncomeDataStatic();
                    IncomeForm.DisplayIncomeCategoriesStatic();
                }

                if (expensesForm.Visible == true)
                {
                    ExpensesForm.DisplayExpensesDataStatic();
                    ExpensesForm.DisplayExpensesCategoriesStatic();
                }
            }
        }   
    }
}
