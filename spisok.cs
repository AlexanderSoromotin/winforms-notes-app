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
    enum RowState //перечисление. состояние данных в таблице
    {
        Existed,
        New,
        Modified,
        ModifiedNew,
        Deleted
    }
    public partial class spisok : Form
    {
        DB DB = new DB();

        int selectedRow;

        private bool isSearchTextDisplayed = true;
        private string searchText = "Поиск...";


        // Свойство для передачи выбранной даты
        
        public spisok()
        {
            InitializeComponent();

            // Установите текст по умолчанию
            textBoxSearch.ForeColor = System.Drawing.Color.Gray;
            textBoxSearch.Text = searchText;
            userName.Text = AppData.user_name;

            // MessageBox.Show(AppData.user_id.ToString());
        }
        
        private void CreateColumns() 
        {
            dataGridView1.Columns.Add("id_note", "№");
            dataGridView1.Columns.Add("dateInSystem", "Дата");
            dataGridView1.Columns.Add("title", "Заголовок");
            dataGridView1.Columns.Add("text", "Текст");
            dataGridView1.Columns.Add("status", "Статус");
            dataGridView1.Columns.Add("status", "Тип");
            //dataGridView1.Columns.Add("id_user", "Логин пользователя");
            //dataGridView1.Columns.Add("IsNew", String.Empty);
        }

        private void ReadSingleRows(DataGridView dgw, IDataRecord record)
        {
            string status = (record.GetString(4) == "1") ? "Завершена" : "Не завершена";
            string is_event = (record.GetString(5) == "True") ? "Событие" : "Заметка";

            // Преобразование форматированного текста заметки в обычный
            string text = record.GetString(3);
            byte[] rtfBytes = Convert.FromBase64String(text);
            string rtfText = Encoding.UTF8.GetString(rtfBytes);
            text = GetPlainTextFromRtf(rtfText);

            dgw.Rows.Add(record.GetInt32(0), record.GetString(1), record.GetString(2), text, status, is_event, RowState.ModifiedNew);
        }
        private void RefreshDataGrid(DataGridView dgw) //выводит данные из бд в датагрид
        {
            dgw.Rows.Clear();

            string queryString = $"select id_note, dateInSystem, title, text, is_completed, is_event from note where id_user = {AppData.user_id} order by id_note desc";

            MySqlCommand command = new MySqlCommand(queryString, DB.getConnection());

            DB.openConnection();

            MySqlDataReader reader = command.ExecuteReader();

            while (reader.Read())
            {
                ReadSingleRows(dgw, reader);
            }
            reader.Close();

            foreach (DataGridViewRow row in dataGridView1.Rows)
            {
                if (!row.IsNewRow)
                {
                    //row.Cells[3].Value = ConvertToPlainText(row.Cells[3].Value.ToString());
                }
            }

            dgw.Columns[0].Width = 25; // Номер
            dgw.Columns[1].Width = 80; // Дата
            dgw.Columns[2].Width = 110; // Заголовок
            dgw.Columns[3].Width = 160; // Текст
            dgw.Columns[4].Width = 90; // Статус
            dgw.Columns[5].Width = 70; // Тип
        }

        public static string GetPlainTextFromRtf(string rtf) {
            using (RichTextBox richTextBox = new RichTextBox()) {
                richTextBox.Rtf = rtf;
                return richTextBox.Text;
            }
        }

        private void spisok_Load(object sender, EventArgs e)
        {
            CreateColumns();
            RefreshDataGrid(dataGridView1);
        }
        private void pictureBox_exit_Click(object sender, EventArgs e)
        {
            AppData.user_name = "";
            AppData.user_id = 0;
            AppData.setUserToken("");
            loginForm form1 = new loginForm();
            form1.Show();
            this.Close();
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            zametka zametkaForm = new zametka();
            zametkaForm.Show(); // Установите флаг, что это новая заметка
            Hide();
        }

        private void textBoxSearch_Enter(object sender, EventArgs e)
        {
            // Проверьте, является ли введенный текст поиском
            if (isSearchTextDisplayed)
            {
                // Очистите текст и измените цвет на черный
                textBoxSearch.Text = "";
                textBoxSearch.ForeColor = System.Drawing.Color.Black;
                isSearchTextDisplayed = false;
            }
        }

        private void textBoxSearch_Leave(object sender, EventArgs e)
        {
            // Проверьте, пустое ли поле ввода
            if (String.IsNullOrWhiteSpace(textBoxSearch.Text))
            {
                // Восстановите текст и цвет по умолчанию
                textBoxSearch.Text = searchText;
                textBoxSearch.ForeColor = System.Drawing.Color.Gray;
                isSearchTextDisplayed = true;
            }
        }
        private void Search(DataGridView dgw)
        {
            dgw.Rows.Clear();

            string searchString = $"select * from note where concat (dateInSystem, text, title) like '%" + textBoxSearch.Text + "%'";

            MySqlCommand com = new MySqlCommand(searchString, DB.getConnection());

            DB.openConnection();

            MySqlDataReader read = com.ExecuteReader();

            while (read.Read())
            {
                ReadSingleRows(dgw, read);
            }
            read.Close();
        }
        private void textBoxSearch_TextChanged(object sender, EventArgs e)
        {
            Search(dataGridView1);
        }

        private void dataGridView1_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0) // Проверьте, что был клик на строке, а не на заголовке
            {
                DataGridViewRow row = dataGridView1.Rows[e.RowIndex];

                string id = row.Cells["id_note"].Value.ToString(); // Получить заголовок из выбранной строки
                string title = row.Cells["title"].Value.ToString(); // Получить заголовок из выбранной строки
                string text = row.Cells["text"].Value.ToString(); // Получить текст заметки из выбранной строки
                DateTime date = Convert.ToDateTime(row.Cells["dateInSystem"].Value); // Получить дату из выбранной строки

                ZametkaEditForm zametkaForm = new ZametkaEditForm(title, text, date, Convert.ToInt32(id)); // Создать экземпляр формы "zametka" и передать данные для редактирования
                DialogResult result = zametkaForm.ShowDialog(); // Показать форму "zametka" модально для редактирования

                if (result == DialogResult.OK) // Проверить, если пользователь нажал "OK" на форме "zametka"
                {
                    // Получить обновленные значения из формы "zametka"
                    string updatedTitle = zametkaForm.GetUpdatedTitle();
                    string updatedText = zametkaForm.GetUpdatedText();
                    DateTime updatedDate = zametkaForm.GetUpdatedDate();

                    // Обновить значения в базе данных
                    //your update code here

                    // Обновить значения в DataGridView
                    dataGridView1.Rows[e.RowIndex].Cells["title"].Value = updatedTitle;
                    dataGridView1.Rows[e.RowIndex].Cells["text"].Value = updatedText;
                    dataGridView1.Rows[e.RowIndex].Cells["dateInSystem"].Value = updatedDate;
                }
            }
        }

        private void refreshListButton_Click(object sender, EventArgs e) {
            // Обновление списка заметок
            RefreshDataGrid(dataGridView1);
        }

        private void pictureBox_event_Click(object sender, EventArgs e)
        {
            @event @eventForm = new @event();
            @eventForm.Show();
            Hide();
        }

        private void pictureBox_money_Click(object sender, EventArgs e)
        {
            money moneyForm = new money();
            moneyForm.Show();
            Hide();
        }

        private void pictureBox_event_MouseHover(object sender, EventArgs e)
        {
            ToolTip tt = new ToolTip();
            tt.SetToolTip(this.pictureBox_event, "События");
        }

        private void pictureBox2_MouseHover(object sender, EventArgs e)
        {
            ToolTip tt = new ToolTip();
            tt.SetToolTip(this.pictureBox2, "Новая заметка");
        }

        private void pictureBox_money_MouseHover(object sender, EventArgs e)
        {
            ToolTip tt = new ToolTip();
            tt.SetToolTip(this.pictureBox_money, "Финансы");
        }

        private void refreshListButton_MouseHover(object sender, EventArgs e)
        {
            ToolTip tt = new ToolTip();
            tt.SetToolTip(this.refreshListButton, "Обновить");
        }

        private void pictureBox_delete_Click(object sender, EventArgs e) {
            // Удаление заметок
            if (dataGridView1.SelectedRows.Count > 0) {
                // Получите выбранную строку
                DataGridViewRow selectedRow = dataGridView1.SelectedRows[0];

                // Получите значение из первого столбца выбранной строки (предполагается, что это столбец с индексом 0)
                int id = Convert.ToInt32(selectedRow.Cells[0].Value);
                
                var addQuery = $"delete from note where id_note = {id}";
                var command = new MySqlCommand(addQuery, DB.getConnection());
                command.ExecuteNonQuery();

                RefreshDataGrid(dataGridView1);
            }
            else {
                // Выведите сообщение пользователю, что не выбрано ни одной строки
                MessageBox.Show("Выберите строку с заметой, которую хотите удалить");
            }
        }

        private void pictureBox_delete_MouseHover(object sender, EventArgs e) {
            ToolTip tt = new ToolTip();
            tt.SetToolTip(this.pictureBox2, "Удалить заметку");
        }
    }
}
