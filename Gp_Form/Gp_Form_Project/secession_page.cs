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
    public partial class secession_page : Form
    {
        public secession_page()
        {
            InitializeComponent();
        }

        private void delete_button_Click(object sender, EventArgs e)
        {
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
                    cmd.Parameters["Member_id"].Value = int.Parse(delete_textBox.Text);
                    cmd.ExecuteNonQuery();

                    trans.Commit();
                }
            }
        }
    }
}
