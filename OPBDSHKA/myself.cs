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
    public partial class myself : Form
    {
        DATAB dataBase = new DATAB();
        public myself()
        {
            InitializeComponent();
            StartPosition = FormStartPosition.CenterScreen;
            string queryID = $"Select [Код пользователя] from Пользователи where Логин = '{Form1.loginUSER}' and Пароль = '{Form1.passUSER}'";
            SqlCommand commandID = new SqlCommand(queryID, dataBase.getConnection());
            dataBase.openConnection();
            int usID = Convert.ToInt32(commandID.ExecuteScalar());
            dataBase.closeConnection();

            string query = $"SELECT * FROM [Агентство недвижимости].dbo.[Квартиры] Where [Код продавца] = {usID}";
            SqlCommand command = new SqlCommand(query, dataBase.getConnection());
            SqlDataAdapter adapter = new SqlDataAdapter(command);
            DataTable dataTable = new DataTable();
            adapter.Fill(dataTable);

            dataGridView1.DataSource = dataTable;
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
           
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Hide();
            Form4 form4 = new Form4();
            form4.ShowDialog();
        }
    }
}
