namespace carwash
{
    partial class LoginForm
    {
        /// <summary>
        /// Обязательная переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором форм Windows

        /// <summary>
        /// Требуемый метод для поддержки конструктора — не изменяйте 
        /// содержимое этого метода с помощью редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(LoginForm));
            this.usernameTb = new Bunifu.Framework.UI.BunifuMaterialTextbox();
            this.passwordTb = new Bunifu.Framework.UI.BunifuMaterialTextbox();
            this.ConnectButton = new Guna.UI2.WinForms.Guna2Button();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.pictureBox4 = new System.Windows.Forms.PictureBox();
            this.pictureBox3 = new System.Windows.Forms.PictureBox();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox4)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // usernameTb
            // 
            this.usernameTb.BackColor = System.Drawing.SystemColors.Window;
            this.usernameTb.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.usernameTb.Font = new System.Drawing.Font("Century Gothic", 9.75F);
            this.usernameTb.ForeColor = System.Drawing.Color.Gray;
            this.usernameTb.HintForeColor = System.Drawing.Color.Empty;
            this.usernameTb.HintText = "";
            this.usernameTb.isPassword = false;
            this.usernameTb.LineFocusedColor = System.Drawing.Color.MediumBlue;
            this.usernameTb.LineIdleColor = System.Drawing.Color.MediumSlateBlue;
            this.usernameTb.LineMouseHoverColor = System.Drawing.Color.MediumBlue;
            this.usernameTb.LineThickness = 3;
            this.usernameTb.Location = new System.Drawing.Point(39, 186);
            this.usernameTb.Margin = new System.Windows.Forms.Padding(4);
            this.usernameTb.Name = "usernameTb";
            this.usernameTb.Size = new System.Drawing.Size(311, 32);
            this.usernameTb.TabIndex = 1;
            this.usernameTb.Text = "Имя пользователя";
            this.usernameTb.TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.usernameTb.Enter += new System.EventHandler(this.usernameTb_Enter);
            this.usernameTb.Leave += new System.EventHandler(this.usernameTb_Leave);
            // 
            // passwordTb
            // 
            this.passwordTb.BackColor = System.Drawing.SystemColors.Window;
            this.passwordTb.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.passwordTb.Font = new System.Drawing.Font("Century Gothic", 9.75F);
            this.passwordTb.ForeColor = System.Drawing.Color.Gray;
            this.passwordTb.HintForeColor = System.Drawing.Color.Empty;
            this.passwordTb.HintText = "";
            this.passwordTb.isPassword = false;
            this.passwordTb.LineFocusedColor = System.Drawing.Color.MediumBlue;
            this.passwordTb.LineIdleColor = System.Drawing.Color.MediumSlateBlue;
            this.passwordTb.LineMouseHoverColor = System.Drawing.Color.MediumBlue;
            this.passwordTb.LineThickness = 3;
            this.passwordTb.Location = new System.Drawing.Point(39, 244);
            this.passwordTb.Margin = new System.Windows.Forms.Padding(4);
            this.passwordTb.Name = "passwordTb";
            this.passwordTb.Size = new System.Drawing.Size(311, 32);
            this.passwordTb.TabIndex = 2;
            this.passwordTb.Text = "Пароль";
            this.passwordTb.TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.passwordTb.Enter += new System.EventHandler(this.passwordTb_Enter);
            this.passwordTb.Leave += new System.EventHandler(this.passwordTb_Leave);
            // 
            // ConnectButton
            // 
            this.ConnectButton.CheckedState.Parent = this.ConnectButton;
            this.ConnectButton.Cursor = System.Windows.Forms.Cursors.Hand;
            this.ConnectButton.CustomImages.Parent = this.ConnectButton;
            this.ConnectButton.FillColor = System.Drawing.Color.MediumSlateBlue;
            this.ConnectButton.Font = new System.Drawing.Font("Century Gothic", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.ConnectButton.ForeColor = System.Drawing.Color.White;
            this.ConnectButton.HoverState.Parent = this.ConnectButton;
            this.ConnectButton.Location = new System.Drawing.Point(0, 305);
            this.ConnectButton.Name = "ConnectButton";
            this.ConnectButton.ShadowDecoration.Parent = this.ConnectButton;
            this.ConnectButton.Size = new System.Drawing.Size(350, 45);
            this.ConnectButton.TabIndex = 0;
            this.ConnectButton.Text = "Авторизоваться";
            this.ConnectButton.Click += new System.EventHandler(this.ConnectButton_Click);
            // 
            // timer1
            // 
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // pictureBox4
            // 
            this.pictureBox4.Image = global::carwash.Properties.Resources.kandinsky_download_1700156573817;
            this.pictureBox4.Location = new System.Drawing.Point(0, 0);
            this.pictureBox4.Name = "pictureBox4";
            this.pictureBox4.Size = new System.Drawing.Size(350, 170);
            this.pictureBox4.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox4.TabIndex = 6;
            this.pictureBox4.TabStop = false;
            // 
            // pictureBox3
            // 
            this.pictureBox3.BackColor = System.Drawing.SystemColors.Window;
            this.pictureBox3.Image = global::carwash.Properties.Resources.hidden;
            this.pictureBox3.Location = new System.Drawing.Point(319, 244);
            this.pictureBox3.Name = "pictureBox3";
            this.pictureBox3.Size = new System.Drawing.Size(28, 28);
            this.pictureBox3.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox3.TabIndex = 5;
            this.pictureBox3.TabStop = false;
            this.pictureBox3.MouseDown += new System.Windows.Forms.MouseEventHandler(this.pictureBox3_MouseDown);
            this.pictureBox3.MouseUp += new System.Windows.Forms.MouseEventHandler(this.pictureBox3_MouseUp);
            // 
            // pictureBox2
            // 
            this.pictureBox2.Image = global::carwash.Properties.Resources.icons8_пароль_100;
            this.pictureBox2.Location = new System.Drawing.Point(3, 244);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(32, 32);
            this.pictureBox2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox2.TabIndex = 4;
            this.pictureBox2.TabStop = false;
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::carwash.Properties.Resources.icons8_логин_в_кружке_100;
            this.pictureBox1.Location = new System.Drawing.Point(3, 186);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(32, 32);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 3;
            this.pictureBox1.TabStop = false;
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.SystemColors.Window;
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.pictureBox4);
            this.panel1.Controls.Add(this.pictureBox3);
            this.panel1.Controls.Add(this.pictureBox2);
            this.panel1.Controls.Add(this.usernameTb);
            this.panel1.Controls.Add(this.passwordTb);
            this.panel1.Controls.Add(this.ConnectButton);
            this.panel1.Controls.Add(this.pictureBox1);
            this.panel1.Location = new System.Drawing.Point(275, 125);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(350, 350);
            this.panel1.TabIndex = 7;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Cursor = System.Windows.Forms.Cursors.Hand;
            this.label1.Font = new System.Drawing.Font("Century Gothic", 9.75F, System.Drawing.FontStyle.Underline, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label1.Location = new System.Drawing.Point(102, 281);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(188, 21);
            this.label1.TabIndex = 8;
            this.label1.Text = "Зарегистрироваться";
            this.label1.Click += new System.EventHandler(this.label1_Click);
            // 
            // LoginForm
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.BackgroundImage = global::carwash.Properties.Resources.kandinsky_download_1700157014211;
            this.ClientSize = new System.Drawing.Size(900, 600);
            this.Controls.Add(this.panel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "LoginForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Авторизация";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.LoginForm_FormClosed);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox4)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private Bunifu.Framework.UI.BunifuMaterialTextbox usernameTb;
        private Bunifu.Framework.UI.BunifuMaterialTextbox passwordTb;
        private Guna.UI2.WinForms.Guna2Button ConnectButton;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.PictureBox pictureBox2;
        private System.Windows.Forms.PictureBox pictureBox3;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.PictureBox pictureBox4;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label1;
    }
}

