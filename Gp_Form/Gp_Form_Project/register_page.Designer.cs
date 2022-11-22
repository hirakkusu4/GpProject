
namespace Gp_Form_Project
{
    partial class register_page
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
            this.name_k_textBox = new System.Windows.Forms.TextBox();
            this.name_kanzi_label = new System.Windows.Forms.Label();
            this.name_h_textBox = new System.Windows.Forms.TextBox();
            this.name_kana_label = new System.Windows.Forms.Label();
            this.password_label = new System.Windows.Forms.Label();
            this.password_textBox = new System.Windows.Forms.TextBox();
            this.decision_button = new System.Windows.Forms.Button();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.button1 = new System.Windows.Forms.Button();
            this.gender_label = new System.Windows.Forms.Label();
            this.gender_comboBox = new System.Windows.Forms.ComboBox();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // name_k_textBox
            // 
            this.name_k_textBox.Location = new System.Drawing.Point(131, 30);
            this.name_k_textBox.Name = "name_k_textBox";
            this.name_k_textBox.Size = new System.Drawing.Size(183, 22);
            this.name_k_textBox.TabIndex = 3;
            // 
            // name_kanzi_label
            // 
            this.name_kanzi_label.AutoSize = true;
            this.name_kanzi_label.ForeColor = System.Drawing.SystemColors.ControlText;
            this.name_kanzi_label.Location = new System.Drawing.Point(30, 33);
            this.name_kanzi_label.Name = "name_kanzi_label";
            this.name_kanzi_label.Size = new System.Drawing.Size(95, 15);
            this.name_kanzi_label.TabIndex = 4;
            this.name_kanzi_label.Text = "お名前（漢字）";
            // 
            // name_h_textBox
            // 
            this.name_h_textBox.Location = new System.Drawing.Point(131, 82);
            this.name_h_textBox.Name = "name_h_textBox";
            this.name_h_textBox.Size = new System.Drawing.Size(183, 22);
            this.name_h_textBox.TabIndex = 6;
            // 
            // name_kana_label
            // 
            this.name_kana_label.AutoSize = true;
            this.name_kana_label.ForeColor = System.Drawing.SystemColors.ControlText;
            this.name_kana_label.Location = new System.Drawing.Point(30, 85);
            this.name_kana_label.Name = "name_kana_label";
            this.name_kana_label.Size = new System.Drawing.Size(90, 15);
            this.name_kana_label.TabIndex = 7;
            this.name_kana_label.Text = "お名前（かな）";
            // 
            // password_label
            // 
            this.password_label.AutoSize = true;
            this.password_label.ForeColor = System.Drawing.SystemColors.ControlText;
            this.password_label.Location = new System.Drawing.Point(36, 193);
            this.password_label.Name = "password_label";
            this.password_label.Size = new System.Drawing.Size(64, 15);
            this.password_label.TabIndex = 9;
            this.password_label.Text = "パスワード";
            // 
            // password_textBox
            // 
            this.password_textBox.Location = new System.Drawing.Point(131, 190);
            this.password_textBox.Name = "password_textBox";
            this.password_textBox.Size = new System.Drawing.Size(183, 22);
            this.password_textBox.TabIndex = 10;
            // 
            // decision_button
            // 
            this.decision_button.Location = new System.Drawing.Point(131, 398);
            this.decision_button.Name = "decision_button";
            this.decision_button.Size = new System.Drawing.Size(75, 23);
            this.decision_button.TabIndex = 12;
            this.decision_button.Text = "確定";
            this.decision_button.UseVisualStyleBackColor = true;
            this.decision_button.Click += new System.EventHandler(this.decision_button_Click);
            // 
            // dataGridView1
            // 
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(400, 30);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.RowHeadersWidth = 51;
            this.dataGridView1.RowTemplate.Height = 24;
            this.dataGridView1.Size = new System.Drawing.Size(388, 391);
            this.dataGridView1.TabIndex = 13;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(319, 12);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 14;
            this.button1.Text = "表示";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // gender_label
            // 
            this.gender_label.AutoSize = true;
            this.gender_label.Location = new System.Drawing.Point(53, 136);
            this.gender_label.Name = "gender_label";
            this.gender_label.Size = new System.Drawing.Size(37, 15);
            this.gender_label.TabIndex = 15;
            this.gender_label.Text = "性別";
            // 
            // gender_comboBox
            // 
            this.gender_comboBox.FormattingEnabled = true;
            this.gender_comboBox.Items.AddRange(new object[] {
            "男性",
            "女性"});
            this.gender_comboBox.Location = new System.Drawing.Point(131, 136);
            this.gender_comboBox.Name = "gender_comboBox";
            this.gender_comboBox.Size = new System.Drawing.Size(121, 23);
            this.gender_comboBox.TabIndex = 16;
            // 
            // register_page
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.gender_comboBox);
            this.Controls.Add(this.gender_label);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.decision_button);
            this.Controls.Add(this.password_textBox);
            this.Controls.Add(this.password_label);
            this.Controls.Add(this.name_kana_label);
            this.Controls.Add(this.name_h_textBox);
            this.Controls.Add(this.name_kanzi_label);
            this.Controls.Add(this.name_k_textBox);
            this.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.Name = "register_page";
            this.Text = "新規登録ページ";
            this.TransparencyKey = System.Drawing.Color.Black;
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.TextBox name_k_textBox;
        private System.Windows.Forms.Label name_kanzi_label;
        private System.Windows.Forms.TextBox name_h_textBox;
        private System.Windows.Forms.Label name_kana_label;
        private System.Windows.Forms.Label password_label;
        private System.Windows.Forms.TextBox password_textBox;
        private System.Windows.Forms.Button decision_button;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Label gender_label;
        private System.Windows.Forms.ComboBox gender_comboBox;
    }
}