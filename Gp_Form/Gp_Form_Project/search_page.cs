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
        private void Search_page_load(object sender, EventArgs e)
        {
            show_textBox1.ReadOnly = true;
            show_textBox2.ReadOnly = true;
            show_textBox3.ReadOnly = true;
            show_textBox4.ReadOnly = true;
            show_textBox5.ReadOnly = true;
            show_textBox6.ReadOnly = true;
            show_textBox7.ReadOnly = true;
            show_textBox8.ReadOnly = true;
            show_textBox9.ReadOnly = true;
            show_textBox10.ReadOnly = true;
            show_textBox11.ReadOnly = true;
            show_textBox12.ReadOnly = true;
        }
        public search_page()
        {
            InitializeComponent();
        }

        private void search_button_Click(object sender, EventArgs e)
        {
            using (SQLiteConnection con = new SQLiteConnection("Data Source=member.db"))
            {
                if (search_textBox == null)
                {

                }
                int search_id = int.Parse(search_textBox.Text);

                var dataTable = new DataTable();
                //
                var adapter = new SQLiteDataAdapter($"SELECT * FROM m_member WHERE member_id = {search_id}", con);
                adapter.Fill(dataTable);
                show_textBox1.Text = dataTable.Rows[0]["name_k"].ToString();
                show_textBox2.Text = dataTable.Rows[0]["name_h"].ToString();
                show_textBox3.Text = dataTable.Rows[0]["postal"].ToString();
                show_textBox4.Text = dataTable.Rows[0]["address"].ToString();
                show_textBox5.Text = dataTable.Rows[0]["telephone"].ToString();
                show_textBox6.Text = dataTable.Rows[0]["gender"].ToString();
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
