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
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace Zametki_Bal_Kuz
{
    public partial class listOfEvents : Form
    {
        DB DB = new DB();

        public DateTime SelectedDate { get; set; }
        public listOfEvents()
        {
            InitializeComponent();
        }

        private void LoadTasksForSelectedDate()
        {
            // Здесь вы должны выполнить запрос к базе данных,
            // чтобы получить задачи для выбранной даты
            string query = "SELECT title, text, is_completed FROM note WHERE dateInSystem = @selectedDate";
            MySqlCommand command = new MySqlCommand(query, DB.getConnection());
            command.Parameters.Add("@selectedDate", MySqlDbType.Date).Value = SelectedDate;

            MySqlDataAdapter adapter = new MySqlDataAdapter(command);
            DataTable dataTable = new DataTable();
            adapter.Fill(dataTable);

            // Отобразите результаты запроса в DataGridView
            dataGridView1.DataSource = dataTable;
        }

       
        private void listOfEvents_Load(object sender, EventArgs e)
        {
            LoadTasksForSelectedDate();
        }

        private void pictureBox_Back_Click(object sender, EventArgs e)
        {
            this.Hide();
            spisok spisok = new spisok();
            spisok.Show();
        }
    }
}
