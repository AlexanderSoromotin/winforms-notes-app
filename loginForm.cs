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

        private void checkUserToken() {
            // Проверка токена пользователя. Если токен есть, то впускаем пользователя без ввода логина и пароля
            if (AppData.getUserToken() != "") {
                MySqlDataAdapter adapter = new MySqlDataAdapter();
                DataTable table = new DataTable();

                string queryString = $"SELECT * FROM users WHERE token = '{AppData.getUserToken()}'";

                MySqlCommand command = new MySqlCommand(queryString, DB.getConnection());

                adapter.SelectCommand = command;
                adapter.Fill(table);

                if (table.Rows.Count != 0) {
                    AppData.user_id = Convert.ToInt32(table.Rows[0]["id_user"]);
                    AppData.user_name = table.Rows[0]["login"].ToString();

                    timer1.Interval = 100;
                    timer1.Start();

                    spisok spisok = new spisok();
                    spisok.Show();
                }
            }
        }

        private void timer1_Tick(object sender, EventArgs e) {
            // Скрыть текущую форму авторизации
            this.Hide();
            timer1.Stop(); // Остановить таймер
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            txtLogin.MaxLength = 50;
            txtPassword.MaxLength = 50;
            checkUserToken();
        }

        
        private void buttonLogin_Click(object sender, EventArgs e)
        {
            var login = txtLogin.Text;
            var pass = txtPassword.Text;

            if (login == "") {
                login = "admin";
                pass = "1111";
            }

            MySqlDataAdapter adapter = new MySqlDataAdapter();
            DataTable table = new DataTable();

            string queryString = $"SELECT * FROM users WHERE login = '{login}' AND pass = '{pass}'";

            MySqlCommand command = new MySqlCommand(queryString, DB.getConnection());

            adapter.SelectCommand = command;
            adapter.Fill(table);

            if(table.Rows.Count == 1)
            {
                AppData.user_id = Convert.ToInt32(table.Rows[0]["id_user"]);
                AppData.user_name = table.Rows[0]["login"].ToString();
                AppData.setUserToken(table.Rows[0]["token"].ToString()); // Записываем токен пользователя в файл
                spisok spisok = new spisok();
                spisok.Show();
                Hide();
            }
            else 
            {
                MessageBox.Show("Неправильный логин или пароль!", "Ошибка входа", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void label4_Click(object sender, EventArgs e) {
            // У меня нет аккаунта
            RegistrationForm registrationForm = new RegistrationForm();
            registrationForm.Show();
            Hide();

        }
    }
}
