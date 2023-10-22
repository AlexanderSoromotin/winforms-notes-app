namespace Zametki_Bal_Kuz {
    partial class RegistrationForm {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing) {
            if (disposing && (components != null)) {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent() {
            this.panel1 = new System.Windows.Forms.Panel();
            this.label4 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.buttonLogin = new System.Windows.Forms.Button();
            this.txtLogin = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.txtPassword = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.label4);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.buttonLogin);
            this.panel1.Controls.Add(this.txtLogin);
            this.panel1.Controls.Add(this.label3);
            this.panel1.Controls.Add(this.txtPassword);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Location = new System.Drawing.Point(3, -1);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(506, 456);
            this.panel1.TabIndex = 7;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(149, 396);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(194, 20);
            this.label4.TabIndex = 6;
            this.label4.Text = "У меня уже есть аккаунт";
            this.label4.Click += new System.EventHandler(this.label4_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Consolas", 24F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label1.Location = new System.Drawing.Point(102, 82);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(310, 56);
            this.label1.TabIndex = 0;
            this.label1.Text = "Регистрация";
            // 
            // buttonLogin
            // 
            this.buttonLogin.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.buttonLogin.Cursor = System.Windows.Forms.Cursors.Hand;
            this.buttonLogin.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonLogin.Font = new System.Drawing.Font("Consolas", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.buttonLogin.ForeColor = System.Drawing.SystemColors.ControlText;
            this.buttonLogin.Location = new System.Drawing.Point(101, 312);
            this.buttonLogin.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.buttonLogin.Name = "buttonLogin";
            this.buttonLogin.Size = new System.Drawing.Size(307, 51);
            this.buttonLogin.TabIndex = 5;
            this.buttonLogin.Text = "Зарегистрироваться";
            this.buttonLogin.UseVisualStyleBackColor = false;
            this.buttonLogin.Click += new System.EventHandler(this.buttonLogin_Click);
            // 
            // txtLogin
            // 
            this.txtLogin.Location = new System.Drawing.Point(115, 185);
            this.txtLogin.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.txtLogin.Name = "txtLogin";
            this.txtLogin.Size = new System.Drawing.Size(278, 26);
            this.txtLogin.TabIndex = 1;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Consolas", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label3.Location = new System.Drawing.Point(112, 160);
            this.label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(65, 23);
            this.label3.TabIndex = 4;
            this.label3.Text = "ЛОГИН";
            // 
            // txtPassword
            // 
            this.txtPassword.Location = new System.Drawing.Point(116, 254);
            this.txtPassword.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.txtPassword.Name = "txtPassword";
            this.txtPassword.Size = new System.Drawing.Size(278, 26);
            this.txtPassword.TabIndex = 2;
            this.txtPassword.UseSystemPasswordChar = true;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Consolas", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label2.Location = new System.Drawing.Point(112, 229);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(76, 23);
            this.label2.TabIndex = 3;
            this.label2.Text = "ПАРОЛЬ";
            // 
            // RegistrationForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Tan;
            this.ClientSize = new System.Drawing.Size(507, 450);
            this.Controls.Add(this.panel1);
            this.Name = "RegistrationForm";
            this.Text = "RegistrationForm";
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button buttonLogin;
        private System.Windows.Forms.TextBox txtLogin;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtPassword;
        private System.Windows.Forms.Label label2;
    }
}