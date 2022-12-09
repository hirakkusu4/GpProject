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
    public partial class search_page : Form
    {
        #region 入力不可
        private void show_textBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            // KeyPressを無効にする
            e.Handled = true;
        }
        private void show_textBox2_KeyPress(object sender, KeyPressEventArgs e)
        {
            // KeyPressを無効にする
            e.Handled = true;
        }
        private void show_textBox3_KeyPress(object sender, KeyPressEventArgs e)
        {
            // KeyPressを無効にする
            e.Handled = true;
        }
        private void show_textBox4_KeyPress(object sender, KeyPressEventArgs e)
        {
            // KeyPressを無効にする
            e.Handled = true;
        }
        private void show_textBox5_KeyPress(object sender, KeyPressEventArgs e)
        {
            // KeyPressを無効にする
            e.Handled = true;
        }
        private void show_textBox6_KeyPress(object sender, KeyPressEventArgs e)
        {
            // KeyPressを無効にする
            e.Handled = true;
        }
        private void show_textBox7_KeyPress(object sender, KeyPressEventArgs e)
        {
            // KeyPressを無効にする
            e.Handled = true;
        }
        private void show_textBox8_KeyPress(object sender, KeyPressEventArgs e)
        {
            // KeyPressを無効にする
            e.Handled = true;
        }
        private void show_textBox9_KeyPress(object sender, KeyPressEventArgs e)
        {
            // KeyPressを無効にする
            e.Handled = true;
        }
        private void show_textBox10_KeyPress(object sender, KeyPressEventArgs e)
        {
            // KeyPressを無効にする
            e.Handled = true;
        }
        private void show_textBox11_KeyPress(object sender, KeyPressEventArgs e)
        {
            // KeyPressを無効にする
            e.Handled = true;
        }
        private void show_textBox12_KeyPress(object sender, KeyPressEventArgs e)
        {
            // KeyPressを無効にする
            e.Handled = true;
        }
        #endregion

        private void search_textBox_KeyPress(object sender, KeyPressEventArgs e)
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
        public search_page()
        {
            InitializeComponent();
            // 検索結果表示欄の入力不可
            show_textBox1.KeyPress += new KeyPressEventHandler(show_textBox1_KeyPress);
            show_textBox2.KeyPress += new KeyPressEventHandler(show_textBox2_KeyPress);
            show_textBox3.KeyPress += new KeyPressEventHandler(show_textBox3_KeyPress);
            show_textBox4.KeyPress += new KeyPressEventHandler(show_textBox4_KeyPress);
            show_textBox5.KeyPress += new KeyPressEventHandler(show_textBox5_KeyPress);
            show_textBox6.KeyPress += new KeyPressEventHandler(show_textBox6_KeyPress);
            show_textBox7.KeyPress += new KeyPressEventHandler(show_textBox7_KeyPress);
            show_textBox8.KeyPress += new KeyPressEventHandler(show_textBox8_KeyPress);
            show_textBox9.KeyPress += new KeyPressEventHandler(show_textBox9_KeyPress);
            show_textBox10.KeyPress += new KeyPressEventHandler(show_textBox10_KeyPress);
            show_textBox11.KeyPress += new KeyPressEventHandler(show_textBox11_KeyPress);
            show_textBox12.KeyPress += new KeyPressEventHandler(show_textBox12_KeyPress);
            // ID入力欄の入力制限(数字のみ)
            search_textBox.KeyPress += new KeyPressEventHandler(search_textBox_KeyPress);
            
        }
        private void search_button_Click(object sender, EventArgs e) // 検索ボタンを押したとき
        {
            using (SQLiteConnection con = new SQLiteConnection("Data Source=member.db"))
            {
                if (String.IsNullOrEmpty(search_textBox.Text)) // 会員が入力されていない場合
                {
                    // 未入力を伝えるダイアログ表示
                    DialogResult Null = MessageBox.Show("会員IDを入力してください。", "エラー",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else
                {
                    // 入力されたデータをintに変換
                    int search_id = int.Parse(search_textBox.Text);
                    // データテーブル作成
                    var dataTable = new DataTable();
                    // SQLの実行
                    var adapter = new SQLiteDataAdapter($"SELECT * FROM m_member WHERE member_id = {search_id}", con);
                    // 結果の取得
                    adapter.Fill(dataTable);

                    if (dataTable.Rows.Count == 0) // 詮索結果がなかった場合
                    {
                        // もう一度入力を促すダイアログ表示
                        DialogResult Not = MessageBox.Show("会員IDが見つかりませんでした。もう一度入力してください。",
                            "エラー", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    else
                    {
                        // テキストボックスに各データを入れる
                        show_textBox1.Text = dataTable.Rows[0]["name_k"].ToString();
                        show_textBox2.Text = dataTable.Rows[0]["name_h"].ToString();
                        show_textBox3.Text = dataTable.Rows[0]["gender"].ToString();
                        show_textBox4.Text = dataTable.Rows[0]["postal"].ToString();
                        show_textBox5.Text = dataTable.Rows[0]["address"].ToString();
                        show_textBox6.Text = dataTable.Rows[0]["telephone"].ToString();
                        show_textBox7.Text = dataTable.Rows[0]["birth_date"].ToString();
                        show_textBox8.Text = dataTable.Rows[0]["mail_address"].ToString();
                        show_textBox9.Text = dataTable.Rows[0]["membertype_code"].ToString();
                        show_textBox10.Text = dataTable.Rows[0]["register_date"].ToString();
                        show_textBox11.Text = dataTable.Rows[0]["last_use_date"].ToString();
                        show_textBox12.Text = dataTable.Rows[0]["next_use_date"].ToString();
                    }
                }
            }
        }
    }
}
