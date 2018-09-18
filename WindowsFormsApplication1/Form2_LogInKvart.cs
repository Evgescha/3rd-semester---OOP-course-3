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
    public partial class Form2_LogInKvart : Form
    {
        Class1_BD bd = new Class1_BD();
        Form3_KvartPlatit kvart;
        public Form2_LogInKvart()
        {
            InitializeComponent();
            bd.ConStr();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string command = "SELECT * FROM Man WHERE name_man = '"+textBox1.Text+"' AND  fmane_man = '"+ textBox2.Text + "'    AND  nomHause_man = "+ textBox3.Text + " AND  nomPassword_man = "+ textBox4.Text + "";
            int res = bd.LogIn(command);

            if(res == 1) {
                kvart = new Form3_KvartPlatit(textBox3.Text);
                kvart.Show();
            } 
        }
    }
}
