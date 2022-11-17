﻿using System;
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
    public partial class register_page : Form
    {
        public register_page()
        {
            InitializeComponent();
        }
        private void decision_button_Click(object sender, EventArgs e)
        {
            DialogResult check = MessageBox.Show("入力内容に誤りはないですか？", "入力内容確認", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (check == DialogResult.Yes)
            {
                using (SQLiteConnection con = new SQLiteConnection("Data Source=member.db"))
                {
                    con.Open();
                    using (SQLiteTransaction trans = con.BeginTransaction())
                    {
                        SQLiteCommand cmd = con.CreateCommand();
                        //　インサート
                        cmd.CommandText = "INSERT INTO m_member (name_k, name_h, gender, password) VALUES (@Name_k, @Name_h, @Gender, @Password)";
                        //　パラメータセット
                        cmd.Parameters.Add("Name_k", System.Data.DbType.String);
                        cmd.Parameters.Add("Name_h", System.Data.DbType.String);
                        cmd.Parameters.Add("Gender", System.Data.DbType.Int32);
                        cmd.Parameters.Add("Password", System.Data.DbType.String);
                        //　データ追加
                        cmd.Parameters["Name_k"].Value = name_k_textBox.Text;
                        cmd.Parameters["Name_h"].Value = name_h_textBox.Text;
                        // cmd.Parameters["Gender"].Value =
                        cmd.Parameters["Password"].Value = password_textBox.Text;
                        cmd.ExecuteNonQuery();
                        //　コミット
                        trans.Commit();
                    }
                }
                DialogResult complete = 
                    MessageBox.Show("登録が完了しました。会員IDはログイン時にも必要なのでメモを取るなどで保管してください。", "登録完了",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                if (complete == DialogResult.OK)
                {
                    mine_page mine = new mine_page();
                    mine.Visible = true;

                    this.Close();
                }
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            using (SQLiteConnection con = new SQLiteConnection("Data Source=member.db"))
            {
                //
                var dataTable = new DataTable();
                //
                var adapter = new SQLiteDataAdapter("SELECT * FROM m_member", con);
                adapter.Fill(dataTable);
                dataGridView1.DataSource = dataTable;
            }
        }
    }
}
