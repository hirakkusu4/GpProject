using System;
using System.Windows.Forms;

namespace GameProgrammingFormProject
{
    public partial class ManagementPage : Form
    {   
        public ManagementPage()
        {
            InitializeComponent();
            // フォームを中央に配置
            this.StartPosition = FormStartPosition.CenterScreen;
        }
        /// <summary>
        /// 検索画面へ遷移
        /// </summary>
        /// <param name="sender">会員情報検索ボタン</param>
        /// <param name="e">会員情報検索ボタンを押したとき</param>
        private void SearchButton_Click(object sender, EventArgs e)
        {
            // 会員情報検索画面を表示
            Program.End.MainForm = new SearchPage();
            Program.End.MainForm.Show();
            // 会員情報管理画面を閉じる
            this.Close();
        }
        /// <summary>
        /// 変更画面へ遷移
        /// </summary>
        /// <param name="sender">会員情報変更ボタン</param>
        /// <param name="e">会員情報変更ボタンを押したとき</param>
        private void ChangeButton_Click(object sender, EventArgs e)
        {
            // 会員情報変更画面を表示
            Program.End.MainForm = new ChangePage();
            Program.End.MainForm.Show();
            // 会員情報管理画面を閉じる
            this.Close();
        }
        /// <summary>
        /// 退会画面へ遷移
        /// </summary>
        /// <param name="sender">退会ボタン</param>
        /// <param name="e">退会ボタンを押したとき</param>
        private void SecessionBottun_Click(object sender, EventArgs e)
        {
            // 退会画面を表示
            Program.End.MainForm = new SecessionPage();
            Program.End.MainForm.Show();
            // 会員情報管理画面を閉じる
            this.Close();
        }
        /// <summary>
        /// メインページへ遷移
        /// </summary>
        /// <param name="sender">ログアウトボタン</param>
        /// <param name="e">ログアウトボタンを押したとき</param>
        private void LogoutButton_Click(object sender, EventArgs e)
        {
            // ログアウト確認のダイアログ表示
            DialogResult check = MessageBox.Show("ログアウトし、メインメニュー画面へ戻ります。" +
                "よろしいですか？", "入力内容確認",
                MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (check == DialogResult.Yes) // はい　を押した場合
            {
                // メインメニューへ遷移
                Program.End.MainForm = new MinePage();
                Program.End.MainForm.Show();
                // このページを閉じる
                this.Close();
            }
        }
    }
}