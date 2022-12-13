
namespace Gp_Form_Project
{
    partial class secession_page
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
            this.components = new System.ComponentModel.Container();
            this.delete_label = new System.Windows.Forms.Label();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.delete_textBox = new System.Windows.Forms.TextBox();
            this.delete_button = new System.Windows.Forms.Button();
            this.return_button = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // delete_label
            // 
            this.delete_label.AutoSize = true;
            this.delete_label.Location = new System.Drawing.Point(245, 160);
            this.delete_label.Name = "delete_label";
            this.delete_label.Size = new System.Drawing.Size(51, 15);
            this.delete_label.TabIndex = 0;
            this.delete_label.Text = "会員ID";
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(61, 4);
            // 
            // delete_textBox
            // 
            this.delete_textBox.Location = new System.Drawing.Point(314, 157);
            this.delete_textBox.Name = "delete_textBox";
            this.delete_textBox.Size = new System.Drawing.Size(143, 22);
            this.delete_textBox.TabIndex = 2;
            // 
            // delete_button
            // 
            this.delete_button.Location = new System.Drawing.Point(474, 156);
            this.delete_button.Name = "delete_button";
            this.delete_button.Size = new System.Drawing.Size(75, 23);
            this.delete_button.TabIndex = 4;
            this.delete_button.Text = "退会";
            this.delete_button.UseVisualStyleBackColor = true;
            this.delete_button.Click += new System.EventHandler(this.delete_button_Click);
            // 
            // return_button
            // 
            this.return_button.Location = new System.Drawing.Point(713, 415);
            this.return_button.Name = "return_button";
            this.return_button.Size = new System.Drawing.Size(75, 23);
            this.return_button.TabIndex = 5;
            this.return_button.Text = "戻る";
            this.return_button.UseVisualStyleBackColor = true;
            // 
            // secession_page
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.return_button);
            this.Controls.Add(this.delete_button);
            this.Controls.Add(this.delete_textBox);
            this.Controls.Add(this.delete_label);
            this.Name = "secession_page";
            this.Text = "退会ページ";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label delete_label;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.TextBox delete_textBox;
        private System.Windows.Forms.Button delete_button;
        private System.Windows.Forms.Button return_button;
    }
}