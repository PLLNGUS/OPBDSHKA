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
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace OPBDSHKA
{
    public partial class Applic : Form
    {
        DATAB dataBase = new DATAB();
        private int usId;
        public Applic()
        {
            InitializeComponent();
            StartPosition = FormStartPosition.CenterScreen;
          
        }

        private void Applic_Load(object sender, EventArgs e)
        {
            string queryDIS = $"Select Distinct Район FROM Квартиры";
           SqlCommand cmd = new SqlCommand(queryDIS, dataBase.getConnection());
            dataBase.openConnection();
            SqlDataReader reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                comboBox1.Items.Add(func(reader));
            }
            reader.Close();
            dataBase.closeConnection();
        }
        private string func(IDataReader reader)
        {
            string perem = reader.GetString(0);
            return perem;
        }
        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
          
        

        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Hide();
            ClientForm clientForm = new ClientForm();
            clientForm.ShowDialog();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                int Wrooms = Convert.ToInt32(textBox4.Text);
            double Cost = Convert.ToDouble(textBox1.Text);
            string Distinct = comboBox1.SelectedItem.ToString();
            string status = "Активный";
                DateTime currentDate = DateTime.Now.Date;
                string queryID = $"Select [Код пользователя] from Пользователи where Логин = '{Form1.loginUSER}' and Пароль = '{Form1.passUSER}'";
            SqlCommand commandID = new SqlCommand(queryID, dataBase.getConnection());
            dataBase.openConnection();
            int usID = Convert.ToInt32(commandID.ExecuteScalar());
            dataBase.closeConnection();

            string queryDOB = $"Insert into Заявки VALUES({usID}, GetDate(), {Cost},'{Distinct}',{Wrooms},'{status}')";
            var commandDOB = new SqlCommand(queryDOB, dataBase.getConnection());
            dataBase.openConnection();
            
                if (commandDOB.ExecuteNonQuery() == 1)
                {
                    MessageBox.Show("Заявка успешно создана!!", "Успех!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
                else {

                }
                    dataBase.closeConnection();
      
            this.Hide();

                     } catch (Exception ex) { MessageBox.Show(ex.Message); }


        }

        private void textBox4_TextChanged(object sender, EventArgs e)
        {

        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}
