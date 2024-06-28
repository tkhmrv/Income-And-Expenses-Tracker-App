namespace Financial.Tracker
{
    partial class CategoryForm
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            this.panel1 = new System.Windows.Forms.Panel();
            this.category_buttonDelete = new System.Windows.Forms.Button();
            this.category_buttonUpdate = new System.Windows.Forms.Button();
            this.category_buttonClear = new System.Windows.Forms.Button();
            this.category_buttonAdd = new System.Windows.Forms.Button();
            this.category_comboBoxStatus = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.category_comboBoxType = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.category_textBoxCategory = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.dataGridViewCategory = new System.Windows.Forms.DataGridView();
            this.label4 = new System.Windows.Forms.Label();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewCategory)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.White;
            this.panel1.Controls.Add(this.category_buttonDelete);
            this.panel1.Controls.Add(this.category_buttonUpdate);
            this.panel1.Controls.Add(this.category_buttonClear);
            this.panel1.Controls.Add(this.category_buttonAdd);
            this.panel1.Controls.Add(this.category_comboBoxStatus);
            this.panel1.Controls.Add(this.label3);
            this.panel1.Controls.Add(this.category_comboBoxType);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.category_textBoxCategory);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Location = new System.Drawing.Point(28, 29);
            this.panel1.Margin = new System.Windows.Forms.Padding(6, 6, 6, 6);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(580, 1202);
            this.panel1.TabIndex = 0;
            // 
            // category_buttonDelete
            // 
            this.category_buttonDelete.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(49)))), ((int)(((byte)(121)))), ((int)(((byte)(74)))));
            this.category_buttonDelete.FlatAppearance.BorderSize = 0;
            this.category_buttonDelete.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.category_buttonDelete.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.category_buttonDelete.ForeColor = System.Drawing.Color.White;
            this.category_buttonDelete.Location = new System.Drawing.Point(300, 567);
            this.category_buttonDelete.Margin = new System.Windows.Forms.Padding(6, 6, 6, 6);
            this.category_buttonDelete.Name = "category_buttonDelete";
            this.category_buttonDelete.Size = new System.Drawing.Size(242, 60);
            this.category_buttonDelete.TabIndex = 12;
            this.category_buttonDelete.Text = "Удалить";
            this.category_buttonDelete.UseVisualStyleBackColor = false;
            this.category_buttonDelete.Click += new System.EventHandler(this.Category_buttonDelete_Click);
            // 
            // category_buttonUpdate
            // 
            this.category_buttonUpdate.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(49)))), ((int)(((byte)(121)))), ((int)(((byte)(74)))));
            this.category_buttonUpdate.FlatAppearance.BorderSize = 0;
            this.category_buttonUpdate.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.category_buttonUpdate.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.category_buttonUpdate.ForeColor = System.Drawing.Color.White;
            this.category_buttonUpdate.Location = new System.Drawing.Point(300, 492);
            this.category_buttonUpdate.Margin = new System.Windows.Forms.Padding(6, 6, 6, 6);
            this.category_buttonUpdate.Name = "category_buttonUpdate";
            this.category_buttonUpdate.Size = new System.Drawing.Size(242, 60);
            this.category_buttonUpdate.TabIndex = 11;
            this.category_buttonUpdate.Text = "Обновить";
            this.category_buttonUpdate.UseVisualStyleBackColor = false;
            this.category_buttonUpdate.Click += new System.EventHandler(this.Category_buttonUpdate_Click);
            // 
            // category_buttonClear
            // 
            this.category_buttonClear.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(49)))), ((int)(((byte)(121)))), ((int)(((byte)(74)))));
            this.category_buttonClear.FlatAppearance.BorderSize = 0;
            this.category_buttonClear.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.category_buttonClear.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.category_buttonClear.ForeColor = System.Drawing.Color.White;
            this.category_buttonClear.Location = new System.Drawing.Point(38, 567);
            this.category_buttonClear.Margin = new System.Windows.Forms.Padding(6, 6, 6, 6);
            this.category_buttonClear.Name = "category_buttonClear";
            this.category_buttonClear.Size = new System.Drawing.Size(242, 60);
            this.category_buttonClear.TabIndex = 10;
            this.category_buttonClear.Text = "Очистить";
            this.category_buttonClear.UseVisualStyleBackColor = false;
            this.category_buttonClear.Click += new System.EventHandler(this.Category_buttonClear_Click);
            // 
            // category_buttonAdd
            // 
            this.category_buttonAdd.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(49)))), ((int)(((byte)(121)))), ((int)(((byte)(74)))));
            this.category_buttonAdd.FlatAppearance.BorderSize = 0;
            this.category_buttonAdd.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.category_buttonAdd.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.category_buttonAdd.ForeColor = System.Drawing.Color.White;
            this.category_buttonAdd.Location = new System.Drawing.Point(38, 492);
            this.category_buttonAdd.Margin = new System.Windows.Forms.Padding(6, 6, 6, 6);
            this.category_buttonAdd.Name = "category_buttonAdd";
            this.category_buttonAdd.Size = new System.Drawing.Size(242, 60);
            this.category_buttonAdd.TabIndex = 8;
            this.category_buttonAdd.Text = "Добавить";
            this.category_buttonAdd.UseVisualStyleBackColor = false;
            this.category_buttonAdd.Click += new System.EventHandler(this.Category_buttonAdd_Click);
            // 
            // category_comboBoxStatus
            // 
            this.category_comboBoxStatus.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.category_comboBoxStatus.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.category_comboBoxStatus.FormattingEnabled = true;
            this.category_comboBoxStatus.Items.AddRange(new object[] {
            "Активный",
            "Неактивный"});
            this.category_comboBoxStatus.Location = new System.Drawing.Point(38, 385);
            this.category_comboBoxStatus.Margin = new System.Windows.Forms.Padding(6, 6, 6, 6);
            this.category_comboBoxStatus.Name = "category_comboBoxStatus";
            this.category_comboBoxStatus.Size = new System.Drawing.Size(500, 45);
            this.category_comboBoxStatus.TabIndex = 7;
            // 
            // label3
            // 
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(30, 335);
            this.label3.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(448, 44);
            this.label3.TabIndex = 6;
            this.label3.Text = "Статус";
            // 
            // category_comboBoxType
            // 
            this.category_comboBoxType.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.category_comboBoxType.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.category_comboBoxType.FormattingEnabled = true;
            this.category_comboBoxType.Items.AddRange(new object[] {
            "Доходы",
            "Расходы"});
            this.category_comboBoxType.Location = new System.Drawing.Point(38, 233);
            this.category_comboBoxType.Margin = new System.Windows.Forms.Padding(6, 6, 6, 6);
            this.category_comboBoxType.Name = "category_comboBoxType";
            this.category_comboBoxType.Size = new System.Drawing.Size(500, 45);
            this.category_comboBoxType.TabIndex = 5;
            // 
            // label2
            // 
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(30, 183);
            this.label2.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(448, 44);
            this.label2.TabIndex = 4;
            this.label2.Text = "Подтип";
            // 
            // category_textBoxCategory
            // 
            this.category_textBoxCategory.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.category_textBoxCategory.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.category_textBoxCategory.Location = new System.Drawing.Point(38, 87);
            this.category_textBoxCategory.Margin = new System.Windows.Forms.Padding(6, 6, 6, 6);
            this.category_textBoxCategory.Name = "category_textBoxCategory";
            this.category_textBoxCategory.Size = new System.Drawing.Size(502, 44);
            this.category_textBoxCategory.TabIndex = 3;
            // 
            // label1
            // 
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(30, 37);
            this.label1.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(448, 44);
            this.label1.TabIndex = 2;
            this.label1.Text = "Категория";
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.White;
            this.panel2.Controls.Add(this.dataGridViewCategory);
            this.panel2.Controls.Add(this.label4);
            this.panel2.Location = new System.Drawing.Point(638, 29);
            this.panel2.Margin = new System.Windows.Forms.Padding(6, 6, 6, 6);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(1440, 1202);
            this.panel2.TabIndex = 1;
            // 
            // dataGridViewCategory
            // 
            this.dataGridViewCategory.AllowUserToAddRows = false;
            this.dataGridViewCategory.AllowUserToDeleteRows = false;
            this.dataGridViewCategory.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dataGridViewCategory.BackgroundColor = System.Drawing.SystemColors.Control;
            this.dataGridViewCategory.BorderStyle = System.Windows.Forms.BorderStyle.None;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(49)))), ((int)(((byte)(121)))), ((int)(((byte)(74)))));
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(254)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridViewCategory.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dataGridViewCategory.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dataGridViewCategory.DefaultCellStyle = dataGridViewCellStyle2;
            this.dataGridViewCategory.Location = new System.Drawing.Point(30, 88);
            this.dataGridViewCategory.Margin = new System.Windows.Forms.Padding(6, 6, 6, 6);
            this.dataGridViewCategory.Name = "dataGridViewCategory";
            this.dataGridViewCategory.ReadOnly = true;
            this.dataGridViewCategory.RowHeadersVisible = false;
            this.dataGridViewCategory.RowHeadersWidth = 82;
            this.dataGridViewCategory.Size = new System.Drawing.Size(1380, 1087);
            this.dataGridViewCategory.TabIndex = 14;
            this.dataGridViewCategory.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.DataGridViewCategory_CellClick);
            this.dataGridViewCategory.CellFormatting += new System.Windows.Forms.DataGridViewCellFormattingEventHandler(this.dataGridViewCategory_CellFormatting);
            // 
            // label4
            // 
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(24, 25);
            this.label4.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(448, 44);
            this.label4.TabIndex = 13;
            this.label4.Text = "Список категорий";
            // 
            // CategoryForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(12F, 25F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Margin = new System.Windows.Forms.Padding(6, 6, 6, 6);
            this.Name = "CategoryForm";
            this.Size = new System.Drawing.Size(2110, 1260);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewCategory)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.TextBox category_textBoxCategory;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox category_comboBoxType;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button category_buttonAdd;
        private System.Windows.Forms.ComboBox category_comboBoxStatus;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button category_buttonDelete;
        private System.Windows.Forms.Button category_buttonUpdate;
        private System.Windows.Forms.Button category_buttonClear;
        private System.Windows.Forms.DataGridView dataGridViewCategory;
        private System.Windows.Forms.Label label4;
    }
}
