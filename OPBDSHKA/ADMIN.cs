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
    public partial class ADMIN : Form
    {
        DATAB dataBase = new DATAB();
        public ADMIN()
        {
            InitializeComponent();
            StartPosition = FormStartPosition.CenterScreen;
        }

        private void button5_Click(object sender, EventArgs e)
        {
            this.Hide();
            adminCAB adminCAB = new adminCAB();
            adminCAB.ShowDialog();
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
            adminKV adminKV = new adminKV();
            adminKV.ShowDialog();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Hide();
            adminUS adminUS = new adminUS();
            adminUS.ShowDialog();

        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Hide();
            adminORD adminORD = new adminORD();
            adminORD.ShowDialog();
        }
    }
}
