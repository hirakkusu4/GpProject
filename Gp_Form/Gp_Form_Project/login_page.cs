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
    public partial class login_page : Form
    {
        public login_page()
        {
            InitializeComponent();
        }

        private void login_button_Click(object sender, EventArgs e)
        {
            change_page change = new change_page();
            change.Show();
        }
    }
}
