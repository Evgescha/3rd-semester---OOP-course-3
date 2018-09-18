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
    public partial class Form6_MoneyPlusMinus : Form
    {       
        int gas = 0, water = 0, light = 0, prev = 0, thism = 0, money = 0;
        int moneyGas = 0, moneyLight = 0, moneyWater = 0;  
        Class1_BD bd = new Class1_BD();
        string command;
        public Form6_MoneyPlusMinus()
        {
            InitializeComponent();
            bd.ConStr();
            GridLoad();
        }
        private void GridLoad()
        {
            command = "SELECT nomHause_hs, plosh_hs, kollKomn_hs, ispSvet_hs, ispGas_hs, ispWater_hs, prevMontMoney_hs, thisMontMoney_hs, thisMoney FROM Hause";
            bd.SelectGridPlus(command, dataGridView1);
            AddLabel();
        }

        private void Form6_MoneyPlusMinus_Load(object sender, EventArgs e)
        {
            
        }
        private void button1_Click(object sender, EventArgs e)
        {
            command = "SELECT * FROM Dom";
            moneyWater = int.Parse(bd.Messag(command, "stWater_dom"));
            moneyLight = int.Parse(bd.Messag(command, "stSvet_dom"));
            moneyGas = int.Parse(bd.Messag(command, "stGas_dom"));

            for (int i = 0; i < dataGridView1.RowCount - 1; i++)
            {
                int l = (moneyLight * int.Parse(dataGridView1[3, i].Value.ToString()));
                int g = (moneyGas * int.Parse(dataGridView1[4, i].Value.ToString()));
                int w = (moneyWater * int.Parse(dataGridView1[5, i].Value.ToString()));
                int step = l + g + w;
                //MessageBox.Show(step.ToString());
                dataGridView1[7, i].Value = step;
                command = "Update Hause SET thisMontMoney_hs = " + step + " WHERE nomHause_hs = '" + dataGridView1[0, i].Value.ToString() +"' ";
                bd.Uddate(command,0);
                
            }

        }
        private void button2_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < dataGridView1.RowCount - 1; i++)
            {
                command = "Update Hause SET thisMoney = thisMoney - "+ dataGridView1[7, i].Value.ToString() + " WHERE nomHause_hs = '" + dataGridView1[0, i].Value.ToString() + "' ";
                //MessageBox.Show(command);
                bd.Uddate(command, 0);
                command = "Update Hause SET prevMontMoney_hs = thisMontMoney_hs WHERE nomHause_hs = '" + dataGridView1[0, i].Value.ToString() + "' ";
                //MessageBox.Show(command);
                bd.Uddate(command, 0);
                command = "Update Hause SET thisMontMoney_hs = 0 WHERE nomHause_hs = '" + dataGridView1[0, i].Value.ToString() + "' ";
                //MessageBox.Show(command);
                bd.Uddate(command, 0);
            }
            GridLoad();
        }
        public void AddLabel()
        {
            for (int i = 0; i < dataGridView1.RowCount-1; i++)
            {
                light += int.Parse(dataGridView1[3, i].Value.ToString());
                gas += int.Parse(dataGridView1[4, i].Value.ToString());
                water += int.Parse(dataGridView1[5, i].Value.ToString());
                prev += int.Parse(dataGridView1[6, i].Value.ToString());
                thism += int.Parse(dataGridView1[7, i].Value.ToString());
                money += int.Parse(dataGridView1[8, i].Value.ToString());
            }
            label9.Text = light.ToString();
            label10.Text = gas.ToString();
            label11.Text = water.ToString();
          
            label13.Text = prev.ToString();
            label14.Text = thism.ToString();
            label15.Text = money.ToString();
        }
    }
}
