using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace OPBDSHKA
{
    public partial class Form1 : Form
    {
        public static string loginUSER;
        public static string passUSER;
        DATAB dataBase = new DATAB();
        public Form1()
        {
            InitializeComponent();
            StartPosition = FormStartPosition.CenterScreen;
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            textBox7.UseSystemPasswordChar = true;

        }

        private void textBox7_TextChanged(object sender, EventArgs e)
        {
            
        }

        private void button1_Click(object sender, EventArgs e)
        {
           
             loginUSER = textBox6.Text;
             passUSER = textBox7.Text;
            SqlDataAdapter adapter = new SqlDataAdapter();
            DataTable table = new DataTable();

            string querystring = $"Select Логин, Пароль, Роль, Почта FROM Пользователи where Логин = '{loginUSER}' and Пароль = '{passUSER}'";
            
            SqlCommand command = new SqlCommand(querystring, dataBase.getConnection());

            string queryROLE = $"Select Роль FROM Пользователи Where Логин = '{loginUSER}' and Пароль = '{passUSER}' ";
            SqlCommand commandROLE = new SqlCommand(queryROLE, dataBase.getConnection());
            dataBase.openConnection();
            string role = Convert.ToString(commandROLE.ExecuteScalar());
            dataBase.closeConnection();
           

            adapter.SelectCommand = command;
            adapter.Fill(table);
            if (table.Rows.Count == 1)
            {
                MessageBox.Show("Вы успешно вошли!", "Успешно!", MessageBoxButtons.OK, MessageBoxIcon.Information);

               if (role == "seller")
                {
                Form4 frm4 = new Form4();
                this.Hide();
                frm4.Show();
               
                }
               else if (role == "client")
                {
                    ClientForm frm = new ClientForm();
                    this.Hide();
                    frm.Show();
                    
                }
            }
            else
                MessageBox.Show("Такого аккаунта не существует!", "Аккаунта не существует!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
        }

        private void textBox6_TextChanged(object sender, EventArgs e)
        {

        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Form2 form2 = new Form2();
            this.Hide();
            form2.ShowDialog();
            

        }

        private void button2_Click(object sender, EventArgs e)
        {
           

        }

        private void button3_Click(object sender, EventArgs e)
        {
           
            
        }

        private void button2_Click_1(object sender, EventArgs e)
        {
            textBox7.UseSystemPasswordChar = false;
            button4.Visible = true;
            button2.Visible = false;

        }

        private void button4_Click(object sender, EventArgs e)
        {
            textBox7.UseSystemPasswordChar = true;
            button4.Visible = false;
            button2.Visible = true;
        }

        private void button3_Click_1(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
