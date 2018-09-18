using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApplication1
{
    public partial class Form4_LogInSotr : Form
    {
        Form6_MoneyPlusMinus frm6;
        Form7_Man frm7;
        public Form4_LogInSotr()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            frm6 = new Form6_MoneyPlusMinus();
            frm6.Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            frm7 = new Form7_Man();
            frm7.Show();
        }

        private void bindingNavigator1_RefreshItems(object sender, EventArgs e)
        {

        }
    }
}
