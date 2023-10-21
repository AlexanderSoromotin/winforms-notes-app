using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.Remoting.Metadata.W3cXsd2001;
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

        int goalMonthlyPaymentAmount = 0;
        int goalAccumulatedAmount = 0;
        int goalAmount = 0;

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

            label_income_total.Text = totalBalance.ToString() + " ₽";
            label_income_month.Text = monthlyIncome.ToString() + " ₽";

            label_expense_total.Text = totalBalance.ToString() + " ₽";
            label_expense_month.Text = monthlyExpense.ToString() + " ₽";
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
            loadRecurringTransactions();
            loadGoalTab();

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

                GetBalance();
                LoadIncomes();
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

                GetBalance();
                LoadExpenses();
            }

            else
            {
                MessageBox.Show("Заполните поля!", "Ошибка!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            DB.closeConnection();
        }

        private void loadGoalTab()
        {
            DB.openConnection();

            string query = $"SELECT * FROM goals WHERE id_user = {AppData.user_id}";
            MySqlCommand command = new MySqlCommand(query, DB.getConnection());

            MySqlDataAdapter adapter = new MySqlDataAdapter(command);
            DataTable dataTable = new DataTable();
            adapter.Fill(dataTable);

            if (dataTable.Rows.Count != 0)
            {
                // Цели есть и надо одну отобразить
                label1.Text = "Ваша цель";
                goalDescriptionTextBox.Text = dataTable.Rows[0]["name"].ToString();
                goalAmountTextBox.Text = dataTable.Rows[0]["accumulated"].ToString() + " из " + dataTable.Rows[0]["amount"].ToString();
                goalDueDateDateTimePicker.Text = dataTable.Rows[0]["due_date"].ToString();

                goalDescriptionTextBox.ReadOnly = true;
                goalAmountTextBox.ReadOnly = true;
                goalDueDateDateTimePicker.Enabled = false;

                goalAccumulatedAmount = Convert.ToInt32(dataTable.Rows[0]["accumulated"]);
                goalAmount = Convert.ToInt32(dataTable.Rows[0]["amount"]);

                goalMonthlyPaymentAmount = Convert.ToInt32(dataTable.Rows[0]["monthly_payment_amount"]);

                createGoalButton.Hide();
                createPaymentButton.Text = "Внести платёж (" + dataTable.Rows[0]["monthly_payment_amount"].ToString() + " ₽)";
                createPaymentButton.Show();
                cancelGoalButton.Show();

                // Текущая дата
                DateTime currentDate = DateTime.Now;
                DateTime lastPaymentDate = DateTime.Now;

                // Проверяем возможность внесения платежа
                if (dataTable.Rows[0]["last_payment_date"].ToString() == "")
                {
                    lastPaymentDate = currentDate.AddMonths(-2);
                }
                else
                {
                     lastPaymentDate = Convert.ToDateTime(dataTable.Rows[0]["last_payment_date"]);
                }

                TimeSpan difference = currentDate - lastPaymentDate;

                // Проверка, был ли платеж в прошлом месяце
                if (difference.Days >= 30)
                {
                    // Платеж был в прошлом месяце
                    createPaymentButton.Enabled = true;
                }
                else
                {
                    // Платеж не был в прошлом месяце
                    createPaymentButton.Enabled = false;
                }
            }
            else
            {
                // Целей нет
                label1.Text = "На что вы хотите накопить?";
                goalDescriptionTextBox.Text = "";
                goalAmountTextBox.Text = "";
                goalDueDateDateTimePicker.Text = "";

                goalDescriptionTextBox.ReadOnly = false;
                goalAmountTextBox.ReadOnly = false;
                goalDueDateDateTimePicker.Enabled = true;

                createGoalButton.Show();
                createPaymentButton.Hide();
                cancelGoalButton.Hide();
            }

            DB.closeConnection();
        }

        private void tabPage5_Click(object sender, EventArgs e)
        {
            loadGoalTab();
        }

        private void createGoalButton_Click(object sender, EventArgs e)
        {
            DB.openConnection();

            var description = goalDescriptionTextBox.Text;
            var amount = Convert.ToInt32(goalAmountTextBox.Text);
            var date = goalDueDateDateTimePicker.Value.ToString("yyyy-MM-dd HH:mm:ss");
            DateTime currentDate = DateTime.Now;

            int monthsApart = ((goalDueDateDateTimePicker.Value.Year - currentDate.Year) * 12) + goalDueDateDateTimePicker.Value.Month - currentDate.Month;
            var monthyPayment = amount / monthsApart;

            var addQuery = $"insert into goals (name, amount, due_date, id_user, monthly_payment_amount) values ('{description}', {amount}, '{date}', {AppData.user_id}, {monthyPayment})";

            var command = new MySqlCommand(addQuery, DB.getConnection());
            command.ExecuteNonQuery();
                
            MessageBox.Show("Цель успешно создана!", "Успех)", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            loadGoalTab();

            DB.closeConnection();
        }

        private void createPaymentButton_Click(object sender, EventArgs e)
        {
            // Создание платежа

            GetBalance();

            if (goalAccumulatedAmount >= goalAmount)
            {
                // Сумма для цели уже накоплена
                MessageBox.Show("Цель уже достигнута. Молодец!");

                // Удаляем цель, если она по какой-то причине ещё существует
                var addQuery = $"delete from goals where id_user = {AppData.user_id}";
                var command = new MySqlCommand(addQuery, DB.getConnection());
                command.ExecuteNonQuery();

                GetBalance();
                loadGoalTab();

                return;
            }

            if (totalBalance >= goalMonthlyPaymentAmount)
            {
                // Списание возможно. Деньги есть
                var addQuery = $"insert into transactions (id_user, amount, is_income, description) values ({AppData.user_id}, {goalMonthlyPaymentAmount}, 0, 'Списание на цель')";
                var command = new MySqlCommand(addQuery, DB.getConnection());
                command.ExecuteNonQuery();

                var addQuery2 = $"update goals set accumulated = accumulated + {goalMonthlyPaymentAmount}, last_payment_date = NOW()";
                var command2 = new MySqlCommand(addQuery2, DB.getConnection());
                command2.ExecuteNonQuery();

                GetBalance();
                LoadExpenses();
                loadGoalTab();

                createPaymentButton.Enabled = false;

                MessageBox.Show("Платёж внесён");
                if (goalAccumulatedAmount >= goalAmount)
                {
                    DB.openConnection();

                    // Сумма для цели уже накоплена
                    MessageBox.Show("Цель уже достигнута. Молодец!");

                    // Удаляем цель, если она по какой-то причине ещё существует
                    var addQuery3 = $"delete from goals where id_user = {AppData.user_id}";
                    var command3 = new MySqlCommand(addQuery3, DB.getConnection());
                    command3.ExecuteNonQuery();

                    GetBalance();
                    loadGoalTab();

                }
            }
            else
            {
                MessageBox.Show("Денег не хватает (Накопи ещё " + (goalMonthlyPaymentAmount - totalBalance).ToString() + " ₽)");
            }

            DB.closeConnection();
        }

        private void cancelGoalButton_Click(object sender, EventArgs e)
        {
            
            DB.openConnection();
            var addQuery2 = $"delete from goals where id_user = {AppData.user_id}";
            var command2 = new MySqlCommand(addQuery2, DB.getConnection());
            command2.ExecuteNonQuery();

            if (goalAccumulatedAmount != 0)
            {
                // Списание возможно. Деньги есть
                var addQuery = $"insert into transactions (id_user, amount, is_income, description) values ({AppData.user_id}, {goalAccumulatedAmount}, 1, 'Возврат накопленных денег')";
                var command = new MySqlCommand(addQuery, DB.getConnection());
                command.ExecuteNonQuery();
            }            

            GetBalance();
            loadGoalTab();
            LoadIncomes();
            LoadExpenses();

            DB.closeConnection();
        }
        private void checkRecurringTransactions()
        {
            string query = $"SELECT  FROM recurring_transactions WHERE id_user = {AppData.user_id}";
            MySqlCommand command = new MySqlCommand(query, DB.getConnection());

            MySqlDataAdapter adapter = new MySqlDataAdapter(command);
            DataTable dataTable = new DataTable();
            adapter.Fill(dataTable);

            DateTime currentDate = DateTime.Now;

            foreach (DataRow row in dataTable.Rows)
            {
                // DateTime transactionDate = Convert.ToDateTime(row[]);
            }
        }
        private void loadRecurringTransactions()
        {
            string query = $"SELECT amount AS 'Сумма', frequency AS 'Частота', description AS 'Описание' FROM recurring_transactions WHERE id_user = {AppData.user_id}";
            MySqlCommand command = new MySqlCommand(query, DB.getConnection());

            MySqlDataAdapter adapter = new MySqlDataAdapter(command);
            DataTable dataTable = new DataTable();
            adapter.Fill(dataTable);

            // Отобразите результаты запроса в DataGridView
            dgwRecurringTransactions.DataSource = dataTable;
        }
        private void createTransactionButton_Click(object sender, EventArgs e)
        {
            

            //recurringTransactions recur = new recurringTransactions();
            //recur.Show();
            //Hide();
        }
    }
}
// Записывать дату последнего платежа при создании платежа
// Проверять возможность внесения платежа
// Возможный баг: после создания цели, дата последнего платежа = null
