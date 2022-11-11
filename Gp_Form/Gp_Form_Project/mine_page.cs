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
        }
        private void login_button_Click(object sender, EventArgs e)
        {
            login_page login = new login_page();
            login.Show();
        }
    }   
}
