namespace Zametki_Bal_Kuz
{
    partial class editNoteForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(editNoteForm));
            this.panel2 = new System.Windows.Forms.Panel();
            this.label3 = new System.Windows.Forms.Label();
            this.pictureBox_Back = new System.Windows.Forms.PictureBox();
            this.dateTimePicker1 = new System.Windows.Forms.DateTimePicker();
            this.panel1 = new System.Windows.Forms.Panel();
            this.button_markIncompleteNote = new System.Windows.Forms.Button();
            this.button_markCompletedNote = new System.Windows.Forms.Button();
            this.button_save = new System.Windows.Forms.Button();
            this.pictureBox_italic = new System.Windows.Forms.PictureBox();
            this.pictureBox_bold = new System.Windows.Forms.PictureBox();
            this.txtTitle = new System.Windows.Forms.TextBox();
            this.panel3 = new System.Windows.Forms.Panel();
            this.richTextBox1 = new System.Windows.Forms.RichTextBox();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox_Back)).BeginInit();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox_italic)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox_bold)).BeginInit();
            this.panel3.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(106)))), ((int)(((byte)(79)))), ((int)(((byte)(61)))));
            this.panel2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel2.Controls.Add(this.label3);
            this.panel2.Controls.Add(this.pictureBox_Back);
            this.panel2.Controls.Add(this.dateTimePicker1);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel2.Location = new System.Drawing.Point(0, 0);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(646, 44);
            this.panel2.TabIndex = 17;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label3.ForeColor = System.Drawing.Color.Snow;
            this.label3.Location = new System.Drawing.Point(164, 8);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(252, 25);
            this.label3.TabIndex = 24;
            this.label3.Text = "Редактирование заметки";
            // 
            // pictureBox_Back
            // 
            this.pictureBox_Back.Cursor = System.Windows.Forms.Cursors.Hand;
            this.pictureBox_Back.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox_Back.Image")));
            this.pictureBox_Back.Location = new System.Drawing.Point(4, 2);
            this.pictureBox_Back.Name = "pictureBox_Back";
            this.pictureBox_Back.Size = new System.Drawing.Size(42, 35);
            this.pictureBox_Back.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox_Back.TabIndex = 12;
            this.pictureBox_Back.TabStop = false;
            this.pictureBox_Back.Click += new System.EventHandler(this.pictureBox_Back_Click);
            // 
            // dateTimePicker1
            // 
            this.dateTimePicker1.CalendarFont = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.dateTimePicker1.Location = new System.Drawing.Point(466, 9);
            this.dateTimePicker1.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.dateTimePicker1.Name = "dateTimePicker1";
            this.dateTimePicker1.Size = new System.Drawing.Size(176, 26);
            this.dateTimePicker1.TabIndex = 0;
            this.dateTimePicker1.ValueChanged += new System.EventHandler(this.dateTimePicker1_ValueChanged);
            // 
            // panel1
            // 
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.Controls.Add(this.button_markIncompleteNote);
            this.panel1.Controls.Add(this.button_markCompletedNote);
            this.panel1.Controls.Add(this.button_save);
            this.panel1.Controls.Add(this.pictureBox_italic);
            this.panel1.Controls.Add(this.pictureBox_bold);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel1.Location = new System.Drawing.Point(0, 532);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(646, 42);
            this.panel1.TabIndex = 16;
            // 
            // button_markIncompleteNote
            // 
            this.button_markIncompleteNote.BackColor = System.Drawing.Color.SaddleBrown;
            this.button_markIncompleteNote.Cursor = System.Windows.Forms.Cursors.Hand;
            this.button_markIncompleteNote.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.button_markIncompleteNote.Font = new System.Drawing.Font("Consolas", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.button_markIncompleteNote.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.button_markIncompleteNote.Location = new System.Drawing.Point(230, 2);
            this.button_markIncompleteNote.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.button_markIncompleteNote.Name = "button_markIncompleteNote";
            this.button_markIncompleteNote.Size = new System.Drawing.Size(273, 37);
            this.button_markIncompleteNote.TabIndex = 16;
            this.button_markIncompleteNote.Text = "Отметить незавершённой";
            this.button_markIncompleteNote.UseVisualStyleBackColor = false;
            this.button_markIncompleteNote.Click += new System.EventHandler(this.button_markIncompleteNote_Click);
            // 
            // button_markCompletedNote
            // 
            this.button_markCompletedNote.BackColor = System.Drawing.Color.SaddleBrown;
            this.button_markCompletedNote.Cursor = System.Windows.Forms.Cursors.Hand;
            this.button_markCompletedNote.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.button_markCompletedNote.Font = new System.Drawing.Font("Consolas", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.button_markCompletedNote.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.button_markCompletedNote.Location = new System.Drawing.Point(338, 2);
            this.button_markCompletedNote.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.button_markCompletedNote.Name = "button_markCompletedNote";
            this.button_markCompletedNote.Size = new System.Drawing.Size(123, 37);
            this.button_markCompletedNote.TabIndex = 15;
            this.button_markCompletedNote.Text = "завершить";
            this.button_markCompletedNote.UseVisualStyleBackColor = false;
            this.button_markCompletedNote.Click += new System.EventHandler(this.button_markCompletedNote_Click);
            // 
            // button_save
            // 
            this.button_save.BackColor = System.Drawing.Color.SaddleBrown;
            this.button_save.Cursor = System.Windows.Forms.Cursors.Hand;
            this.button_save.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.button_save.Font = new System.Drawing.Font("Consolas", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.button_save.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.button_save.Location = new System.Drawing.Point(514, 2);
            this.button_save.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.button_save.Name = "button_save";
            this.button_save.Size = new System.Drawing.Size(124, 37);
            this.button_save.TabIndex = 14;
            this.button_save.Text = "cохранить";
            this.button_save.UseVisualStyleBackColor = false;
            this.button_save.Click += new System.EventHandler(this.button_save_Click);
            // 
            // pictureBox_italic
            // 
            this.pictureBox_italic.Cursor = System.Windows.Forms.Cursors.Hand;
            this.pictureBox_italic.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox_italic.Image")));
            this.pictureBox_italic.Location = new System.Drawing.Point(66, 2);
            this.pictureBox_italic.Name = "pictureBox_italic";
            this.pictureBox_italic.Size = new System.Drawing.Size(42, 35);
            this.pictureBox_italic.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox_italic.TabIndex = 13;
            this.pictureBox_italic.TabStop = false;
            this.pictureBox_italic.Click += new System.EventHandler(this.pictureBox_italic_Click);
            // 
            // pictureBox_bold
            // 
            this.pictureBox_bold.Cursor = System.Windows.Forms.Cursors.Hand;
            this.pictureBox_bold.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox_bold.Image")));
            this.pictureBox_bold.Location = new System.Drawing.Point(4, 2);
            this.pictureBox_bold.Name = "pictureBox_bold";
            this.pictureBox_bold.Size = new System.Drawing.Size(42, 35);
            this.pictureBox_bold.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox_bold.TabIndex = 12;
            this.pictureBox_bold.TabStop = false;
            this.pictureBox_bold.Click += new System.EventHandler(this.pictureBox_bold_Click);
            // 
            // txtTitle
            // 
            this.txtTitle.Location = new System.Drawing.Point(40, 15);
            this.txtTitle.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.txtTitle.Name = "txtTitle";
            this.txtTitle.Size = new System.Drawing.Size(450, 26);
            this.txtTitle.TabIndex = 14;
            this.txtTitle.TextChanged += new System.EventHandler(this.txtTitle_TextChanged);
            // 
            // panel3
            // 
            this.panel3.Controls.Add(this.richTextBox1);
            this.panel3.Controls.Add(this.txtTitle);
            this.panel3.Location = new System.Drawing.Point(52, 58);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(532, 448);
            this.panel3.TabIndex = 18;
            // 
            // richTextBox1
            // 
            this.richTextBox1.Location = new System.Drawing.Point(40, 49);
            this.richTextBox1.Name = "richTextBox1";
            this.richTextBox1.Size = new System.Drawing.Size(450, 366);
            this.richTextBox1.TabIndex = 16;
            this.richTextBox1.Text = "";
            this.richTextBox1.TextChanged += new System.EventHandler(this.richTextBox1_TextChanged);
            // 
            // editNoteForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(148)))), ((int)(((byte)(109)))), ((int)(((byte)(84)))));
            this.ClientSize = new System.Drawing.Size(646, 574);
            this.Controls.Add(this.panel3);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "editNoteForm";
            this.Text = "Заметки";
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox_Back)).EndInit();
            this.panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox_italic)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox_bold)).EndInit();
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.PictureBox pictureBox_Back;
        private System.Windows.Forms.DateTimePicker dateTimePicker1;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.PictureBox pictureBox_italic;
        private System.Windows.Forms.PictureBox pictureBox_bold;
        private System.Windows.Forms.TextBox txtTitle;
        private System.Windows.Forms.Button button_save;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.RichTextBox richTextBox1;
        private System.Windows.Forms.Button button_markCompletedNote;
        private System.Windows.Forms.Button button_markIncompleteNote;
    }
}