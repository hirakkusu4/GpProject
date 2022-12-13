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

namespace Gp_Form_Project
{
    public partial class register_page : Form
    {
        public register_page()
        {
            InitializeComponent();

            insert_comboBox6.DropDownStyle = ComboBoxStyle.DropDownList;
            insert_comboBox9.DropDownStyle = ComboBoxStyle.DropDownList;
            // KeyPressのイベントハンドラ
            insert_comboBox6.KeyPress += new KeyPressEventHandler(comboBox_KeyPress);
            insert_comboBox9.KeyPress += new KeyPressEventHandler(comboBox_KeyPress);
        }
        private void decision_button_Click(object sender, EventArgs e)
        {
            // 入力内容確認のダイアログ表示
            DialogResult check = MessageBox.Show("入力内容に誤りはないですか？", "入力内容確認", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (check == DialogResult.Yes) // はい　を押した場合
            {
                using (SQLiteConnection con = new SQLiteConnection("Data Source=member.db"))
                {
                    con.Open();
                    using (SQLiteTransaction trans = con.BeginTransaction())
                    {
                        SQLiteCommand cmd = con.CreateCommand();
                        /*
                         * インサート
                         * name_k = 名前(漢字), name_h = 名前(ひらがな), 性別 = gender, password = パスワード
                         */
                        cmd.CommandText = "INSERT INTO m_member (name_k, name_h, postal, address, telephone gender, birth_date, " +
                            "mail_address, membertype_code, password) VALUES (@Name_k, @Name_h, @Postal, @Address, @Telephone, @Gender, " +
                            "@Birth_date, @Mail_address, @Membertype_code, @Password)";
                        // パラメータセット
                        cmd.Parameters.Add("Name_k", System.Data.DbType.String);
                        cmd.Parameters.Add("Name_h", System.Data.DbType.String);
                        cmd.Parameters.Add("Postal", System.Data.DbType.Int32);
                        cmd.Parameters.Add("Address", System.Data.DbType.String);
                        cmd.Parameters.Add("Telephone", System.Data.DbType.Int64);
                        cmd.Parameters.Add("Gender", System.Data.DbType.String);
                        cmd.Parameters.Add("Birth_date", System.Data.DbType.Int32);
                        cmd.Parameters.Add("Mail_address", System.Data.DbType.String);
                        cmd.Parameters.Add("Membertype_code", System.Data.DbType.String);
                        cmd.Parameters.Add("Password", System.Data.DbType.String);
                        // データ追加
                        cmd.Parameters["Name_k"].Value = insert_textBox1.Text;
                        cmd.Parameters["Name_h"].Value = insert_textBox2.Text;
                        cmd.Parameters["Postal"].Value = int.Parse(insert_textBox3.Text);
                        cmd.Parameters["Address"].Value = insert_textBox4.Text;
                        cmd.Parameters["Terephone"].Value = ulong.Parse(insert_textBox5.Text);
                        cmd.Parameters["Gender"].Value = insert_comboBox6.Text;
                        cmd.Parameters["Birth_date"].Value = int.Parse(insert_textBox7.Text);
                        cmd.Parameters["Mail_address"].Value = insert_textBox8.Text;
                        cmd.Parameters["Membertype_code"].Value = insert_comboBox9.Text;
                        cmd.Parameters["Password"].Value = insert_textBox10.PasswordChar;

                        cmd.ExecuteNonQuery();
                        // コミット
                        trans.Commit();
                        //trans.Commit();
                    }
                }
                using (SQLiteConnection con = new SQLiteConnection("Data Source=member.db"))
                {
                    // データテーブル作成
                    var dataTable = new DataTable();
                    // SQL実行
                    var adapter = new SQLiteDataAdapter("SELECT max(member_id) FROM m_member", con);
                    adapter.Fill(dataTable);

                    // 登録完了ダイアログ表示
                    DialogResult complete =
                        MessageBox.Show($"登録が完了しました。" +
                        $"会員IDはログイン時にも必要なのでメモを取るなどで保管してください " +
                        $"会員番号 {dataTable.Rows[0][0]}", "登録完了",
                        MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    if (complete == DialogResult.OK)
                    {
                        mine_page mine = new mine_page();
                        mine.Visible = true;

                        this.Close();
                    }
                }
            }
        }

        //private void button1_Click(object sender, EventArgs e)
        //{
        //using (SQLiteConnection con = new SQLiteConnection("Data Source=member.db"))
        //{
        // データテーブル作成
        //var dataTable = new DataTable();
        // SQL実行
        //var adapter = new SQLiteDataAdapter("SELECT * FROM m_member", con);
        //adapter.Fill(dataTable);
        //dataGridView1.DataSource = dataTable;
        //}
        //}
        private void comboBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            // KeyPressを無効にする
            e.Handled = true;
        }
    }
}
