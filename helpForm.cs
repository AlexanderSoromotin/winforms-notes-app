using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace Zametki_Bal_Kuz
{
    public partial class helpForm : Form
    {
        DB DB = new DB();

        public helpForm(string tabName = "")
        {
            InitializeComponent();
            if (tabName == "home") 
            {
                tabControlHelp.SelectedIndex = 0;
            }

            if (tabName == "events")
            {
                tabControlHelp.SelectedIndex = 1;
            }

            if (tabName == "addNote")
            {
                tabControlHelp.SelectedIndex = 2;
            }

            if (tabName == "editNote")
            {
                tabControlHelp.SelectedIndex = 3;
            }

            if (tabName == "finance")
            {
                tabControlHelp.SelectedIndex = 4;
            }

            guideText.Text += "========= " + tabControlHelp.TabPages[0].Text + " =========\n";
            guideText.Text += textBox1.Text + "\n\n";

            guideText.Text += "========= " + tabControlHelp.TabPages[1].Text + " =========\n";
            guideText.Text += textBox2.Text + "\n\n";

            guideText.Text += "========= " + tabControlHelp.TabPages[2].Text + " =========\n";
            guideText.Text += textBox3.Text + "\n\n";

            guideText.Text += "========= " + tabControlHelp.TabPages[3].Text + " =========\n";
            guideText.Text += textBox4.Text + "\n\n";

            guideText.Text += "========= " + tabControlHelp.TabPages[4].Text + " =========\n";
            guideText.Text += textBox5.Text + "\n\n";
        }

        private void transactions_Click(object sender, EventArgs e)
        {

        }

        private void textBoxSearch_TextChanged(object sender, EventArgs e) {
            string searchText = textBoxSearch.Text;
            SearchTextInRichTextBox(searchText);
        }

        private void SearchTextInRichTextBox(string searchText) {
            // Очистите выделение в RichTextBox
            ClearTextSelectionInRichTextBox();

            if (!string.IsNullOrEmpty(searchText)) {
                int index = guideText.Text.IndexOf(searchText);
                if (index >= 0) {
                    // Найдено совпадение, выделите текст в RichTextBox
                    guideText.Select(index, searchText.Length);
                    guideText.SelectionBackColor = Color.Yellow; // Измените цвет фона по вашему желанию
                }
            }
        }

        private void ClearTextSelectionInRichTextBox() {
            guideText.DeselectAll();
            guideText.Select(0, guideText.Text.Length);
            guideText.SelectionBackColor = Color.White; // Измените цвет фона по вашему желанию
            guideText.SelectionBackColor = guideText.BackColor; // Восстановите цвет фона по умолчанию
        }
    }
}
