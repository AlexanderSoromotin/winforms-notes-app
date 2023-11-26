using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.StartPanel;


namespace Zametki_Bal_Kuz
{
    public partial class @event : Form
    {
        DB DB = new DB();
        private DateTime selectedDate;
        public @event()
        {
            InitializeComponent();
            LoadDataFromDatabase();
        }

        private void LoadDataFromDatabase()
        {
            // Замените этот код на свой запрос к базе данных
            MySqlCommand notesCommand = new MySqlCommand("SELECT dateInSystem FROM note WHERE id_user = @userId", DB.getConnection());
            notesCommand.Parameters.Add("@userId", MySqlDbType.Int32).Value = AppData.user_id;
            DataTable notesTable = new DataTable();
            MySqlDataAdapter notesAdapter = new MySqlDataAdapter(notesCommand);
            notesAdapter.Fill(notesTable);

            // Перебираем записи из базы данных и выделяем даты в MonthCalendar
            foreach (DataRow row in notesTable.Rows)
            {
                            
                DateTime date = Convert.ToDateTime(row["dateInSystem"]);
                // MessageBox.Show(date.ToString()); 
                monthCalendar1.AddBoldedDate(date);
            }

            monthCalendar1.UpdateBoldedDates();
        }
        private void monthCalendar1_DateChanged(object sender, DateRangeEventArgs e)
        {
            
        }
        private void HighlightUpcomingTasks(DateTime selectedDate)
        {
           
        }

        private void monthCalendar1_DateSelected(object sender, DateRangeEventArgs e)
        {
            // Обработчик события выбора даты в MonthCalendar
            // Получите выбранную дату из события
            selectedDate = monthCalendar1.SelectionStart;

            OpenSpisokForm();
        }
        private void OpenSpisokForm()
        {
            // Создайте экземпляр формы spisok
            listOfEvents listForm = new listOfEvents();

            // Передайте выбранную дату в форму spisok
            listForm.SelectedDate = selectedDate;

            // Откройте форму spisok
            listForm.Show();
            this.Close();
        }

        private void pictureBox_Back_Click(object sender, EventArgs e)
        {
            this.Hide();
            spisok spisok = new spisok();
            spisok.Show();
        }

        private void pictureBox_help_Click(object sender, EventArgs e)
        {
            helpForm helpForm = new helpForm("events");
            helpForm.Show();
        }
        private void changeTheme()
        {
            this.BackColor = AppData.backColor1;
            panel2.BackColor = AppData.backColor2;
            label2.ForeColor = AppData.fontColor;
        }
        private void event_Load(object sender, EventArgs e)
        {
            changeTheme();
        }
    }
}
