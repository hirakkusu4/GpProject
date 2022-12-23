using System;
using System.Data;
using System.Windows.Forms;
using System.Data.SQLite;

namespace GameProgrammingFormProject
{
    public partial class SearchPage : Form
    {
        /// <summary>
        /// 会員IDで会員情報を検索
        /// </summary>
        /// <param name="sender">検索ボタン</param>
        /// <param name="e">検索するとき</param>
        private void SearchButtonClick(object sender, EventArgs e)
        {
            // 会員IDが入力されていない場合
            if (searchTextBox.Text == String.Empty)
            {
                // 未入力を伝えるダイアログ表示
                DialogResult Null = MessageBox.Show("会員IDを入力してください。", "エラー",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                using (SQLiteConnection con = new SQLiteConnection("Data Source=member.db"))
                {
                    // 入力されたデータをintに変換
                    int searchId = int.Parse(searchTextBox.Text);
                    // データテーブル作成
                    DataTable dataTable = new DataTable();
                    // SQLの実行
                    SQLiteDataAdapter adapter = new SQLiteDataAdapter($"SELECT * FROM m_member WHERE memberId = {searchId}", con);
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
                        // テキストボックスに各データを入れる
                        textBoxShowNameK.Text = dataTable.Rows[0]["nameK"].ToString(); // 名前(漢字)
                        textBoxShowNameH.Text = dataTable.Rows[0]["nameH"].ToString(); // 名前(かな)
                        textBoxShowPostal.Text = dataTable.Rows[0]["postal"].ToString(); // 郵便番号
                        textBoxShowAddres.Text = dataTable.Rows[0]["address"].ToString(); // 住所
                        textBoxShowTelephone.Text = dataTable.Rows[0]["telephone"].ToString(); // 電話番号
                        textBoxShowGender.Text = dataTable.Rows[0]["gender"].ToString(); // 性別
                        textBoxShowBirth.Text = dataTable.Rows[0]["birthDate"].ToString(); // 生年月日
                        textBoxShowMialAddress.Text = dataTable.Rows[0]["mailAddress"].ToString(); // メールアドレス
                        textBoxShowMemberType.Text = dataTable.Rows[0]["membertypeCode"].ToString(); // 会員種別
                        textBoxShowPassword.Text = dataTable.Rows[0]["registerDate"].ToString(); // パスワード
                        textBoxShowLastUse.Text = dataTable.Rows[0]["lastUseDate"].ToString(); // 最終利用日
                        textBoxShowNextUse.Text = dataTable.Rows[0]["nextUseDate"].ToString(); // 次回予約日
                    }
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
        public SearchPage()
        {
            InitializeComponent();
            // 検索結果表示欄の入力不可
            textBoxShowNameK.KeyPress += new KeyPressEventHandler(ShowTextBoxKeyPress);
            textBoxShowNameH.KeyPress += new KeyPressEventHandler(ShowTextBoxKeyPress);
            textBoxShowPostal.KeyPress += new KeyPressEventHandler(ShowTextBoxKeyPress);
            textBoxShowAddres.KeyPress += new KeyPressEventHandler(ShowTextBoxKeyPress);
            textBoxShowTelephone.KeyPress += new KeyPressEventHandler(ShowTextBoxKeyPress);
            textBoxShowGender.KeyPress += new KeyPressEventHandler(ShowTextBoxKeyPress);
            textBoxShowBirth.KeyPress += new KeyPressEventHandler(ShowTextBoxKeyPress);
            textBoxShowMialAddress.KeyPress += new KeyPressEventHandler(ShowTextBoxKeyPress);
            textBoxShowMemberType.KeyPress += new KeyPressEventHandler(ShowTextBoxKeyPress);
            textBoxShowPassword.KeyPress += new KeyPressEventHandler(ShowTextBoxKeyPress);
            textBoxShowLastUse.KeyPress += new KeyPressEventHandler(ShowTextBoxKeyPress);
            textBoxShowNextUse.KeyPress += new KeyPressEventHandler(ShowTextBoxKeyPress);
            // ID入力欄の入力制限(数字のみ)
            searchTextBox.KeyPress += new KeyPressEventHandler(SearchTextBoxKeyPress);   
        }
        /// <summary>
        /// 管理画面へ戻る
        /// </summary>
        /// <param name="sender">管理画面へボタン</param>
        /// <param name="e">管理画面へボタンを押したとき</param>
        private void BackButtonClick(object sender, EventArgs e)
        {
            // 会員情報管理画面を表示
            ManagementPage management = new ManagementPage();
            management.Show();
            // 検索ページを閉じる
            this.Close();
        }
    }
}
