namespace Course_Work__WinForms.NET_Framework__C___MS_SQL_
{
    partial class RegisterForm
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
            this.panelNavigation = new System.Windows.Forms.Panel();
            this.buttonBackToAuth = new System.Windows.Forms.Button();
            this.appLabel = new System.Windows.Forms.Label();
            this.labelLogo = new System.Windows.Forms.Label();
            this.labelLogoPadding = new System.Windows.Forms.Label();
            this.textboxConfirmPassword = new System.Windows.Forms.TextBox();
            this.labelConfirmPassword = new System.Windows.Forms.Label();
            this.checkboxShowRegPassword = new System.Windows.Forms.CheckBox();
            this.buttonRegistration = new System.Windows.Forms.Button();
            this.textboxRegPassword = new System.Windows.Forms.TextBox();
            this.labelPass = new System.Windows.Forms.Label();
            this.textboxRegisterUsername = new System.Windows.Forms.TextBox();
            this.labelUser = new System.Windows.Forms.Label();
            this.labelRegistration = new System.Windows.Forms.Label();
            this.labelCloseApp = new System.Windows.Forms.Label();
            this.pictureboxLogo = new System.Windows.Forms.PictureBox();
            this.panelNavigation.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureboxLogo)).BeginInit();
            this.SuspendLayout();
            // 
            // panelNavigation
            // 
            this.panelNavigation.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(49)))), ((int)(((byte)(121)))), ((int)(((byte)(74)))));
            this.panelNavigation.Controls.Add(this.buttonBackToAuth);
            this.panelNavigation.Controls.Add(this.appLabel);
            this.panelNavigation.Controls.Add(this.labelLogo);
            this.panelNavigation.Controls.Add(this.pictureboxLogo);
            this.panelNavigation.Controls.Add(this.labelLogoPadding);
            this.panelNavigation.Dock = System.Windows.Forms.DockStyle.Left;
            this.panelNavigation.Location = new System.Drawing.Point(0, 0);
            this.panelNavigation.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.panelNavigation.Name = "panelNavigation";
            this.panelNavigation.Size = new System.Drawing.Size(305, 457);
            this.panelNavigation.TabIndex = 22;
            // 
            // buttonBackToAuth
            // 
            this.buttonBackToAuth.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(49)))), ((int)(((byte)(121)))), ((int)(((byte)(74)))));
            this.buttonBackToAuth.FlatAppearance.BorderColor = System.Drawing.Color.White;
            this.buttonBackToAuth.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(93)))), ((int)(((byte)(160)))), ((int)(((byte)(108)))));
            this.buttonBackToAuth.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(93)))), ((int)(((byte)(160)))), ((int)(((byte)(108)))));
            this.buttonBackToAuth.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonBackToAuth.Font = new System.Drawing.Font("Verdana", 10.125F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonBackToAuth.ForeColor = System.Drawing.Color.White;
            this.buttonBackToAuth.Location = new System.Drawing.Point(36, 387);
            this.buttonBackToAuth.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.buttonBackToAuth.Name = "buttonBackToAuth";
            this.buttonBackToAuth.Size = new System.Drawing.Size(231, 42);
            this.buttonBackToAuth.TabIndex = 22;
            this.buttonBackToAuth.Text = "← Вход в приложение";
            this.buttonBackToAuth.UseVisualStyleBackColor = false;
            this.buttonBackToAuth.Click += new System.EventHandler(this.ButtonBackToAuth_Click);
            // 
            // appLabel
            // 
            this.appLabel.AutoSize = true;
            this.appLabel.BackColor = System.Drawing.Color.Transparent;
            this.appLabel.Font = new System.Drawing.Font("Verdana", 13.875F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.appLabel.ForeColor = System.Drawing.Color.White;
            this.appLabel.Location = new System.Drawing.Point(14, 128);
            this.appLabel.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.appLabel.Name = "appLabel";
            this.appLabel.Size = new System.Drawing.Size(262, 46);
            this.appLabel.TabIndex = 10;
            this.appLabel.Text = "Приложение‎ управления‎ \r\nдоходами и‎ расходами";
            // 
            // labelLogo
            // 
            this.labelLogo.AutoSize = true;
            this.labelLogo.BackColor = System.Drawing.Color.White;
            this.labelLogo.Font = new System.Drawing.Font("Bookman Old Style", 19.875F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelLogo.ForeColor = System.Drawing.Color.Black;
            this.labelLogo.Location = new System.Drawing.Point(114, 45);
            this.labelLogo.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.labelLogo.Name = "labelLogo";
            this.labelLogo.Size = new System.Drawing.Size(164, 32);
            this.labelLogo.TabIndex = 0;
            this.labelLogo.Text = "Be Wealthy";
            // 
            // labelLogoPadding
            // 
            this.labelLogoPadding.BackColor = System.Drawing.Color.White;
            this.labelLogoPadding.Font = new System.Drawing.Font("Verdana", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelLogoPadding.Location = new System.Drawing.Point(14, 16);
            this.labelLogoPadding.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.labelLogoPadding.Name = "labelLogoPadding";
            this.labelLogoPadding.Size = new System.Drawing.Size(275, 88);
            this.labelLogoPadding.TabIndex = 10;
            // 
            // textboxConfirmPassword
            // 
            this.textboxConfirmPassword.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.textboxConfirmPassword.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textboxConfirmPassword.Location = new System.Drawing.Point(348, 279);
            this.textboxConfirmPassword.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.textboxConfirmPassword.Name = "textboxConfirmPassword";
            this.textboxConfirmPassword.PasswordChar = '*';
            this.textboxConfirmPassword.Size = new System.Drawing.Size(338, 26);
            this.textboxConfirmPassword.TabIndex = 32;
            // 
            // labelConfirmPassword
            // 
            this.labelConfirmPassword.AutoSize = true;
            this.labelConfirmPassword.Font = new System.Drawing.Font("Verdana", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelConfirmPassword.Location = new System.Drawing.Point(344, 253);
            this.labelConfirmPassword.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.labelConfirmPassword.Name = "labelConfirmPassword";
            this.labelConfirmPassword.Size = new System.Drawing.Size(179, 18);
            this.labelConfirmPassword.TabIndex = 31;
            this.labelConfirmPassword.Text = "Подтвердите пароль";
            // 
            // checkboxShowRegPassword
            // 
            this.checkboxShowRegPassword.AutoSize = true;
            this.checkboxShowRegPassword.Font = new System.Drawing.Font("Verdana", 7.875F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.checkboxShowRegPassword.Location = new System.Drawing.Point(348, 310);
            this.checkboxShowRegPassword.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.checkboxShowRegPassword.Name = "checkboxShowRegPassword";
            this.checkboxShowRegPassword.Size = new System.Drawing.Size(126, 17);
            this.checkboxShowRegPassword.TabIndex = 30;
            this.checkboxShowRegPassword.Text = "Показать пароль";
            this.checkboxShowRegPassword.UseVisualStyleBackColor = true;
            this.checkboxShowRegPassword.CheckedChanged += new System.EventHandler(this.CheckboxShowRegPassword_CheckedChanged);
            // 
            // buttonRegistration
            // 
            this.buttonRegistration.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(49)))), ((int)(((byte)(121)))), ((int)(((byte)(74)))));
            this.buttonRegistration.FlatAppearance.BorderSize = 0;
            this.buttonRegistration.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(93)))), ((int)(((byte)(160)))), ((int)(((byte)(108)))));
            this.buttonRegistration.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(93)))), ((int)(((byte)(160)))), ((int)(((byte)(108)))));
            this.buttonRegistration.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonRegistration.Font = new System.Drawing.Font("Verdana", 10.125F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonRegistration.ForeColor = System.Drawing.Color.White;
            this.buttonRegistration.Location = new System.Drawing.Point(348, 355);
            this.buttonRegistration.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.buttonRegistration.Name = "buttonRegistration";
            this.buttonRegistration.Size = new System.Drawing.Size(336, 42);
            this.buttonRegistration.TabIndex = 29;
            this.buttonRegistration.Text = "Зарегистрироваться";
            this.buttonRegistration.UseVisualStyleBackColor = false;
            this.buttonRegistration.Click += new System.EventHandler(this.ButtonRegistration_Click);
            // 
            // textboxRegPassword
            // 
            this.textboxRegPassword.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.textboxRegPassword.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textboxRegPassword.Location = new System.Drawing.Point(348, 214);
            this.textboxRegPassword.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.textboxRegPassword.Name = "textboxRegPassword";
            this.textboxRegPassword.PasswordChar = '*';
            this.textboxRegPassword.Size = new System.Drawing.Size(338, 26);
            this.textboxRegPassword.TabIndex = 28;
            // 
            // labelPass
            // 
            this.labelPass.AutoSize = true;
            this.labelPass.Font = new System.Drawing.Font("Verdana", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelPass.Location = new System.Drawing.Point(344, 188);
            this.labelPass.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.labelPass.Name = "labelPass";
            this.labelPass.Size = new System.Drawing.Size(69, 18);
            this.labelPass.TabIndex = 27;
            this.labelPass.Text = "Пароль";
            // 
            // textboxRegisterUsername
            // 
            this.textboxRegisterUsername.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.textboxRegisterUsername.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textboxRegisterUsername.Location = new System.Drawing.Point(348, 148);
            this.textboxRegisterUsername.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.textboxRegisterUsername.Name = "textboxRegisterUsername";
            this.textboxRegisterUsername.Size = new System.Drawing.Size(338, 26);
            this.textboxRegisterUsername.TabIndex = 26;
            // 
            // labelUser
            // 
            this.labelUser.AutoSize = true;
            this.labelUser.Font = new System.Drawing.Font("Verdana", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelUser.Location = new System.Drawing.Point(344, 122);
            this.labelUser.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.labelUser.Name = "labelUser";
            this.labelUser.Size = new System.Drawing.Size(162, 18);
            this.labelUser.TabIndex = 25;
            this.labelUser.Text = "Имя пользователя";
            // 
            // labelRegistration
            // 
            this.labelRegistration.AutoSize = true;
            this.labelRegistration.Font = new System.Drawing.Font("Verdana", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelRegistration.Location = new System.Drawing.Point(430, 59);
            this.labelRegistration.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.labelRegistration.Name = "labelRegistration";
            this.labelRegistration.Size = new System.Drawing.Size(165, 29);
            this.labelRegistration.TabIndex = 24;
            this.labelRegistration.Text = "Регистрация";
            // 
            // labelCloseApp
            // 
            this.labelCloseApp.AutoSize = true;
            this.labelCloseApp.Cursor = System.Windows.Forms.Cursors.Hand;
            this.labelCloseApp.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelCloseApp.Location = new System.Drawing.Point(700, 5);
            this.labelCloseApp.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.labelCloseApp.Name = "labelCloseApp";
            this.labelCloseApp.Size = new System.Drawing.Size(20, 19);
            this.labelCloseApp.TabIndex = 23;
            this.labelCloseApp.Text = "X";
            this.labelCloseApp.Click += new System.EventHandler(this.LabelCloseApp_Click);
            // 
            // pictureboxLogo
            // 
            this.pictureboxLogo.BackColor = System.Drawing.Color.White;
            this.pictureboxLogo.Image = global::Course_Work__WinForms.NET_Framework__C___MS_SQL_.Properties.Resources.pay;
            this.pictureboxLogo.Location = new System.Drawing.Point(27, 20);
            this.pictureboxLogo.Margin = new System.Windows.Forms.Padding(2);
            this.pictureboxLogo.Name = "pictureboxLogo";
            this.pictureboxLogo.Size = new System.Drawing.Size(75, 78);
            this.pictureboxLogo.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureboxLogo.TabIndex = 1;
            this.pictureboxLogo.TabStop = false;
            // 
            // RegisterForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(727, 457);
            this.Controls.Add(this.panelNavigation);
            this.Controls.Add(this.textboxConfirmPassword);
            this.Controls.Add(this.labelConfirmPassword);
            this.Controls.Add(this.checkboxShowRegPassword);
            this.Controls.Add(this.buttonRegistration);
            this.Controls.Add(this.textboxRegPassword);
            this.Controls.Add(this.labelPass);
            this.Controls.Add(this.textboxRegisterUsername);
            this.Controls.Add(this.labelUser);
            this.Controls.Add(this.labelRegistration);
            this.Controls.Add(this.labelCloseApp);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.Name = "RegisterForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "testform";
            this.panelNavigation.ResumeLayout(false);
            this.panelNavigation.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureboxLogo)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel panelNavigation;
        private System.Windows.Forms.Button buttonBackToAuth;
        private System.Windows.Forms.Label appLabel;
        private System.Windows.Forms.Label labelLogo;
        private System.Windows.Forms.PictureBox pictureboxLogo;
        private System.Windows.Forms.Label labelLogoPadding;
        private System.Windows.Forms.TextBox textboxConfirmPassword;
        private System.Windows.Forms.Label labelConfirmPassword;
        private System.Windows.Forms.CheckBox checkboxShowRegPassword;
        private System.Windows.Forms.Button buttonRegistration;
        private System.Windows.Forms.TextBox textboxRegPassword;
        private System.Windows.Forms.Label labelPass;
        private System.Windows.Forms.TextBox textboxRegisterUsername;
        private System.Windows.Forms.Label labelUser;
        private System.Windows.Forms.Label labelRegistration;
        private System.Windows.Forms.Label labelCloseApp;
    }
}