namespace carwash
{
    partial class OrderAddForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(OrderAddForm));
            this.OrderAddWorkgroup = new MetroFramework.Controls.MetroComboBox();
            this.OrderAddClient = new MetroFramework.Controls.MetroComboBox();
            this.OrderAddDate = new Guna.UI2.WinForms.Guna2DateTimePicker();
            this.OrderAddCost = new Guna.UI2.WinForms.Guna2NumericUpDown();
            this.OrderAddStatus = new MetroFramework.Controls.MetroComboBox();
            this.OrderAddLabel2 = new System.Windows.Forms.Label();
            this.OrderAddLabel3 = new System.Windows.Forms.Label();
            this.OrderAddLabel4 = new System.Windows.Forms.Label();
            this.OrderAddLabel5 = new System.Windows.Forms.Label();
            this.OrderAddLabel6 = new System.Windows.Forms.Label();
            this.OrderAddLabel7 = new System.Windows.Forms.Label();
            this.OrderAddButton = new Guna.UI2.WinForms.Guna2Button();
            this.OrderAddServices = new System.Windows.Forms.CheckedListBox();
            ((System.ComponentModel.ISupportInitialize)(this.OrderAddCost)).BeginInit();
            this.SuspendLayout();
            // 
            // OrderAddWorkgroup
            // 
            this.OrderAddWorkgroup.FormattingEnabled = true;
            this.OrderAddWorkgroup.ItemHeight = 24;
            this.OrderAddWorkgroup.Location = new System.Drawing.Point(13, 33);
            this.OrderAddWorkgroup.Margin = new System.Windows.Forms.Padding(4);
            this.OrderAddWorkgroup.Name = "OrderAddWorkgroup";
            this.OrderAddWorkgroup.Size = new System.Drawing.Size(413, 30);
            this.OrderAddWorkgroup.TabIndex = 3;
            this.OrderAddWorkgroup.UseSelectable = true;
            // 
            // OrderAddClient
            // 
            this.OrderAddClient.FormattingEnabled = true;
            this.OrderAddClient.ItemHeight = 24;
            this.OrderAddClient.Location = new System.Drawing.Point(13, 97);
            this.OrderAddClient.Margin = new System.Windows.Forms.Padding(4);
            this.OrderAddClient.Name = "OrderAddClient";
            this.OrderAddClient.Size = new System.Drawing.Size(413, 30);
            this.OrderAddClient.TabIndex = 4;
            this.OrderAddClient.UseSelectable = true;
            // 
            // OrderAddDate
            // 
            this.OrderAddDate.CheckedState.Parent = this.OrderAddDate;
            this.OrderAddDate.FillColor = System.Drawing.Color.MediumSlateBlue;
            this.OrderAddDate.FocusedColor = System.Drawing.Color.MediumBlue;
            this.OrderAddDate.Font = new System.Drawing.Font("Century Gothic", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.OrderAddDate.Format = System.Windows.Forms.DateTimePickerFormat.Long;
            this.OrderAddDate.HoverState.Parent = this.OrderAddDate;
            this.OrderAddDate.Location = new System.Drawing.Point(13, 320);
            this.OrderAddDate.Margin = new System.Windows.Forms.Padding(4);
            this.OrderAddDate.MaxDate = new System.DateTime(9998, 12, 31, 0, 0, 0, 0);
            this.OrderAddDate.MinDate = new System.DateTime(1753, 1, 1, 0, 0, 0, 0);
            this.OrderAddDate.Name = "OrderAddDate";
            this.OrderAddDate.ShadowDecoration.Parent = this.OrderAddDate;
            this.OrderAddDate.Size = new System.Drawing.Size(415, 44);
            this.OrderAddDate.TabIndex = 6;
            this.OrderAddDate.Value = new System.DateTime(2023, 5, 30, 15, 38, 44, 622);
            // 
            // OrderAddCost
            // 
            this.OrderAddCost.BackColor = System.Drawing.Color.Transparent;
            this.OrderAddCost.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.OrderAddCost.DisabledState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(208)))), ((int)(((byte)(208)))));
            this.OrderAddCost.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(226)))), ((int)(((byte)(226)))));
            this.OrderAddCost.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.OrderAddCost.DisabledState.Parent = this.OrderAddCost;
            this.OrderAddCost.DisabledState.UpDownButtonFillColor = System.Drawing.Color.FromArgb(((int)(((byte)(177)))), ((int)(((byte)(177)))), ((int)(((byte)(177)))));
            this.OrderAddCost.DisabledState.UpDownButtonForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(203)))), ((int)(((byte)(203)))), ((int)(((byte)(203)))));
            this.OrderAddCost.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.OrderAddCost.FocusedState.Parent = this.OrderAddCost;
            this.OrderAddCost.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.OrderAddCost.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(126)))), ((int)(((byte)(137)))), ((int)(((byte)(149)))));
            this.OrderAddCost.Location = new System.Drawing.Point(13, 392);
            this.OrderAddCost.Margin = new System.Windows.Forms.Padding(4);
            this.OrderAddCost.Maximum = new decimal(new int[] {
            1000000,
            0,
            0,
            0});
            this.OrderAddCost.Name = "OrderAddCost";
            this.OrderAddCost.ShadowDecoration.Parent = this.OrderAddCost;
            this.OrderAddCost.Size = new System.Drawing.Size(415, 44);
            this.OrderAddCost.TabIndex = 7;
            this.OrderAddCost.UpDownButtonFillColor = System.Drawing.Color.MediumSlateBlue;
            // 
            // OrderAddStatus
            // 
            this.OrderAddStatus.FormattingEnabled = true;
            this.OrderAddStatus.ItemHeight = 24;
            this.OrderAddStatus.Items.AddRange(new object[] {
            "Выполнен",
            "Отклонен",
            "В процессе"});
            this.OrderAddStatus.Location = new System.Drawing.Point(13, 465);
            this.OrderAddStatus.Margin = new System.Windows.Forms.Padding(4);
            this.OrderAddStatus.Name = "OrderAddStatus";
            this.OrderAddStatus.Size = new System.Drawing.Size(413, 30);
            this.OrderAddStatus.TabIndex = 8;
            this.OrderAddStatus.UseSelectable = true;
            // 
            // OrderAddLabel2
            // 
            this.OrderAddLabel2.AutoSize = true;
            this.OrderAddLabel2.Font = new System.Drawing.Font("Century Gothic", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.OrderAddLabel2.Location = new System.Drawing.Point(13, 8);
            this.OrderAddLabel2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.OrderAddLabel2.Name = "OrderAddLabel2";
            this.OrderAddLabel2.Size = new System.Drawing.Size(172, 21);
            this.OrderAddLabel2.TabIndex = 10;
            this.OrderAddLabel2.Text = "Выберите бригаду:";
            // 
            // OrderAddLabel3
            // 
            this.OrderAddLabel3.AutoSize = true;
            this.OrderAddLabel3.Font = new System.Drawing.Font("Century Gothic", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.OrderAddLabel3.Location = new System.Drawing.Point(9, 72);
            this.OrderAddLabel3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.OrderAddLabel3.Name = "OrderAddLabel3";
            this.OrderAddLabel3.Size = new System.Drawing.Size(171, 21);
            this.OrderAddLabel3.TabIndex = 11;
            this.OrderAddLabel3.Text = "Выберите клиента:";
            // 
            // OrderAddLabel4
            // 
            this.OrderAddLabel4.AutoSize = true;
            this.OrderAddLabel4.Font = new System.Drawing.Font("Century Gothic", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.OrderAddLabel4.Location = new System.Drawing.Point(9, 136);
            this.OrderAddLabel4.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.OrderAddLabel4.Name = "OrderAddLabel4";
            this.OrderAddLabel4.Size = new System.Drawing.Size(155, 21);
            this.OrderAddLabel4.TabIndex = 12;
            this.OrderAddLabel4.Text = "Выберите услуги:";
            // 
            // OrderAddLabel5
            // 
            this.OrderAddLabel5.AutoSize = true;
            this.OrderAddLabel5.Font = new System.Drawing.Font("Century Gothic", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.OrderAddLabel5.Location = new System.Drawing.Point(9, 295);
            this.OrderAddLabel5.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.OrderAddLabel5.Name = "OrderAddLabel5";
            this.OrderAddLabel5.Size = new System.Drawing.Size(204, 21);
            this.OrderAddLabel5.TabIndex = 13;
            this.OrderAddLabel5.Text = "Выберите дату заказа:";
            // 
            // OrderAddLabel6
            // 
            this.OrderAddLabel6.AutoSize = true;
            this.OrderAddLabel6.Font = new System.Drawing.Font("Century Gothic", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.OrderAddLabel6.Location = new System.Drawing.Point(9, 368);
            this.OrderAddLabel6.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.OrderAddLabel6.Name = "OrderAddLabel6";
            this.OrderAddLabel6.Size = new System.Drawing.Size(248, 21);
            this.OrderAddLabel6.TabIndex = 14;
            this.OrderAddLabel6.Text = "Укажите стоимость заказа:";
            // 
            // OrderAddLabel7
            // 
            this.OrderAddLabel7.AutoSize = true;
            this.OrderAddLabel7.Font = new System.Drawing.Font("Century Gothic", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.OrderAddLabel7.Location = new System.Drawing.Point(9, 440);
            this.OrderAddLabel7.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.OrderAddLabel7.Name = "OrderAddLabel7";
            this.OrderAddLabel7.Size = new System.Drawing.Size(213, 21);
            this.OrderAddLabel7.TabIndex = 15;
            this.OrderAddLabel7.Text = "Укажите статус заказа:";
            // 
            // OrderAddButton
            // 
            this.OrderAddButton.CheckedState.Parent = this.OrderAddButton;
            this.OrderAddButton.CustomImages.Parent = this.OrderAddButton;
            this.OrderAddButton.FillColor = System.Drawing.Color.MediumSlateBlue;
            this.OrderAddButton.Font = new System.Drawing.Font("Century Gothic", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.OrderAddButton.ForeColor = System.Drawing.Color.White;
            this.OrderAddButton.HoverState.Parent = this.OrderAddButton;
            this.OrderAddButton.Location = new System.Drawing.Point(13, 508);
            this.OrderAddButton.Margin = new System.Windows.Forms.Padding(4);
            this.OrderAddButton.Name = "OrderAddButton";
            this.OrderAddButton.ShadowDecoration.Parent = this.OrderAddButton;
            this.OrderAddButton.Size = new System.Drawing.Size(415, 55);
            this.OrderAddButton.TabIndex = 16;
            this.OrderAddButton.Text = "Добавить";
            this.OrderAddButton.Click += new System.EventHandler(this.OrderAddButton_Click);
            // 
            // OrderAddServices
            // 
            this.OrderAddServices.Font = new System.Drawing.Font("Century Gothic", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.OrderAddServices.FormattingEnabled = true;
            this.OrderAddServices.Location = new System.Drawing.Point(13, 161);
            this.OrderAddServices.Margin = new System.Windows.Forms.Padding(4);
            this.OrderAddServices.Name = "OrderAddServices";
            this.OrderAddServices.Size = new System.Drawing.Size(413, 130);
            this.OrderAddServices.TabIndex = 17;
            this.OrderAddServices.SelectedIndexChanged += new System.EventHandler(this.OrderAddLb_SelectedIndexChanged);
            this.OrderAddServices.MouseDown += new System.Windows.Forms.MouseEventHandler(this.OrderAddLb_MouseDown);
            // 
            // OrderAddForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(451, 573);
            this.Controls.Add(this.OrderAddServices);
            this.Controls.Add(this.OrderAddButton);
            this.Controls.Add(this.OrderAddLabel7);
            this.Controls.Add(this.OrderAddLabel6);
            this.Controls.Add(this.OrderAddLabel5);
            this.Controls.Add(this.OrderAddLabel4);
            this.Controls.Add(this.OrderAddLabel3);
            this.Controls.Add(this.OrderAddLabel2);
            this.Controls.Add(this.OrderAddStatus);
            this.Controls.Add(this.OrderAddCost);
            this.Controls.Add(this.OrderAddDate);
            this.Controls.Add(this.OrderAddClient);
            this.Controls.Add(this.OrderAddWorkgroup);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "OrderAddForm";
            this.Text = "Добавить заказ";
            this.Load += new System.EventHandler(this.OrderAddForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.OrderAddCost)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private MetroFramework.Controls.MetroComboBox OrderAddWorkgroup;
        private MetroFramework.Controls.MetroComboBox OrderAddClient;
        private Guna.UI2.WinForms.Guna2DateTimePicker OrderAddDate;
        private Guna.UI2.WinForms.Guna2NumericUpDown OrderAddCost;
        private MetroFramework.Controls.MetroComboBox OrderAddStatus;
        private System.Windows.Forms.Label OrderAddLabel2;
        private System.Windows.Forms.Label OrderAddLabel3;
        private System.Windows.Forms.Label OrderAddLabel4;
        private System.Windows.Forms.Label OrderAddLabel5;
        private System.Windows.Forms.Label OrderAddLabel6;
        private System.Windows.Forms.Label OrderAddLabel7;
        private Guna.UI2.WinForms.Guna2Button OrderAddButton;
        private System.Windows.Forms.CheckedListBox OrderAddServices;
    }
}