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
    public partial class adminUS : Form
    {
        DATAB dataBase = new DATAB();
       
        public adminUS()
        {
            InitializeComponent();
            StartPosition = FormStartPosition.CenterScreen;
            string query = $"SELECT * FROM [Агентство недвижимости].dbo.[Пользователи]";
            SqlCommand command = new SqlCommand(query, dataBase.getConnection());
            SqlDataAdapter adapter = new SqlDataAdapter(command);
            DataTable dataTable = new DataTable();
            adapter.Fill(dataTable);

            dataGridView1.DataSource = dataTable;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Hide();
            ADMIN aDMIN = new ADMIN();
            aDMIN.ShowDialog();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void adminUS_Load(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {

            try
            {
              
                if (dataGridView1.SelectedRows.Count > 0)
                {
                    int id = Convert.ToInt32(dataGridView1.SelectedRows[0].Cells["Код пользователя"].Value);
                    string queryDEL = $"DELETE FROM [Пользователи] WHERE [Код пользователя] = {id}";
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
    }
}
