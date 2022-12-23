
namespace GameProgrammingFormProject
{
    partial class Login_Page
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
            this.login_memberID_label = new System.Windows.Forms.Label();
            this.login_password_label = new System.Windows.Forms.Label();
            this.loginIdTextBox = new System.Windows.Forms.TextBox();
            this.loginPassTextBox = new System.Windows.Forms.TextBox();
            this.loginButton = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // login_memberID_label
            // 
            this.login_memberID_label.AutoSize = true;
            this.login_memberID_label.Location = new System.Drawing.Point(198, 77);
            this.login_memberID_label.Name = "login_memberID_label";
            this.login_memberID_label.Size = new System.Drawing.Size(51, 15);
            this.login_memberID_label.TabIndex = 0;
            this.login_memberID_label.Text = "会員ID";
            // 
            // login_password_label
            // 
            this.login_password_label.AutoSize = true;
            this.login_password_label.Location = new System.Drawing.Point(198, 149);
            this.login_password_label.Name = "login_password_label";
            this.login_password_label.Size = new System.Drawing.Size(64, 15);
            this.login_password_label.TabIndex = 1;
            this.login_password_label.Text = "パスワード";
            // 
            // loginIdTextBox
            // 
            this.loginIdTextBox.Location = new System.Drawing.Point(309, 74);
            this.loginIdTextBox.Name = "loginIdTextBox";
            this.loginIdTextBox.Size = new System.Drawing.Size(211, 22);
            this.loginIdTextBox.TabIndex = 4;
            // 
            // loginPassTextBox
            // 
            this.loginPassTextBox.Location = new System.Drawing.Point(309, 146);
            this.loginPassTextBox.Name = "loginPassTextBox";
            this.loginPassTextBox.Size = new System.Drawing.Size(211, 22);
            this.loginPassTextBox.TabIndex = 3;
            // 
            // loginButton
            // 
            this.loginButton.Location = new System.Drawing.Point(343, 224);
            this.loginButton.Name = "loginButton";
            this.loginButton.Size = new System.Drawing.Size(75, 23);
            this.loginButton.TabIndex = 5;
            this.loginButton.Text = "ログイン";
            this.loginButton.UseVisualStyleBackColor = true;
            this.loginButton.Click += new System.EventHandler(this.LoginButtonClick);
            // 
            // Login_Page
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.loginButton);
            this.Controls.Add(this.loginPassTextBox);
            this.Controls.Add(this.loginIdTextBox);
            this.Controls.Add(this.login_password_label);
            this.Controls.Add(this.login_memberID_label);
            this.Name = "Login_Page";
            this.Text = "ログインページ";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label login_memberID_label;
        private System.Windows.Forms.Label login_password_label;
        private System.Windows.Forms.TextBox loginIdTextBox;
        private System.Windows.Forms.TextBox loginPassTextBox;
        private System.Windows.Forms.Button loginButton;
    }
}