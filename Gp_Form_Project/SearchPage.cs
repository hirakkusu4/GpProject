using System;
using System.Data;
using System.Windows.Forms;
using System.Data.SQLite;

namespace GameProgrammingFormProject
{
    public partial class SearchPage : Form
    {
        // 検索用SQL
        const string searchSQL = "SELECT * FROM m_member WHERE memberId = ";
        public SearchPage()
        {
            InitializeComponent();
            // フォームを中央に配置
            this.StartPosition = FormStartPosition.CenterScreen;
            // 検索結果表示欄の入力不可
            textBoxShowNameK.KeyPress += new KeyPressEventHandler(ShowTextBoxKeyPress);
            textBoxShowNameH.KeyPress += new KeyPressEventHandler(ShowTextBoxKeyPress);
            textBoxShowPostal.KeyPress += new KeyPressEventHandler(ShowTextBoxKeyPress);
            textBoxShowAddress.KeyPress += new KeyPressEventHandler(ShowTextBoxKeyPress);
            textBoxShowTelephone.KeyPress += new KeyPressEventHandler(ShowTextBoxKeyPress);
            textBoxShowGender.KeyPress += new KeyPressEventHandler(ShowTextBoxKeyPress);
            textBoxShowBirth.KeyPress += new KeyPressEventHandler(ShowTextBoxKeyPress);
            textBoxShowMailAddress.KeyPress += new KeyPressEventHandler(ShowTextBoxKeyPress);
            textBoxShowMemberType.KeyPress += new KeyPressEventHandler(ShowTextBoxKeyPress);
            textBoxShowPassword.KeyPress += new KeyPressEventHandler(ShowTextBoxKeyPress);
        }
        /// <summary>
        /// 会員IDで会員情報を検索
        /// </summary>
        /// <param name="sender">検索ボタン</param>
        /// <param name="e">検索するとき</param>
        private void SearchButtonClick(object sender, EventArgs e)
        {
            using (SQLiteConnection search = new SQLiteConnection("Data Source=member.db"))
            {
                // データテーブル作成
                DataTable dataTable = new DataTable();
                // SQLの実行
                SQLiteDataAdapter adapter = new SQLiteDataAdapter(searchSQL + Properties.Settings.Default.loginId, search);
                // 結果の取得
                adapter.Fill(dataTable);
                // 詮索結果がなかった場合
                if (dataTable.Rows.Count == 0)
                {
                    // もう一度入力を促すダイアログ表示
                    DialogResult = MessageBox.Show("会員IDが見つかりませんでした。もう一度入力してください。",
                        "エラー", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else
                {
                    // テキストボックスに各データを入れる
                    // 名前(漢字)
                    textBoxShowNameK.Text = dataTable.Rows[0]["nameK"].ToString();
                    // 名前(かな)
                    textBoxShowNameH.Text = dataTable.Rows[0]["nameH"].ToString();
                    // 郵便番号
                    textBoxShowPostal.Text = dataTable.Rows[0]["postal"].ToString();
                    // 住所
                    textBoxShowAddress.Text = dataTable.Rows[0]["address"].ToString();
                    // 電話番号
                    textBoxShowTelephone.Text = dataTable.Rows[0]["telephone"].ToString();
                    // 性別
                    textBoxShowGender.Text = dataTable.Rows[0]["gender"].ToString();
                    // 生年月日
                    textBoxShowBirth.Text = dataTable.Rows[0]["birthDate"].ToString();
                    // メールアドレス
                    textBoxShowMailAddress.Text = dataTable.Rows[0]["mailAddress"].ToString();
                    // 会員種別
                    if (int.Parse(dataTable.Rows[0]["membertypeCode"].ToString()) == 1)
                    {
                        textBoxShowMemberType.Text = "一般会員";
                    }
                    else
                    {
                        textBoxShowMemberType.Text = "特別会員";
                    }
                    // パスワード
                    textBoxShowPassword.Text = dataTable.Rows[0]["password"].ToString();
                }
            }
        }
        /// <summary>
        /// 結果表示欄の入力不可
        /// </summary>
        /// <param name="sender">結果を表示するテキストボックス</param>
        /// <param name="e">結果を表示するとき</param>
        private void ShowTextBoxKeyPress(object sender, KeyPressEventArgs e)
        {
            // 入力を無効にする
            e.Handled = true;
        }
        /// <summary>
        /// ID入力欄の入力制限
        /// </summary>
        /// <param name="sender">検索するIDの入力欄</param>
        /// <param name="e">IDを入力するとき</param>
        private void SearchTextBoxKeyPress(object sender, KeyPressEventArgs e)
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
        /// 管理画面へ戻る
        /// </summary>
        /// <param name="sender">管理画面へボタン</param>
        /// <param name="e">管理画面へボタンを押したとき</param>
        private void BackButtonClick(object sender, EventArgs e)
        {
            // 会員情報管理画面を表示
            Program.End.MainForm = new ManagementPage();
            Program.End.MainForm.Show();
            // 検索ページを閉じる
            this.Close();
        }
    }
}