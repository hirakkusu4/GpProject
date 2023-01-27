using System;
using System.Data;
using System.Windows.Forms;
using System.Data.SQLite;

namespace GameProgrammingFormProject
{
    public partial class ChangePage : Form
    {
        // 
        const string showSQL = "SELECT * FROM m_member WHERE memberId =";
        // 
        const string changeSQL = "UPDATE m_member SET nameK = @NameK, nameH = @NameH, postal = @Postal," +
            "address = @Address, telephone = @Telephone, mailAddress = @MailAddress, " +
            "membertypeCode = @MembertypeCode WHERE memberId = ";
        public ChangePage()
        {
            InitializeComponent();
            // フォームを中央に配置
            this.StartPosition = FormStartPosition.CenterScreen;

            comboBoxChangeMembertype.DropDownStyle = ComboBoxStyle.DropDownList;
            // KeyPressのイベントハンドラ
            comboBoxChangeMembertype.KeyPress += new KeyPressEventHandler(ComboBoxKeyPress);
            // 入力制限(数字のみ)
            textBoxChangePostal.KeyPress += new KeyPressEventHandler(NumbersKeyPress);
            textBoxChangeTelephone.KeyPress += new KeyPressEventHandler(NumbersKeyPress);

            using (SQLiteConnection show = new SQLiteConnection("Data Source=member.db"))
            {
                // データテーブル作成
                DataTable dataTable = new DataTable();
                // SQLの実行
                SQLiteDataAdapter adapter = new SQLiteDataAdapter(showSQL + Properties.Settings.Default.loginId, show);
                // 結果の取得
                adapter.Fill(dataTable);
                // テキストボックスに各データを入れる
                // 名前(漢字)
                textBoxChangeNamek.Text = dataTable.Rows[0]["nameK"].ToString();
                // 名前(かな)
                textBoxChangeNameH.Text = dataTable.Rows[0]["nameH"].ToString();
                // 郵便番号
                textBoxChangePostal.Text = dataTable.Rows[0]["postal"].ToString();
                // 住所
                textBoxChangeAddress.Text = dataTable.Rows[0]["address"].ToString();
                // 電話番号
                textBoxChangeTelephone.Text = dataTable.Rows[0]["telephone"].ToString();
                // メールアドレス
                textBoxChangeMailAddress.Text = dataTable.Rows[0]["mailAddress"].ToString();
                // 会員種別
                if (int.Parse(dataTable.Rows[0]["membertypeCode"].ToString()) == 1)
                {
                    comboBoxChangeMembertype.SelectedItem = "一般会員";
                }
                else
                {
                    comboBoxChangeMembertype.SelectedItem = "特別会員";
                }
            }
        }
        /// <summary>
        /// 会員情報の変更
        /// </summary>
        /// <param name="sender">変更ボタン</param>
        /// <param name="e">変更ボタンを押したとき</param>
        private void ChangeButton_Click(object sender, EventArgs e)
        {
            using (SQLiteConnection change = new SQLiteConnection("Data Source=member.db"))
            {
                change.Open();
                using (SQLiteTransaction trans = change.BeginTransaction())
                {
                    SQLiteCommand cmd = change.CreateCommand();
                    // 会員情報の変更のUPDATE
                    cmd.CommandText = changeSQL + Properties.Settings.Default.loginId;
                    // パラメータセット
                    cmd.Parameters.Add("Namek", System.Data.DbType.String);
                    cmd.Parameters.Add("Nameh", System.Data.DbType.String);
                    cmd.Parameters.Add("Postal", System.Data.DbType.Int32);
                    cmd.Parameters.Add("Address", System.Data.DbType.String);
                    cmd.Parameters.Add("Telephone", System.Data.DbType.String);
                    cmd.Parameters.Add("MailAddress", System.Data.DbType.String);
                    cmd.Parameters.Add("MembertypeCode", System.Data.DbType.String);
                    // データ追加
                    cmd.Parameters["Namek"].Value = textBoxChangeNamek.Text;
                    cmd.Parameters["Nameh"].Value = textBoxChangeNameH.Text;
                    cmd.Parameters["Postal"].Value = int.Parse(textBoxChangePostal.Text);
                    cmd.Parameters["Address"].Value = textBoxChangeAddress.Text;
                    cmd.Parameters["Telephone"].Value = textBoxChangeTelephone.Text;
                    cmd.Parameters["MailAddress"].Value = textBoxChangeMailAddress.Text;
                    cmd.Parameters["MembertypeCode"].Value = comboBoxChangeMembertype.Text;
                    // 実行
                    cmd.ExecuteNonQuery();
                    // コミット
                    trans.Commit();
                }
                change.Close();
            }
        }
        /// <summary>
        /// コンボボックスの入力不可
        /// </summary>
        /// <param name="sender">コンボボックス</param>
        /// <param name="e">コンボボックス使用時</param>
        private void ComboBoxKeyPress(object sender, KeyPressEventArgs e)
        {
            // KeyPressを無効にする
            e.Handled = true;
        }
        /// <summary>
        /// 数字のみの入力可
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e">コンボボックス使用時</param>
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
        /// 管理画面へ戻る
        /// </summary>
        /// <param name="sender">管理画面へボタン</param>
        /// <param name="e">管理画面へボタンを押したとき</param>
        private void BackButton_Click(object sender, EventArgs e)
        {
            // 会員情報管理画面を表示
            Program.End.MainForm = new ManagementPage();
            Program.End.MainForm.Show();
            // 検索ページを閉じる
            this.Close();
        }
    }
}