
namespace GameProgrammingFormProject
{
    partial class Secession_Page
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
            this.deleteLabel = new System.Windows.Forms.Label();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.deleteTextBox = new System.Windows.Forms.TextBox();
            this.deleteButton = new System.Windows.Forms.Button();
            this.return_button = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // deleteLabel
            // 
            this.deleteLabel.AutoSize = true;
            this.deleteLabel.Location = new System.Drawing.Point(245, 160);
            this.deleteLabel.Name = "deleteLabel";
            this.deleteLabel.Size = new System.Drawing.Size(51, 15);
            this.deleteLabel.TabIndex = 0;
            this.deleteLabel.Text = "会員ID";
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(61, 4);
            // 
            // deleteTextBox
            // 
            this.deleteTextBox.Location = new System.Drawing.Point(314, 157);
            this.deleteTextBox.Name = "deleteTextBox";
            this.deleteTextBox.Size = new System.Drawing.Size(143, 22);
            this.deleteTextBox.TabIndex = 2;
            // 
            // deleteButton
            // 
            this.deleteButton.Location = new System.Drawing.Point(474, 156);
            this.deleteButton.Name = "deleteButton";
            this.deleteButton.Size = new System.Drawing.Size(75, 23);
            this.deleteButton.TabIndex = 4;
            this.deleteButton.Text = "退会";
            this.deleteButton.UseVisualStyleBackColor = true;
            this.deleteButton.Click += new System.EventHandler(this.delete_button_Click);
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
            // Secession_page
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.return_button);
            this.Controls.Add(this.deleteButton);
            this.Controls.Add(this.deleteTextBox);
            this.Controls.Add(this.deleteLabel);
            this.Name = "Secession_page";
            this.Text = "退会ページ";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label deleteLabel;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.TextBox deleteTextBox;
        private System.Windows.Forms.Button deleteButton;
        private System.Windows.Forms.Button return_button;
    }
}