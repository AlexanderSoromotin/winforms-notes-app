using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Zametki_Bal_Kuz {
    public partial class RegistrationForm : Form {
        DB DB = new DB();

        public RegistrationForm() {
            InitializeComponent();
        }

        public static string ComputeMD5Hash(string input) {
            using (MD5 md5 = MD5.Create()) {
                byte[] inputBytes = Encoding.UTF8.GetBytes(input);
                byte[] hashBytes = md5.ComputeHash(inputBytes);

                // Преобразование байтов хеша в строку
                StringBuilder sb = new StringBuilder();
                for (int i = 0; i < hashBytes.Length; i++) {
                    sb.Append(hashBytes[i].ToString("x2")); // x2 обеспечивает двузначное шестнадцатеричное представление
                }

                return sb.ToString();
            }
        }

        private void buttonLogin_Click(object sender, EventArgs e) {
            // Регистрация

            DB.openConnection();
            string login = txtLogin.Text;
            string password = txtPassword.Text;

            MySqlDataAdapter adapter = new MySqlDataAdapter();
            DataTable table = new DataTable();

            string queryString = $"SELECT * FROM users WHERE login = '{login}'";

            MySqlCommand command = new MySqlCommand(queryString, DB.getConnection());

            adapter.SelectCommand = command;
            adapter.Fill(table);

            if (table.Rows.Count != 0) {
                // Такой логин уже есть в системе
                MessageBox.Show("Такой логин уже зарегистрирован в системе", "Ошибка входа", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else {
                DateTime currectDate = DateTime.Now;
                string token = ComputeMD5Hash(currectDate.ToString());

                var addQuery = $"insert into users (login, pass, token) values ('{login}', '{password}', '{token}')";
                var command2 = new MySqlCommand(addQuery, DB.getConnection());
                command2.ExecuteNonQuery();

                MySqlDataAdapter adapter2 = new MySqlDataAdapter();
                DataTable table2 = new DataTable();

                string queryString2 = $"SELECT * FROM users WHERE login = '{login}'";

                MySqlCommand command3 = new MySqlCommand(queryString2, DB.getConnection());

                adapter2.SelectCommand = command3;
                adapter2.Fill(table2);

                AppData.user_id = Convert.ToInt32(table2.Rows[0]["id_user"]);
                AppData.user_name = table2.Rows[0]["login"].ToString();
                AppData.setUserToken(table2.Rows[0]["token"].ToString());
                spisok spisok = new spisok();
                spisok.Show();
                Hide();
            }
            DB.closeConnection();
        }

        private void label4_Click(object sender, EventArgs e) {
            // У меня уже есть аккаунт
            loginForm LoginForm = new loginForm();
            LoginForm.Show();
            Hide();
        }
    }
}
