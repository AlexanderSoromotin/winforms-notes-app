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
using static System.Net.Mime.MediaTypeNames;


namespace Zametki_Bal_Kuz
{
    public partial class money : Form
    {
        DB DB = new DB();
        decimal totalIncome = 0;
        decimal totalExpense = 0;
        decimal monthlyIncome = 0;
        decimal monthlyExpense = 0;
        decimal totalBalance = 0;
        decimal monthlyBalance = 0;

        public money()
        {
            InitializeComponent();
        }
        public void GetBalance()
        {
            DB.openConnection();
            MySqlCommand cmd = new MySqlCommand("CalculateIncomeExpenseDifference", DB.getConnection());
            cmd.CommandType = CommandType.StoredProcedure;

            cmd.Parameters.AddWithValue("@userId", AppData.user_id);

            cmd.Parameters.Add(new MySqlParameter("@totalIncome", MySqlDbType.Decimal));
            cmd.Parameters["@totalIncome"].Direction = ParameterDirection.Output;

            cmd.Parameters.Add(new MySqlParameter("@totalExpense", MySqlDbType.Decimal));
            cmd.Parameters["@totalExpense"].Direction = ParameterDirection.Output;

            cmd.Parameters.Add(new MySqlParameter("@monthlyIncome", MySqlDbType.Decimal));
            cmd.Parameters["@monthlyIncome"].Direction = ParameterDirection.Output;

            cmd.Parameters.Add(new MySqlParameter("@monthlyExpense", MySqlDbType.Decimal));
            cmd.Parameters["@monthlyExpense"].Direction = ParameterDirection.Output;

            cmd.ExecuteNonQuery();

            totalIncome = (decimal)cmd.Parameters["@totalIncome"].Value;
            totalExpense = (decimal)cmd.Parameters["@totalExpense"].Value;
            monthlyIncome = (decimal)cmd.Parameters["@monthlyIncome"].Value;
            monthlyExpense = (decimal)cmd.Parameters["@monthlyExpense"].Value;
            totalBalance = totalIncome - totalExpense;
            monthlyBalance = monthlyIncome - monthlyExpense;
        }

        private void LoadIncomes()
        {
            // Здесь вы должны выполнить запрос к базе данных,
            // чтобы получить задачи для выбранной даты
            string query = $"SELECT date AS 'Дата', amount AS 'Сумма', description AS 'Описание' FROM transactions WHERE id_user = {AppData.user_id} and is_income = 1";
            MySqlCommand command = new MySqlCommand(query, DB.getConnection());

            MySqlDataAdapter adapter = new MySqlDataAdapter(command);
            DataTable dataTable = new DataTable();
            adapter.Fill(dataTable);

            // Отобразите результаты запроса в DataGridView
            dgw_income.DataSource = dataTable;
        }

        private void LoadExpenses()
        {
            // Здесь вы должны выполнить запрос к базе данных,
            // чтобы получить задачи для выбранной даты
            string query = $"SELECT date AS 'Дата', amount AS 'Сумма', description AS 'Описание' FROM transactions WHERE id_user = {AppData.user_id} and is_income = 0";
            MySqlCommand command = new MySqlCommand(query, DB.getConnection());

            MySqlDataAdapter adapter = new MySqlDataAdapter(command);
            DataTable dataTable = new DataTable();
            adapter.Fill(dataTable);

            // Отобразите результаты запроса в DataGridView
            dgw_expenses.DataSource = dataTable;
        }

        private void money_Load(object sender, EventArgs e)
        {
            DB.openConnection();
            GetBalance();
            LoadIncomes();
            LoadExpenses();

            label_income_total.Text = totalBalance.ToString();
            label_income_month.Text = monthlyIncome.ToString();

            label_expense_total.Text = totalBalance.ToString();
            label_expense_month.Text = monthlyExpense.ToString();

            DB.closeConnection();
        }

        private void pictureBox_Back_Click(object sender, EventArgs e)
        {
            this.Hide();
            spisok spisok = new spisok();
            spisok.Show();
        }
        private void add_income_button_Click(object sender, EventArgs e)
        {
            DB.openConnection();

            var amount = income_amont_txtbox.Text;
            var date = date_income.Value.ToString("yyyy-MM-dd HH:mm:ss");
            var description = income_description.Text;

            if (!string.IsNullOrWhiteSpace(amount) && !string.IsNullOrWhiteSpace(date) && !string.IsNullOrWhiteSpace(description))
            {
                var addQuery = $"insert into transactions (id_user, amount, date, is_income, description) values ('{AppData.user_id}', '{amount}', '{date}', {1}, '{description}')";

                var command = new MySqlCommand(addQuery, DB.getConnection());
                command.ExecuteNonQuery();

                MessageBox.Show("Доход записан!", "Успех)", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                income_amont_txtbox.Text = "";
               // date_income.Text;
                income_description.Text = "";
            }

            else
            {
                MessageBox.Show("Заполните поля!", "Ошибка!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            DB.closeConnection();

        }

        private void add_expense_button_Click(object sender, EventArgs e)
        {
            DB.openConnection();

            var amount = expense_amont_txtbox.Text;
            var date = date_expense.Value.ToString("yyyy-MM-dd HH:mm:ss");
            var description = expense_description.Text;

            if (!string.IsNullOrWhiteSpace(amount) && !string.IsNullOrWhiteSpace(date) && !string.IsNullOrWhiteSpace(description))
            {
                var addQuery = $"insert into transactions (id_user, amount, date, is_income, description) values ('{AppData.user_id}', '{amount}', '{date}', {0}, '{description}')";

                var command = new MySqlCommand(addQuery, DB.getConnection());
                command.ExecuteNonQuery();

                MessageBox.Show("Расход записан!", "Успех)", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                expense_amont_txtbox.Text = "";
                // date_expense.Text;
                expense_description.Text = "";
            }

            else
            {
                MessageBox.Show("Заполните поля!", "Ошибка!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            DB.closeConnection();
        }

        private void date_expense_ValueChanged(object sender, EventArgs e)
        {

        }

        private void label12_Click(object sender, EventArgs e)
        {

        }

        private void expense_description_TextChanged(object sender, EventArgs e)
        {

        }

        private void label13_Click(object sender, EventArgs e)
        {

        }

        private void expense_amont_txtbox_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
