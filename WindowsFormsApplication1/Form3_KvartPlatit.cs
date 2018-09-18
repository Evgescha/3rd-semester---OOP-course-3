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
    public partial class Form3_KvartPlatit : Form
    {
        string kvart;
        string command;
        Class1_BD bd = new Class1_BD();
        public Form3_KvartPlatit(string kvartNom)
        {
            InitializeComponent();
            kvart = kvartNom;
            bd.ConStr();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            command = "UPDATE Hause  SET  ispSvet_hs = " + textBox1.Text + ", ispGas_hs =" + textBox2.Text + " , ispWater_hs  =  " + textBox3.Text + ", thisMoney = thisMoney + " + textBox4.Text + "  WHERE nomHause_hs='"+ kvart+"' ";
            //MessageBox.Show(command);
            bd.Uddate(command,1);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            command = "SELECT * FROM  Hause WHERE nomHause_hs='" + kvart + "'";
            MessageBox.Show( bd.Messag(command, "prevMontMoney_hs"));
        }

        private void button3_Click(object sender, EventArgs e)
        {
            command = "SELECT * FROM  Hause WHERE nomHause_hs='" + kvart + "'";
            MessageBox.Show( bd.Messag(command, "thisMoney"));
        }
    }
}
