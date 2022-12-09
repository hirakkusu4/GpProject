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
            change_textBox1.ReadOnly = true;
        }
        public change_page()
        {
            InitializeComponent();
        }
        private void show_button_Click(object sender, EventArgs e)
        {
            using (SQLiteConnection con = new SQLiteConnection("Data Source=member.db"))
            {
                int show_id = int.Parse(shows_textBox.Text);
                //
                var dataTable = new DataTable();
                //
                var adapter = new SQLiteDataAdapter($"SELECT * FROM m_member WHERE member_id = {show_id}", con);
                adapter.Fill(dataTable);
                
            }
        }
        private void change_button_Click(object sender, EventArgs e)
        {
            var con = new SQLiteConnection("member.db=:memory:");
            
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


                    cmd.Parameters["Name_k"].Value = change_textBox1.Text;
                    cmd.Parameters["Name_h"].Value = change_textBox2.Text;
                    cmd.Parameters["Postal"].Value = int.Parse(change_textBox3.Text);
                    cmd.Parameters["Address"].Value = change_textBox4.Text;
                    cmd.Parameters["Telephone"].Value = int.Parse(change_textBox5.Text);
                    cmd.Parameters["Mailaddress"].Value = change_textBox6.Text;
                    cmd.Parameters["Member_id"].Value = int.Parse(shows_textBox.Text);

                    cmd.ExecuteNonQuery();

                    trans.Commit();
                }
            
        }

        private void change_page_Load_1(object sender, EventArgs e)
        {

        }
    }
}
