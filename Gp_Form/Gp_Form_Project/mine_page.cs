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
    public partial class Mine_Page : Form
    {
        public Mine_Page()
        {
            InitializeComponent();
        }
        private void register_button_Click(object sender, EventArgs e)
        {
            // 登録ページへ遷移
            Register_Page register = new Register_Page();
            register.Show();
            // メインメニュー非表示
            this.Visible = false;
        }
        private void login_button_Click(object sender, EventArgs e)
        {
            // ログインページへ遷移
            Login_Page login = new Login_Page();
            login.Show();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            // テーブル作成
            using (var con = new SQLiteConnection("Data Source=member.db"))
            {
                con.Open();
                using (SQLiteCommand command = con.CreateCommand())
                {
                    command.CommandText =
                        "create table m_member(memberId INTEGER PRIMARY KEY AUTOINCREMENT, nameK TEXT, nameH TEXT," +
                        " postal INTEGER, address TEXT, telephone TEXT, gender TEXT, birthDate INTEGER, mailAddress TEXT, " +
                        "membertypeCode INTEGER,registerDate INTEGER, lastUseDate INTEGER, nextUseDate INTEGER, password TEXT)";

                   // command.CommandText =
                   //     "create table m_membertype()";

                   // command.CommandText =
                   //     "create table m_plan()";

                    command.ExecuteNonQuery();
                }
                con.Close();
            }
        }
        private void button3_Click(object sender, EventArgs e)
        {
            using (SQLiteConnection conn = new SQLiteConnection("Date Source=member.db"))
            {
                var dataTable = new DataTable();
                var adapter = new SQLiteDataAdapter("SELECT * FROM m_member", conn);
                dataGridView1.DataSource = dataTable;
            }
        }
    }
}
