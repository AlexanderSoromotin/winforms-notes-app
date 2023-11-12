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
using System.Diagnostics;
using System.Xml.Linq;
using System.IO;
using MySql.Data.MySqlClient;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.StartPanel;

namespace Zametki_Bal_Kuz
{
    public partial class addNote : Form
    {
        DB DB = new DB();

        float a, b; // для калькулятора
        int count;
        bool znak = true;

        private bool isTxtMessageDisplayed = true;
        private string TxtMessage = "напишите что-нибудь";

        private bool isTxtTitleDisplayed = true;
        private string TxtTitle = "Заголовок";
        public addNote()
        {
            InitializeComponent();
            // Установите текст по умолчанию
            richTextBox1.ForeColor = System.Drawing.Color.Gray;
            richTextBox1.Text = TxtMessage;
            // Установите текст по умолчанию
            txtTitle.ForeColor = System.Drawing.Color.Gray;
            txtTitle.Text = TxtTitle;
        }
       
        private void zametka_Load(object sender, EventArgs e)
        {
            changeTheme();
        }
        private void pictureBox_Back_Click(object sender, EventArgs e)
        {
            this.Hide();
            spisok spisok = new spisok();
            spisok.Show();
        }
        private void txtTitle_Enter(object sender, EventArgs e)
        {
            // Проверьте, является ли введенный текст поиском
            if (isTxtTitleDisplayed)
            {
                // Очистите текст и измените цвет на черный
                txtTitle.Text = "";
                txtTitle.ForeColor = System.Drawing.Color.Black;
                isTxtTitleDisplayed = false;
            }
        }

        private void txtTitle_Leave(object sender, EventArgs e)
        {
            // Проверьте, пустое ли поле ввода
            if (String.IsNullOrWhiteSpace(txtTitle.Text))
            {
                // Восстановите текст и цвет по умолчанию
                txtTitle.Text = TxtTitle;
                txtTitle.ForeColor = System.Drawing.Color.Gray;
                isTxtTitleDisplayed = true;
            }
        } 
        private void richTextBox1_Enter(object sender, EventArgs e)
        {
            // Проверьте, является ли введенный текст поиском
            if (isTxtMessageDisplayed)
            {
                // Очистите текст и измените цвет на черный
                richTextBox1.Text = "";
                richTextBox1.ForeColor = System.Drawing.Color.Black;
                isTxtMessageDisplayed = false;
            }
        }
        private void richTextBox1_Leave(object sender, EventArgs e)
        {
            // Проверьте, пустое ли поле ввода
            if (String.IsNullOrWhiteSpace(richTextBox1.Text))
            {
                // Восстановите текст и цвет по умолчанию
                richTextBox1.Text = TxtMessage;
                richTextBox1.ForeColor = System.Drawing.Color.Gray;
                isTxtMessageDisplayed = true;
            }
        }
        private void button_save_Click(object sender, EventArgs e)
        {
            DB.openConnection();

            dateTimePicker1.Format = DateTimePickerFormat.Custom;
            dateTimePicker1.CustomFormat = "yyyy-MM-dd";
            var date = dateTimePicker1.Text;
            var title = txtTitle.Text;
            var text = richTextBox1.Rtf;
            int is_event = isEventCheckBox.Checked ? 1 : 0;


            byte[] rtfBytes = Encoding.UTF8.GetBytes(text); // Используйте соответствующую кодировку
            string base64Rtf = Convert.ToBase64String(rtfBytes);

            if (!string.IsNullOrWhiteSpace(richTextBox1.Text) && !string.IsNullOrWhiteSpace(dateTimePicker1.Text))
            {
                var addQuery = $"insert into note (dateInSystem, title, text, id_user, is_event) values ('{date}', '{title}', @text, {AppData.user_id}, {is_event})";

                MySqlCommand cmd = new MySqlCommand(addQuery, DB.getConnection());
                cmd.Parameters.AddWithValue("@text", base64Rtf);
                cmd.ExecuteNonQuery();

                MessageBox.Show("Запись создана!", "Успех)", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                spisok spisok = new spisok();
                spisok.Show();
                Hide();
            }

            else
            {
                MessageBox.Show("Заполните поля!", "Ошибка!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            DB.closeConnection();
        }
        private void pictureBox_bold_Click(object sender, EventArgs e) //полужирный
        {
            if (richTextBox1.SelectedText != "")
            {
                Font currentFont = richTextBox1.SelectionFont;
                Font newFont;
                if (richTextBox1.SelectionFont.Bold)
                {
                    newFont = new Font(currentFont, FontStyle.Regular);
                }
                else
                {
                    newFont = new Font(currentFont, FontStyle.Bold);
                }
                richTextBox1.SelectionFont = newFont;
            }
        }
        
        private void pictureBox_italic_Click(object sender, EventArgs e) //курсив
        {
            if (richTextBox1.SelectionFont != null)
            {
                System.Drawing.Font currentFont = richTextBox1.SelectionFont;
                // Здесь используется тернарная условная операция для определения стиля шрифта
                System.Drawing.FontStyle newFontStyle = richTextBox1.SelectionFont.Italic ? FontStyle.Regular : FontStyle.Italic;

                richTextBox1.SelectionFont = new Font(currentFont.FontFamily, currentFont.Size, newFontStyle);
            }
        }

        //калькулятор
        private void button1_Click(object sender, EventArgs e)
        {
            textBox1.Text = textBox1.Text + 0;
        }
        private void button2_Click(object sender, EventArgs e)
        {
            textBox1.Text = textBox1.Text + 1;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            textBox1.Text = textBox1.Text + 2;
        }

        private void button4_Click(object sender, EventArgs e)
        {
            textBox1.Text = textBox1.Text + 3;
        }

        private void button5_Click(object sender, EventArgs e)
        {
            textBox1.Text = textBox1.Text + 4;
        }

        private void button6_Click(object sender, EventArgs e)
        {
            textBox1.Text = textBox1.Text + 5;
        }

        private void button7_Click(object sender, EventArgs e)
        {
            textBox1.Text = textBox1.Text + 6;
        }

        private void button8_Click(object sender, EventArgs e)
        {
            textBox1.Text = textBox1.Text + 7;
        }

        private void button9_Click(object sender, EventArgs e)
        {
            textBox1.Text = textBox1.Text + 8;
        }

        private void button10_Click(object sender, EventArgs e)
        {
            textBox1.Text = textBox1.Text + 9;
        }
        private void button18_Click(object sender, EventArgs e)
        {
            textBox1.Text = textBox1.Text + ",";
        }
        private void button16_Click(object sender, EventArgs e) //сложение
        {
            a = float.Parse(textBox1.Text);
            textBox1.Clear();
            count = 1;
            label3.Text = a.ToString() + " +";
            znak = true;
        }

        private void button15_Click(object sender, EventArgs e) //вычитание
        {
            a = float.Parse(textBox1.Text);
            textBox1.Clear();
            count = 2;
            label3.Text = a.ToString() + " -";
            znak = true;
        }

        private void button14_Click(object sender, EventArgs e) //умножение
        {
            a = float.Parse(textBox1.Text);
            textBox1.Clear();
            count = 3;
            label3.Text = a.ToString() + " *";
            znak = true;
        }

        private void button13_Click(object sender, EventArgs e) //деление
        {
            a = float.Parse(textBox1.Text);
            textBox1.Clear();
            count = 4;
            label3.Text = a.ToString() + " /";
            znak = true;
        }
        private void calculate()
        {
            switch (count)
            {
                case 1:
                    b = a + float.Parse(textBox1.Text);
                    textBox1.Text = b.ToString();
                    break;
                case 2:
                    b = a - float.Parse(textBox1.Text);
                    textBox1.Text = b.ToString();
                    break;
                case 3:
                    b = a * float.Parse(textBox1.Text);
                    textBox1.Text = b.ToString();
                    break;
                case 4:
                    b = a / float.Parse(textBox1.Text);
                    textBox1.Text = b.ToString();
                    break;

                    default:
                    break;
            }

        }
        private void button17_Click(object sender, EventArgs e)
        {
            calculate();
            label3.Text = "";
        }
        private void button11_Click(object sender, EventArgs e) //очистка всего
        {
            textBox1.Text = "";
            label3.Text = "";
        }
        private void button19_Click(object sender, EventArgs e) //очистка последнего символа
        {
            int lenght = textBox1.Text.Length - 1;
            string text = textBox1.Text;
            textBox1.Clear();
            for (int i = 0; i < lenght; i++)
            {
                textBox1.Text = textBox1.Text + text[i];
            }
        }
        private void button20_Click(object sender, EventArgs e) //знак первого слагаемого
        {
            if (znak == true)
            {
                textBox1.Text = "-" + textBox1.Text;
                znak = false;
            }
            else if (znak == false)
            {
                textBox1.Text = textBox1.Text.Replace("-", "");
                znak = true;
            }
        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox_help_Click(object sender, EventArgs e)
        {
            helpForm helpForm = new helpForm("addNote");
            helpForm.Show();
        }

        private void button12_Click(object sender, EventArgs e) //проценты
        {
            float percentage = float.Parse(textBox1.Text) / 100;
            textBox1.Text = percentage.ToString();
        }
        private void changeTheme()
        {
            this.BackColor = AppData.backColor1;
            panel2.BackColor = AppData.backColor2;
            label1.ForeColor = AppData.fontColor;
            isEventCheckBox.ForeColor = AppData.fontColor;
            label_name.ForeColor = AppData.fontColor;
            button_save.ForeColor = AppData.fontColor;
            button_save.BackColor = AppData.backColor2;
        }

    }
}
