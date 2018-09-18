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
    public partial class Form5_SotrAddRedactTrans : Form
    {
        Class1_BD bd = new Class1_BD();
        string command, id;
        int sad;
        public Form5_SotrAddRedactTrans(int was, string idd)
        {
            InitializeComponent();
            bd.ConStr();
            sad = was;
            id = idd;
        }

        private void Form5_SotrAddRedactTrans_Load(object sender, EventArgs e)
        {
            if (sad == 1)
            {
                textBox6.Visible = false;
                label6.Visible = false;
            }
            if (sad == 2)
            {
                command = "SELECT * FROM Man WHERE id_man = "+int.Parse(id)+"";
                textBox1.Text = bd.Messag(command, "name_man");
                textBox2.Text = bd.Messag(command, "nomPassword_man");
                textBox3.Text = bd.Messag(command, "many_man");
                textBox4.Text = bd.Messag(command, "fmane_man");
                textBox5.Text = bd.Messag(command, "nomHause_man");
                textBox6.Visible = false;
                label6.Visible = false;
            }
            if (sad == 3)
            {
                command = "SELECT * FROM Man WHERE id_man = " + int.Parse(id) + "";
                textBox1.Text = bd.Messag(command, "name_man");
                textBox2.Text = bd.Messag(command, "nomPassword_man");
                textBox3.Text = bd.Messag(command, "many_man");
                textBox4.Text = bd.Messag(command, "fmane_man");
                textBox5.Text = bd.Messag(command, "nomHause_man");

                textBox1.Enabled = false;
                label1.Enabled = false;
                textBox2.Enabled = false;
                label2.Enabled = false;
                textBox3.Enabled = false;
                label3.Enabled = false;
                textBox4.Enabled = false;
                label4.Enabled = false;
                textBox5.Enabled = false;
                label5.Enabled = false;


            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if(sad == 1)
            command = "INSERT INTO Man(name_man, fmane_man,nomPassword_man, nomHause_man, many_man) VALUES ('"+textBox1.Text+"', '"+ textBox4.Text + "', "+ textBox2.Text + ", "+ textBox5.Text + ", "+ textBox3.Text + ")";
            if (sad == 2)
            command = "UPDATE Man SET name_man = '" + textBox1.Text + "',fmane_man = '" + textBox4.Text + "',nomPassword_man = " + textBox2.Text + ",nomHause_man = " + textBox5.Text + ",many_man = " + textBox3.Text + " WHERE id_man = " + int.Parse(id) + "";
            if (sad == 3)
            command = "UPDATE Man SET nomHause_man = "+textBox6.Text+ " WHERE id_man = " + int.Parse(id) + "";

            bd.Uddate(command,1);
            this.Close();
        }
    }
}
