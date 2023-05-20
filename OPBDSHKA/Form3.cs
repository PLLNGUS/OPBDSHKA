using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.Design;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace OPBDSHKA
{
    public partial class Form3 : Form
    {
        DATAB dataBase = new DATAB();
       
        public Form3()
        {
            InitializeComponent();
            StartPosition = FormStartPosition.CenterScreen;
        }
       

       
        private void Form3_Load(object sender, EventArgs e)
        {
            
            string queryID = $"Select [Код пользователя] from Пользователи where Логин = '{Form1.loginUSER}' and Пароль = '{Form1.passUSER}'";
            SqlCommand commandID = new SqlCommand(queryID, dataBase.getConnection());
            dataBase.openConnection();
            int usID = Convert.ToInt32(commandID.ExecuteScalar());
            dataBase.closeConnection();

            string query = $"Select [Имя] from Продавцы where [Код продавца] = {usID}";
            SqlCommand command1 = new SqlCommand(query, dataBase.getConnection());
            dataBase.openConnection();
            string name = Convert.ToString(command1.ExecuteScalar());
            dataBase.closeConnection();


            string query2 = $"Select [Фамилия] from Продавцы where [Код продавца] = {usID}";
            SqlCommand command2 = new SqlCommand(query2, dataBase.getConnection());
            dataBase.openConnection();
            string surname = Convert.ToString(command2.ExecuteScalar());
            dataBase.closeConnection();


            string query3 = $"Select [Отчество] from Продавцы where [Код продавца] = {usID}";
            SqlCommand command3 = new SqlCommand(query3, dataBase.getConnection());
            dataBase.openConnection();
            string otchestvo = Convert.ToString(command3.ExecuteScalar());
            dataBase.closeConnection();

            string query4 = $"Select [Паспорт] from Продавцы where [Код продавца] = {usID}";
            SqlCommand command4 = new SqlCommand(query4, dataBase.getConnection());
            dataBase.openConnection();
            string pasport = Convert.ToString(command4.ExecuteScalar());
            dataBase.closeConnection();

            string query5 = $"Select [Телефон] from Продавцы where [Код продавца] = {usID}";
            SqlCommand command5 = new SqlCommand(query5, dataBase.getConnection());
            dataBase.openConnection();
            string telephone = Convert.ToString(command5.ExecuteScalar());
            dataBase.closeConnection();

            string query6 = $"Select [Логин] from Пользователи where [Код пользователя] = {usID}";
            SqlCommand command6 = new SqlCommand(query6, dataBase.getConnection());
            dataBase.openConnection();
            string loginCL = Convert.ToString(command6.ExecuteScalar());
            dataBase.closeConnection();

            string query7 = $"Select [Почта] from Пользователи where [Код пользователя] = {usID}";
            SqlCommand command7 = new SqlCommand(query7, dataBase.getConnection());
            dataBase.openConnection();
            string emailCL = Convert.ToString(command7.ExecuteScalar());
            dataBase.closeConnection();

            label1.Text = name;
            label2.Text = surname;
            label3.Text = otchestvo;
            label4.Text = pasport;
            label5.Text = telephone;
            label6.Text = loginCL;
            label7.Text = emailCL;

        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Hide();
        }
    }
}
