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
    public partial class change_page : Form
    {
        private SQLiteConnection con = new SQLiteConnection("Date Source=member.db");
        public change_page()
        {
            InitializeComponent();
        }
        private void change_button_Click(object sender, EventArgs e)
        {

        }

        private void show_button_Click(object sender, EventArgs e)
        {
            using (SQLiteConnection con = new SQLiteConnection("Data Source=member.db"))
            {
                //
                var dataTable = new DataTable();
                //
                var adapter = new SQLiteDataAdapter("SELECT name_k FROM m_member WHERE member_id=showtextBox.Text", con);
                string shownk = adapter.ToString();
                textBox1.Text = shownk;
            }
        }
    }
}
