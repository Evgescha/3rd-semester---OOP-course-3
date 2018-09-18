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
    
    public partial class Form1_LogIn : Form
    {
        Form4_LogInSotr lgSotr;
        Form2_LogInKvart lgKvart;
       
        public Form1_LogIn()
        {
            InitializeComponent();
           
            
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (textBox1.Text == "1")
            {
                MessageBox.Show("ok");
                lgSotr = new Form4_LogInSotr();
                lgSotr.Show();
                    
            }
            else { MessageBox.Show("неверно"); }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            lgKvart = new Form2_LogInKvart();
            lgKvart.Show();
        }
    }
}
