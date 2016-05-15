using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DBInterface
{
    public partial class LoginForm : Form
    {
        public LoginForm()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (DBUtils.init(tb1.Text, tb2.Text))
            {
                AddHumanForm ahf = new AddHumanForm();
                ahf.Show();
                this.Hide();
            } else
            {
                MessageBox.Show("Error!");
            }
        }
    }
}
