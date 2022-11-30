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
        private void change_page_Load(object sender, EventArgs e)
        {
            textBox1.ReadOnly = true;
        }
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
                int show_id =int.Parse(show_textBox.Text); 
                //
                var dataTable = new DataTable();
                //
                var adapter = new SQLiteDataAdapter($"SELECT * FROM m_member WHERE member_id = {show_id}", con);
                adapter.Fill(dataTable);
                textBox1.Text = dataTable.Rows[0]["name_k"].ToString();
            }
        }
    }
}
