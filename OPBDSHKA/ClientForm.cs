using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Data.SqlClient;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Reflection.Emit;

namespace OPBDSHKA
{
    public partial class ClientForm : Form
    {
        DATAB dataBase = new DATAB();

        public ClientForm()
        {
            InitializeComponent();
            StartPosition = FormStartPosition.CenterScreen;
            
        }

        private void button5_Click(object sender, EventArgs e)
        {
            this.Hide();
            CabinetCLIENT clientC = new CabinetCLIENT();
            clientC.ShowDialog();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            this.Hide();
            Form1 form1 = new Form1();
            form1.ShowDialog();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Hide();
            Applic applic = new Applic();
            applic.ShowDialog();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.Hide();
            spisok spisok = new spisok();  
            spisok.ShowDialog();
        }

        private void ClientForm_Load(object sender, EventArgs e)
        {

        }
    }
}
