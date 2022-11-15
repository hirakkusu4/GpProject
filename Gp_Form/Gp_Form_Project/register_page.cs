using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
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
            MessageBox.Show("入力内容に誤りはないですか？", "入力内容確認", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
        }
    }
}
