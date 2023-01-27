using System;
using System.Data;
using System.Windows.Forms;
using System.Data.SQLite;

namespace GameProgrammingFormProject
{
    public partial class RegisterPage : Form
    {
        //  未入力欄検出用
        int but = 0;
        // 登録用SQL
        const string registerSQL = "INSERT INTO m_member (nameK, nameH, postal, address, telephone, gender, birthDate, " +
                                    "mailAddress, membertypeCode, password) VALUES (@NameK, @NameH, @Postal, @Address, @Telephone, @Gender, " +
                                    "@BirthDate, @MailAddress, @MembertypeCode, @Password)";
        // id確認用
        const string idShow = "SELECT max(memberId) FROM m_member";
        public RegisterPage()
        {
            InitializeComponent();
            // フォームを中央に配置
            this.StartPosition = FormStartPosition.CenterScreen;

            comboBoxInsertGender.DropDownStyle = ComboBoxStyle.DropDownList;
            comboBoxInsertMemberType.DropDownStyle = ComboBoxStyle.DropDownList;
            // KeyPressのイベントハンドラ
            comboBoxInsertGender.KeyPress += new KeyPressEventHandler(ComboBoxKeyPress);
            comboBoxInsertMemberType.KeyPress += new KeyPressEventHandler(ComboBoxKeyPress);
            // 入力制限(数字のみ)
            textBoxInsertPostal.KeyPress += new KeyPressEventHandler(NumbersKeyPress);
            textBoxInsertTelephone.KeyPress += new KeyPressEventHandler(NumbersKeyPress);
            textBoxInsertbirth.KeyPress += new KeyPressEventHandler(NumbersKeyPress);
        }
        /// <summary>
        /// 会員情報の登録
        /// </summary>
        /// <param name="sender">確定ボタン</param>
        /// <param name="e">確定ボタンを押したとき</param>
        private void InsertButton_Click(object sender, EventArgs e)
        {
            // テキストボックス名の配列
            string[] count = new string[8] { "NameK", "NameH", "Postal", "Address", "Telephone",
                "Birth", "MailAddress", "Password"};
            // 未入力欄のチェック    
            foreach (string chr in count)
            {
                // 確認したテキストボックス数のカウント
                but++;
                // 入力欄の入力チェック
                if (((TextBox)Controls[$"textBoxInsert{chr}"]).Text == String.Empty)
                {
                    // 未入力欄確認のダイアログ表示
                    DialogResult Null = MessageBox.Show("未入力の欄があります。", "エラー",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                    but = 0;
                    break;
                }
                else if (but == 8)
                {
                    // 入力内容確認のダイアログ表示
                    DialogResult check = MessageBox.Show("入力内容に誤りはないですか？", "入力内容確認",
                        MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                    if (check == DialogResult.Yes) // はい　を押した場合
                    {
                        using (SQLiteConnection register = new SQLiteConnection("Data Source=member.db"))
                        {
                            register.Open();
                            using (SQLiteTransaction trans = register.BeginTransaction())
                            {
                                SQLiteCommand cmd = register.CreateCommand();
                                // インサート
                                cmd.CommandText = registerSQL;
                                // パラメータセット
                                cmd.Parameters.Add("NameK", System.Data.DbType.String);
                                cmd.Parameters.Add("NameH", System.Data.DbType.String);
                                cmd.Parameters.Add("Postal", System.Data.DbType.Int32);
                                cmd.Parameters.Add("Address", System.Data.DbType.String);
                                cmd.Parameters.Add("Telephone", System.Data.DbType.String);
                                cmd.Parameters.Add("Gender", System.Data.DbType.String);
                                cmd.Parameters.Add("BirthDate", System.Data.DbType.Int32);
                                cmd.Parameters.Add("MailAddress", System.Data.DbType.String);
                                cmd.Parameters.Add("MembertypeCode", System.Data.DbType.Int32);
                                cmd.Parameters.Add("Password", System.Data.DbType.String);
                                // データ追加
                                cmd.Parameters["NameK"].Value = textBoxInsertNameK.Text;
                                cmd.Parameters["NameH"].Value = textBoxInsertNameH.Text;
                                cmd.Parameters["Postal"].Value = int.Parse(textBoxInsertPostal.Text);
                                cmd.Parameters["Address"].Value = textBoxInsertAddress.Text;
                                cmd.Parameters["Telephone"].Value = textBoxInsertTelephone.Text;
                                cmd.Parameters["Gender"].Value = comboBoxInsertGender.Text;
                                cmd.Parameters["BirthDate"].Value = int.Parse(textBoxInsertbirth.Text);
                                cmd.Parameters["MailAddress"].Value = textBoxInsertMailAddress.Text;
                                cmd.Parameters["Password"].Value = textBoxInsertPassword.Text;
                                // 一般会員の場合
                                if (comboBoxInsertMemberType.Text == "一般会員")
                                {
                                    cmd.Parameters["MembertypeCode"].Value = int.Parse("1");
                                }
                                // 特別会員の場合
                                else if (comboBoxInsertMemberType.Text == "特別会員")
                                {
                                    cmd.Parameters["MembertypeCode"].Value = int.Parse("2");
                                }
                                cmd.ExecuteNonQuery();
                                // コミット
                                trans.Commit();
                            }
                        }
                        using (SQLiteConnection con = new SQLiteConnection("Data Source=member.db"))
                        {
                            // データテーブル作成
                            var dataTable = new DataTable();
                            // SQL実行
                            var adapter = new SQLiteDataAdapter(idShow, con);
                            adapter.Fill(dataTable);
                            // 登録完了ダイアログ表示
                            DialogResult complete =
                               MessageBox.Show($"登録が完了しました。" +
                               $"会員IDはログイン時にも必要なのでメモを取るなどで保管してください " +
                               $"会員番号 {dataTable.Rows[0][0]}", "登録完了",
                               MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            // OKボタンを押したとき
                            if (complete == DialogResult.OK)
                            {
                                // メインページへ遷移
                                Program.End.MainForm = new MinePage();
                                Program.End.MainForm.Show();
                                // ログインページ非表示
                                this.Close();
                            }
                        }
                    }
                }
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
            // 数0～9以外はキャンセル
            if ((e.KeyChar < '0' || '9' < e.KeyChar))
            {
                e.Handled = true;
            }
        }
        /// <summary>
        /// メインページへ遷移
        /// </summary>
        /// <param name="sender">メインページへボタン</param>
        /// <param name="e">メインページへボタンを押したとき</param>
        private void BackButton_Click(object sender, EventArgs e)
        {
            // メインメニュー画面へ遷移
            MinePage mine = new MinePage();
            mine.Visible = true;
            // このページを閉じる
            this.Close();
        }
    }
}
