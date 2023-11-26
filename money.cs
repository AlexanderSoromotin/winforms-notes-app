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
using static System.Windows.Forms.VisualStyles.VisualStyleElement.StartPanel;


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
        string goalName = "";

        public money()
        {
            InitializeComponent();
            checkRecurringTransactions();
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

            totalIncome = cmd.Parameters["@totalIncome"].Value != DBNull.Value ? Convert.ToDecimal(cmd.Parameters["@totalIncome"].Value) : 0;
            totalExpense = cmd.Parameters["@totalExpense"].Value != DBNull.Value ? Convert.ToDecimal(cmd.Parameters["@totalExpense"].Value) : 0;
            monthlyIncome = cmd.Parameters["@monthlyIncome"].Value != DBNull.Value ? Convert.ToDecimal(cmd.Parameters["@monthlyIncome"].Value) : 0;
            monthlyExpense = cmd.Parameters["@monthlyExpense"].Value != DBNull.Value ? Convert.ToDecimal(cmd.Parameters["@monthlyExpense"].Value) : 0;
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
            string query = $"SELECT date AS 'Дата', amount AS 'Сумма', description AS 'Описание' FROM transactions WHERE id_user = {AppData.user_id} and is_income = 1 order by id desc";
            MySqlCommand command = new MySqlCommand(query, DB.getConnection());

            MySqlDataAdapter adapter = new MySqlDataAdapter(command);
            DataTable dataTable = new DataTable();
            adapter.Fill(dataTable);

            // Отобразите результаты запроса в DataGridView
            dgw_income.DataSource = dataTable;
            dgw_income.Columns[2].Width = 280;
        }

        private void LoadExpenses()
        {
            // Здесь вы должны выполнить запрос к базе данных,
            // чтобы получить задачи для выбранной даты
            string query = $"SELECT date AS 'Дата', amount AS 'Сумма', description AS 'Описание' FROM transactions WHERE id_user = {AppData.user_id} and is_income = 0 order by id desc";
            MySqlCommand command = new MySqlCommand(query, DB.getConnection());

            MySqlDataAdapter adapter = new MySqlDataAdapter(command);
            DataTable dataTable = new DataTable();
            adapter.Fill(dataTable);

            // Отобразите результаты запроса в DataGridView
            dgw_expenses.DataSource = dataTable;
            dgw_expenses.Columns[2].Width = 280;
        }

        private void checkRecurringTransactions() {
            // Проверка повторяющихся транзакций
            string query = $"SELECT id, startDate, frequency, amount, description, DATEDIFF(DATE_ADD(startDate, INTERVAL frequency DAY), CURRENT_DATE) as 'date_diff' FROM recurring_transactions WHERE id_user = {AppData.user_id} order by id desc";
            MySqlCommand command = new MySqlCommand(query, DB.getConnection());

            MySqlDataAdapter adapter = new MySqlDataAdapter(command);
            DataTable dataTable = new DataTable();
            adapter.Fill(dataTable);

            DateTime currentDate = DateTime.Now;

            int changesCounter = 0;

            foreach (DataRow row in dataTable.Rows) {
                int frequency = Convert.ToInt32(row[2]);

                // MessageBox.Show(row[4] + ": " + row[5]);

                DateTime transactionDate = Convert.ToDateTime(row[1]);
                TimeSpan days = currentDate - transactionDate;

                if (Convert.ToInt32(row[5]) <= 0) {
                    // Разница между датами больше платёжного периода
                    // Записываем новую транзакцию

                    changesCounter++;

                    int amount = Convert.ToInt32(row[3]);
                    int is_income = 1;
                    string description = row[4].ToString();

                    if (amount < 0) {
                        // Сумма транзакции отрицательная, значит тип транзакции - расход
                        is_income = 0;
                    }
                    else if (amount == 0) {
                        // Если сумма транзакции = 0, то переходим к следующей
                        continue;
                    }

                    // Создание новой транзакции
                    var addQuery = $"insert into transactions (id_user, amount, is_income, description) values ({AppData.user_id}, {amount}, {is_income}, 'Повторяющаяся операция: {description}')";
                    var command2 = new MySqlCommand(addQuery, DB.getConnection());
                    command2.ExecuteNonQuery();

                    // Изменяем дату последнего выполнения повтояющейся транзакции
                    addQuery = $"update recurring_transactions set startDate = '{(transactionDate.AddDays(frequency)).ToString("yyyy-MM-dd HH:mm:ss")}' where id = {Convert.ToInt32(row[0])}";
                    var command3 = new MySqlCommand(addQuery, DB.getConnection());
                    command3.ExecuteNonQuery();
                }
            }

            if (changesCounter != 0) {
                GetBalance();
                LoadExpenses();
                LoadIncomes();

                // Запускаем проверку ещё раз, вдруг зарплата раз в месяц, а пользователь не заходил в приложение 2 месяца
                checkRecurringTransactions(); 
            }
        }

        private void loadGoalTab() {
            DB.openConnection();

            string query = $"SELECT * FROM goals WHERE id_user = {AppData.user_id}";
            MySqlCommand command = new MySqlCommand(query, DB.getConnection());

            MySqlDataAdapter adapter = new MySqlDataAdapter(command);
            DataTable dataTable = new DataTable();
            adapter.Fill(dataTable);

            if (dataTable.Rows.Count != 0) {
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
                goalName = dataTable.Rows[0]["name"].ToString();

                goalMonthlyPaymentAmount = Convert.ToInt32(dataTable.Rows[0]["monthly_payment_amount"]);

                createGoalButton.Hide();
                createPaymentButton.Text = "Внести платёж (" + dataTable.Rows[0]["monthly_payment_amount"].ToString() + " ₽)";
                createPaymentButton.Show();
                cancelGoalButton.Show();

                // Текущая дата
                DateTime currentDate = DateTime.Now;
                DateTime lastPaymentDate = DateTime.Now;

                // Проверяем возможность внесения платежа
                if (dataTable.Rows[0]["last_payment_date"].ToString() == "") {
                    lastPaymentDate = currentDate.AddMonths(-2);
                }
                else {
                    lastPaymentDate = Convert.ToDateTime(dataTable.Rows[0]["last_payment_date"]);
                }

                TimeSpan difference = currentDate - lastPaymentDate;

                // Проверка, был ли платеж в прошлом месяце
                if (difference.Days >= 30) {
                    // Платеж был в прошлом месяце
                    createPaymentButton.Enabled = true;
                }
                else {
                    // Платеж не был в прошлом месяце
                    createPaymentButton.Enabled = false;
                }
            }
            else {
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

        private void loadRecurringTransactions() {
            string query = $"SELECT id as '№', amount AS 'Сумма', frequency AS 'Период (дней)', description AS 'Описание', startDate as 'Дата последнего зачисления', DATEDIFF(DATE_ADD(startDate, INTERVAL frequency DAY), CURRENT_DATE) as 'Планируемое выполнение через (дней)'  FROM recurring_transactions WHERE id_user = {AppData.user_id} order by id desc";
            MySqlCommand command = new MySqlCommand(query, DB.getConnection());

            MySqlDataAdapter adapter = new MySqlDataAdapter(command);
            DataTable dataTable = new DataTable();
            adapter.Fill(dataTable);

            // Отобразите результаты запроса в DataGridView
            dgwRecurringTransactions.DataSource = dataTable;

            dgwRecurringTransactions.Columns[0].Width = 30; // Номер
            dgwRecurringTransactions.Columns[1].Width = 70; // Сумма
            dgwRecurringTransactions.Columns[2].Width = 60; // Период
            dgwRecurringTransactions.Columns[3].Width = 180; // Описание
            dgwRecurringTransactions.Columns[4].Width = 75; // Дата последнего выполнения
            dgwRecurringTransactions.Columns[5].Width = 85; // Планируемое выполнение через
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
            changeTheme();
        }
        private void changeTheme()
        {
            this.BackColor = AppData.backColor1;
            panel3.BackColor = AppData.backColor2;
            label9.ForeColor = AppData.fontColor;
            label17.ForeColor = AppData.fontColor;
            label6.ForeColor = AppData.fontColor;
            panel5.BackColor = AppData.backColor2;
            panel1.BackColor = AppData.backColor2;
            panel4.BackColor = AppData.backColor2;
            panel2.BackColor = AppData.backColor2;
            dgw_income.BackgroundColor = AppData.backColor2;
            dgw_expenses.BackgroundColor = AppData.backColor2;
            label16.ForeColor = AppData.fontColor;
            label_income_total.ForeColor = AppData.fontColor;
            label3.ForeColor = AppData.fontColor;
            label_income_month.ForeColor = AppData.fontColor;
            tabPage1.BackColor = AppData.backColor1;
            label_expense_total.ForeColor = AppData.fontColor;
            label_expense_month.ForeColor = AppData.fontColor;
            tabPage2.BackColor = AppData.backColor1;
            tabPage3.BackColor = AppData.backColor1;
            label7.ForeColor = AppData.fontColor;
            label10.ForeColor = AppData.fontColor;
            label15.ForeColor = AppData.fontColor;
            label8.ForeColor = AppData.fontColor;
            label13.ForeColor = AppData.fontColor;
            label11.ForeColor = AppData.fontColor;
            label14.ForeColor = AppData.fontColor;
            label12.ForeColor = AppData.fontColor;
            label1.ForeColor = AppData.fontColor;
            label2.ForeColor = AppData.fontColor;
            label4.ForeColor = AppData.fontColor;
            label5.ForeColor = AppData.fontColor;
            recurringTransactionsLabel.ForeColor = AppData.fontColor;
            tabPage4.BackColor = AppData.backColor1;
            tabPage5.BackColor = AppData.backColor1;
            recurring_transactions.BackColor = AppData.backColor2;
            dgwRecurringTransactions.BackgroundColor = AppData.backColor1;



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

            if (Convert.ToInt16(amount) <= 0)
            {
                MessageBox.Show("Укажите другую сумму");
                return;
            }

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

            if (Convert.ToInt16(amount) <= 0)
            {
                MessageBox.Show("Укажите другую сумму");
                return;
            }

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

        

        private void tabPage5_Click(object sender, EventArgs e)
        {
            loadGoalTab();
        }

        private void createGoalButton_Click(object sender, EventArgs e)
        {
            DB.openConnection();

            var description = goalDescriptionTextBox.Text;
            var amount = Convert.ToInt32(goalAmountTextBox.Text);

            if (amount <= 0)
            {
                MessageBox.Show("Укажите другую сумму");
                return;

            }
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
                var addQuery = $"insert into transactions (id_user, amount, is_income, description) values ({AppData.user_id}, {goalMonthlyPaymentAmount}, 0, 'Списание на цель: {goalName}')";
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
                var addQuery = $"insert into transactions (id_user, amount, is_income, description) values ({AppData.user_id}, {goalAccumulatedAmount}, 1, 'Возврат накопленных средст с цели: {goalName}')";
                var command = new MySqlCommand(addQuery, DB.getConnection());
                command.ExecuteNonQuery();
            }            

            GetBalance();
            loadGoalTab();
            LoadIncomes();
            LoadExpenses();

            DB.closeConnection();
        }
        
        private void createTransactionButton_Click(object sender, EventArgs e)
        {
            // Создание новой повторяющейся транзакции
            string query = $"insert into recurring_transactions (amount, frequency, is_income, description, id_user) values  (0, 30, 1, 'Новая повторяющаяся операция', {AppData.user_id})";
            MySqlCommand command = new MySqlCommand(query, DB.getConnection());

            MySqlDataAdapter adapter = new MySqlDataAdapter(command);
            DataTable dataTable = new DataTable();
            adapter.Fill(dataTable);

            loadRecurringTransactions();
        }

        private void dgwRecurringTransactions_CellDoubleClick(object sender, DataGridViewCellEventArgs e) {
            int id = Convert.ToInt32(dgwRecurringTransactions.Rows[e.RowIndex].Cells[0].Value);

            recurringTransactions form = new recurringTransactions(id);
            form.Show();
            this.Hide();
        }

        private void deleteTransactionButton_Click(object sender, EventArgs e)
        { // удаление транзакции

            DB.openConnection();

            if (dgwRecurringTransactions.SelectedRows.Count > 0)
            {
                DataGridViewRow selectedRow = dgwRecurringTransactions.SelectedRows[0]; // Первая выбранная строка
                var id = selectedRow.Cells[0].Value.ToString(); // Получение значения в ячейке "id"
                var addQuery = $"delete from recurring_transactions where id = '{id}'"; // Вставляем значение в запрос
                var command = new MySqlCommand(addQuery, DB.getConnection());
                command.ExecuteNonQuery();

                loadRecurringTransactions();
            }

            DB.closeConnection();
        }

        private void pictureBox_help_Click(object sender, EventArgs e)
        {
            helpForm helpForm = new helpForm("finance");
            helpForm.Show();
        }
    }
}
// Записывать дату последнего платежа при создании платежа
// Проверять возможность внесения платежа
// Возможный баг: после создания цели, дата последнего платежа = null
