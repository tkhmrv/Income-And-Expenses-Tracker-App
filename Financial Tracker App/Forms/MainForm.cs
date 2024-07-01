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
        /// Идентификатор текущего пользователя.
        /// </summary>
        private int currentUserId => AuthForm.CurrentUserId;

        /// <summary>
        /// Статический экземпляр главного окна приложения.
        /// </summary>
        public static MainForm Instance { get; private set; }

        /// <summary>
        /// Флаг процесса загрузки кошельков в ComboBox.
        /// </summary>
        private bool isLoadingWallets = false;

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

            if (dashboardForm is DashboardUserControl dForm)
            {
                dForm.RefreshData();
            }
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

            if (categoryForm is CategoryUserControl cForm)
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

            if (incomeForm is IncomeUserControl iForm)
            {
                iForm.RefreshData();
            }
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

            if (expensesForm is ExpensesUserControl eForm)
            {
                eForm.RefreshData();
            }
        }

        /// <summary>
        /// Обработчик события клика на кнопку кошельков.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ButtonWallets_Click(object sender, EventArgs e)
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

        /// <summary>
        /// Загружает кошельки пользователя в ComboBox.
        /// </summary>
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
                        sqlCommand.Parameters.AddWithValue("@userId", currentUserId);

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
                                comboBoxAllWallets.SelectedValue = CurrentWalletId;
                            else
                                comboBoxAllWallets.SelectedIndex = 0;

                            isLoadingWallets = false;
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Ошибка при загрузке кошельков в MainForm: " + ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                finally
                {
                    DBConnection.CloseConnection();
                }
            }
        }

        /// <summary>
        /// Выводит текущий баланс кошелька/кошельков в label.
        /// </summary>
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
                        incomeCommand.Parameters.AddWithValue("@userId", currentUserId);
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
                        expensesCommand.Parameters.AddWithValue("@userId", currentUserId);
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
                    MessageBox.Show("Не удалось провести соединение, ошибка в MainForm: " + ex.Message, "Сообщение об ошибке", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                finally
                {
                    DBConnection.CloseConnection();
                }
            }
        }

        /// <summary>
        /// Обработчик события смены выбранного элемента в ComboBox.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ComboBoxAllWallets_SelectedIndexChanged(object sender, EventArgs e)
        {
            // Обработчик события выполнится только если isLoadingWallets == false
            if (!isLoadingWallets && comboBoxAllWallets.SelectedValue != null)
            {
                CurrentWalletId = Convert.ToInt32(comboBoxAllWallets.SelectedValue);

                DisplayWalletBalance();

                if (dashboardForm.Visible == true)
                    DashboardUserControl.RefreshDataStatic();

                if (categoryForm.Visible == true)
                    CategoryUserControl.DisplayCategoryListStatic();

                if (incomeForm.Visible == true)
                {
                    IncomeUserControl.DisplayIncomeDataStatic();
                    IncomeUserControl.DisplayIncomeCategoriesStatic();
                }

                if (expensesForm.Visible == true)
                {
                    ExpensesUserControl.DisplayExpensesDataStatic();
                    ExpensesUserControl.DisplayExpensesCategoriesStatic();
                }
            }
        }   
    }
}
