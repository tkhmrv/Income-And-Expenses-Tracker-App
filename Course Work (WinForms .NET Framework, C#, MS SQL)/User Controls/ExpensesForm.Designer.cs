namespace Course_Work__WinForms.NET_Framework__C___MS_SQL_
{
    partial class ExpensesForm
    {
        /// <summary> 
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            this.label6 = new System.Windows.Forms.Label();
            this.expenses_dateTimePicker = new System.Windows.Forms.DateTimePicker();
            this.expenses_textBoxDescription = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.expenses_buttonDelete = new System.Windows.Forms.Button();
            this.expenses_buttonUpdate = new System.Windows.Forms.Button();
            this.expenses_buttonClear = new System.Windows.Forms.Button();
            this.expenses_buttonAdd = new System.Windows.Forms.Button();
            this.expenses_textBoxExpenses = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.expenses_textBoxItem = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.expenses_comboBoxCategory = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.dataGridViewExpenses = new System.Windows.Forms.DataGridView();
            this.label1 = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.panel1 = new System.Windows.Forms.Panel();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewExpenses)).BeginInit();
            this.panel2.SuspendLayout();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(1094, 204);
            this.label6.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(114, 30);
            this.label6.TabIndex = 20;
            this.label6.Text = "Доходы:";
            // 
            // expenses_dateTimePicker
            // 
            this.expenses_dateTimePicker.Location = new System.Drawing.Point(1222, 200);
            this.expenses_dateTimePicker.Margin = new System.Windows.Forms.Padding(6, 6, 6, 6);
            this.expenses_dateTimePicker.Name = "expenses_dateTimePicker";
            this.expenses_dateTimePicker.Size = new System.Drawing.Size(494, 37);
            this.expenses_dateTimePicker.TabIndex = 19;
            // 
            // expenses_textBoxDescription
            // 
            this.expenses_textBoxDescription.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.expenses_textBoxDescription.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.expenses_textBoxDescription.Location = new System.Drawing.Point(1222, 56);
            this.expenses_textBoxDescription.Margin = new System.Windows.Forms.Padding(6, 6, 6, 6);
            this.expenses_textBoxDescription.Multiline = true;
            this.expenses_textBoxDescription.Name = "expenses_textBoxDescription";
            this.expenses_textBoxDescription.Size = new System.Drawing.Size(674, 114);
            this.expenses_textBoxDescription.TabIndex = 18;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(1060, 60);
            this.label5.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(139, 30);
            this.label5.TabIndex = 17;
            this.label5.Text = "Описание:";
            // 
            // expenses_buttonDelete
            // 
            this.expenses_buttonDelete.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(49)))), ((int)(((byte)(121)))), ((int)(((byte)(74)))));
            this.expenses_buttonDelete.FlatAppearance.BorderSize = 0;
            this.expenses_buttonDelete.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.expenses_buttonDelete.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.expenses_buttonDelete.ForeColor = System.Drawing.Color.White;
            this.expenses_buttonDelete.Location = new System.Drawing.Point(1022, 317);
            this.expenses_buttonDelete.Margin = new System.Windows.Forms.Padding(6, 6, 6, 6);
            this.expenses_buttonDelete.Name = "expenses_buttonDelete";
            this.expenses_buttonDelete.Size = new System.Drawing.Size(242, 60);
            this.expenses_buttonDelete.TabIndex = 16;
            this.expenses_buttonDelete.Text = "Удалить";
            this.expenses_buttonDelete.UseVisualStyleBackColor = false;
            this.expenses_buttonDelete.Click += new System.EventHandler(this.Expenses_buttonDelete_Click);
            // 
            // expenses_buttonUpdate
            // 
            this.expenses_buttonUpdate.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(49)))), ((int)(((byte)(121)))), ((int)(((byte)(74)))));
            this.expenses_buttonUpdate.FlatAppearance.BorderSize = 0;
            this.expenses_buttonUpdate.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.expenses_buttonUpdate.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.expenses_buttonUpdate.ForeColor = System.Drawing.Color.White;
            this.expenses_buttonUpdate.Location = new System.Drawing.Point(760, 317);
            this.expenses_buttonUpdate.Margin = new System.Windows.Forms.Padding(6, 6, 6, 6);
            this.expenses_buttonUpdate.Name = "expenses_buttonUpdate";
            this.expenses_buttonUpdate.Size = new System.Drawing.Size(242, 60);
            this.expenses_buttonUpdate.TabIndex = 15;
            this.expenses_buttonUpdate.Text = "Обновить";
            this.expenses_buttonUpdate.UseVisualStyleBackColor = false;
            this.expenses_buttonUpdate.Click += new System.EventHandler(this.Expenses_buttonUpdate_Click);
            // 
            // expenses_buttonClear
            // 
            this.expenses_buttonClear.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(49)))), ((int)(((byte)(121)))), ((int)(((byte)(74)))));
            this.expenses_buttonClear.FlatAppearance.BorderSize = 0;
            this.expenses_buttonClear.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.expenses_buttonClear.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.expenses_buttonClear.ForeColor = System.Drawing.Color.White;
            this.expenses_buttonClear.Location = new System.Drawing.Point(1284, 317);
            this.expenses_buttonClear.Margin = new System.Windows.Forms.Padding(6, 6, 6, 6);
            this.expenses_buttonClear.Name = "expenses_buttonClear";
            this.expenses_buttonClear.Size = new System.Drawing.Size(242, 60);
            this.expenses_buttonClear.TabIndex = 14;
            this.expenses_buttonClear.Text = "Очистить";
            this.expenses_buttonClear.UseVisualStyleBackColor = false;
            this.expenses_buttonClear.Click += new System.EventHandler(this.Expenses_buttonClear_Click);
            // 
            // expenses_buttonAdd
            // 
            this.expenses_buttonAdd.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(49)))), ((int)(((byte)(121)))), ((int)(((byte)(74)))));
            this.expenses_buttonAdd.FlatAppearance.BorderSize = 0;
            this.expenses_buttonAdd.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.expenses_buttonAdd.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.expenses_buttonAdd.ForeColor = System.Drawing.Color.White;
            this.expenses_buttonAdd.Location = new System.Drawing.Point(498, 317);
            this.expenses_buttonAdd.Margin = new System.Windows.Forms.Padding(6, 6, 6, 6);
            this.expenses_buttonAdd.Name = "expenses_buttonAdd";
            this.expenses_buttonAdd.Size = new System.Drawing.Size(242, 60);
            this.expenses_buttonAdd.TabIndex = 13;
            this.expenses_buttonAdd.Text = "Добавить";
            this.expenses_buttonAdd.UseVisualStyleBackColor = false;
            this.expenses_buttonAdd.Click += new System.EventHandler(this.Expenses_buttonAdd_Click);
            // 
            // expenses_textBoxExpenses
            // 
            this.expenses_textBoxExpenses.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.expenses_textBoxExpenses.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.expenses_textBoxExpenses.Location = new System.Drawing.Point(308, 200);
            this.expenses_textBoxExpenses.Margin = new System.Windows.Forms.Padding(6, 6, 6, 6);
            this.expenses_textBoxExpenses.Name = "expenses_textBoxExpenses";
            this.expenses_textBoxExpenses.Size = new System.Drawing.Size(506, 37);
            this.expenses_textBoxExpenses.TabIndex = 5;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(192, 202);
            this.label4.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(104, 30);
            this.label4.TabIndex = 4;
            this.label4.Text = "Сумма:";
            // 
            // expenses_textBoxItem
            // 
            this.expenses_textBoxItem.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.expenses_textBoxItem.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.expenses_textBoxItem.Location = new System.Drawing.Point(308, 129);
            this.expenses_textBoxItem.Margin = new System.Windows.Forms.Padding(6, 6, 6, 6);
            this.expenses_textBoxItem.Name = "expenses_textBoxItem";
            this.expenses_textBoxItem.Size = new System.Drawing.Size(506, 37);
            this.expenses_textBoxItem.TabIndex = 3;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(96, 131);
            this.label3.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(200, 30);
            this.label3.TabIndex = 2;
            this.label3.Text = "Наименование:";
            // 
            // expenses_comboBoxCategory
            // 
            this.expenses_comboBoxCategory.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.expenses_comboBoxCategory.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.expenses_comboBoxCategory.FormattingEnabled = true;
            this.expenses_comboBoxCategory.Location = new System.Drawing.Point(308, 54);
            this.expenses_comboBoxCategory.Margin = new System.Windows.Forms.Padding(6, 6, 6, 6);
            this.expenses_comboBoxCategory.Name = "expenses_comboBoxCategory";
            this.expenses_comboBoxCategory.Size = new System.Drawing.Size(504, 38);
            this.expenses_comboBoxCategory.TabIndex = 1;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(152, 58);
            this.label2.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(144, 30);
            this.label2.TabIndex = 0;
            this.label2.Text = "Категория:";
            // 
            // dataGridViewExpenses
            // 
            this.dataGridViewExpenses.AllowUserToAddRows = false;
            this.dataGridViewExpenses.AllowUserToDeleteRows = false;
            this.dataGridViewExpenses.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dataGridViewExpenses.BackgroundColor = System.Drawing.SystemColors.Control;
            this.dataGridViewExpenses.BorderStyle = System.Windows.Forms.BorderStyle.None;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(49)))), ((int)(((byte)(121)))), ((int)(((byte)(74)))));
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridViewExpenses.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dataGridViewExpenses.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewExpenses.Location = new System.Drawing.Point(32, 85);
            this.dataGridViewExpenses.Margin = new System.Windows.Forms.Padding(6, 6, 6, 6);
            this.dataGridViewExpenses.Name = "dataGridViewExpenses";
            this.dataGridViewExpenses.ReadOnly = true;
            this.dataGridViewExpenses.RowHeadersVisible = false;
            this.dataGridViewExpenses.RowHeadersWidth = 82;
            this.dataGridViewExpenses.Size = new System.Drawing.Size(1988, 625);
            this.dataGridViewExpenses.TabIndex = 2;
            this.dataGridViewExpenses.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.DataGridViewExpenses_CellClick);
            // 
            // label1
            // 
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(30, 19);
            this.label1.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(580, 44);
            this.label1.TabIndex = 1;
            this.label1.Text = "Список расходов";
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.White;
            this.panel2.Controls.Add(this.label6);
            this.panel2.Controls.Add(this.expenses_dateTimePicker);
            this.panel2.Controls.Add(this.expenses_textBoxDescription);
            this.panel2.Controls.Add(this.label5);
            this.panel2.Controls.Add(this.expenses_buttonDelete);
            this.panel2.Controls.Add(this.expenses_buttonUpdate);
            this.panel2.Controls.Add(this.expenses_buttonClear);
            this.panel2.Controls.Add(this.expenses_buttonAdd);
            this.panel2.Controls.Add(this.expenses_textBoxExpenses);
            this.panel2.Controls.Add(this.label4);
            this.panel2.Controls.Add(this.expenses_textBoxItem);
            this.panel2.Controls.Add(this.label3);
            this.panel2.Controls.Add(this.expenses_comboBoxCategory);
            this.panel2.Controls.Add(this.label2);
            this.panel2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.panel2.Location = new System.Drawing.Point(30, 802);
            this.panel2.Margin = new System.Windows.Forms.Padding(6, 6, 6, 6);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(2050, 427);
            this.panel2.TabIndex = 5;
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.White;
            this.panel1.Controls.Add(this.dataGridViewExpenses);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Location = new System.Drawing.Point(30, 31);
            this.panel1.Margin = new System.Windows.Forms.Padding(6, 6, 6, 6);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(2050, 740);
            this.panel1.TabIndex = 4;
            // 
            // ExpensesForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(12F, 25F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Margin = new System.Windows.Forms.Padding(6, 6, 6, 6);
            this.Name = "ExpensesForm";
            this.Size = new System.Drawing.Size(2110, 1260);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewExpenses)).EndInit();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.DateTimePicker expenses_dateTimePicker;
        private System.Windows.Forms.TextBox expenses_textBoxDescription;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Button expenses_buttonDelete;
        private System.Windows.Forms.Button expenses_buttonUpdate;
        private System.Windows.Forms.Button expenses_buttonClear;
        private System.Windows.Forms.Button expenses_buttonAdd;
        private System.Windows.Forms.TextBox expenses_textBoxExpenses;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox expenses_textBoxItem;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox expenses_comboBoxCategory;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.DataGridView dataGridViewExpenses;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Panel panel1;
    }
}
