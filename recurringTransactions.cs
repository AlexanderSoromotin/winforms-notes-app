using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;

using System.Windows.Forms;
using static System.Net.Mime.MediaTypeNames;
using System.Runtime.InteropServices.ComTypes;

namespace Zametki_Bal_Kuz
{
    public partial class recurringTransactions : Form

    {
        DB DB = new DB();
        int transactionId = 0;
        int amount = 0;
        int frequency = 0;
        int is_income = 0;
        string description = "";
        string startDate = "";

        public recurringTransactions(int id)
        {
            InitializeComponent();
            transactionId = id;
            loadTransactionData();
        }

        private void loadTransactionData() {
            // Получение информации о выбранной повторяющейся транзакции
            DB.openConnection();

            string query = $"SELECT * FROM recurring_transactions WHERE id = {transactionId}";
            MySqlCommand command = new MySqlCommand(query, DB.getConnection());

            MySqlDataAdapter adapter = new MySqlDataAdapter(command);
            DataTable dataTable = new DataTable();
            adapter.Fill(dataTable);

            amount = Convert.ToInt32(dataTable.Rows[0]["amount"]);
            frequency = Convert.ToInt32(dataTable.Rows[0]["frequency"]);
            is_income = Convert.ToInt32(dataTable.Rows[0]["is_income"]);
            description = dataTable.Rows[0]["description"].ToString();
            startDate = dataTable.Rows[0]["startDate"].ToString();

            recurringTransactionAmount.Text = amount.ToString();
            dateRecurringTransaction.Text = startDate;
            frequencyTextBox.Text = frequency.ToString();
            recurringTransactionDescription.Text = description;

            DB.closeConnection();
        }

        private void add_income_button_Click(object sender, EventArgs e) {
            // Сохранение регулярных транзакций

            DB.openConnection();
            int amount = Convert.ToInt32(recurringTransactionAmount.Text);
            var startDate = dateRecurringTransaction.Value.ToString("yyyy-MM-dd HH:mm:ss");
            int frequency = Convert.ToInt32(frequencyTextBox.Text);
            var text = recurringTransactionDescription.Text;
            int isIncome = 1;

            if (amount < 0) {
                isIncome = 0;
            }

            var addQuery = $"update recurring_transactions set amount = {amount}, startDate = '{startDate}', is_income = {isIncome}, description = '{text}', frequency = {frequency} where id = {transactionId}";

            var command = new MySqlCommand(addQuery, DB.getConnection());
            command.ExecuteNonQuery();

            DB.closeConnection();

            this.Hide();
            money form = new money();
            form.Show();
        }

        private void pictureBox_Back_Click(object sender, EventArgs e) {
            // Возврат на предыдущую форму
            this.Hide();
            money form = new money();
            form.Show();
        }
    }
}
