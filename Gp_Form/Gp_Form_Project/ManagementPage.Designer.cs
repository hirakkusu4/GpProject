
namespace GameProgrammingFormProject
{
    partial class ManagementPage
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
            this.secessionButton = new System.Windows.Forms.Button();
            this.changeButton = new System.Windows.Forms.Button();
            this.searchButton = new System.Windows.Forms.Button();
            this.logoutButton = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // secessionButton
            // 
            this.secessionButton.Location = new System.Drawing.Point(335, 245);
            this.secessionButton.Name = "secessionButton";
            this.secessionButton.Size = new System.Drawing.Size(123, 31);
            this.secessionButton.TabIndex = 7;
            this.secessionButton.Text = "退会";
            this.secessionButton.UseVisualStyleBackColor = true;
            this.secessionButton.Click += new System.EventHandler(this.SecessionBottun_Click);
            // 
            // changeButton
            // 
            this.changeButton.Location = new System.Drawing.Point(335, 157);
            this.changeButton.Name = "changeButton";
            this.changeButton.Size = new System.Drawing.Size(123, 31);
            this.changeButton.TabIndex = 5;
            this.changeButton.Text = "会員情報変更";
            this.changeButton.UseVisualStyleBackColor = true;
            this.changeButton.Click += new System.EventHandler(this.ChangeButton_Click);
            // 
            // searchButton
            // 
            this.searchButton.Location = new System.Drawing.Point(335, 65);
            this.searchButton.Name = "searchButton";
            this.searchButton.Size = new System.Drawing.Size(123, 31);
            this.searchButton.TabIndex = 4;
            this.searchButton.Text = "会員情報検索";
            this.searchButton.UseVisualStyleBackColor = true;
            this.searchButton.Click += new System.EventHandler(this.SearchButton_Click);
            // 
            // logoutButton
            // 
            this.logoutButton.Location = new System.Drawing.Point(335, 335);
            this.logoutButton.Name = "logoutButton";
            this.logoutButton.Size = new System.Drawing.Size(123, 31);
            this.logoutButton.TabIndex = 8;
            this.logoutButton.Text = "ログアウト";
            this.logoutButton.UseVisualStyleBackColor = true;
            this.logoutButton.Click += new System.EventHandler(this.LogoutButton_Click);
            // 
            // ManagementPage
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.logoutButton);
            this.Controls.Add(this.secessionButton);
            this.Controls.Add(this.changeButton);
            this.Controls.Add(this.searchButton);
            this.Name = "ManagementPage";
            this.Text = "会員情報管理画面";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button secessionButton;
        private System.Windows.Forms.Button changeButton;
        private System.Windows.Forms.Button searchButton;
        private System.Windows.Forms.Button logoutButton;
    }
}