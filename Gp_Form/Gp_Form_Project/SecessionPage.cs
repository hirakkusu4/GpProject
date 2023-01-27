using System;
using System.Data;
using System.Windows.Forms;
using System.Data.SQLite;

namespace GameProgrammingFormProject
{
    public partial class SecessionPage : Form
    {
        // パスワードチェック用SQL
        const string passCheckSQL = "SELECT * FROM m_member WHERE memberId = ";
        // 会員情報削除SQL
        const string deleteSQL = "DELETE FROM m_member WHERE memberid = ";
        public SecessionPage()
        {
            InitializeComponent();
            // フォームを中央に配置
            this.StartPosition = FormStartPosition.CenterScreen;
        }
        /// <summary>
        /// 退会
        /// </summary>
        /// <param name="sender">退会ボタン</param>
        /// <param name="e">退会ボタンを押したとき</param>
        private void DeleteButton_Click(object sender, EventArgs e)
        {
            // パスワードが入力されていない場合 
            if (textBoxDeletePass.Text == string.Empty)
            {
                // パスワード未入力のダイアログ表示
                DialogResult Null = MessageBox.Show("パスワードを入力してください。", "エラー",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                // 入力内容確認のダイアログ表示
                DialogResult check = MessageBox.Show("本当に退会してもよろしいでしょうか？", "退会確認",
                    MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                // はい　を押した場合
                if (check == DialogResult.Yes)
                {
                    using (SQLiteConnection passCheck = new SQLiteConnection("Data Source=member.db"))
                    {
                        // データテーブル作成
                        DataTable dataTable = new DataTable();
                        // SQLの実行
                        SQLiteDataAdapter adapter = new SQLiteDataAdapter(passCheckSQL +
                            Properties.Settings.Default.loginId, passCheck);
                        // 結果の取得
                        adapter.Fill(dataTable);
                        // パスワードが合っていたら
                        if (textBoxDeletePass.Text == dataTable.Rows[0]["password"].ToString())
                        {
                            using (SQLiteConnection delete = new SQLiteConnection("Data Source=member.db"))
                            {
                                delete.Open();
                                using (SQLiteTransaction trans = delete.BeginTransaction())
                                {
                                    SQLiteCommand cmd = delete.CreateCommand();
                                    // 会員情報の削除
                                    cmd.CommandText = deleteSQL + Properties.Settings.Default.loginId;
                                    // 実行
                                    cmd.ExecuteNonQuery();
                                    // コミット
                                    trans.Commit();
                                }
                                delete.Close();
                            }
                            // 会員情報管理画面を表示
                            Program.End.MainForm = new MinePage();
                            Program.End.MainForm.Show();
                            // 検索ページを閉じる
                            this.Close();
                        }
                        else
                        {
                            // パスワード確認のダイアログ表示
                            DialogResult Null = MessageBox.Show("パスワードが間違えています。", "エラー",
                                MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                }
            }   
        }
        /// <summary>
        /// 管理画面へ戻る
        /// </summary>
        /// <param name="sender">管理画面へボタン</param>
        /// <param name="e">管理画面へボタンを押したとき</param>
        private void BackButton_Click(object sender, EventArgs e)
        {
            // メインメニューを表示
            Program.End.MainForm = new MinePage();
            Program.End.MainForm.Show();
            // 検索ページを閉じる
            this.Close();
        }
    }
}