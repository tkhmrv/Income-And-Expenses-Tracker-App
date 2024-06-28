namespace Financial.Tracker
{
    partial class AuthForm
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
            this.appLabel = new System.Windows.Forms.Label();
            this.labelLogo = new System.Windows.Forms.Label();
            this.pictureboxLogo = new System.Windows.Forms.PictureBox();
            this.labelLogoPadding = new System.Windows.Forms.Label();
            this.labelCloseApp = new System.Windows.Forms.Label();
            this.labelAuth = new System.Windows.Forms.Label();
            this.labelUser = new System.Windows.Forms.Label();
            this.textboxAuthUser = new System.Windows.Forms.TextBox();
            this.textboxPassword = new System.Windows.Forms.TextBox();
            this.labelPass = new System.Windows.Forms.Label();
            this.buttonAuth = new System.Windows.Forms.Button();
            this.checkboxShowAuthPassword = new System.Windows.Forms.CheckBox();
            this.labelCreateAccount = new System.Windows.Forms.Label();
            this.panelNavigation.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureboxLogo)).BeginInit();
            this.SuspendLayout();
            // 
            // panelNavigation
            // 
            this.panelNavigation.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(49)))), ((int)(((byte)(121)))), ((int)(((byte)(74)))));
            this.panelNavigation.Controls.Add(this.appLabel);
            this.panelNavigation.Controls.Add(this.labelLogo);
            this.panelNavigation.Controls.Add(this.pictureboxLogo);
            this.panelNavigation.Controls.Add(this.labelLogoPadding);
            this.panelNavigation.Dock = System.Windows.Forms.DockStyle.Left;
            this.panelNavigation.Location = new System.Drawing.Point(0, 0);
            this.panelNavigation.Margin = new System.Windows.Forms.Padding(2);
            this.panelNavigation.Name = "panelNavigation";
            this.panelNavigation.Size = new System.Drawing.Size(305, 457);
            this.panelNavigation.TabIndex = 0;
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
            // pictureboxLogo
            // 
            this.pictureboxLogo.BackColor = System.Drawing.Color.White;
            this.pictureboxLogo.Image = global::Financial.Tracker.Properties.Resources.pay;
            this.pictureboxLogo.Location = new System.Drawing.Point(27, 20);
            this.pictureboxLogo.Margin = new System.Windows.Forms.Padding(2);
            this.pictureboxLogo.Name = "pictureboxLogo";
            this.pictureboxLogo.Size = new System.Drawing.Size(75, 78);
            this.pictureboxLogo.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureboxLogo.TabIndex = 1;
            this.pictureboxLogo.TabStop = false;
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
            // labelCloseApp
            // 
            this.labelCloseApp.AutoSize = true;
            this.labelCloseApp.Cursor = System.Windows.Forms.Cursors.Hand;
            this.labelCloseApp.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelCloseApp.Location = new System.Drawing.Point(702, 5);
            this.labelCloseApp.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.labelCloseApp.Name = "labelCloseApp";
            this.labelCloseApp.Size = new System.Drawing.Size(20, 19);
            this.labelCloseApp.TabIndex = 1;
            this.labelCloseApp.Text = "X";
            this.labelCloseApp.Click += new System.EventHandler(this.LabelCloseApp_Click);
            // 
            // labelAuth
            // 
            this.labelAuth.AutoSize = true;
            this.labelAuth.Font = new System.Drawing.Font("Verdana", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelAuth.Location = new System.Drawing.Point(432, 95);
            this.labelAuth.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.labelAuth.Name = "labelAuth";
            this.labelAuth.Size = new System.Drawing.Size(171, 29);
            this.labelAuth.TabIndex = 2;
            this.labelAuth.Text = "Авторизация";
            // 
            // labelUser
            // 
            this.labelUser.AutoSize = true;
            this.labelUser.Font = new System.Drawing.Font("Verdana", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelUser.Location = new System.Drawing.Point(346, 158);
            this.labelUser.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.labelUser.Name = "labelUser";
            this.labelUser.Size = new System.Drawing.Size(162, 18);
            this.labelUser.TabIndex = 3;
            this.labelUser.Text = "Имя пользователя";
            // 
            // textboxAuthUser
            // 
            this.textboxAuthUser.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.textboxAuthUser.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textboxAuthUser.Location = new System.Drawing.Point(350, 184);
            this.textboxAuthUser.Margin = new System.Windows.Forms.Padding(2);
            this.textboxAuthUser.Name = "textboxAuthUser";
            this.textboxAuthUser.Size = new System.Drawing.Size(338, 26);
            this.textboxAuthUser.TabIndex = 5;
            // 
            // textboxPassword
            // 
            this.textboxPassword.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.textboxPassword.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textboxPassword.Location = new System.Drawing.Point(350, 250);
            this.textboxPassword.Margin = new System.Windows.Forms.Padding(2);
            this.textboxPassword.Name = "textboxPassword";
            this.textboxPassword.PasswordChar = '*';
            this.textboxPassword.Size = new System.Drawing.Size(338, 26);
            this.textboxPassword.TabIndex = 7;
            this.textboxPassword.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.TextboxPassword_KeyPress);
            // 
            // labelPass
            // 
            this.labelPass.AutoSize = true;
            this.labelPass.Font = new System.Drawing.Font("Verdana", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelPass.Location = new System.Drawing.Point(346, 224);
            this.labelPass.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.labelPass.Name = "labelPass";
            this.labelPass.Size = new System.Drawing.Size(69, 18);
            this.labelPass.TabIndex = 6;
            this.labelPass.Text = "Пароль";
            // 
            // buttonAuth
            // 
            this.buttonAuth.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(49)))), ((int)(((byte)(121)))), ((int)(((byte)(74)))));
            this.buttonAuth.FlatAppearance.BorderSize = 0;
            this.buttonAuth.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(93)))), ((int)(((byte)(160)))), ((int)(((byte)(108)))));
            this.buttonAuth.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(93)))), ((int)(((byte)(160)))), ((int)(((byte)(108)))));
            this.buttonAuth.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonAuth.Font = new System.Drawing.Font("Verdana", 10.125F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonAuth.ForeColor = System.Drawing.Color.White;
            this.buttonAuth.Location = new System.Drawing.Point(350, 322);
            this.buttonAuth.Margin = new System.Windows.Forms.Padding(2);
            this.buttonAuth.Name = "buttonAuth";
            this.buttonAuth.Size = new System.Drawing.Size(336, 42);
            this.buttonAuth.TabIndex = 8;
            this.buttonAuth.Text = "Войти";
            this.buttonAuth.UseVisualStyleBackColor = false;
            this.buttonAuth.Click += new System.EventHandler(this.ButtonAuth_Click);
            // 
            // checkboxShowAuthPassword
            // 
            this.checkboxShowAuthPassword.AutoSize = true;
            this.checkboxShowAuthPassword.Font = new System.Drawing.Font("Verdana", 7.875F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.checkboxShowAuthPassword.Location = new System.Drawing.Point(350, 277);
            this.checkboxShowAuthPassword.Margin = new System.Windows.Forms.Padding(2);
            this.checkboxShowAuthPassword.Name = "checkboxShowAuthPassword";
            this.checkboxShowAuthPassword.Size = new System.Drawing.Size(126, 17);
            this.checkboxShowAuthPassword.TabIndex = 9;
            this.checkboxShowAuthPassword.Text = "Показать пароль";
            this.checkboxShowAuthPassword.UseVisualStyleBackColor = true;
            this.checkboxShowAuthPassword.CheckedChanged += new System.EventHandler(this.CheckboxShowAuthPassword_CheckedChanged);
            // 
            // labelCreateAccount
            // 
            this.labelCreateAccount.AutoSize = true;
            this.labelCreateAccount.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.875F, System.Drawing.FontStyle.Underline, System.Drawing.GraphicsUnit.Point, ((byte)(254)));
            this.labelCreateAccount.Location = new System.Drawing.Point(574, 278);
            this.labelCreateAccount.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.labelCreateAccount.Name = "labelCreateAccount";
            this.labelCreateAccount.Size = new System.Drawing.Size(116, 13);
            this.labelCreateAccount.TabIndex = 10;
            this.labelCreateAccount.Text = " У меня нет аккаунта";
            this.labelCreateAccount.Click += new System.EventHandler(this.LabelCreateAccount_Click);
            this.labelCreateAccount.MouseLeave += new System.EventHandler(this.CreateAccountLabel_MouseLeave);
            this.labelCreateAccount.MouseHover += new System.EventHandler(this.CreateAccountLabel_MouseHover);
            // 
            // AuthForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(727, 457);
            this.Controls.Add(this.labelCreateAccount);
            this.Controls.Add(this.checkboxShowAuthPassword);
            this.Controls.Add(this.buttonAuth);
            this.Controls.Add(this.textboxPassword);
            this.Controls.Add(this.labelPass);
            this.Controls.Add(this.textboxAuthUser);
            this.Controls.Add(this.labelUser);
            this.Controls.Add(this.labelAuth);
            this.Controls.Add(this.labelCloseApp);
            this.Controls.Add(this.panelNavigation);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "AuthForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Форма авторизации";
            this.panelNavigation.ResumeLayout(false);
            this.panelNavigation.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureboxLogo)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel panelNavigation;
        private System.Windows.Forms.Label labelLogo;
        private System.Windows.Forms.Label labelCloseApp;
        private System.Windows.Forms.PictureBox pictureboxLogo;
        private System.Windows.Forms.Label labelAuth;
        private System.Windows.Forms.Label labelUser;
        private System.Windows.Forms.TextBox textboxAuthUser;
        private System.Windows.Forms.TextBox textboxPassword;
        private System.Windows.Forms.Label labelPass;
        private System.Windows.Forms.Button buttonAuth;
        private System.Windows.Forms.CheckBox checkboxShowAuthPassword;
        private System.Windows.Forms.Label labelLogoPadding;
        private System.Windows.Forms.Label appLabel;
        private System.Windows.Forms.Label labelCreateAccount;
    }
}

