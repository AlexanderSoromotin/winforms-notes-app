namespace Zametki_Bal_Kuz
{
    partial class helpForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(helpForm));
            this.tabControlHelp = new System.Windows.Forms.TabControl();
            this.mainScreen = new System.Windows.Forms.TabPage();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.events = new System.Windows.Forms.TabPage();
            this.textBox2 = new System.Windows.Forms.TextBox();
            this.addNote = new System.Windows.Forms.TabPage();
            this.textBox3 = new System.Windows.Forms.TextBox();
            this.editNote = new System.Windows.Forms.TabPage();
            this.textBox4 = new System.Windows.Forms.TextBox();
            this.finance = new System.Windows.Forms.TabPage();
            this.textBox5 = new System.Windows.Forms.TextBox();
            this.transactions = new System.Windows.Forms.TabPage();
            this.label2 = new System.Windows.Forms.Label();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.label1 = new System.Windows.Forms.Label();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.pictureBox3 = new System.Windows.Forms.PictureBox();
            this.textBoxSearch = new System.Windows.Forms.TextBox();
            this.guideText = new System.Windows.Forms.RichTextBox();
            this.panel3 = new System.Windows.Forms.Panel();
            this.label9 = new System.Windows.Forms.Label();
            this.tabControlHelp.SuspendLayout();
            this.mainScreen.SuspendLayout();
            this.events.SuspendLayout();
            this.addNote.SuspendLayout();
            this.editNote.SuspendLayout();
            this.finance.SuspendLayout();
            this.transactions.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.tabPage1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).BeginInit();
            this.panel3.SuspendLayout();
            this.SuspendLayout();
            // 
            // tabControlHelp
            // 
            this.tabControlHelp.Controls.Add(this.mainScreen);
            this.tabControlHelp.Controls.Add(this.events);
            this.tabControlHelp.Controls.Add(this.addNote);
            this.tabControlHelp.Controls.Add(this.editNote);
            this.tabControlHelp.Controls.Add(this.finance);
            this.tabControlHelp.Controls.Add(this.transactions);
            this.tabControlHelp.Controls.Add(this.tabPage1);
            this.tabControlHelp.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.tabControlHelp.Location = new System.Drawing.Point(0, 49);
            this.tabControlHelp.Name = "tabControlHelp";
            this.tabControlHelp.SelectedIndex = 0;
            this.tabControlHelp.Size = new System.Drawing.Size(1264, 623);
            this.tabControlHelp.TabIndex = 0;
            // 
            // mainScreen
            // 
            this.mainScreen.BackColor = System.Drawing.Color.Tan;
            this.mainScreen.Controls.Add(this.textBox1);
            this.mainScreen.Location = new System.Drawing.Point(4, 29);
            this.mainScreen.Name = "mainScreen";
            this.mainScreen.Padding = new System.Windows.Forms.Padding(3);
            this.mainScreen.Size = new System.Drawing.Size(1256, 590);
            this.mainScreen.TabIndex = 0;
            this.mainScreen.Text = "Раздел \"Главная страница\"";
            // 
            // textBox1
            // 
            this.textBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.textBox1.Location = new System.Drawing.Point(3, 3);
            this.textBox1.Multiline = true;
            this.textBox1.Name = "textBox1";
            this.textBox1.ReadOnly = true;
            this.textBox1.Size = new System.Drawing.Size(1250, 584);
            this.textBox1.TabIndex = 0;
            this.textBox1.Text = resources.GetString("textBox1.Text");
            // 
            // events
            // 
            this.events.BackColor = System.Drawing.Color.Tan;
            this.events.Controls.Add(this.textBox2);
            this.events.Location = new System.Drawing.Point(4, 29);
            this.events.Name = "events";
            this.events.Padding = new System.Windows.Forms.Padding(3);
            this.events.Size = new System.Drawing.Size(1256, 590);
            this.events.TabIndex = 1;
            this.events.Text = "Раздел \"События\"";
            // 
            // textBox2
            // 
            this.textBox2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.textBox2.Location = new System.Drawing.Point(3, 3);
            this.textBox2.Multiline = true;
            this.textBox2.Name = "textBox2";
            this.textBox2.ReadOnly = true;
            this.textBox2.Size = new System.Drawing.Size(1250, 584);
            this.textBox2.TabIndex = 1;
            this.textBox2.Text = "При нажатии на календарь из главной формы, мы попадаем в календарь, где выделены " +
    "даты, на которые у нас стоят заметки. По нажатию на определённую дату, открывает" +
    "ся форма со списком задач на этот день.";
            // 
            // addNote
            // 
            this.addNote.BackColor = System.Drawing.Color.Tan;
            this.addNote.Controls.Add(this.textBox3);
            this.addNote.Location = new System.Drawing.Point(4, 29);
            this.addNote.Name = "addNote";
            this.addNote.Padding = new System.Windows.Forms.Padding(3);
            this.addNote.Size = new System.Drawing.Size(1256, 590);
            this.addNote.TabIndex = 2;
            this.addNote.Text = "Раздел \"Добавить заметку\"";
            // 
            // textBox3
            // 
            this.textBox3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.textBox3.Location = new System.Drawing.Point(3, 3);
            this.textBox3.Multiline = true;
            this.textBox3.Name = "textBox3";
            this.textBox3.ReadOnly = true;
            this.textBox3.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.textBox3.Size = new System.Drawing.Size(1250, 584);
            this.textBox3.TabIndex = 2;
            this.textBox3.Text = resources.GetString("textBox3.Text");
            // 
            // editNote
            // 
            this.editNote.BackColor = System.Drawing.Color.Tan;
            this.editNote.Controls.Add(this.textBox4);
            this.editNote.Location = new System.Drawing.Point(4, 29);
            this.editNote.Name = "editNote";
            this.editNote.Padding = new System.Windows.Forms.Padding(3);
            this.editNote.Size = new System.Drawing.Size(1256, 590);
            this.editNote.TabIndex = 3;
            this.editNote.Text = "Раздел \"Редактировать заметку\"";
            // 
            // textBox4
            // 
            this.textBox4.Dock = System.Windows.Forms.DockStyle.Fill;
            this.textBox4.Location = new System.Drawing.Point(3, 3);
            this.textBox4.Multiline = true;
            this.textBox4.Name = "textBox4";
            this.textBox4.ReadOnly = true;
            this.textBox4.Size = new System.Drawing.Size(1250, 584);
            this.textBox4.TabIndex = 2;
            this.textBox4.Text = resources.GetString("textBox4.Text");
            // 
            // finance
            // 
            this.finance.BackColor = System.Drawing.Color.Tan;
            this.finance.Controls.Add(this.textBox5);
            this.finance.Location = new System.Drawing.Point(4, 29);
            this.finance.Name = "finance";
            this.finance.Padding = new System.Windows.Forms.Padding(3);
            this.finance.Size = new System.Drawing.Size(1256, 590);
            this.finance.TabIndex = 4;
            this.finance.Text = "Раздел \"Финансы\"";
            // 
            // textBox5
            // 
            this.textBox5.Dock = System.Windows.Forms.DockStyle.Fill;
            this.textBox5.Location = new System.Drawing.Point(3, 3);
            this.textBox5.Multiline = true;
            this.textBox5.Name = "textBox5";
            this.textBox5.ReadOnly = true;
            this.textBox5.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.textBox5.Size = new System.Drawing.Size(1250, 584);
            this.textBox5.TabIndex = 2;
            this.textBox5.Text = resources.GetString("textBox5.Text");
            // 
            // transactions
            // 
            this.transactions.BackColor = System.Drawing.Color.Tan;
            this.transactions.Controls.Add(this.label2);
            this.transactions.Controls.Add(this.pictureBox2);
            this.transactions.Controls.Add(this.label1);
            this.transactions.Controls.Add(this.pictureBox1);
            this.transactions.Location = new System.Drawing.Point(4, 29);
            this.transactions.Name = "transactions";
            this.transactions.Padding = new System.Windows.Forms.Padding(3);
            this.transactions.Size = new System.Drawing.Size(1256, 590);
            this.transactions.TabIndex = 5;
            this.transactions.Text = "Авторы";
            this.transactions.Click += new System.EventHandler(this.transactions_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label2.Location = new System.Drawing.Point(661, 457);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(480, 32);
            this.label2.TabIndex = 6;
            this.label2.Text = "Баландина Полина Александровна";
            // 
            // pictureBox2
            // 
            this.pictureBox2.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox2.Image")));
            this.pictureBox2.Location = new System.Drawing.Point(744, 86);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(285, 339);
            this.pictureBox2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox2.TabIndex = 5;
            this.pictureBox2.TabStop = false;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label1.Location = new System.Drawing.Point(166, 456);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(461, 32);
            this.label1.TabIndex = 4;
            this.label1.Text = "Соромотин Александр Сергеевич";
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(264, 86);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(275, 339);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 3;
            this.pictureBox1.TabStop = false;
            // 
            // tabPage1
            // 
            this.tabPage1.BackColor = System.Drawing.Color.Tan;
            this.tabPage1.Controls.Add(this.pictureBox3);
            this.tabPage1.Controls.Add(this.textBoxSearch);
            this.tabPage1.Controls.Add(this.guideText);
            this.tabPage1.Location = new System.Drawing.Point(4, 29);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(1256, 590);
            this.tabPage1.TabIndex = 6;
            this.tabPage1.Text = "Поиск";
            // 
            // pictureBox3
            // 
            this.pictureBox3.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox3.Image")));
            this.pictureBox3.Location = new System.Drawing.Point(323, 23);
            this.pictureBox3.Name = "pictureBox3";
            this.pictureBox3.Size = new System.Drawing.Size(37, 41);
            this.pictureBox3.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox3.TabIndex = 13;
            this.pictureBox3.TabStop = false;
            // 
            // textBoxSearch
            // 
            this.textBoxSearch.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.textBoxSearch.Location = new System.Drawing.Point(369, 27);
            this.textBoxSearch.Name = "textBoxSearch";
            this.textBoxSearch.Size = new System.Drawing.Size(551, 32);
            this.textBoxSearch.TabIndex = 1;
            this.textBoxSearch.TextChanged += new System.EventHandler(this.textBoxSearch_TextChanged);
            // 
            // guideText
            // 
            this.guideText.Location = new System.Drawing.Point(369, 71);
            this.guideText.Name = "guideText";
            this.guideText.Size = new System.Drawing.Size(551, 495);
            this.guideText.TabIndex = 0;
            this.guideText.Text = "";
            // 
            // panel3
            // 
            this.panel3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(106)))), ((int)(((byte)(79)))), ((int)(((byte)(61)))));
            this.panel3.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel3.Controls.Add(this.label9);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel3.Location = new System.Drawing.Point(0, 0);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(1264, 43);
            this.panel3.TabIndex = 13;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label9.ForeColor = System.Drawing.Color.Snow;
            this.label9.Location = new System.Drawing.Point(582, 8);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(121, 25);
            this.label9.TabIndex = 23;
            this.label9.Text = "Справочник";
            // 
            // helpForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(149)))), ((int)(((byte)(109)))), ((int)(((byte)(84)))));
            this.ClientSize = new System.Drawing.Size(1264, 672);
            this.Controls.Add(this.panel3);
            this.Controls.Add(this.tabControlHelp);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "helpForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Заметки";
            this.Load += new System.EventHandler(this.helpForm_Load);
            this.tabControlHelp.ResumeLayout(false);
            this.mainScreen.ResumeLayout(false);
            this.mainScreen.PerformLayout();
            this.events.ResumeLayout(false);
            this.events.PerformLayout();
            this.addNote.ResumeLayout(false);
            this.addNote.PerformLayout();
            this.editNote.ResumeLayout(false);
            this.editNote.PerformLayout();
            this.finance.ResumeLayout(false);
            this.finance.PerformLayout();
            this.transactions.ResumeLayout(false);
            this.transactions.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.tabPage1.ResumeLayout(false);
            this.tabPage1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).EndInit();
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl tabControlHelp;
        private System.Windows.Forms.TabPage mainScreen;
        private System.Windows.Forms.TabPage events;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.TabPage addNote;
        private System.Windows.Forms.TabPage editNote;
        private System.Windows.Forms.TabPage finance;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.TextBox textBox2;
        private System.Windows.Forms.TextBox textBox3;
        private System.Windows.Forms.TextBox textBox4;
        private System.Windows.Forms.TextBox textBox5;
        private System.Windows.Forms.TabPage transactions;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.PictureBox pictureBox2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.TextBox textBoxSearch;
        private System.Windows.Forms.RichTextBox guideText;
        private System.Windows.Forms.PictureBox pictureBox3;
    }
}