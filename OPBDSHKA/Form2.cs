using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace OPBDSHKA
{
    public partial class Form2 : Form
    {
        DATAB dataBase = new DATAB();
        
        
        
        public Form2()
        {
            InitializeComponent();
            StartPosition = FormStartPosition.CenterScreen;
            textBox7.UseSystemPasswordChar = true;
        }

        private void Form2_Load(object sender, EventArgs e)
        {
            
        }

        private void button1_Click(object sender, EventArgs e)
        {

            string name = textBox1.Text;
            string surname = textBox2.Text;
            string otchestvo = textBox3.Text;
            string pasport = maskedTextBox2.Text;
            string telephone = maskedTextBox1.Text;
            string loginUSER = textBox6.Text;
            string passUSER = textBox7.Text;
            string email = textBox8.Text;
            string role;
            if (checkBox1.Checked)
            {
                role = "seller";
            }
            else
            {
                role = "client";
            }
            


            string querystring = $"insert into Пользователи VALUES('{loginUSER}','{passUSER}','{role}','{email}');";
            string queryID = $"Select [Код пользователя] from Пользователи where Логин = '{loginUSER}' and Пароль = '{passUSER}'";
            SqlCommand commandID = new SqlCommand(queryID, dataBase.getConnection());
            SqlCommand command = new SqlCommand(querystring, dataBase.getConnection());


            dataBase.openConnection();
            if (textBox1.Text != "" && textBox2.Text != "" && maskedTextBox2.Text != "" && maskedTextBox1.Text != ""&& textBox6.Text != "" && textBox7.Text != "" && textBox8.Text != "")
            {
                if (command.ExecuteNonQuery() == 1)
                {
                    MessageBox.Show("Аккаунт успешно создан!", "Успех!");
                    int usID = Convert.ToInt32(commandID.ExecuteScalar());
                    if (checkBox1.Checked)
                    {
                        string querystring4 = $"insert into Продавцы VALUES({usID},'{surname}','{name}','{otchestvo}','{pasport}', '{telephone}');";

                        SqlCommand command1 = new SqlCommand(querystring4, dataBase.getConnection());
                        command1.ExecuteNonQuery();
                        Form1 form1 = new Form1();
                        this.Hide();
                        form1.ShowDialog();
                    }
                    else
                    {
                        string querystring2 = $"insert into Клиенты VALUES({usID},'{surname}','{name}','{otchestvo}','{pasport}', '{telephone}');";
                        SqlCommand command1 = new SqlCommand(querystring2, dataBase.getConnection());
                        command1.ExecuteNonQuery();
                        Form1 form1 = new Form1();
                        this.Hide();
                        form1.ShowDialog();
                    }


                                    }
                                    else
                                    {
                                        MessageBox.Show("Аккаунт не создан!");
                                    }

            }
            else
            {
                MessageBox.Show("Заполните все поля!", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            dataBase.closeConnection();
           

            
            
        }
            private Boolean checkuser()
            {
                var loginUSER = textBox6.Text;
                var passUSER = textBox7.Text;
                SqlDataAdapter adapter = new SqlDataAdapter();
            DataTable table = new DataTable();
            string querystring = $"Select Логин, Пароль, Роль, Почта FROM Пользователи where Логин = '{loginUSER}' and Пароль = '{passUSER}'";

            SqlCommand command = new SqlCommand(querystring, dataBase.getConnection());
            adapter.SelectCommand = command;
            adapter.Fill(table);
            if(table.Rows.Count > 0 )  { MessageBox.Show("Такой пользователь уже существует!"); return true;}
            else { return false; };
            
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            this.Hide();
            Form1 form1 = new Form1();
            form1.ShowDialog();
        }

        private void button2_Click(object sender, EventArgs e)
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

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void StretchImage(object sender, EventArgs e)
        {

        }

        private void maskedTextBox1_MaskInputRejected(object sender, MaskInputRejectedEventArgs e)
        {

        }
    }
}
