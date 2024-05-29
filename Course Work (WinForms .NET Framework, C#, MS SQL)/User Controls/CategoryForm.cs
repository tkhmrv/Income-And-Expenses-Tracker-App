using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace Course_Work__WinForms.NET_Framework__C___MS_SQL_
{
    public partial class CategoryForm : UserControl
    {
        public CategoryForm()
        {
            InitializeComponent();

            DisplayCategoryList();
        }

        public void RefreshData()
        {
            if (InvokeRequired)
            {
                Invoke((MethodInvoker)RefreshData);
                return;
            }

            DisplayCategoryList();

            dataGridViewCategory.ColumnHeadersDefaultCellStyle.BackColor = Color.FromArgb(49, 121, 74);
            dataGridViewCategory.EnableHeadersVisualStyles = false;
            dataGridViewCategory.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;
            dataGridViewCategory.ColumnHeadersDefaultCellStyle.Font = new Font(dataGridViewCategory.Font, FontStyle.Bold);
        }

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
        }

        private void Category_buttonAdd_Click(object sender, EventArgs e)
        {
            if (!ValidateCategoryInputs())
                return;

            if (DBConnection.CheckConnection())
            {
                try
                {
                    DBConnection.SqlConnection.Open();

                    string insertData = "INSERT INTO categories (category, [type], [status], creation_date)" + "VALUES (@category, @type, @status, GETDATE())";

                    using (SqlCommand sqlCommand = new SqlCommand(insertData, DBConnection.SqlConnection))
                    {
                        sqlCommand.Parameters.AddWithValue("@category", category_textBoxCategory.Text.Trim());
                        sqlCommand.Parameters.AddWithValue("@type", category_comboBoxType.Text.Trim());
                        sqlCommand.Parameters.AddWithValue("@status", category_comboBoxStatus.Text.Trim());

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

        private void DataGridViewCategory_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex != -1)
            {
                DataGridViewRow row = dataGridViewCategory.Rows[e.RowIndex];

                getID = Convert.ToInt32(row.Cells["ID"].Value);
                category_textBoxCategory.Text = row.Cells["category"].Value.ToString();
                category_comboBoxType.SelectedItem = row.Cells["type"].Value.ToString();
                category_comboBoxStatus.SelectedItem = row.Cells["status"].Value.ToString();
            }
        }

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

                        /*CategoryData categoryData = new CategoryData();

                        // Проверка существования категории
                        if (!categoryData.CategoryExists(category_textBoxCategory))
                        {
                            MessageBox.Show("Категория не существует. Пожалуйста, введите существующую категорию.", "Сообщение об ошибке", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            
                            DBConnection.CloseConnection();
                            
                            return;

                        }*/

                        string updateData = "UPDATE categories SET category = @cat, type = @type, status = @status WHERE id_category = @id";

                        using (SqlCommand cmd = new SqlCommand(updateData, DBConnection.SqlConnection))
                        {
                            cmd.Parameters.AddWithValue("@id", getID);
                            cmd.Parameters.AddWithValue("@cat", category_textBoxCategory.Text.Trim());
                            cmd.Parameters.AddWithValue("@type", category_comboBoxType.SelectedItem);
                            cmd.Parameters.AddWithValue("@status", category_comboBoxStatus.SelectedItem);

                            cmd.ExecuteNonQuery();

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

        public void ClearFields()
        {
            category_textBoxCategory.Text = "";
            category_comboBoxType.SelectedIndex = -1;
            category_comboBoxStatus.SelectedIndex = -1;
        }

        private void Category_buttonClear_Click(object sender, EventArgs e)
        {
            ClearFields();
        }

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
                        if (!categoryData.CategoryExists(category_textBoxCategory))
                        {
                            MessageBox.Show("Категория не существует. Пожалуйста, введите существующую категорию.", "Сообщение об ошибке", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            
                            DBConnection.CloseConnection();

                            return;
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

    }
}
