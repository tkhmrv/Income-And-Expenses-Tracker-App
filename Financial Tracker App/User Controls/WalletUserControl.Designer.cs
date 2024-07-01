namespace Financial.Tracker
{
    partial class WalletUserControl
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle7 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle8 = new System.Windows.Forms.DataGridViewCellStyle();
            this.panel1 = new System.Windows.Forms.Panel();
            this.label5 = new System.Windows.Forms.Label();
            this.wallet_textBoxDescription = new System.Windows.Forms.TextBox();
            this.wallet_textBoxType = new System.Windows.Forms.TextBox();
            this.wallet_buttonDelete = new System.Windows.Forms.Button();
            this.wallet_buttonUpdate = new System.Windows.Forms.Button();
            this.wallet_buttonClear = new System.Windows.Forms.Button();
            this.wallet_buttonAdd = new System.Windows.Forms.Button();
            this.wallet_comboBoxStatus = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.wallet_textBoxWallet = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.dataGridViewWallet = new System.Windows.Forms.DataGridView();
            this.label4 = new System.Windows.Forms.Label();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewWallet)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.White;
            this.panel1.Controls.Add(this.label5);
            this.panel1.Controls.Add(this.wallet_textBoxDescription);
            this.panel1.Controls.Add(this.wallet_textBoxType);
            this.panel1.Controls.Add(this.wallet_buttonDelete);
            this.panel1.Controls.Add(this.wallet_buttonUpdate);
            this.panel1.Controls.Add(this.wallet_buttonClear);
            this.panel1.Controls.Add(this.wallet_buttonAdd);
            this.panel1.Controls.Add(this.wallet_comboBoxStatus);
            this.panel1.Controls.Add(this.label3);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.wallet_textBoxWallet);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Location = new System.Drawing.Point(15, 15);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(290, 625);
            this.panel1.TabIndex = 2;
            // 
            // label5
            // 
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(16, 247);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(224, 23);
            this.label5.TabIndex = 20;
            this.label5.Text = "Описание";
            // 
            // wallet_textBoxDescription
            // 
            this.wallet_textBoxDescription.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.wallet_textBoxDescription.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.wallet_textBoxDescription.Location = new System.Drawing.Point(18, 273);
            this.wallet_textBoxDescription.Multiline = true;
            this.wallet_textBoxDescription.Name = "wallet_textBoxDescription";
            this.wallet_textBoxDescription.Size = new System.Drawing.Size(252, 96);
            this.wallet_textBoxDescription.TabIndex = 19;
            // 
            // wallet_textBoxType
            // 
            this.wallet_textBoxType.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.wallet_textBoxType.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.wallet_textBoxType.Location = new System.Drawing.Point(18, 121);
            this.wallet_textBoxType.Name = "wallet_textBoxType";
            this.wallet_textBoxType.Size = new System.Drawing.Size(252, 26);
            this.wallet_textBoxType.TabIndex = 13;
            // 
            // wallet_buttonDelete
            // 
            this.wallet_buttonDelete.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(49)))), ((int)(((byte)(121)))), ((int)(((byte)(74)))));
            this.wallet_buttonDelete.FlatAppearance.BorderSize = 0;
            this.wallet_buttonDelete.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.wallet_buttonDelete.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.wallet_buttonDelete.ForeColor = System.Drawing.Color.White;
            this.wallet_buttonDelete.Location = new System.Drawing.Point(150, 437);
            this.wallet_buttonDelete.Name = "wallet_buttonDelete";
            this.wallet_buttonDelete.Size = new System.Drawing.Size(121, 31);
            this.wallet_buttonDelete.TabIndex = 12;
            this.wallet_buttonDelete.Text = "Удалить";
            this.wallet_buttonDelete.UseVisualStyleBackColor = false;
            this.wallet_buttonDelete.Click += new System.EventHandler(this.Wallet_buttonDelete_Click);
            // 
            // wallet_buttonUpdate
            // 
            this.wallet_buttonUpdate.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(49)))), ((int)(((byte)(121)))), ((int)(((byte)(74)))));
            this.wallet_buttonUpdate.FlatAppearance.BorderSize = 0;
            this.wallet_buttonUpdate.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.wallet_buttonUpdate.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.wallet_buttonUpdate.ForeColor = System.Drawing.Color.White;
            this.wallet_buttonUpdate.Location = new System.Drawing.Point(150, 398);
            this.wallet_buttonUpdate.Name = "wallet_buttonUpdate";
            this.wallet_buttonUpdate.Size = new System.Drawing.Size(121, 31);
            this.wallet_buttonUpdate.TabIndex = 11;
            this.wallet_buttonUpdate.Text = "Обновить";
            this.wallet_buttonUpdate.UseVisualStyleBackColor = false;
            this.wallet_buttonUpdate.Click += new System.EventHandler(this.Wallet_buttonUpdate_Click);
            // 
            // wallet_buttonClear
            // 
            this.wallet_buttonClear.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(49)))), ((int)(((byte)(121)))), ((int)(((byte)(74)))));
            this.wallet_buttonClear.FlatAppearance.BorderSize = 0;
            this.wallet_buttonClear.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.wallet_buttonClear.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.wallet_buttonClear.ForeColor = System.Drawing.Color.White;
            this.wallet_buttonClear.Location = new System.Drawing.Point(18, 437);
            this.wallet_buttonClear.Name = "wallet_buttonClear";
            this.wallet_buttonClear.Size = new System.Drawing.Size(121, 31);
            this.wallet_buttonClear.TabIndex = 10;
            this.wallet_buttonClear.Text = "Очистить";
            this.wallet_buttonClear.UseVisualStyleBackColor = false;
            this.wallet_buttonClear.Click += new System.EventHandler(this.Wallet_buttonClear_Click);
            // 
            // wallet_buttonAdd
            // 
            this.wallet_buttonAdd.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(49)))), ((int)(((byte)(121)))), ((int)(((byte)(74)))));
            this.wallet_buttonAdd.FlatAppearance.BorderSize = 0;
            this.wallet_buttonAdd.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.wallet_buttonAdd.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.wallet_buttonAdd.ForeColor = System.Drawing.Color.White;
            this.wallet_buttonAdd.Location = new System.Drawing.Point(18, 398);
            this.wallet_buttonAdd.Name = "wallet_buttonAdd";
            this.wallet_buttonAdd.Size = new System.Drawing.Size(121, 31);
            this.wallet_buttonAdd.TabIndex = 8;
            this.wallet_buttonAdd.Text = "Добавить";
            this.wallet_buttonAdd.UseVisualStyleBackColor = false;
            this.wallet_buttonAdd.Click += new System.EventHandler(this.Wallet_buttonAdd_Click);
            // 
            // wallet_comboBoxStatus
            // 
            this.wallet_comboBoxStatus.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.wallet_comboBoxStatus.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.wallet_comboBoxStatus.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.wallet_comboBoxStatus.FormattingEnabled = true;
            this.wallet_comboBoxStatus.Items.AddRange(new object[] {
            "Активный",
            "Неактивный"});
            this.wallet_comboBoxStatus.Location = new System.Drawing.Point(19, 200);
            this.wallet_comboBoxStatus.Name = "wallet_comboBoxStatus";
            this.wallet_comboBoxStatus.Size = new System.Drawing.Size(253, 28);
            this.wallet_comboBoxStatus.TabIndex = 7;
            // 
            // label3
            // 
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(15, 174);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(224, 23);
            this.label3.TabIndex = 6;
            this.label3.Text = "Статус";
            // 
            // label2
            // 
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(15, 95);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(224, 23);
            this.label2.TabIndex = 4;
            this.label2.Text = "Тип";
            // 
            // wallet_textBoxWallet
            // 
            this.wallet_textBoxWallet.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.wallet_textBoxWallet.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.wallet_textBoxWallet.Location = new System.Drawing.Point(19, 45);
            this.wallet_textBoxWallet.Name = "wallet_textBoxWallet";
            this.wallet_textBoxWallet.Size = new System.Drawing.Size(252, 26);
            this.wallet_textBoxWallet.TabIndex = 3;
            // 
            // label1
            // 
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(15, 19);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(224, 23);
            this.label1.TabIndex = 2;
            this.label1.Text = "Название кошелька";
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.White;
            this.panel2.Controls.Add(this.dataGridViewWallet);
            this.panel2.Controls.Add(this.label4);
            this.panel2.Location = new System.Drawing.Point(320, 15);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(720, 625);
            this.panel2.TabIndex = 3;
            // 
            // dataGridViewWallet
            // 
            this.dataGridViewWallet.AllowUserToAddRows = false;
            this.dataGridViewWallet.AllowUserToDeleteRows = false;
            this.dataGridViewWallet.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dataGridViewWallet.BackgroundColor = System.Drawing.SystemColors.Control;
            this.dataGridViewWallet.BorderStyle = System.Windows.Forms.BorderStyle.None;
            dataGridViewCellStyle7.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle7.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(49)))), ((int)(((byte)(121)))), ((int)(((byte)(74)))));
            dataGridViewCellStyle7.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(254)));
            dataGridViewCellStyle7.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle7.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle7.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle7.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridViewWallet.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle7;
            this.dataGridViewWallet.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle8.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle8.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle8.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle8.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle8.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle8.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle8.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dataGridViewWallet.DefaultCellStyle = dataGridViewCellStyle8;
            this.dataGridViewWallet.Location = new System.Drawing.Point(15, 46);
            this.dataGridViewWallet.Name = "dataGridViewWallet";
            this.dataGridViewWallet.ReadOnly = true;
            this.dataGridViewWallet.RowHeadersVisible = false;
            this.dataGridViewWallet.RowHeadersWidth = 82;
            this.dataGridViewWallet.Size = new System.Drawing.Size(690, 565);
            this.dataGridViewWallet.TabIndex = 14;
            this.dataGridViewWallet.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.DataGridViewWallet_CellClick);
            // 
            // label4
            // 
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(12, 13);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(224, 23);
            this.label4.TabIndex = 13;
            this.label4.Text = "Список кошельков";
            // 
            // WalletUserControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.panel2);
            this.Name = "WalletUserControl";
            this.Size = new System.Drawing.Size(1055, 655);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewWallet)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button wallet_buttonDelete;
        private System.Windows.Forms.Button wallet_buttonUpdate;
        private System.Windows.Forms.Button wallet_buttonClear;
        private System.Windows.Forms.Button wallet_buttonAdd;
        private System.Windows.Forms.ComboBox wallet_comboBoxStatus;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox wallet_textBoxWallet;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.DataGridView dataGridViewWallet;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox wallet_textBoxType;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox wallet_textBoxDescription;
    }
}
