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
using MySql.Data.MySqlClient;

namespace Zametki_Bal_Kuz
{
    public partial class loginForm : Form
    {
        DB DB = new DB();
        public loginForm()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            txtLogin.MaxLength = 50;
            txtPassword.MaxLength = 50;
        }
        
        private void buttonLogin_Click(object sender, EventArgs e)
        {
            var login = txtLogin.Text;
            var pass = txtPassword.Text;

            MySqlDataAdapter adapter = new MySqlDataAdapter();
            DataTable table = new DataTable();

            string queryString = $"SELECT * FROM users WHERE login = '{login}' AND pass = '{pass}'";

            MySqlCommand command = new MySqlCommand(queryString, DB.getConnection());

            adapter.SelectCommand = command;
            adapter.Fill(table);

            if(table.Rows.Count == 1)
            {
                AppData.user_id = Convert.ToInt32(table.Rows[0]["id_user"]);
                spisok spisok = new spisok();
                spisok.Show();
                Hide();
            }
            else 
            {
                MessageBox.Show("Неправильный логин или пароль!", "Ошибка входа", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }
    }
}
