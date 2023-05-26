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
    public partial class adminORD : Form
    {
        public static int idORDER;
        DATAB dataBase = new DATAB();
        public adminORD()
        {
            InitializeComponent();
            StartPosition = FormStartPosition.CenterScreen;

            string query = $"SELECT * FROM [Агентство недвижимости].dbo.[Заявки]";
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
            ADMIN aDMIN = new ADMIN();
            aDMIN.Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            try
            {

                if (dataGridView1.SelectedRows.Count > 0)
                {
                    int id = Convert.ToInt32(dataGridView1.SelectedRows[0].Cells["Код заявки"].Value);
                    string queryDEL = $"DELETE FROM [Заявки] WHERE [Код заявки] = {id}";
                    SqlCommand commandDEL = new SqlCommand(queryDEL, dataBase.getConnection());

                    DialogResult result = MessageBox.Show("Вы уверены, что хотите удалить выбранную строку?",
                                                           "Подтверждение удаления",
                                                           MessageBoxButtons.YesNo,
                                                           MessageBoxIcon.Question);

                    if (result == DialogResult.Yes)
                    {
                        // Удаляем строку из базы данных
                        dataBase.openConnection();
                        commandDEL.ExecuteNonQuery();
                        dataBase.closeConnection();

                        // Удаляем строку из DataGridView
                        dataGridView1.Rows.RemoveAt(dataGridView1.SelectedRows[0].Index);

                        MessageBox.Show("Строка успешно удалена.", "Успех", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка при удалении строки: {ex.Message}", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void adminORD_Load(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {
            try
            {
                if (dataGridView1.SelectedRows.Count > 0)
                {
                    string stat = "Рассматривается";

                    idORDER = Convert.ToInt32(dataGridView1.SelectedRows[0].Cells["Код заявки"].Value);

                    string queryRED = $"UPDATE  [Заявки] SET Статус = '{stat}' WHERE [Код заявки] = {idORDER}";

                    SqlCommand commandRED = new SqlCommand(queryRED, dataBase.getConnection());
                    DialogResult result = MessageBox.Show("Вы уверены, что принять заявку?",
                                                                  "Подтверждение принятия",
                                                                  MessageBoxButtons.YesNo,
                                                                  MessageBoxIcon.Question);

                    int IDclient = Convert.ToInt32(dataGridView1.SelectedRows[0].Cells["Код клиента"].Value);

                    if (result == DialogResult.Yes)
                    {
                        // Удаляем строку из базы данных
                        dataBase.openConnection();
                        commandRED.ExecuteNonQuery();
                        dataBase.closeConnection();

                        // Удаляем строку из DataGridView
                        dataGridView1.Rows.RemoveAt(dataGridView1.SelectedRows[0].Index);

                        MessageBox.Show("Строка успешно изменена.", "Успех", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        this.Hide();
                        adminDEAL adminDEAL = new adminDEAL(IDclient);
                        adminDEAL.ShowDialog();
                    }
                }
             }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка при изменении строки: {ex.Message}", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
                      
}
    }

