﻿namespace Zametki_Bal_Kuz
{
    partial class spisok
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(spisok));
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.pictureBox_delete = new System.Windows.Forms.PictureBox();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.userName = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.pictureBox_exit = new System.Windows.Forms.PictureBox();
            this.textBoxSearch = new System.Windows.Forms.TextBox();
            this.pictureBox3 = new System.Windows.Forms.PictureBox();
            this.pictureBox_event = new System.Windows.Forms.PictureBox();
            this.refreshListButton = new System.Windows.Forms.PictureBox();
            this.pictureBox_money = new System.Windows.Forms.PictureBox();
            this.pictureBox_help = new System.Windows.Forms.PictureBox();
            this.pictureBoxTheme = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox_delete)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox_exit)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox_event)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.refreshListButton)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox_money)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox_help)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxTheme)).BeginInit();
            this.SuspendLayout();
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.AllowUserToDeleteRows = false;
            this.dataGridView1.BackgroundColor = System.Drawing.Color.GhostWhite;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(90, 89);
            this.dataGridView1.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.ReadOnly = true;
            this.dataGridView1.RowHeadersWidth = 62;
            this.dataGridView1.Size = new System.Drawing.Size(900, 505);
            this.dataGridView1.TabIndex = 2;
            this.dataGridView1.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellDoubleClick);
            // 
            // pictureBox_delete
            // 
            this.pictureBox_delete.Cursor = System.Windows.Forms.Cursors.Hand;
            this.pictureBox_delete.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox_delete.Image")));
            this.pictureBox_delete.Location = new System.Drawing.Point(11, 248);
            this.pictureBox_delete.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.pictureBox_delete.Name = "pictureBox_delete";
            this.pictureBox_delete.Size = new System.Drawing.Size(64, 56);
            this.pictureBox_delete.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox_delete.TabIndex = 8;
            this.pictureBox_delete.TabStop = false;
            this.pictureBox_delete.Click += new System.EventHandler(this.pictureBox_delete_Click);
            this.pictureBox_delete.MouseHover += new System.EventHandler(this.pictureBox_delete_MouseHover);
            // 
            // pictureBox2
            // 
            this.pictureBox2.Cursor = System.Windows.Forms.Cursors.Hand;
            this.pictureBox2.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox2.Image")));
            this.pictureBox2.Location = new System.Drawing.Point(16, 180);
            this.pictureBox2.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(60, 58);
            this.pictureBox2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox2.TabIndex = 9;
            this.pictureBox2.TabStop = false;
            this.pictureBox2.Click += new System.EventHandler(this.pictureBox2_Click);
            this.pictureBox2.MouseHover += new System.EventHandler(this.pictureBox2_MouseHover);
            // 
            // panel1
            // 
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.Controls.Add(this.userName);
            this.panel1.Controls.Add(this.label3);
            this.panel1.Controls.Add(this.pictureBox_exit);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1008, 45);
            this.panel1.TabIndex = 10;
            // 
            // userName
            // 
            this.userName.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.userName.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.userName.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.userName.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.userName.Location = new System.Drawing.Point(719, 6);
            this.userName.Name = "userName";
            this.userName.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.userName.Size = new System.Drawing.Size(225, 30);
            this.userName.TabIndex = 15;
            this.userName.Text = "Имя пользователя";
            this.userName.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Consolas", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label3.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.label3.Location = new System.Drawing.Point(404, 4);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(215, 37);
            this.label3.TabIndex = 14;
            this.label3.Text = "Все заметки";
            // 
            // pictureBox_exit
            // 
            this.pictureBox_exit.Cursor = System.Windows.Forms.Cursors.Hand;
            this.pictureBox_exit.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox_exit.Image")));
            this.pictureBox_exit.Location = new System.Drawing.Point(950, 3);
            this.pictureBox_exit.Name = "pictureBox_exit";
            this.pictureBox_exit.Size = new System.Drawing.Size(39, 37);
            this.pictureBox_exit.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox_exit.TabIndex = 11;
            this.pictureBox_exit.TabStop = false;
            this.pictureBox_exit.Click += new System.EventHandler(this.pictureBox_exit_Click);
            this.pictureBox_exit.MouseHover += new System.EventHandler(this.pictureBox_exit_MouseHover);
            // 
            // textBoxSearch
            // 
            this.textBoxSearch.Location = new System.Drawing.Point(90, 55);
            this.textBoxSearch.Name = "textBoxSearch";
            this.textBoxSearch.Size = new System.Drawing.Size(898, 26);
            this.textBoxSearch.TabIndex = 11;
            this.textBoxSearch.TextChanged += new System.EventHandler(this.textBoxSearch_TextChanged);
            this.textBoxSearch.Enter += new System.EventHandler(this.textBoxSearch_Enter);
            this.textBoxSearch.Leave += new System.EventHandler(this.textBoxSearch_Leave);
            // 
            // pictureBox3
            // 
            this.pictureBox3.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox3.Image")));
            this.pictureBox3.Location = new System.Drawing.Point(47, 54);
            this.pictureBox3.Name = "pictureBox3";
            this.pictureBox3.Size = new System.Drawing.Size(37, 30);
            this.pictureBox3.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox3.TabIndex = 12;
            this.pictureBox3.TabStop = false;
            // 
            // pictureBox_event
            // 
            this.pictureBox_event.Cursor = System.Windows.Forms.Cursors.Hand;
            this.pictureBox_event.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox_event.Image")));
            this.pictureBox_event.Location = new System.Drawing.Point(16, 114);
            this.pictureBox_event.Name = "pictureBox_event";
            this.pictureBox_event.Size = new System.Drawing.Size(57, 54);
            this.pictureBox_event.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox_event.TabIndex = 16;
            this.pictureBox_event.TabStop = false;
            this.pictureBox_event.Click += new System.EventHandler(this.pictureBox_event_Click);
            this.pictureBox_event.MouseHover += new System.EventHandler(this.pictureBox_event_MouseHover);
            // 
            // refreshListButton
            // 
            this.refreshListButton.Cursor = System.Windows.Forms.Cursors.Hand;
            this.refreshListButton.Image = ((System.Drawing.Image)(resources.GetObject("refreshListButton.Image")));
            this.refreshListButton.Location = new System.Drawing.Point(18, 540);
            this.refreshListButton.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.refreshListButton.Name = "refreshListButton";
            this.refreshListButton.Size = new System.Drawing.Size(52, 54);
            this.refreshListButton.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.refreshListButton.TabIndex = 17;
            this.refreshListButton.TabStop = false;
            this.refreshListButton.Click += new System.EventHandler(this.refreshListButton_Click);
            this.refreshListButton.MouseHover += new System.EventHandler(this.refreshListButton_MouseHover);
            // 
            // pictureBox_money
            // 
            this.pictureBox_money.Cursor = System.Windows.Forms.Cursors.Hand;
            this.pictureBox_money.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox_money.Image")));
            this.pictureBox_money.Location = new System.Drawing.Point(13, 314);
            this.pictureBox_money.Name = "pictureBox_money";
            this.pictureBox_money.Size = new System.Drawing.Size(63, 65);
            this.pictureBox_money.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox_money.TabIndex = 18;
            this.pictureBox_money.TabStop = false;
            this.pictureBox_money.Click += new System.EventHandler(this.pictureBox_money_Click);
            this.pictureBox_money.MouseHover += new System.EventHandler(this.pictureBox_money_MouseHover);
            // 
            // pictureBox_help
            // 
            this.pictureBox_help.Cursor = System.Windows.Forms.Cursors.Hand;
            this.pictureBox_help.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox_help.Image")));
            this.pictureBox_help.Location = new System.Drawing.Point(17, 392);
            this.pictureBox_help.Name = "pictureBox_help";
            this.pictureBox_help.Size = new System.Drawing.Size(56, 51);
            this.pictureBox_help.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox_help.TabIndex = 19;
            this.pictureBox_help.TabStop = false;
            this.pictureBox_help.Click += new System.EventHandler(this.pictureBox_help_Click);
            this.pictureBox_help.MouseHover += new System.EventHandler(this.pictureBox_help_MouseHover);
            // 
            // pictureBoxTheme
            // 
            this.pictureBoxTheme.Cursor = System.Windows.Forms.Cursors.Hand;
            this.pictureBoxTheme.Image = ((System.Drawing.Image)(resources.GetObject("pictureBoxTheme.Image")));
            this.pictureBoxTheme.Location = new System.Drawing.Point(16, 456);
            this.pictureBoxTheme.Name = "pictureBoxTheme";
            this.pictureBoxTheme.Size = new System.Drawing.Size(56, 50);
            this.pictureBoxTheme.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBoxTheme.TabIndex = 20;
            this.pictureBoxTheme.TabStop = false;
            this.pictureBoxTheme.Click += new System.EventHandler(this.pictureBoxTheme_Click);
            // 
            // spisok
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(148)))), ((int)(((byte)(109)))), ((int)(((byte)(84)))));
            this.ClientSize = new System.Drawing.Size(1008, 612);
            this.Controls.Add(this.pictureBoxTheme);
            this.Controls.Add(this.pictureBox_help);
            this.Controls.Add(this.pictureBox_money);
            this.Controls.Add(this.refreshListButton);
            this.Controls.Add(this.pictureBox_event);
            this.Controls.Add(this.pictureBox_delete);
            this.Controls.Add(this.pictureBox2);
            this.Controls.Add(this.pictureBox3);
            this.Controls.Add(this.textBoxSearch);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.dataGridView1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.Name = "spisok";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Заметки";
            this.Load += new System.EventHandler(this.spisok_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox_delete)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox_exit)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox_event)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.refreshListButton)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox_money)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox_help)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxTheme)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.PictureBox pictureBox_delete;
        private System.Windows.Forms.PictureBox pictureBox2;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.PictureBox pictureBox_exit;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox textBoxSearch;
        private System.Windows.Forms.PictureBox pictureBox3;
        private System.Windows.Forms.PictureBox pictureBox_event;
        private System.Windows.Forms.PictureBox refreshListButton;
        private System.Windows.Forms.PictureBox pictureBox_money;
        private System.Windows.Forms.Label userName;
        private System.Windows.Forms.PictureBox pictureBox_help;
        private System.Windows.Forms.PictureBox pictureBoxTheme;
    }
}