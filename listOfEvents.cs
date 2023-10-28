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
        public static string GetPlainTextFromRtf(string rtf) {
            using (RichTextBox richTextBox = new RichTextBox()) {
                richTextBox.Rtf = rtf;
                return richTextBox.Text;
            }
        }

        private void LoadTasksForSelectedDate()
        {
            // Здесь вы должны выполнить запрос к базе данных,
            // чтобы получить задачи для выбранной даты
            string query = "SELECT title as `Заголовок`, text as `Текст`, " +
                            "CASE WHEN is_event = 1 THEN 'Событие' ELSE 'Заметка' END as `Тип`, " +
                            $"is_completed as `Статус` FROM note WHERE id_user = {AppData.user_id} and dateInSystem = @selectedDate";

            MySqlCommand command = new MySqlCommand(query, DB.getConnection());
            command.Parameters.Add("@selectedDate", MySqlDbType.Date).Value = SelectedDate;

            MySqlDataAdapter adapter = new MySqlDataAdapter(command);
            DataTable dataTable = new DataTable();

            dataTable.Columns.Add("Статус", typeof(string));

            // Заполните dataTable
            adapter.Fill(dataTable);

            // Пройдитесь по записям и измените столбец
            foreach (DataRow row in dataTable.Rows)
            {
                if (Convert.ToInt32(row["Статус"]) == 1)
                {
                    row["Статус"] = "Завершено";
                }
                else
                {
                    row["Статус"] = "Не завершено";
                }
                
                string text = row["Текст"].ToString();
                byte[] rtfBytes = Convert.FromBase64String(text);
                string rtfText = Encoding.UTF8.GetString(rtfBytes);
                row["Текст"] = GetPlainTextFromRtf(rtfText);
            }

            // Удалите столбец int
            // dataTable.Columns.Remove("is_completed");

            // Отобразите результаты запроса в DataGridView
            dataGridView1.DataSource = dataTable;
            dataGridView1.Columns[2].Width = 175;
        }

       
        private void listOfEvents_Load(object sender, EventArgs e)
        {
            LoadTasksForSelectedDate();
        }

        private void pictureBox_Back_Click(object sender, EventArgs e)
        {
            this.Hide();
            @event eventForm = new @event();
            eventForm.Show();
        }

        private void pictureBox_help_Click(object sender, EventArgs e)
        {
            helpForm helpForm = new helpForm("events");
            helpForm.Show();
        }
    }
}
