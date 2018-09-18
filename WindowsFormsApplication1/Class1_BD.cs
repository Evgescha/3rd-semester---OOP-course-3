using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.OleDb;
using System.Windows.Forms;
using System.Data;

namespace WindowsFormsApplication1
{

    class Class1_BD
    {
        OleDbConnection connection = new OleDbConnection();
        
        //задать путь
        public void ConStr()
        {
            connection.ConnectionString = @"Provider=Microsoft.ACE.OLEDB.12.0;Data Source=bd.accdb;Persist Security Info = False; ";
        }
        //проверка  входа квартирантов
        public int LogIn(string com)
        {
            try
            {
                connection.Open();
                OleDbCommand command = new OleDbCommand();
                command.Connection = connection;
                command.CommandText = com;
                OleDbDataReader reader = command.ExecuteReader();
                int count = 0;
                while (reader.Read())
                {                    
                    count++;
                }
                if (count == 1) { MessageBox.Show("Вход выполнен успешно"); connection.Close(); return 1; }
                else { MessageBox.Show("Неправильный. Повторите еще раз"); connection.Close(); return 0; }

            }
            catch (Exception ex)
            {
                MessageBox.Show("FAIL" + ex);
                connection.Close();
                return 0;
            }
            return 0;
        }
       //обновить значение
        public void Uddate(string com, int mess)
        {
            try
            {
                connection.Open();

                OleDbCommand add = new OleDbCommand();
                add.Connection = connection;
                add.CommandText = com;
                add.ExecuteNonQuery();
                if (mess == 1) MessageBox.Show("успешно!");
                connection.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("FAIL" + ex);
                connection.Close();
            }
        }
        //получить ячейку значения
        public string Messag(string com, string wh)
        {
            try
            {
                connection.Open();

                OleDbCommand mes = new OleDbCommand();
                mes.Connection = connection;
                mes.CommandText = com;
                OleDbDataReader reader = mes.ExecuteReader();
                string massageString = "";
                while (reader.Read())
                {
                    massageString = reader[wh].ToString();
                }
               // MessageBox.Show(massageString);
                connection.Close();
                return massageString;
            }
            catch (Exception ex)
            {
                MessageBox.Show("FAIL" + ex);
                connection.Close();
                return "";
            }
        }
        //вывести данные в грид
        public void SelectGridPlus(string com, DataGridView dg)
        {
            try
            {
                connection.Open();

                OleDbCommand mes = new OleDbCommand();
                mes.Connection = connection;
                mes.CommandText = com;
                OleDbDataAdapter da = new OleDbDataAdapter(mes.CommandText, connection);
                DataTable dt = new DataTable();
                da.Fill(dt);
                dg.DataSource = dt;
                connection.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("FAIL" + ex);
                connection.Close();
            }
        }

    }
}
