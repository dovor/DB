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
    public partial class AddHumanForm : Form
    {
        public AddHumanForm()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Dictionary<string, object> dict = new Dictionary<string, object>();
            dict.Add("@EMail", tb_email.Text);
            dict.Add("@Adress", tb_adress.Text);
            dict.Add("@Phone", tb_phone.Text);
            bool a = DBUtils.executeCommand("InsertContragent", dict);
            dict.Clear();
            dict.Add("@Phone", tb_phone.Text);
            dict.Add("@FirstName", tb_n.Text);
            dict.Add("@LastName", tb_ln.Text);
            dict.Add("@FatherName", tb_fn.Text);
            dict.Add("@Birthday", dtp.Value.ToString("yyyy-MM-dd"));
            bool b = DBUtils.executeCommand("InsertHuman", dict);
            MessageBox.Show("A = " + a.ToString() + ". B = " + b.ToString() + ".");
        }
    }
}
