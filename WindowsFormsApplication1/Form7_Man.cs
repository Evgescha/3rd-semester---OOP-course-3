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
    public partial class Form7_Man : Form
    {
        Class1_BD bd = new Class1_BD();
        string command;
        Form5_SotrAddRedactTrans frm5;
        
        public Form7_Man()
        {
            InitializeComponent();
            bd.ConStr();
            GridLoad();
            
        }
        private void GridLoad()
        {
            command = "SELECT * FROM Man";
            bd.SelectGridPlus(command, dataGridView1);
            
        }

        private void button5_Click(object sender, EventArgs e)
        {
            textBox1.Text = "";
            textBox2.Text = "";
            textBox3.Text = "";
            textBox4.Text = "";
            GridLoad();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            command = "SELECT * FROM Man WHERE id_man > 1 ";
            if (textBox1.Text != "") { command += " AND name_man LIKE ('%" + textBox1.Text + "%')"; }
            if (textBox2.Text != "") { command += " AND fmane_man LIKE ('%" + textBox2.Text + "%')"; }
            if (textBox3.Text != "") { command += " AND nomPassword_man LIKE ('%" + textBox3.Text + "%')"; }
            if (textBox4.Text != "") { command += " AND nomHause_man LIKE ('%" + textBox4.Text + "%')"; }
            bd.SelectGridPlus(command, dataGridView1);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            frm5 = new Form5_SotrAddRedactTrans(1, dataGridView1[0, dataGridView1.CurrentRow.Index].Value.ToString());
            frm5.Show();
            
        }

        private void button2_Click(object sender, EventArgs e)
        {
            frm5 = new Form5_SotrAddRedactTrans(2, dataGridView1[0, dataGridView1.CurrentRow.Index].Value.ToString());
            frm5.Show();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            frm5 = new Form5_SotrAddRedactTrans(3, dataGridView1[0, dataGridView1.CurrentRow.Index].Value.ToString());
            frm5.Show();
        }
    }
}
