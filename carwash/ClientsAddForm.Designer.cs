namespace carwash
{
    partial class ClientsAddForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ClientsAddForm));
            this.ClientsAddButton = new Guna.UI2.WinForms.Guna2Button();
            this.ClientsAddLabel4 = new System.Windows.Forms.Label();
            this.ClientsAddLabel3 = new System.Windows.Forms.Label();
            this.ClientsAddLabel2 = new System.Windows.Forms.Label();
            this.ClientsAddCar = new MetroFramework.Controls.MetroComboBox();
            this.ClientsAddName = new Bunifu.Framework.UI.BunifuMaterialTextbox();
            this.ClientsAddPhone = new Bunifu.Framework.UI.BunifuMaterialTextbox();
            this.SuspendLayout();
            // 
            // ClientsAddButton
            // 
            this.ClientsAddButton.CheckedState.Parent = this.ClientsAddButton;
            this.ClientsAddButton.CustomImages.Parent = this.ClientsAddButton;
            this.ClientsAddButton.FillColor = System.Drawing.Color.MediumSlateBlue;
            this.ClientsAddButton.Font = new System.Drawing.Font("Century Gothic", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.ClientsAddButton.ForeColor = System.Drawing.Color.White;
            this.ClientsAddButton.HoverState.Parent = this.ClientsAddButton;
            this.ClientsAddButton.Location = new System.Drawing.Point(14, 218);
            this.ClientsAddButton.Margin = new System.Windows.Forms.Padding(4);
            this.ClientsAddButton.Name = "ClientsAddButton";
            this.ClientsAddButton.ShadowDecoration.Parent = this.ClientsAddButton;
            this.ClientsAddButton.Size = new System.Drawing.Size(415, 55);
            this.ClientsAddButton.TabIndex = 31;
            this.ClientsAddButton.Text = "Добавить";
            this.ClientsAddButton.Click += new System.EventHandler(this.ClientsAddButton_Click);
            // 
            // ClientsAddLabel4
            // 
            this.ClientsAddLabel4.AutoSize = true;
            this.ClientsAddLabel4.Font = new System.Drawing.Font("Century Gothic", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.ClientsAddLabel4.Location = new System.Drawing.Point(9, 144);
            this.ClientsAddLabel4.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.ClientsAddLabel4.Name = "ClientsAddLabel4";
            this.ClientsAddLabel4.Size = new System.Drawing.Size(237, 21);
            this.ClientsAddLabel4.TabIndex = 27;
            this.ClientsAddLabel4.Text = "Введите телефон клиента:";
            // 
            // ClientsAddLabel3
            // 
            this.ClientsAddLabel3.AutoSize = true;
            this.ClientsAddLabel3.Font = new System.Drawing.Font("Century Gothic", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.ClientsAddLabel3.Location = new System.Drawing.Point(9, 74);
            this.ClientsAddLabel3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.ClientsAddLabel3.Name = "ClientsAddLabel3";
            this.ClientsAddLabel3.Size = new System.Drawing.Size(203, 21);
            this.ClientsAddLabel3.TabIndex = 26;
            this.ClientsAddLabel3.Text = "Введите ФИО клиента:";
            // 
            // ClientsAddLabel2
            // 
            this.ClientsAddLabel2.AutoSize = true;
            this.ClientsAddLabel2.Font = new System.Drawing.Font("Century Gothic", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.ClientsAddLabel2.Location = new System.Drawing.Point(9, 10);
            this.ClientsAddLabel2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.ClientsAddLabel2.Name = "ClientsAddLabel2";
            this.ClientsAddLabel2.Size = new System.Drawing.Size(205, 21);
            this.ClientsAddLabel2.TabIndex = 25;
            this.ClientsAddLabel2.Text = "Выберите автомобиль:";
            // 
            // ClientsAddCar
            // 
            this.ClientsAddCar.FormattingEnabled = true;
            this.ClientsAddCar.ItemHeight = 24;
            this.ClientsAddCar.Location = new System.Drawing.Point(13, 35);
            this.ClientsAddCar.Margin = new System.Windows.Forms.Padding(4);
            this.ClientsAddCar.Name = "ClientsAddCar";
            this.ClientsAddCar.Size = new System.Drawing.Size(413, 30);
            this.ClientsAddCar.TabIndex = 18;
            this.ClientsAddCar.UseSelectable = true;
            // 
            // ClientsAddName
            // 
            this.ClientsAddName.BackColor = System.Drawing.SystemColors.Window;
            this.ClientsAddName.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.ClientsAddName.Font = new System.Drawing.Font("Century Gothic", 9.75F);
            this.ClientsAddName.ForeColor = System.Drawing.Color.Gray;
            this.ClientsAddName.HintForeColor = System.Drawing.Color.Empty;
            this.ClientsAddName.HintText = "";
            this.ClientsAddName.isPassword = false;
            this.ClientsAddName.LineFocusedColor = System.Drawing.Color.MediumBlue;
            this.ClientsAddName.LineIdleColor = System.Drawing.Color.MediumSlateBlue;
            this.ClientsAddName.LineMouseHoverColor = System.Drawing.Color.MediumBlue;
            this.ClientsAddName.LineThickness = 3;
            this.ClientsAddName.Location = new System.Drawing.Point(13, 100);
            this.ClientsAddName.Margin = new System.Windows.Forms.Padding(5);
            this.ClientsAddName.Name = "ClientsAddName";
            this.ClientsAddName.Size = new System.Drawing.Size(415, 39);
            this.ClientsAddName.TabIndex = 32;
            this.ClientsAddName.TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            // 
            // ClientsAddPhone
            // 
            this.ClientsAddPhone.BackColor = System.Drawing.SystemColors.Window;
            this.ClientsAddPhone.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.ClientsAddPhone.Font = new System.Drawing.Font("Century Gothic", 9.75F);
            this.ClientsAddPhone.ForeColor = System.Drawing.Color.Gray;
            this.ClientsAddPhone.HintForeColor = System.Drawing.Color.Empty;
            this.ClientsAddPhone.HintText = "";
            this.ClientsAddPhone.isPassword = false;
            this.ClientsAddPhone.LineFocusedColor = System.Drawing.Color.MediumBlue;
            this.ClientsAddPhone.LineIdleColor = System.Drawing.Color.MediumSlateBlue;
            this.ClientsAddPhone.LineMouseHoverColor = System.Drawing.Color.MediumBlue;
            this.ClientsAddPhone.LineThickness = 3;
            this.ClientsAddPhone.Location = new System.Drawing.Point(13, 170);
            this.ClientsAddPhone.Margin = new System.Windows.Forms.Padding(5);
            this.ClientsAddPhone.Name = "ClientsAddPhone";
            this.ClientsAddPhone.Size = new System.Drawing.Size(415, 39);
            this.ClientsAddPhone.TabIndex = 33;
            this.ClientsAddPhone.TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            // 
            // ClientsAddForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(448, 283);
            this.Controls.Add(this.ClientsAddPhone);
            this.Controls.Add(this.ClientsAddName);
            this.Controls.Add(this.ClientsAddButton);
            this.Controls.Add(this.ClientsAddLabel4);
            this.Controls.Add(this.ClientsAddLabel3);
            this.Controls.Add(this.ClientsAddLabel2);
            this.Controls.Add(this.ClientsAddCar);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "ClientsAddForm";
            this.Text = "Добавить клиента";
            this.Load += new System.EventHandler(this.ClientsAddForm_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Guna.UI2.WinForms.Guna2Button ClientsAddButton;
        private System.Windows.Forms.Label ClientsAddLabel4;
        private System.Windows.Forms.Label ClientsAddLabel3;
        private System.Windows.Forms.Label ClientsAddLabel2;
        private MetroFramework.Controls.MetroComboBox ClientsAddCar;
        private Bunifu.Framework.UI.BunifuMaterialTextbox ClientsAddName;
        private Bunifu.Framework.UI.BunifuMaterialTextbox ClientsAddPhone;
    }
}