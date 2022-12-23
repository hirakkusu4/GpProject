using System;
using System.Windows.Forms;
using System.Data.SQLite;

namespace GameProgrammingFormProject
{
    public partial class Login_Page : Form
    {
        public Login_Page()
        {
            InitializeComponent();
        }

        private void LoginButtonClick(object sender, EventArgs e)
        {
            // 会員IDが入力されていない場合
            if (loginIdTextBox.Text == string.Empty)
            {
                // ID未入力を伝えるダイアログ表示
                DialogResult Null = MessageBox.Show("会員IDを入力してください。", "エラー",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            // パスワードが入力されていない場合 
            else if (loginPassTextBox.Text == string.Empty)
            {
                DialogResult Null = MessageBox.Show("パスワードを入力してください。", "エラー",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                using (SQLiteConnection con = new SQLiteConnection("Data Source=member.db"))
                {

                }
            }
            //SearchPage search = new SearchPage();
            //search.Show();
        }
    }
}
