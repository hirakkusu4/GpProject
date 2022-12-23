using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SQLite;

namespace GameProgrammingFormProject
{
    public partial class Register_Page : Form
    {
        int but = 0;
        public Register_Page()
        {
            InitializeComponent();

            comboBox_InsertGender.DropDownStyle = ComboBoxStyle.DropDownList;
            comboBox_InsertMemberType.DropDownStyle = ComboBoxStyle.DropDownList;
            // KeyPressのイベントハンドラ
            comboBox_InsertGender.KeyPress += new KeyPressEventHandler(ComboBoxKeyPress);
            comboBox_InsertMemberType.KeyPress += new KeyPressEventHandler(ComboBoxKeyPress);
            // 入力制限(数字のみ)
            textBoxInsertPostal.KeyPress += new KeyPressEventHandler(NumbersKeyPress);
            //textBox_InsertTelephone.KeyPress += new KeyPressEventHandler(Numbers_KeyPress);
            textBoxInsertbirth.KeyPress += new KeyPressEventHandler(NumbersKeyPress);
        }
        private void insertButton_Click(object sender, EventArgs e)
        {
            string[] count = new string[8] { "NameK", "NameH", "Postal", "Address", "Telephone",
                "Birth", "MailAddress", "Password"};


            foreach (string chr in count)
            {
                but++;
                // 入力欄の入力チェック
                if (((TextBox)Controls[$"textBoxInsert{chr}"]).Text == String.Empty)
                {
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
                        using (SQLiteConnection con = new SQLiteConnection("Data Source=member.db"))
                        {
                            con.Open();
                            using (SQLiteTransaction trans = con.BeginTransaction())
                            {
                                SQLiteCommand cmd = con.CreateCommand();
                                // インサート
                                cmd.CommandText = "INSERT INTO m_member (nameK, nameH, postal, address, telephone, gender, birthDate, " +
                                    "mailAddress, membertypeCode, password) VALUES (@NameK, @NameH, @Postal, @Address, @Telephone, @Gender, " +
                                    "@BirthDate, @MailAddress, @MembertypeCode, @Password)";
                                // パラメータセット
                                cmd.Parameters.Add("NameK", System.Data.DbType.String);
                                cmd.Parameters.Add("NameH", System.Data.DbType.String);
                                cmd.Parameters.Add("Postal", System.Data.DbType.Int32);
                                cmd.Parameters.Add("Address", System.Data.DbType.String);
                                cmd.Parameters.Add("Telephone", System.Data.DbType.String);
                                cmd.Parameters.Add("Gender", System.Data.DbType.String);
                                cmd.Parameters.Add("BirthDate", System.Data.DbType.Int32);
                                cmd.Parameters.Add("MailAddress", System.Data.DbType.String);
                                cmd.Parameters.Add("MembertypeCode", System.Data.DbType.String);
                                cmd.Parameters.Add("Password", System.Data.DbType.String);
                                // データ追加
                                cmd.Parameters["NameK"].Value = textBoxInsertNameK.Text;
                                cmd.Parameters["NameH"].Value = textBoxInsertNameH.Text;
                                cmd.Parameters["Postal"].Value = int.Parse(textBoxInsertPostal.Text);
                                cmd.Parameters["Address"].Value = textBoxInsertAddress.Text;
                                cmd.Parameters["Telephone"].Value = textBoxInsertTelephone.Text;
                                cmd.Parameters["Gender"].Value = comboBox_InsertGender.Text;
                                cmd.Parameters["BirthDate"].Value = int.Parse(textBoxInsertbirth.Text);
                                cmd.Parameters["MailAddress"].Value = textBoxInsertMailAddress.Text;
                                cmd.Parameters["MembertypeCode"].Value = comboBox_InsertMemberType.Text;
                                cmd.Parameters["Password"].Value = textBoxInsertPassword.PasswordChar;

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
                            var adapter = new SQLiteDataAdapter("SELECT max(memberId) FROM m_member", con);
                            adapter.Fill(dataTable);
                            // 登録完了ダイアログ表示
                            DialogResult complete =
                               MessageBox.Show($"登録が完了しました。" +
                               $"会員IDはログイン時にも必要なのでメモを取るなどで保管してください " +
                               $"会員番号 {dataTable.Rows[0][0]}", "登録完了",
                               MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            if (complete == DialogResult.OK)
                            {
                                // メインページに戻る
                                Mine_Page mine = new Mine_Page();
                                mine.Visible = true;

                                this.Close();
                            }
                        }
                    }
                }
            }
        }
        private void ComboBoxKeyPress(object sender, KeyPressEventArgs e)
        {
            // KeyPressを無効にする
            e.Handled = true;
        }
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
    }
}
