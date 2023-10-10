using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Net.Mime.MediaTypeNames;
using System.Data.SqlClient;
using MySql.Data.MySqlClient;

namespace Zametki_Bal_Kuz
{
    public partial class ZametkaEditForm : Form
    {
        DB DB = new DB();
        

        private string originalTitle;
        private int noteId;
        private string originalText;
        private DateTime originalDate;
        private bool isNoteModified = false; // Флаг для отслеживания изменений в заметке
        public ZametkaEditForm(string title, string text, DateTime date, int id)
        {
            InitializeComponent();

            originalTitle = title;
            originalText = text;
            originalDate = date;
            noteId = id;

            // Получение данных заметки
            var addQuery = $"SELECT * FROM note WHERE id_note = {noteId}";
            var command = new MySqlCommand(addQuery, DB.getConnection());

            // Создайте адаптер данных и таблицу для хранения результатов
            var adapter = new MySqlDataAdapter(command);
            var dataTable = new DataTable();

            // Заполните таблицу данными из базы данных
            adapter.Fill(dataTable);

            // Извлеките значение "is_completed" из первой строки (предполагая, что у вас только одна запись)
            bool isCompleted = Convert.ToBoolean(dataTable.Rows[0]["is_completed"]);

            // Проверяем статус задачи
            if (isCompleted) {
                // Прячем кнопку "Завершить"
                button_markCompletedNote.Hide();
            } else {
                // Прячем кнопку "Отметить незавершённой"
                button_markIncompleteNote.Hide();
            }

            txtTitle.Text = title; // Отобразить заголовок на форме
            richTextBox1.Text = text; // Отобразить текст заметки на форме
            dateTimePicker1.Value = date; // Установить выбранную дату в DateTimePicker
        }
        private void button_save_Click(object sender, EventArgs e)
        {
            // Если заметка была изменена, сохраняем изменения
            if (isNoteModified)
            {
                string newTitle = txtTitle.Text;
                string newText = richTextBox1.Text;
                DateTime currentDate = DateTime.Today;

                // Ваш код для сохранения изменений в заметке в базе данных
                var addQuery = $"update note set dateInSystem = '{currentDate}', title = '{newTitle}', text = '{newText}' where id_note = {noteId}";

                var command = new MySqlCommand(addQuery, DB.getConnection());
                command.ExecuteNonQuery();

                MessageBox.Show("Заметка сохранена");

                this.DialogResult = DialogResult.OK;
            }
            else
            {
                this.DialogResult = DialogResult.Cancel;
            }
        }

        private void pictureBox_Back_Click(object sender, EventArgs e)
        {
            // Проверяем, были ли внесены изменения в заметку
            if (!isNoteModified)
            {
                this.DialogResult = DialogResult.Cancel; // Не было изменений, закрываем форму без создания новой заметки
            }
            else
            {
                // Если внесены изменения, спрашиваем пользователя, хочет ли он сохранить изменения
                DialogResult result = MessageBox.Show("Сохранить внесённые изменения?", "Внимание", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Warning);

                if (result == DialogResult.Yes)
                {
                    // Сохраняем изменения
                    string newTitle = txtTitle.Text;
                    string newText = richTextBox1.Text;
                    DateTime currentDate = DateTime.Today;

                    // Ваш код для сохранения изменений в заметке в базе данных
                    // ...

                    MessageBox.Show("Заметка сохранена");

                    this.DialogResult = DialogResult.Cancel; // Закрываем форму без создания новой заметки
                }
                else if (result == DialogResult.No)
                {
                    this.DialogResult = DialogResult.Cancel; // Не сохраняем изменения, закрываем форму без создания новой заметки
                }
                else
                {
                    // Отмена операции
                }
            }
        }

        private void txtTitle_TextChanged(object sender, EventArgs e)
        {
            isNoteModified = true; // Установить флаг изменения заметки
        }
        private void richTextBox1_TextChanged(object sender, EventArgs e)
        {
            isNoteModified = true; // Установить флаг изменения заметки
        }

        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {
            isNoteModified = true; // Установить флаг изменения заметки
        }        
        
            // Метод для получения обновленного заголовка
            public string GetUpdatedTitle()
            {
                return txtTitle.Text;
            }

            // Метод для получения обновленного текста
            public string GetUpdatedText()
            {
                return richTextBox1.Text;
            }

            // Метод для получения обновленной даты
            public DateTime GetUpdatedDate()
            {
                return dateTimePicker1.Value;
            }

        private void pictureBox_bold_Click(object sender, EventArgs e)
        {
            if (richTextBox1.SelectionFont != null)
            {
                System.Drawing.Font currentFont = richTextBox1.SelectionFont;
                // Здесь используется тернарная условная операция для определения стиля шрифта
                System.Drawing.FontStyle newFontStyle = richTextBox1.SelectionFont.Bold ? FontStyle.Regular : FontStyle.Bold;

                richTextBox1.SelectionFont = new Font(currentFont.FontFamily, currentFont.Size, newFontStyle);
            }
        }

        private void pictureBox_italic_Click(object sender, EventArgs e)
        {
            if (richTextBox1.SelectionFont != null)
            {
                System.Drawing.Font currentFont = richTextBox1.SelectionFont;
                // Здесь используется тернарная условная операция для определения стиля шрифта
                System.Drawing.FontStyle newFontStyle = richTextBox1.SelectionFont.Italic ? FontStyle.Regular : FontStyle.Italic;

                richTextBox1.SelectionFont = new Font(currentFont.FontFamily, currentFont.Size, newFontStyle);
            }
        }

        private void button_markCompletedNote_Click(object sender, EventArgs e) {
            // Пометка задачи как "Завершённая"
            // Ваш код для сохранения изменений в заметке в базе данных
            var addQuery = $"update note set is_completed = 1 where id_note = {noteId}";

            var command = new MySqlCommand(addQuery, DB.getConnection());
            command.ExecuteNonQuery();

            button_markCompletedNote.Hide();
            button_markIncompleteNote.Show();

            MessageBox.Show("Задача завершена");
            Hide();
        }

        private void button_markIncompleteNote_Click(object sender, EventArgs e) {
            // Пометка задачи как "Незавершённая"
            var addQuery = $"update note set is_completed = 0 where id_note = {noteId}";

            var command = new MySqlCommand(addQuery, DB.getConnection());
            command.ExecuteNonQuery();

            button_markCompletedNote.Show();
            button_markIncompleteNote.Hide();
        }

        
    }
}
