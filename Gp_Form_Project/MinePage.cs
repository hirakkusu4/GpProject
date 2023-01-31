using System;
using System.Data;
using System.Windows.Forms;
using System.Data.SQLite;

namespace GameProgrammingFormProject
{
    public partial class MinePage : Form
    {
        public MinePage()
        {
            // 会員テーブル作成SQL
            const string memberSQL = "CREATE TABLE IF NOT EXISTS m_member(memberId INTEGER PRIMARY KEY AUTOINCREMENT," +
                " nameK TEXT, nameH TEXT, postal INTEGER, address TEXT, telephone TEXT, gender TEXT, birthDate INTEGER, " +
                "mailAddress TEXT, membertypeCode INTEGER, password TEXT)";
            // 会員種別テーブル作成SQL
            const string membertypeSQL = "CREATE TABLE IF NOT EXISTS m_membertype(membertypeCode INTEGER PRIMARY KEY AUTOINCREMENT, " +
                        "membertypeName TEXT, monthly INTEGER)";
            // 最初の一回目か判定するSQL
            const string decisionSQL = "SELECT * FROM m_membertype ";
            // 会員種別追加SQL
            const string addSQL = "INSERT into m_membertype (membertypeCode,membertypeName,monthly)" +
                                " values (null, '一般会員', 1000),(null, '特別会員', 2000);";
            InitializeComponent();
            // フォームを中央に配置
            this.StartPosition = FormStartPosition.CenterScreen;
            // テーブル作成
            using (SQLiteConnection cleate = new SQLiteConnection("Data Source=member.db"))
            {
                cleate.Open();
                using (SQLiteCommand com = cleate.CreateCommand())
                {
                    // 会員テーブル作成
                    com.CommandText = memberSQL;
                    // 実行
                    com.ExecuteNonQuery();
                    // 会員種別テーブル作成
                    com.CommandText = membertypeSQL;
                    // 実行
                    com.ExecuteNonQuery();
                    // データテーブル作成
                    DataTable dataTable = new DataTable();
                    // SQLの実行
                    SQLiteDataAdapter adapter = new SQLiteDataAdapter(decisionSQL, cleate);
                    // 結果の取得
                    adapter.Fill(dataTable);
                    // 最初だけ通る
                    if (dataTable.Rows.Count == 0)
                    {
                        using (SQLiteTransaction trans = cleate.BeginTransaction())
                        {
                            // データ追加
                            com.CommandText = addSQL;
                            // 実行
                            com.ExecuteNonQuery();
                            // コミット
                            trans.Commit();
                        }
                    }                   
                }
                cleate.Close();
            }
        }
        /// <summary>
        /// 登録画面へ遷移
        /// </summary>
        /// <param name="sender">登録ボタン</param>
        /// <param name="e">登録ボタンを押したとき</param>
        private void RegisterButton_Click(object sender, EventArgs e)
        {
            // 登録ページへ遷移
            Program.End.MainForm = new RegisterPage();
            Program.End.MainForm.Show();
            // メインメニュー非表示
            this.Close();
        }
        /// <summary>
        /// ログイン画面へ遷移
        /// </summary>
        /// <param name="sender">ログイン画面へボタン</param>
        /// <param name="e">ログイン画面へボタンを押したとき</param>
        private void LoginButton_Click(object sender, EventArgs e)
        {
            // ログインページへ遷移
            Program.End.MainForm = new LoginPage();
            Program.End.MainForm.Show();
            // メインメニュー非表示
            this.Close();
        }
        /// <summary>
        /// 終了する
        /// </summary>
        /// <param name="sender">終了ボタン</param>
        /// <param name="e">終了ボタンを押したとき</param>
        private void EndButton_Click(object sender, EventArgs e)
        {
            DialogResult check = MessageBox.Show("システムを終了しますか？", "終了確認",
                        MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (check == DialogResult.Yes) // はい　を押した場合
            {
                // 終了
                this.Close();
            }
        }
    }
}