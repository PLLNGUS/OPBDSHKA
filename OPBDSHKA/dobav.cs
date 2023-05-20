using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace OPBDSHKA
{
    public partial class dobav : Form
    {
        DATAB dataBase = new DATAB();
        public dobav()
        {
            InitializeComponent();
            StartPosition = FormStartPosition.CenterScreen;

            
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Hide();
            Form4 form4 = new Form4();
            form4.ShowDialog();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {

            dataBase.openConnection();
            string District = textBox1.Text;
            string Street = textBox2.Text;
            int Nhouse = Convert.ToInt32(textBox3.Text);
            int Npod = Convert.ToInt32(textBox4.Text);
            int Nflat = Convert.ToInt32(textBox8.Text);

            int KolFlats = Convert.ToInt32(textBox7.Text);
                int etazh = Convert.ToInt32(textBox6.Text);
                if (etazh> KolFlats)
                {
                    MessageBox.Show("Нет такого этажа!!");
                    return;
                }

            int KolRooms = Convert.ToInt32(textBox5.Text);
            int Square = Convert.ToInt32(textBox9.Text);
            double Cost = Convert.ToDouble(textBox10.Text);
          

            string queryID = $"Select [Код пользователя] from Пользователи where Логин = '{Form1.loginUSER}' and Пароль = '{Form1.passUSER}'";
            SqlCommand commandID = new SqlCommand(queryID, dataBase.getConnection());
            dataBase.openConnection();
            int usID = Convert.ToInt32(commandID.ExecuteScalar());
            dataBase.closeConnection();
            dataBase.openConnection();
            if (double.TryParse(textBox10.Text, out Cost))
            {

            var addQuery = $"insert into Квартиры VALUES('{District}','{Street}',{Nhouse},{Npod},{Nflat},{KolFlats},{etazh},{KolRooms},{Square},{Cost}, {usID})";
            var command = new SqlCommand(addQuery, dataBase.getConnection());
                dataBase.openConnection();
                command.ExecuteNonQuery();
            MessageBox.Show("Запись успешно создана!!", "Успех!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                dataBase.closeConnection();
            }
            else
            {
                MessageBox.Show("Цена должна числовой формат!", "Ошибка!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            dataBase.closeConnection();
            this.Hide();
            Form4 form4 = new Form4();
            form4.ShowDialog();
            }
            catch (Exception ex) { MessageBox.Show(ex.Message); }
        }



        private void dobav_Load(object sender, EventArgs e)
        {

        }

        private void textBox6_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox8_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
