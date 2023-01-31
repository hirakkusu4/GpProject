using System;
using System.Data;
using System.Windows.Forms;
using System.Data.SQLite;

namespace GameProgrammingFormProject
{
    public partial class LoginPage : Form
    {
        // ログイン用SQL
        const string loginSQL = "SELECT * FROM m_member WHERE memberId =";
        public LoginPage()
        {
            InitializeComponent();
            // フォームを中央に配置
            this.StartPosition = FormStartPosition.CenterScreen;
            // 入力制限(数字のみ)
            loginIdTextBox.KeyPress += new KeyPressEventHandler(NumbersKeyPress);
        }
        /// <summary>
        /// 会員IDでログイン
        /// </summary>
        /// <param name="sender">ログインボタン</param>
        /// <param name="e">ログインするとき</param>
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
                // パスワード未入力を伝えるダイアログ表示
                DialogResult Null = MessageBox.Show("パスワードを入力してください。", "エラー",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                using (SQLiteConnection con = new SQLiteConnection("Data Source=member.db"))
                {
                    // 入力されたIDをログインIDに設定
                    Properties.Settings.Default.loginId = int.Parse(loginIdTextBox.Text);
                    // データテーブル作成
                    DataTable dataTable = new DataTable();
                    // SQLの実行
                    SQLiteDataAdapter adapter = new SQLiteDataAdapter(loginSQL + Properties.Settings.Default.loginId, con);
                    // 結果の取得
                    adapter.Fill(dataTable);
                    // 詮索結果がなかった場合
                    if (dataTable.Rows.Count == 0)
                    {
                        // もう一度入力を促すダイアログ表示
                        DialogResult notId = MessageBox.Show("会員IDが見つかりませんでした。もう一度入力してください。",
                            "エラー", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    else
                    {
                        // 入力したパスワードが合っていた場合
                        if (loginPassTextBox.Text == dataTable.Rows[0]["password"].ToString())
                        {
                            // 会員情報管理画面を表示
                            Program.End.MainForm = new ManagementPage();
                            Program.End.MainForm.Show();
                            // ログインページを閉じる
                            this.Close();
                        }
                        else
                        {
                            // パスワードが間違えていた場合のダイアログ表示
                            DialogResult Null = MessageBox.Show("パスワードが間違えています。", "エラー",
                                MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                }
            }
        }
        /// <summary>
        /// 入力したパスワードの表示、非表示を切り替える
        /// </summary>
        /// <param name="sender">表示ボタン</param>
        /// <param name="e">パスワードを表示するとき</param>
        private void PassShowButton_Click(object sender, EventArgs e)
        {
            // パスワードの表示、非表示を切り替える
            loginPassTextBox.UseSystemPasswordChar = !loginPassTextBox.UseSystemPasswordChar;
            if (passShowButton.Text == "表示")
            {
                // 表示から非表示
                passShowButton.Text = "非表示";
            }
            else
            {
                // 非表示から表示
                passShowButton.Text = "表示";
            }
        }
        /// <summary>
        /// ID入力欄の入力制限
        /// </summary>
        /// <param name="sender">ログインするIDの入力欄</param>
        /// <param name="e">IDを入力するとき</param>
        private void NumbersKeyPress(object sender, KeyPressEventArgs e)
        {
            //バックスペースは有効（Deleteも有効）
            if (e.KeyChar == '\b')
            {
                return;
            }
            //数0～9以外はキャンセル
            if ((e.KeyChar < '0' || '9' < e.KeyChar))
            {
                e.Handled = true;
            }
        }
        /// <summary>
        /// メインページへ戻る
        /// </summary>
        /// <param name="sender">メインページへボタン</param>
        /// <param name="e">メインページへボタンを押したとき</param>
        private void BackButton_Click(object sender, EventArgs e)
        {
            // メインメニュー画面へ遷移
            Program.End.MainForm = new MinePage();
            Program.End.MainForm.Show();
            // このページを閉じる
            this.Close();
        }
    }
}