using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace Course_Work__WinForms.NET_Framework__C___MS_SQL_
{
    public partial class CategoryForm : UserControl
    {
        public CategoryForm()
        {
            InitializeComponent();

            displayCategoryList();
        }

        private void displayCategoryList()
        {
            CategoryData categoryData = new CategoryData();
            List<CategoryData> listData = categoryData.categoryListData();

            if (listData != null && listData.Count > 0)
            {
                dataGridViewCategory.DataSource = listData;
            }
            else
            {
                dataGridViewCategory.DataSource = null;
            }
        }

        private void category_buttonAdd_Click(object sender, EventArgs e)
        {
            if (category_textBoxCategory.Text == "" || category_comboBoxType.SelectedIndex == -1 || category_comboBoxStatus.SelectedIndex == -1)
            {
                MessageBox.Show("Пожалуйста, заполните все поля?", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                if (DBConnection.CheckConnection())
                {
                    try
                    {
                        DBConnection.SqlConnection.Open();

                        string insertData = "INSERT INTO categories (category, [type], [status], creation_date)" + "VALUES (@cat, @type, @status, GETDATE())";

                        using (SqlCommand cmd = new SqlCommand(insertData, DBConnection.SqlConnection))
                        {
                            cmd.Parameters.AddWithValue("@cat", category_textBoxCategory.Text.Trim());
                            cmd.Parameters.AddWithValue("@type", category_comboBoxType.Text.Trim());
                            cmd.Parameters.AddWithValue("@status", category_comboBoxStatus.Text.Trim());

                            cmd.ExecuteNonQuery();

                            MessageBox.Show("Категория успешно добавлена!", "Информация", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            clearFields();
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Не удалось провести соединие, ошибка:" + ex, "Сообщение об ошибке", MessageBoxButtons.OKCancel, MessageBoxIcon.Error);
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
            displayCategoryList();
        }

        private int getID = 0;

        private void dataGridViewCategory_CellClick(object sender, DataGridViewCellEventArgs e)
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

        private void category_buttonUpdate_Click(object sender, EventArgs e)
        {
            if (category_textBoxCategory.Text == "" || category_comboBoxType.SelectedIndex == -1 || category_comboBoxStatus.SelectedIndex == -1)
            {
                MessageBox.Show("Пожалуйста, выберите категорию из таблицы", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                if (MessageBox.Show("Вы уверены, что хотите обновить категорию?", "Подтверждение действия", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    if (DBConnection.CheckConnection())
                    {
                        try
                        {
                            DBConnection.SqlConnection.Open();

                            string updateData = "UPDATE categories SET category = @cat, type = @type, status = @status WHERE id_category = @id";

                            using (SqlCommand cmd = new SqlCommand(updateData, DBConnection.SqlConnection))
                            {
                                cmd.Parameters.AddWithValue("@id", getID);
                                cmd.Parameters.AddWithValue("@cat", category_textBoxCategory.Text.Trim());
                                cmd.Parameters.AddWithValue("@type", category_comboBoxType.SelectedItem);
                                cmd.Parameters.AddWithValue("@status", category_comboBoxStatus.SelectedItem);

                                cmd.ExecuteNonQuery();

                                MessageBox.Show("Категория успешно обновлена!", "Информация", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                clearFields();
                            }
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show("Не удалось провести соединие, ошибка:" + ex, "Сообщение об ошибке", MessageBoxButtons.OKCancel, MessageBoxIcon.Error);
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
            }
            displayCategoryList();
        }

        public void clearFields()
        {
            category_textBoxCategory.Text = "";
            category_comboBoxType.SelectedIndex = -1;
            category_comboBoxStatus.SelectedIndex = -1;
        }

        private void category_buttonClear_Click(object sender, EventArgs e)
        {
            clearFields();
        }

        private void category_buttonDelete_Click(object sender, EventArgs e)
        {
            if (category_textBoxCategory.Text == "" || category_comboBoxType.SelectedIndex == -1 || category_comboBoxStatus.SelectedIndex == -1)
            {
                MessageBox.Show("Пожалуйста, выберите категорию из таблицы", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                if (MessageBox.Show("Вы уверены, что хотите удалить категорию?", "Подтверждение действия", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    if (DBConnection.CheckConnection())
                    {
                        try
                        {
                            DBConnection.SqlConnection.Open();

                            string updateData = "DELETE FROM categories WHERE id_category = @id";

                            using (SqlCommand cmd = new SqlCommand(updateData, DBConnection.SqlConnection))
                            {
                                cmd.Parameters.AddWithValue("@id", getID);

                                cmd.ExecuteNonQuery();

                                MessageBox.Show("Категория успешно удалена!", "Информация", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                clearFields();
                            }
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show("Не удалось провести соединие, ошибка:" + ex, "Сообщение об ошибке", MessageBoxButtons.OKCancel, MessageBoxIcon.Error);
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
            }
            displayCategoryList();
        }
    }
}
