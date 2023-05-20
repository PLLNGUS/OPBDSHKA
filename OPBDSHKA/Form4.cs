using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace OPBDSHKA
{

    enum RowState
    {
        Existed,
        New,
        Modified,
        ModifiedNew,
        Deleted
    }
    public partial class Form4 : Form
    {
        DATAB dataBase = new DATAB();
        int selectedRow;
        public Form4()
        {
            InitializeComponent();
            StartPosition = FormStartPosition.CenterScreen;
        }
        private void CreateColumns()
        {
         
           /* dataGridView1.Columns.Add("[Код квартиры]", "[Код квартиры]");
            dataGridView1.Columns.Add("[Район]", "[Район]");
            dataGridView1.Columns.Add("[Улица]", "[Улица]");
            dataGridView1.Columns.Add("[Номер дома]", "[Номер дома]");//3
            dataGridView1.Columns.Add("[Номер подъезда]", "[Номер подъезда]");
            dataGridView1.Columns.Add("[Номер квартиры]", "[Номер квартиры]");
            dataGridView1.Columns.Add("[Количество этажей]", "[Количество этажей]");//6
            dataGridView1.Columns.Add("[Этаж]", "[Этаж]");
            dataGridView1.Columns.Add("[Количество комнат]", "[Количество комнат]");
            dataGridView1.Columns.Add("[Площадь]", "[Площадь]");
            dataGridView1.Columns.Add("[Стоимость]", "[Стоимость]");
            dataGridView1.Columns.Add("[Код продавца]", "[Код продавца]");
            dataGridView1.Columns.Add("isNew", String.Empty);*/

        }
        private void ReadSingleRow(DataGridView dgw, IDataRecord record)
        {
/*            dgw.Rows.Add(record.GetInt32(0), record.GetString(1), record.GetString(2), record.GetInt32(3), record.GetInt32(4), record.GetInt32(5), record.GetInt32(6), record.GetInt32(7), record.GetInt32(8), record.GetDouble(9), record.GetDouble(10), record.GetInt32(11), RowState.ModifiedNew);
*/        }

        private void RefreshDataGrid(DataGridView dgw)
        {
           /* dgw.Rows.Clear();

            string querystring = $"select * from Квартиры";

            SqlCommand command = new SqlCommand(querystring, dataBase.getConnection());

            dataBase.openConnection();

            SqlDataReader reader = command.ExecuteReader();

            while (reader.Read()) { ReadSingleRow(dgw, reader); }

            reader.Close();*/
        }
        private void Form4_Load(object sender, EventArgs e)
        {
            string query = $"SELECT * FROM [Агентство недвижимости].dbo.[Квартиры]";
            SqlCommand command = new SqlCommand(query, dataBase.getConnection());
            SqlDataAdapter adapter = new SqlDataAdapter(command);
            DataTable dataTable = new DataTable();
            adapter.Fill(dataTable);

            dataGridView1.DataSource = dataTable;
            /*  CreateColumns();
              RefreshDataGrid(dataGridView1);*/
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            RefreshDataGrid(dataGridView1);
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Hide();
            dobav dobav = new dobav();
            dobav.ShowDialog();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            Form3 form3 = new Form3();
            form3.ShowDialog();

        }

        private void button4_Click(object sender, EventArgs e)
        {
            this.Hide();
            Form1 form1 = new Form1();
            form1.ShowDialog();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.Hide();
            myself myself = new myself();
            myself.ShowDialog();
        }

        private void dataGridView1_CellContentClick_1(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
