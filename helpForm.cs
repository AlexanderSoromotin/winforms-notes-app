using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace Zametki_Bal_Kuz
{
    public partial class helpForm : Form
    {
        DB DB = new DB();

        public helpForm()
        {
            InitializeComponent();
        }

        private void pictureBox_Back_Click(object sender, EventArgs e)
        {
            this.Hide();
            spisok spisok = new spisok();
            spisok.Show();
        }

        private void transactions_Click(object sender, EventArgs e)
        {

        }
    }
}
