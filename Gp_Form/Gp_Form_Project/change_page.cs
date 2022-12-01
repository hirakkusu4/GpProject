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
            show_textBox1.ReadOnly = true;
        }
        public change_page()
        {
            InitializeComponent();
        }
        private void show_button_Click(object sender, EventArgs e)
        {
            using (SQLiteConnection con = new SQLiteConnection("Data Source=member.db"))
            {
                int show_id = int.Parse(show_textBox.Text);
                //
                var dataTable = new DataTable();
                //
                var adapter = new SQLiteDataAdapter($"SELECT * FROM m_member WHERE member_id = {show_id}", con);
                adapter.Fill(dataTable);
                show_textBox1.Text = dataTable.Rows[0]["name_k"].ToString();
                show_textBox2.Text = dataTable.Rows[0]["name_h"].ToString();
                show_textBox3.Text = dataTable.Rows[0]["postal"].ToString();
                show_textBox4.Text = dataTable.Rows[0]["address"].ToString();
                show_textBox5.Text = dataTable.Rows[0]["telephone"].ToString();
                show_textBox6.Text = dataTable.Rows[0]["mail_address"].ToString();
            }
        }
        private void change_button_Click(object sender, EventArgs e)
        {
            using (SQLiteConnection con = new SQLiteConnection("Date Source=member.db"))
            {
                con.Open();
                using (SQLiteTransaction trans = con.BeginTransaction())
                {
                    SQLiteCommand cmd = con.CreateCommand();
                    cmd.CommandText = "UPDATE m_member SET name_k = @Name_k, name_h = @Name_h, postal = @Postal," +
                        "address = @Address, telephone = @Telephone, mail_address = @Mail_address WHERE member_id = @Member_id";
                    cmd.Parameters.Add("Name_k", System.Data.DbType.String);
                    cmd.Parameters.Add("Name_h", System.Data.DbType.String);
                    cmd.Parameters.Add("Postal", System.Data.DbType.Int32);
                    cmd.Parameters.Add("Address", System.Data.DbType.String);
                    cmd.Parameters.Add("Telephone", System.Data.DbType.Int32);
                    cmd.Parameters.Add("Mailaddress", System.Data.DbType.String);
                    cmd.Parameters.Add("Member_id", System.Data.DbType.Int32);


                    cmd.Parameters["Name_k"].Value = ;
                    cmd.Parameters[""].Value = ;
                    cmd.Parameters[""].Value = ;
                    cmd.Parameters[""].Value = ;
                    cmd.Parameters[""].Value = ;
                    cmd.Parameters[""].Value = ;
                }
            }
        }
    }
}
