using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SQLite;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Gp_Form_Project
{
    public partial class mine_page : Form
    {
        public mine_page()
        {
            InitializeComponent();
        }
        private void register_button_Click(object sender, EventArgs e)
        {
            register_page register = new register_page();
            register.Show();
            this.Visible = false;
        }
        private void login_button_Click(object sender, EventArgs e)
        {
            login_page login = new login_page();
            login.Show();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            using (var con = new SQLiteConnection("Data Source=member.db"))
            {
                con.Open();
                using (SQLiteCommand command = con.CreateCommand())
                {
                    command.CommandText =
                        "create table m_member(CD INTEGER  PRIMARY KEY AUTOINCREMENT, member_id INTEGER, name_k TEXT, name_h TEXT," +
                        " postal INTEGER, address TEXT, telephone INTEGER, gender INTEGER, birth_date INTEGER, mail_address TEXT, " +
                        "membertype_code INTEGER,register_date INTEGER, last_use_date INTEGER, next_use_date INTEGER, password TEXT)";
                    command.ExecuteNonQuery();
                }
                con.Close();
            }
        }
    }   
}
