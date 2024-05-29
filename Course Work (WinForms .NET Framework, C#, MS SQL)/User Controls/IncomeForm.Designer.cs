namespace Course_Work__WinForms.NET_Framework__C___MS_SQL_
{
    partial class IncomeForm
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
            this.panel1 = new System.Windows.Forms.Panel();
            this.dataGridViewIncome = new System.Windows.Forms.DataGridView();
            this.label1 = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.label6 = new System.Windows.Forms.Label();
            this.income_dateTimePicker = new System.Windows.Forms.DateTimePicker();
            this.income_textBoxDescription = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.income_buttonDelete = new System.Windows.Forms.Button();
            this.income_buttonUpdate = new System.Windows.Forms.Button();
            this.income_buttonClear = new System.Windows.Forms.Button();
            this.income_buttonAdd = new System.Windows.Forms.Button();
            this.income_textBoxIncome = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.income_textBoxItem = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.income_comboBoxCategory = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewIncome)).BeginInit();
            this.panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.White;
            this.panel1.Controls.Add(this.dataGridViewIncome);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Location = new System.Drawing.Point(15, 16);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1025, 385);
            this.panel1.TabIndex = 1;
            // 
            // dataGridViewIncome
            // 
            this.dataGridViewIncome.AllowUserToAddRows = false;
            this.dataGridViewIncome.AllowUserToDeleteRows = false;
            this.dataGridViewIncome.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dataGridViewIncome.BackgroundColor = System.Drawing.SystemColors.Control;
            this.dataGridViewIncome.BorderStyle = System.Windows.Forms.BorderStyle.None;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(49)))), ((int)(((byte)(121)))), ((int)(((byte)(74)))));
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridViewIncome.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dataGridViewIncome.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewIncome.Location = new System.Drawing.Point(16, 44);
            this.dataGridViewIncome.Name = "dataGridViewIncome";
            this.dataGridViewIncome.ReadOnly = true;
            this.dataGridViewIncome.RowHeadersVisible = false;
            this.dataGridViewIncome.Size = new System.Drawing.Size(994, 325);
            this.dataGridViewIncome.TabIndex = 2;
            this.dataGridViewIncome.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.DataGridViewIncome_CellClick);
            // 
            // label1
            // 
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(15, 10);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(290, 23);
            this.label1.TabIndex = 1;
            this.label1.Text = "Список доходов";
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.White;
            this.panel2.Controls.Add(this.label6);
            this.panel2.Controls.Add(this.income_dateTimePicker);
            this.panel2.Controls.Add(this.income_textBoxDescription);
            this.panel2.Controls.Add(this.label5);
            this.panel2.Controls.Add(this.income_buttonDelete);
            this.panel2.Controls.Add(this.income_buttonUpdate);
            this.panel2.Controls.Add(this.income_buttonClear);
            this.panel2.Controls.Add(this.income_buttonAdd);
            this.panel2.Controls.Add(this.income_textBoxIncome);
            this.panel2.Controls.Add(this.label4);
            this.panel2.Controls.Add(this.income_textBoxItem);
            this.panel2.Controls.Add(this.label3);
            this.panel2.Controls.Add(this.income_comboBoxCategory);
            this.panel2.Controls.Add(this.label2);
            this.panel2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.panel2.Location = new System.Drawing.Point(15, 417);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(1025, 222);
            this.panel2.TabIndex = 3;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(547, 106);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(58, 16);
            this.label6.TabIndex = 20;
            this.label6.Text = "Доходы:";
            // 
            // income_dateTimePicker
            // 
            this.income_dateTimePicker.Location = new System.Drawing.Point(611, 104);
            this.income_dateTimePicker.Name = "income_dateTimePicker";
            this.income_dateTimePicker.Size = new System.Drawing.Size(249, 22);
            this.income_dateTimePicker.TabIndex = 19;
            // 
            // income_textBoxDescription
            // 
            this.income_textBoxDescription.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.income_textBoxDescription.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.income_textBoxDescription.Location = new System.Drawing.Point(611, 29);
            this.income_textBoxDescription.Multiline = true;
            this.income_textBoxDescription.Name = "income_textBoxDescription";
            this.income_textBoxDescription.Size = new System.Drawing.Size(338, 60);
            this.income_textBoxDescription.TabIndex = 18;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(530, 31);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(75, 16);
            this.label5.TabIndex = 17;
            this.label5.Text = "Описание:";
            // 
            // income_buttonDelete
            // 
            this.income_buttonDelete.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(49)))), ((int)(((byte)(121)))), ((int)(((byte)(74)))));
            this.income_buttonDelete.FlatAppearance.BorderSize = 0;
            this.income_buttonDelete.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.income_buttonDelete.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.income_buttonDelete.ForeColor = System.Drawing.Color.White;
            this.income_buttonDelete.Location = new System.Drawing.Point(511, 165);
            this.income_buttonDelete.Name = "income_buttonDelete";
            this.income_buttonDelete.Size = new System.Drawing.Size(121, 31);
            this.income_buttonDelete.TabIndex = 16;
            this.income_buttonDelete.Text = "Удалить";
            this.income_buttonDelete.UseVisualStyleBackColor = false;
            this.income_buttonDelete.Click += new System.EventHandler(this.Income_buttonDelete_Click);
            // 
            // income_buttonUpdate
            // 
            this.income_buttonUpdate.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(49)))), ((int)(((byte)(121)))), ((int)(((byte)(74)))));
            this.income_buttonUpdate.FlatAppearance.BorderSize = 0;
            this.income_buttonUpdate.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.income_buttonUpdate.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.income_buttonUpdate.ForeColor = System.Drawing.Color.White;
            this.income_buttonUpdate.Location = new System.Drawing.Point(380, 165);
            this.income_buttonUpdate.Name = "income_buttonUpdate";
            this.income_buttonUpdate.Size = new System.Drawing.Size(121, 31);
            this.income_buttonUpdate.TabIndex = 15;
            this.income_buttonUpdate.Text = "Обновить";
            this.income_buttonUpdate.UseVisualStyleBackColor = false;
            this.income_buttonUpdate.Click += new System.EventHandler(this.Income_buttonUpdate_Click);
            // 
            // income_buttonClear
            // 
            this.income_buttonClear.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(49)))), ((int)(((byte)(121)))), ((int)(((byte)(74)))));
            this.income_buttonClear.FlatAppearance.BorderSize = 0;
            this.income_buttonClear.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.income_buttonClear.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.income_buttonClear.ForeColor = System.Drawing.Color.White;
            this.income_buttonClear.Location = new System.Drawing.Point(642, 165);
            this.income_buttonClear.Name = "income_buttonClear";
            this.income_buttonClear.Size = new System.Drawing.Size(121, 31);
            this.income_buttonClear.TabIndex = 14;
            this.income_buttonClear.Text = "Очистить";
            this.income_buttonClear.UseVisualStyleBackColor = false;
            this.income_buttonClear.Click += new System.EventHandler(this.Income_buttonClear_Click);
            // 
            // income_buttonAdd
            // 
            this.income_buttonAdd.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(49)))), ((int)(((byte)(121)))), ((int)(((byte)(74)))));
            this.income_buttonAdd.FlatAppearance.BorderSize = 0;
            this.income_buttonAdd.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.income_buttonAdd.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.income_buttonAdd.ForeColor = System.Drawing.Color.White;
            this.income_buttonAdd.Location = new System.Drawing.Point(249, 165);
            this.income_buttonAdd.Name = "income_buttonAdd";
            this.income_buttonAdd.Size = new System.Drawing.Size(121, 31);
            this.income_buttonAdd.TabIndex = 13;
            this.income_buttonAdd.Text = "Добавить";
            this.income_buttonAdd.UseVisualStyleBackColor = false;
            this.income_buttonAdd.Click += new System.EventHandler(this.Income_buttonAdd_Click);
            // 
            // income_textBoxIncome
            // 
            this.income_textBoxIncome.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.income_textBoxIncome.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.income_textBoxIncome.Location = new System.Drawing.Point(154, 104);
            this.income_textBoxIncome.Name = "income_textBoxIncome";
            this.income_textBoxIncome.Size = new System.Drawing.Size(254, 22);
            this.income_textBoxIncome.TabIndex = 5;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(95, 106);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(53, 16);
            this.label4.TabIndex = 4;
            this.label4.Text = "Сумма:";
            // 
            // income_textBoxItem
            // 
            this.income_textBoxItem.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.income_textBoxItem.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.income_textBoxItem.Location = new System.Drawing.Point(154, 67);
            this.income_textBoxItem.Name = "income_textBoxItem";
            this.income_textBoxItem.Size = new System.Drawing.Size(254, 22);
            this.income_textBoxItem.TabIndex = 3;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(81, 69);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(67, 16);
            this.label3.TabIndex = 2;
            this.label3.Text = "Событие:";
            // 
            // income_comboBoxCategory
            // 
            this.income_comboBoxCategory.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.income_comboBoxCategory.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.income_comboBoxCategory.FormattingEnabled = true;
            this.income_comboBoxCategory.Location = new System.Drawing.Point(154, 28);
            this.income_comboBoxCategory.Name = "income_comboBoxCategory";
            this.income_comboBoxCategory.Size = new System.Drawing.Size(254, 24);
            this.income_comboBoxCategory.TabIndex = 1;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(70, 31);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(78, 16);
            this.label2.TabIndex = 0;
            this.label2.Text = "Категория:";
            // 
            // IncomeForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Name = "IncomeForm";
            this.Size = new System.Drawing.Size(1055, 655);
            this.panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewIncome)).EndInit();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.DataGridView dataGridViewIncome;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox income_textBoxIncome;
        private System.Windows.Forms.TextBox income_textBoxItem;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox income_comboBoxCategory;
        private System.Windows.Forms.Button income_buttonDelete;
        private System.Windows.Forms.Button income_buttonUpdate;
        private System.Windows.Forms.Button income_buttonClear;
        private System.Windows.Forms.Button income_buttonAdd;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.DateTimePicker income_dateTimePicker;
        private System.Windows.Forms.TextBox income_textBoxDescription;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
    }
}
