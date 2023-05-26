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
using System.Xml.Linq;

namespace OPBDSHKA
{
    public partial class adminDEAL : Form
    {
        DATAB dataBase = new DATAB();
        private int idclient;
        public adminDEAL()
        {
            InitializeComponent();
            StartPosition = FormStartPosition.CenterScreen;
        }
        public adminDEAL(int idclient)
        {
            InitializeComponent();
            this.idclient = idclient;
        }

        private void adminDEAL_Load(object sender, EventArgs e)
        {

            StartPosition = FormStartPosition.CenterScreen;
            string queryDAT = $"EXEC [Поиск квартир по заявке] {adminORD.idORDER}";
            SqlCommand command = new SqlCommand(queryDAT, dataBase.getConnection());
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
            ADMIN aDMIN = new ADMIN();
            aDMIN.ShowDialog();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            try
            {

            if (dataGridView1.SelectedRows.Count > 0)
            {
                string queryID = $"Select [Код пользователя] from Пользователи where Логин = '{Form1.loginUSER}' and Пароль = '{Form1.passUSER}'";
                SqlCommand commandID = new SqlCommand(queryID, dataBase.getConnection());
                dataBase.openConnection();
                int usID = Convert.ToInt32(commandID.ExecuteScalar());
                dataBase.closeConnection();

                int idFLAT = Convert.ToInt32(dataGridView1.SelectedRows[0].Cells["Код квартиры"].Value);
              
                int COST = Convert.ToInt32(dataGridView1.SelectedRows[0].Cells["Стоимость"].Value);

                string queryRED = $"insert into Сделки VALUES({idFLAT},{usID}, {idclient}, getdate(), {0.3 * COST}) ";

                SqlCommand commandRED = new SqlCommand(queryRED, dataBase.getConnection());
                DialogResult result = MessageBox.Show("Вы уверены, что оформить сделку?",
                                                              "Подтверждение принятия",
                                                              MessageBoxButtons.YesNo,
                                                              MessageBoxIcon.Question);

                if (result == DialogResult.Yes)
                {
                    // Удаляем строку из базы данных
                    dataBase.openConnection();
                    commandRED.ExecuteNonQuery();
                    dataBase.closeConnection();

                    MessageBox.Show("Сделка успешно оформлена!!", "Успех", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    this.Hide();
                    adminDEAL adminDEAL = new adminDEAL();
                    adminDEAL.ShowDialog();
                }
             }
            }
            catch (Exception ex) { MessageBox.Show(ex.Message); }
        }
    }
}
