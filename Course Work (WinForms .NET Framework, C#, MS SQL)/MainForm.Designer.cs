namespace Course_Work__WinForms.NET_Framework__C___MS_SQL_
{
    partial class MainForm
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

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.panel1 = new System.Windows.Forms.Panel();
            this.labelCloseApp = new System.Windows.Forms.Label();
            this.labelAbout = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.buttonLogout = new System.Windows.Forms.Button();
            this.buttonIncome = new System.Windows.Forms.Button();
            this.buttonExpenses = new System.Windows.Forms.Button();
            this.buttonAddCategory = new System.Windows.Forms.Button();
            this.buttonDashboard = new System.Windows.Forms.Button();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.expensesForm1 = new Course_Work__WinForms.NET_Framework__C___MS_SQL_.ExpensesForm();
            this.incomeForm = new Course_Work__WinForms.NET_Framework__C___MS_SQL_.IncomeForm();
            this.categoryForm = new Course_Work__WinForms.NET_Framework__C___MS_SQL_.CategoryForm();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.pictureBox1);
            this.panel1.Controls.Add(this.labelCloseApp);
            this.panel1.Controls.Add(this.labelAbout);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Margin = new System.Windows.Forms.Padding(2);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1300, 44);
            this.panel1.TabIndex = 0;
            // 
            // labelCloseApp
            // 
            this.labelCloseApp.AutoSize = true;
            this.labelCloseApp.Cursor = System.Windows.Forms.Cursors.Hand;
            this.labelCloseApp.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelCloseApp.Location = new System.Drawing.Point(1267, 13);
            this.labelCloseApp.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.labelCloseApp.Name = "labelCloseApp";
            this.labelCloseApp.Size = new System.Drawing.Size(20, 19);
            this.labelCloseApp.TabIndex = 24;
            this.labelCloseApp.Text = "X";
            this.labelCloseApp.Click += new System.EventHandler(this.labelCloseApp_Click);
            // 
            // labelAbout
            // 
            this.labelAbout.AutoSize = true;
            this.labelAbout.Cursor = System.Windows.Forms.Cursors.Hand;
            this.labelAbout.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelAbout.Location = new System.Drawing.Point(45, 13);
            this.labelAbout.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.labelAbout.Name = "labelAbout";
            this.labelAbout.Size = new System.Drawing.Size(293, 19);
            this.labelAbout.TabIndex = 25;
            this.labelAbout.Text = "Управление доходами и расходами";
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(49)))), ((int)(((byte)(121)))), ((int)(((byte)(74)))));
            this.panel2.Controls.Add(this.buttonLogout);
            this.panel2.Controls.Add(this.buttonIncome);
            this.panel2.Controls.Add(this.buttonExpenses);
            this.panel2.Controls.Add(this.buttonAddCategory);
            this.panel2.Controls.Add(this.buttonDashboard);
            this.panel2.Controls.Add(this.label1);
            this.panel2.Controls.Add(this.pictureBox2);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel2.Location = new System.Drawing.Point(0, 44);
            this.panel2.Margin = new System.Windows.Forms.Padding(2);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(243, 656);
            this.panel2.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Verdana", 10.875F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(6, 145);
            this.label1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(122, 18);
            this.label1.TabIndex = 2;
            this.label1.Text = "Вы вошли как ";
            // 
            // buttonLogout
            // 
            this.buttonLogout.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(49)))), ((int)(((byte)(121)))), ((int)(((byte)(74)))));
            this.buttonLogout.FlatAppearance.BorderSize = 0;
            this.buttonLogout.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonLogout.Font = new System.Drawing.Font("Verdana", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonLogout.ForeColor = System.Drawing.Color.White;
            this.buttonLogout.Image = global::Course_Work__WinForms.NET_Framework__C___MS_SQL_.Properties.Resources.expenses_24;
            this.buttonLogout.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.buttonLogout.Location = new System.Drawing.Point(18, 604);
            this.buttonLogout.Margin = new System.Windows.Forms.Padding(2);
            this.buttonLogout.Name = "buttonLogout";
            this.buttonLogout.Size = new System.Drawing.Size(208, 34);
            this.buttonLogout.TabIndex = 30;
            this.buttonLogout.Text = "Выйти";
            this.buttonLogout.UseVisualStyleBackColor = false;
            this.buttonLogout.Click += new System.EventHandler(this.buttonLogout_Click);
            // 
            // buttonIncome
            // 
            this.buttonIncome.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(49)))), ((int)(((byte)(121)))), ((int)(((byte)(74)))));
            this.buttonIncome.FlatAppearance.BorderSize = 0;
            this.buttonIncome.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonIncome.Font = new System.Drawing.Font("Verdana", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonIncome.ForeColor = System.Drawing.Color.White;
            this.buttonIncome.Image = global::Course_Work__WinForms.NET_Framework__C___MS_SQL_.Properties.Resources.income_24;
            this.buttonIncome.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.buttonIncome.Location = new System.Drawing.Point(18, 369);
            this.buttonIncome.Margin = new System.Windows.Forms.Padding(2);
            this.buttonIncome.Name = "buttonIncome";
            this.buttonIncome.Size = new System.Drawing.Size(208, 34);
            this.buttonIncome.TabIndex = 29;
            this.buttonIncome.Text = "Доходы";
            this.buttonIncome.UseVisualStyleBackColor = false;
            // 
            // buttonExpenses
            // 
            this.buttonExpenses.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(49)))), ((int)(((byte)(121)))), ((int)(((byte)(74)))));
            this.buttonExpenses.FlatAppearance.BorderSize = 0;
            this.buttonExpenses.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonExpenses.Font = new System.Drawing.Font("Verdana", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonExpenses.ForeColor = System.Drawing.Color.White;
            this.buttonExpenses.Image = global::Course_Work__WinForms.NET_Framework__C___MS_SQL_.Properties.Resources.expenses_24;
            this.buttonExpenses.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.buttonExpenses.Location = new System.Drawing.Point(18, 319);
            this.buttonExpenses.Margin = new System.Windows.Forms.Padding(2);
            this.buttonExpenses.Name = "buttonExpenses";
            this.buttonExpenses.Size = new System.Drawing.Size(208, 34);
            this.buttonExpenses.TabIndex = 28;
            this.buttonExpenses.Text = "Расходы";
            this.buttonExpenses.UseVisualStyleBackColor = false;
            // 
            // buttonAddCategory
            // 
            this.buttonAddCategory.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(49)))), ((int)(((byte)(121)))), ((int)(((byte)(74)))));
            this.buttonAddCategory.FlatAppearance.BorderSize = 0;
            this.buttonAddCategory.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonAddCategory.Font = new System.Drawing.Font("Verdana", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonAddCategory.ForeColor = System.Drawing.Color.White;
            this.buttonAddCategory.Image = global::Course_Work__WinForms.NET_Framework__C___MS_SQL_.Properties.Resources.plus_24;
            this.buttonAddCategory.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.buttonAddCategory.Location = new System.Drawing.Point(18, 269);
            this.buttonAddCategory.Margin = new System.Windows.Forms.Padding(2);
            this.buttonAddCategory.Name = "buttonAddCategory";
            this.buttonAddCategory.Size = new System.Drawing.Size(208, 34);
            this.buttonAddCategory.TabIndex = 27;
            this.buttonAddCategory.Text = "Добавить кат";
            this.buttonAddCategory.UseVisualStyleBackColor = false;
            // 
            // buttonDashboard
            // 
            this.buttonDashboard.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(49)))), ((int)(((byte)(121)))), ((int)(((byte)(74)))));
            this.buttonDashboard.FlatAppearance.BorderSize = 0;
            this.buttonDashboard.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonDashboard.Font = new System.Drawing.Font("Verdana", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonDashboard.ForeColor = System.Drawing.Color.White;
            this.buttonDashboard.Image = global::Course_Work__WinForms.NET_Framework__C___MS_SQL_.Properties.Resources.compass_24;
            this.buttonDashboard.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.buttonDashboard.Location = new System.Drawing.Point(18, 220);
            this.buttonDashboard.Margin = new System.Windows.Forms.Padding(2);
            this.buttonDashboard.Name = "buttonDashboard";
            this.buttonDashboard.Size = new System.Drawing.Size(208, 34);
            this.buttonDashboard.TabIndex = 2;
            this.buttonDashboard.Text = "Dashboard";
            this.buttonDashboard.UseVisualStyleBackColor = false;
            // 
            // pictureBox2
            // 
            this.pictureBox2.Image = global::Course_Work__WinForms.NET_Framework__C___MS_SQL_.Properties.Resources.pay;
            this.pictureBox2.Location = new System.Drawing.Point(62, 19);
            this.pictureBox2.Margin = new System.Windows.Forms.Padding(2);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(99, 105);
            this.pictureBox2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox2.TabIndex = 26;
            this.pictureBox2.TabStop = false;
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::Course_Work__WinForms.NET_Framework__C___MS_SQL_.Properties.Resources.pay;
            this.pictureBox1.Location = new System.Drawing.Point(6, 6);
            this.pictureBox1.Margin = new System.Windows.Forms.Padding(2);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(31, 29);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox1.TabIndex = 1;
            this.pictureBox1.TabStop = false;
            // 
            // expensesForm1
            // 
            this.expensesForm1.Location = new System.Drawing.Point(243, 46);
            this.expensesForm1.Name = "expensesForm1";
            this.expensesForm1.Size = new System.Drawing.Size(1055, 655);
            this.expensesForm1.TabIndex = 4;
            // 
            // incomeForm
            // 
            this.incomeForm.Location = new System.Drawing.Point(243, 45);
            this.incomeForm.Margin = new System.Windows.Forms.Padding(6);
            this.incomeForm.Name = "incomeForm";
            this.incomeForm.Size = new System.Drawing.Size(1055, 655);
            this.incomeForm.TabIndex = 3;
            this.incomeForm.Load += new System.EventHandler(this.incomeForm_Load);
            // 
            // categoryForm
            // 
            this.categoryForm.Location = new System.Drawing.Point(244, 45);
            this.categoryForm.Margin = new System.Windows.Forms.Padding(6);
            this.categoryForm.Name = "categoryForm";
            this.categoryForm.Size = new System.Drawing.Size(1055, 655);
            this.categoryForm.TabIndex = 2;
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1300, 700);
            this.Controls.Add(this.expensesForm1);
            this.Controls.Add(this.incomeForm);
            this.Controls.Add(this.categoryForm);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "MainForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "MainForm";
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label labelCloseApp;
        private System.Windows.Forms.Label labelAbout;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.PictureBox pictureBox2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button buttonDashboard;
        private System.Windows.Forms.Button buttonLogout;
        private System.Windows.Forms.Button buttonIncome;
        private System.Windows.Forms.Button buttonExpenses;
        private System.Windows.Forms.Button buttonAddCategory;
        private CategoryForm categoryForm;
        private IncomeForm incomeForm;
        private ExpensesForm expensesForm1;
    }
}