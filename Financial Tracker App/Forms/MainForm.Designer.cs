namespace Financial.Tracker
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
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.labelCloseApp = new System.Windows.Forms.Label();
            this.labelAbout = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.labelLogo = new System.Windows.Forms.Label();
            this.pictureboxLogo = new System.Windows.Forms.PictureBox();
            this.labelLogoPadding = new System.Windows.Forms.Label();
            this.buttonLogout = new System.Windows.Forms.Button();
            this.buttonIncome = new System.Windows.Forms.Button();
            this.buttonExpenses = new System.Windows.Forms.Button();
            this.buttonAddCategory = new System.Windows.Forms.Button();
            this.buttonDashboard = new System.Windows.Forms.Button();
            this.labelDisplayUsername = new System.Windows.Forms.Label();
            this.dashboardForm = new Financial.Tracker.DashboardForm();
            this.categoryForm = new Financial.Tracker.CategoryForm();
            this.incomeForm = new Financial.Tracker.IncomeForm();
            this.expensesForm = new Financial.Tracker.ExpensesForm();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureboxLogo)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.White;
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
            // pictureBox1
            // 
            this.pictureBox1.Image = global::Financial.Tracker.Properties.Resources.pay;
            this.pictureBox1.Location = new System.Drawing.Point(6, 6);
            this.pictureBox1.Margin = new System.Windows.Forms.Padding(2);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(31, 29);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox1.TabIndex = 1;
            this.pictureBox1.TabStop = false;
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
            this.labelCloseApp.Click += new System.EventHandler(this.LabelCloseApp_Click);
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
            this.panel2.Controls.Add(this.label1);
            this.panel2.Controls.Add(this.labelLogo);
            this.panel2.Controls.Add(this.pictureboxLogo);
            this.panel2.Controls.Add(this.labelLogoPadding);
            this.panel2.Controls.Add(this.buttonLogout);
            this.panel2.Controls.Add(this.buttonIncome);
            this.panel2.Controls.Add(this.buttonExpenses);
            this.panel2.Controls.Add(this.buttonAddCategory);
            this.panel2.Controls.Add(this.buttonDashboard);
            this.panel2.Controls.Add(this.labelDisplayUsername);
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
            this.label1.Font = new System.Drawing.Font("Verdana", 12.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(12, 100);
            this.label1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(203, 20);
            this.label1.TabIndex = 34;
            this.label1.Text = "Добро пожаловать!";
            // 
            // labelLogo
            // 
            this.labelLogo.AutoSize = true;
            this.labelLogo.BackColor = System.Drawing.Color.White;
            this.labelLogo.Font = new System.Drawing.Font("Bookman Old Style", 17.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelLogo.ForeColor = System.Drawing.Color.Black;
            this.labelLogo.Location = new System.Drawing.Point(85, 34);
            this.labelLogo.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.labelLogo.Name = "labelLogo";
            this.labelLogo.Size = new System.Drawing.Size(138, 26);
            this.labelLogo.TabIndex = 31;
            this.labelLogo.Text = "Be Wealthy";
            // 
            // pictureboxLogo
            // 
            this.pictureboxLogo.BackColor = System.Drawing.Color.White;
            this.pictureboxLogo.Image = global::Financial.Tracker.Properties.Resources.pay;
            this.pictureboxLogo.Location = new System.Drawing.Point(24, 21);
            this.pictureboxLogo.Margin = new System.Windows.Forms.Padding(2);
            this.pictureboxLogo.Name = "pictureboxLogo";
            this.pictureboxLogo.Size = new System.Drawing.Size(50, 50);
            this.pictureboxLogo.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureboxLogo.TabIndex = 32;
            this.pictureboxLogo.TabStop = false;
            // 
            // labelLogoPadding
            // 
            this.labelLogoPadding.BackColor = System.Drawing.Color.White;
            this.labelLogoPadding.Font = new System.Drawing.Font("Verdana", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelLogoPadding.Location = new System.Drawing.Point(14, 14);
            this.labelLogoPadding.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.labelLogoPadding.Name = "labelLogoPadding";
            this.labelLogoPadding.Size = new System.Drawing.Size(215, 65);
            this.labelLogoPadding.TabIndex = 33;
            // 
            // buttonLogout
            // 
            this.buttonLogout.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(49)))), ((int)(((byte)(121)))), ((int)(((byte)(74)))));
            this.buttonLogout.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonLogout.Font = new System.Drawing.Font("Verdana", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonLogout.ForeColor = System.Drawing.Color.White;
            this.buttonLogout.Image = global::Financial.Tracker.Properties.Resources.logout_24;
            this.buttonLogout.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.buttonLogout.Location = new System.Drawing.Point(16, 605);
            this.buttonLogout.Margin = new System.Windows.Forms.Padding(2);
            this.buttonLogout.Name = "buttonLogout";
            this.buttonLogout.Size = new System.Drawing.Size(210, 35);
            this.buttonLogout.TabIndex = 30;
            this.buttonLogout.Text = "Выйти";
            this.buttonLogout.UseVisualStyleBackColor = false;
            this.buttonLogout.Click += new System.EventHandler(this.ButtonLogout_Click);
            // 
            // buttonIncome
            // 
            this.buttonIncome.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(49)))), ((int)(((byte)(121)))), ((int)(((byte)(74)))));
            this.buttonIncome.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonIncome.Font = new System.Drawing.Font("Verdana", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonIncome.ForeColor = System.Drawing.Color.White;
            this.buttonIncome.Image = global::Financial.Tracker.Properties.Resources.income_24;
            this.buttonIncome.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.buttonIncome.Location = new System.Drawing.Point(16, 279);
            this.buttonIncome.Margin = new System.Windows.Forms.Padding(2);
            this.buttonIncome.Name = "buttonIncome";
            this.buttonIncome.Size = new System.Drawing.Size(210, 35);
            this.buttonIncome.TabIndex = 29;
            this.buttonIncome.Text = "Доходы";
            this.buttonIncome.UseVisualStyleBackColor = false;
            this.buttonIncome.Click += new System.EventHandler(this.ButtonIncome_Click);
            // 
            // buttonExpenses
            // 
            this.buttonExpenses.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(49)))), ((int)(((byte)(121)))), ((int)(((byte)(74)))));
            this.buttonExpenses.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonExpenses.Font = new System.Drawing.Font("Verdana", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonExpenses.ForeColor = System.Drawing.Color.White;
            this.buttonExpenses.Image = global::Financial.Tracker.Properties.Resources.expenses_24;
            this.buttonExpenses.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.buttonExpenses.Location = new System.Drawing.Point(16, 327);
            this.buttonExpenses.Margin = new System.Windows.Forms.Padding(2);
            this.buttonExpenses.Name = "buttonExpenses";
            this.buttonExpenses.Size = new System.Drawing.Size(210, 35);
            this.buttonExpenses.TabIndex = 28;
            this.buttonExpenses.Text = "Расходы";
            this.buttonExpenses.UseVisualStyleBackColor = false;
            this.buttonExpenses.Click += new System.EventHandler(this.ButtonExpenses_Click);
            // 
            // buttonAddCategory
            // 
            this.buttonAddCategory.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(49)))), ((int)(((byte)(121)))), ((int)(((byte)(74)))));
            this.buttonAddCategory.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonAddCategory.Font = new System.Drawing.Font("Verdana", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonAddCategory.ForeColor = System.Drawing.Color.White;
            this.buttonAddCategory.Image = global::Financial.Tracker.Properties.Resources.plus_24;
            this.buttonAddCategory.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.buttonAddCategory.Location = new System.Drawing.Point(16, 230);
            this.buttonAddCategory.Margin = new System.Windows.Forms.Padding(2);
            this.buttonAddCategory.Name = "buttonAddCategory";
            this.buttonAddCategory.Size = new System.Drawing.Size(210, 35);
            this.buttonAddCategory.TabIndex = 27;
            this.buttonAddCategory.Text = "Категории";
            this.buttonAddCategory.UseVisualStyleBackColor = false;
            this.buttonAddCategory.Click += new System.EventHandler(this.ButtonAddCategory_Click);
            // 
            // buttonDashboard
            // 
            this.buttonDashboard.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(49)))), ((int)(((byte)(121)))), ((int)(((byte)(74)))));
            this.buttonDashboard.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonDashboard.Font = new System.Drawing.Font("Verdana", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonDashboard.ForeColor = System.Drawing.Color.White;
            this.buttonDashboard.Image = global::Financial.Tracker.Properties.Resources.compass_24;
            this.buttonDashboard.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.buttonDashboard.Location = new System.Drawing.Point(16, 182);
            this.buttonDashboard.Margin = new System.Windows.Forms.Padding(2);
            this.buttonDashboard.Name = "buttonDashboard";
            this.buttonDashboard.Size = new System.Drawing.Size(210, 35);
            this.buttonDashboard.TabIndex = 2;
            this.buttonDashboard.Text = "Главная";
            this.buttonDashboard.UseVisualStyleBackColor = false;
            this.buttonDashboard.Click += new System.EventHandler(this.ButtonDashboard_Click);
            // 
            // labelDisplayUsername
            // 
            this.labelDisplayUsername.AutoSize = true;
            this.labelDisplayUsername.Font = new System.Drawing.Font("Verdana", 10.875F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelDisplayUsername.ForeColor = System.Drawing.Color.White;
            this.labelDisplayUsername.Location = new System.Drawing.Point(13, 132);
            this.labelDisplayUsername.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.labelDisplayUsername.Name = "labelDisplayUsername";
            this.labelDisplayUsername.Size = new System.Drawing.Size(118, 18);
            this.labelDisplayUsername.TabIndex = 2;
            this.labelDisplayUsername.Text = "Ваш аккаунт: ";
            // 
            // dashboardForm
            // 
            this.dashboardForm.Location = new System.Drawing.Point(243, 43);
            this.dashboardForm.Name = "dashboardForm";
            this.dashboardForm.Size = new System.Drawing.Size(1055, 655);
            this.dashboardForm.TabIndex = 5;
            // 
            // categoryForm
            // 
            this.categoryForm.Location = new System.Drawing.Point(243, 43);
            this.categoryForm.Name = "categoryForm";
            this.categoryForm.Size = new System.Drawing.Size(1055, 655);
            this.categoryForm.TabIndex = 4;
            // 
            // incomeForm
            // 
            this.incomeForm.Location = new System.Drawing.Point(243, 43);
            this.incomeForm.Name = "incomeForm";
            this.incomeForm.Size = new System.Drawing.Size(1055, 655);
            this.incomeForm.TabIndex = 3;
            // 
            // expensesForm
            // 
            this.expensesForm.Location = new System.Drawing.Point(243, 43);
            this.expensesForm.Name = "expensesForm";
            this.expensesForm.Size = new System.Drawing.Size(1055, 655);
            this.expensesForm.TabIndex = 2;
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1300, 700);
            this.Controls.Add(this.dashboardForm);
            this.Controls.Add(this.categoryForm);
            this.Controls.Add(this.incomeForm);
            this.Controls.Add(this.expensesForm);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "MainForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "MainForm";
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureboxLogo)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label labelCloseApp;
        private System.Windows.Forms.Label labelAbout;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Label labelDisplayUsername;
        private System.Windows.Forms.Button buttonDashboard;
        private System.Windows.Forms.Button buttonLogout;
        private System.Windows.Forms.Button buttonIncome;
        private System.Windows.Forms.Button buttonExpenses;
        private System.Windows.Forms.Button buttonAddCategory;
        private ExpensesForm expensesForm;
        private IncomeForm incomeForm;
        private CategoryForm categoryForm;
        private DashboardForm dashboardForm;
        private System.Windows.Forms.Label labelLogo;
        private System.Windows.Forms.PictureBox pictureboxLogo;
        private System.Windows.Forms.Label labelLogoPadding;
        private System.Windows.Forms.Label label1;
    }
}