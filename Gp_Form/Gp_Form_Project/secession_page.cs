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
    public partial class Secession_Page : Form
    {
        public Secession_Page()
        {
            InitializeComponent();
        }

        private void delete_button_Click(object sender, EventArgs e)
        {
            // 会員が入力されていない場合
            if (String.IsNullOrEmpty(deleteTextBox.Text))
            {
                // 未入力を伝えるダイアログ表示
                DialogResult Null = MessageBox.Show("会員IDを入力してください。", "エラー",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            using (SQLiteConnection con = new SQLiteConnection("Date Source=member.db"))
            {
                con.Open();
                using (SQLiteTransaction trans = con.BeginTransaction())
                {
                    SQLiteCommand cmd = con.CreateCommand();
                    // 
                    cmd.CommandText = "DELETE FROM m_member WHERE member_id = @Member_id;";
                    // 
                    cmd.Parameters.Add("Member_id", System.Data.DbType.Int32);
                    // 
                    cmd.Parameters["Member_id"].Value = int.Parse(deleteTextBox.Text);
                    cmd.ExecuteNonQuery();

                    trans.Commit();
                }
            }
        }
    }
}
