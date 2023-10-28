namespace Zametki_Bal_Kuz
{
    partial class recurringTransactions
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(recurringTransactions));
            this.label7 = new System.Windows.Forms.Label();
            this.pictureBox5 = new System.Windows.Forms.PictureBox();
            this.label15 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.dateRecurringTransaction = new System.Windows.Forms.DateTimePicker();
            this.label8 = new System.Windows.Forms.Label();
            this.saveRecurringTransaction = new System.Windows.Forms.Button();
            this.recurringTransactionDescription = new System.Windows.Forms.TextBox();
            this.recurringTransactionAmount = new System.Windows.Forms.TextBox();
            this.pictureBox_Back = new System.Windows.Forms.PictureBox();
            this.label1 = new System.Windows.Forms.Label();
            this.frequencyTextBox = new System.Windows.Forms.TextBox();
            this.pictureBox_help = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox5)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox_Back)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox_help)).BeginInit();
            this.SuspendLayout();
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label7.Location = new System.Drawing.Point(72, 84);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(502, 32);
            this.label7.TabIndex = 26;
            this.label7.Text = "Изменение повтояющейся операции";
            // 
            // pictureBox5
            // 
            this.pictureBox5.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox5.Image")));
            this.pictureBox5.Location = new System.Drawing.Point(417, 221);
            this.pictureBox5.Name = "pictureBox5";
            this.pictureBox5.Size = new System.Drawing.Size(34, 32);
            this.pictureBox5.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox5.TabIndex = 25;
            this.pictureBox5.TabStop = false;
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label15.Location = new System.Drawing.Point(211, 277);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(212, 25);
            this.label15.TabIndex = 24;
            this.label15.Text = "Дата начала периода";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label10.Location = new System.Drawing.Point(276, 188);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(78, 25);
            this.label10.TabIndex = 23;
            this.label10.Text = "Сумма";
            // 
            // dateRecurringTransaction
            // 
            this.dateRecurringTransaction.Location = new System.Drawing.Point(223, 305);
            this.dateRecurringTransaction.Name = "dateRecurringTransaction";
            this.dateRecurringTransaction.Size = new System.Drawing.Size(200, 26);
            this.dateRecurringTransaction.TabIndex = 22;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label8.Location = new System.Drawing.Point(238, 433);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(146, 25);
            this.label8.TabIndex = 21;
            this.label8.Text = "Комментарий";
            // 
            // saveRecurringTransaction
            // 
            this.saveRecurringTransaction.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(156)))), ((int)(((byte)(210)))), ((int)(((byte)(140)))));
            this.saveRecurringTransaction.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(156)))), ((int)(((byte)(210)))), ((int)(((byte)(140)))));
            this.saveRecurringTransaction.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.saveRecurringTransaction.Location = new System.Drawing.Point(249, 570);
            this.saveRecurringTransaction.Name = "saveRecurringTransaction";
            this.saveRecurringTransaction.Size = new System.Drawing.Size(147, 44);
            this.saveRecurringTransaction.TabIndex = 20;
            this.saveRecurringTransaction.Text = "Сохранить";
            this.saveRecurringTransaction.UseVisualStyleBackColor = true;
            this.saveRecurringTransaction.Click += new System.EventHandler(this.add_income_button_Click);
            // 
            // recurringTransactionDescription
            // 
            this.recurringTransactionDescription.Location = new System.Drawing.Point(159, 461);
            this.recurringTransactionDescription.Multiline = true;
            this.recurringTransactionDescription.Name = "recurringTransactionDescription";
            this.recurringTransactionDescription.Size = new System.Drawing.Size(344, 72);
            this.recurringTransactionDescription.TabIndex = 19;
            // 
            // recurringTransactionAmount
            // 
            this.recurringTransactionAmount.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.recurringTransactionAmount.Location = new System.Drawing.Point(211, 221);
            this.recurringTransactionAmount.Name = "recurringTransactionAmount";
            this.recurringTransactionAmount.Size = new System.Drawing.Size(200, 32);
            this.recurringTransactionAmount.TabIndex = 18;
            // 
            // pictureBox_Back
            // 
            this.pictureBox_Back.Cursor = System.Windows.Forms.Cursors.Hand;
            this.pictureBox_Back.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox_Back.Image")));
            this.pictureBox_Back.Location = new System.Drawing.Point(12, 12);
            this.pictureBox_Back.Name = "pictureBox_Back";
            this.pictureBox_Back.Size = new System.Drawing.Size(42, 36);
            this.pictureBox_Back.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox_Back.TabIndex = 27;
            this.pictureBox_Back.TabStop = false;
            this.pictureBox_Back.Click += new System.EventHandler(this.pictureBox_Back_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label1.Location = new System.Drawing.Point(249, 349);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(135, 25);
            this.label1.TabIndex = 29;
            this.label1.Text = "Приод (дней)";
            // 
            // frequencyTextBox
            // 
            this.frequencyTextBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.frequencyTextBox.Location = new System.Drawing.Point(223, 377);
            this.frequencyTextBox.Name = "frequencyTextBox";
            this.frequencyTextBox.Size = new System.Drawing.Size(200, 32);
            this.frequencyTextBox.TabIndex = 28;
            // 
            // pictureBox_help
            // 
            this.pictureBox_help.Cursor = System.Windows.Forms.Cursors.Hand;
            this.pictureBox_help.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox_help.Image")));
            this.pictureBox_help.Location = new System.Drawing.Point(592, 12);
            this.pictureBox_help.Name = "pictureBox_help";
            this.pictureBox_help.Size = new System.Drawing.Size(51, 36);
            this.pictureBox_help.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox_help.TabIndex = 30;
            this.pictureBox_help.TabStop = false;
            this.pictureBox_help.Click += new System.EventHandler(this.pictureBox_help_Click);
            // 
            // recurringTransactions
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(149)))), ((int)(((byte)(109)))), ((int)(((byte)(84)))));
            this.ClientSize = new System.Drawing.Size(655, 672);
            this.Controls.Add(this.pictureBox_help);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.frequencyTextBox);
            this.Controls.Add(this.pictureBox_Back);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.pictureBox5);
            this.Controls.Add(this.label15);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.dateRecurringTransaction);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.saveRecurringTransaction);
            this.Controls.Add(this.recurringTransactionDescription);
            this.Controls.Add(this.recurringTransactionAmount);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "recurringTransactions";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Заметки";
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox5)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox_Back)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox_help)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.PictureBox pictureBox5;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.DateTimePicker dateRecurringTransaction;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Button saveRecurringTransaction;
        private System.Windows.Forms.TextBox recurringTransactionDescription;
        private System.Windows.Forms.TextBox recurringTransactionAmount;
        private System.Windows.Forms.PictureBox pictureBox_Back;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox frequencyTextBox;
        private System.Windows.Forms.PictureBox pictureBox_help;
    }
}