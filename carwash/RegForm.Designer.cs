namespace carwash
{
    partial class RegForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(RegForm));
            this.usernameTb = new Bunifu.Framework.UI.BunifuMaterialTextbox();
            this.passwordTb = new Bunifu.Framework.UI.BunifuMaterialTextbox();
            this.RegButton = new Guna.UI2.WinForms.Guna2Button();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
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
            this.usernameTb.Location = new System.Drawing.Point(81, 26);
            this.usernameTb.Margin = new System.Windows.Forms.Padding(5);
            this.usernameTb.Name = "usernameTb";
            this.usernameTb.Size = new System.Drawing.Size(415, 39);
            this.usernameTb.TabIndex = 10;
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
            this.passwordTb.Location = new System.Drawing.Point(81, 97);
            this.passwordTb.Margin = new System.Windows.Forms.Padding(5);
            this.passwordTb.Name = "passwordTb";
            this.passwordTb.Size = new System.Drawing.Size(415, 39);
            this.passwordTb.TabIndex = 11;
            this.passwordTb.Text = "Пароль";
            this.passwordTb.TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.passwordTb.Enter += new System.EventHandler(this.passwordTb_Enter);
            this.passwordTb.Leave += new System.EventHandler(this.passwordTb_Leave);
            // 
            // RegButton
            // 
            this.RegButton.CheckedState.Parent = this.RegButton;
            this.RegButton.Cursor = System.Windows.Forms.Cursors.Hand;
            this.RegButton.CustomImages.Parent = this.RegButton;
            this.RegButton.FillColor = System.Drawing.Color.MediumSlateBlue;
            this.RegButton.Font = new System.Drawing.Font("Century Gothic", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.RegButton.ForeColor = System.Drawing.Color.White;
            this.RegButton.HoverState.Parent = this.RegButton;
            this.RegButton.Location = new System.Drawing.Point(33, 145);
            this.RegButton.Margin = new System.Windows.Forms.Padding(4);
            this.RegButton.Name = "RegButton";
            this.RegButton.ShadowDecoration.Parent = this.RegButton;
            this.RegButton.Size = new System.Drawing.Size(463, 55);
            this.RegButton.TabIndex = 9;
            this.RegButton.Text = "Зарегистрироваться";
            this.RegButton.Click += new System.EventHandler(this.RegButton_Click);
            // 
            // pictureBox2
            // 
            this.pictureBox2.Image = global::carwash.Properties.Resources.icons8_пароль_100;
            this.pictureBox2.Location = new System.Drawing.Point(33, 97);
            this.pictureBox2.Margin = new System.Windows.Forms.Padding(4);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(43, 39);
            this.pictureBox2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox2.TabIndex = 13;
            this.pictureBox2.TabStop = false;
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::carwash.Properties.Resources.icons8_логин_в_кружке_100;
            this.pictureBox1.Location = new System.Drawing.Point(33, 26);
            this.pictureBox1.Margin = new System.Windows.Forms.Padding(4);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(43, 39);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 12;
            this.pictureBox1.TabStop = false;
            // 
            // RegForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(531, 234);
            this.Controls.Add(this.pictureBox2);
            this.Controls.Add(this.usernameTb);
            this.Controls.Add(this.passwordTb);
            this.Controls.Add(this.RegButton);
            this.Controls.Add(this.pictureBox1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "RegForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Регистрация";
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.PictureBox pictureBox2;
        private Bunifu.Framework.UI.BunifuMaterialTextbox usernameTb;
        private Bunifu.Framework.UI.BunifuMaterialTextbox passwordTb;
        private Guna.UI2.WinForms.Guna2Button RegButton;
        private System.Windows.Forms.PictureBox pictureBox1;
    }
}