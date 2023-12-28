namespace carwash
{
    partial class ServicesAddForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ServicesAddForm));
            this.ServiceAddButton = new Guna.UI2.WinForms.Guna2Button();
            this.ServiceAddLabel3 = new System.Windows.Forms.Label();
            this.ServiceAddLabel2 = new System.Windows.Forms.Label();
            this.ServiceAddNum = new Guna.UI2.WinForms.Guna2NumericUpDown();
            this.ServiceAddTb = new Bunifu.Framework.UI.BunifuMaterialTextbox();
            ((System.ComponentModel.ISupportInitialize)(this.ServiceAddNum)).BeginInit();
            this.SuspendLayout();
            // 
            // ServiceAddButton
            // 
            this.ServiceAddButton.CheckedState.Parent = this.ServiceAddButton;
            this.ServiceAddButton.CustomImages.Parent = this.ServiceAddButton;
            this.ServiceAddButton.FillColor = System.Drawing.Color.MediumSlateBlue;
            this.ServiceAddButton.Font = new System.Drawing.Font("Century Gothic", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.ServiceAddButton.ForeColor = System.Drawing.Color.White;
            this.ServiceAddButton.HoverState.Parent = this.ServiceAddButton;
            this.ServiceAddButton.Location = new System.Drawing.Point(13, 159);
            this.ServiceAddButton.Margin = new System.Windows.Forms.Padding(4);
            this.ServiceAddButton.Name = "ServiceAddButton";
            this.ServiceAddButton.ShadowDecoration.Parent = this.ServiceAddButton;
            this.ServiceAddButton.Size = new System.Drawing.Size(415, 55);
            this.ServiceAddButton.TabIndex = 31;
            this.ServiceAddButton.Text = "Добавить";
            this.ServiceAddButton.Click += new System.EventHandler(this.ServiceAddButton_Click);
            // 
            // ServiceAddLabel3
            // 
            this.ServiceAddLabel3.AutoSize = true;
            this.ServiceAddLabel3.Font = new System.Drawing.Font("Century Gothic", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.ServiceAddLabel3.Location = new System.Drawing.Point(13, 82);
            this.ServiceAddLabel3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.ServiceAddLabel3.Name = "ServiceAddLabel3";
            this.ServiceAddLabel3.Size = new System.Drawing.Size(241, 21);
            this.ServiceAddLabel3.TabIndex = 29;
            this.ServiceAddLabel3.Text = "Укажите стоимость услуги:";
            // 
            // ServiceAddLabel2
            // 
            this.ServiceAddLabel2.AutoSize = true;
            this.ServiceAddLabel2.Font = new System.Drawing.Font("Century Gothic", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.ServiceAddLabel2.Location = new System.Drawing.Point(13, 12);
            this.ServiceAddLabel2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.ServiceAddLabel2.Name = "ServiceAddLabel2";
            this.ServiceAddLabel2.Size = new System.Drawing.Size(274, 21);
            this.ServiceAddLabel2.TabIndex = 25;
            this.ServiceAddLabel2.Text = "Введите наименование услуги:";
            // 
            // ServiceAddNum
            // 
            this.ServiceAddNum.BackColor = System.Drawing.Color.Transparent;
            this.ServiceAddNum.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.ServiceAddNum.DisabledState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(208)))), ((int)(((byte)(208)))));
            this.ServiceAddNum.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(226)))), ((int)(((byte)(226)))));
            this.ServiceAddNum.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.ServiceAddNum.DisabledState.Parent = this.ServiceAddNum;
            this.ServiceAddNum.DisabledState.UpDownButtonFillColor = System.Drawing.Color.FromArgb(((int)(((byte)(177)))), ((int)(((byte)(177)))), ((int)(((byte)(177)))));
            this.ServiceAddNum.DisabledState.UpDownButtonForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(203)))), ((int)(((byte)(203)))), ((int)(((byte)(203)))));
            this.ServiceAddNum.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.ServiceAddNum.FocusedState.Parent = this.ServiceAddNum;
            this.ServiceAddNum.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ServiceAddNum.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(126)))), ((int)(((byte)(137)))), ((int)(((byte)(149)))));
            this.ServiceAddNum.Location = new System.Drawing.Point(13, 107);
            this.ServiceAddNum.Margin = new System.Windows.Forms.Padding(4);
            this.ServiceAddNum.Maximum = new decimal(new int[] {
            100000,
            0,
            0,
            0});
            this.ServiceAddNum.Name = "ServiceAddNum";
            this.ServiceAddNum.ShadowDecoration.Parent = this.ServiceAddNum;
            this.ServiceAddNum.Size = new System.Drawing.Size(415, 44);
            this.ServiceAddNum.TabIndex = 22;
            this.ServiceAddNum.UpDownButtonFillColor = System.Drawing.Color.MediumSlateBlue;
            // 
            // ServiceAddTb
            // 
            this.ServiceAddTb.BackColor = System.Drawing.SystemColors.Window;
            this.ServiceAddTb.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.ServiceAddTb.Font = new System.Drawing.Font("Century Gothic", 9.75F);
            this.ServiceAddTb.ForeColor = System.Drawing.Color.Gray;
            this.ServiceAddTb.HintForeColor = System.Drawing.Color.Empty;
            this.ServiceAddTb.HintText = "";
            this.ServiceAddTb.isPassword = false;
            this.ServiceAddTb.LineFocusedColor = System.Drawing.Color.MediumBlue;
            this.ServiceAddTb.LineIdleColor = System.Drawing.Color.MediumSlateBlue;
            this.ServiceAddTb.LineMouseHoverColor = System.Drawing.Color.MediumBlue;
            this.ServiceAddTb.LineThickness = 3;
            this.ServiceAddTb.Location = new System.Drawing.Point(14, 38);
            this.ServiceAddTb.Margin = new System.Windows.Forms.Padding(5);
            this.ServiceAddTb.Name = "ServiceAddTb";
            this.ServiceAddTb.Size = new System.Drawing.Size(415, 39);
            this.ServiceAddTb.TabIndex = 32;
            this.ServiceAddTb.TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            // 
            // ServicesAddForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(451, 228);
            this.Controls.Add(this.ServiceAddTb);
            this.Controls.Add(this.ServiceAddButton);
            this.Controls.Add(this.ServiceAddLabel3);
            this.Controls.Add(this.ServiceAddLabel2);
            this.Controls.Add(this.ServiceAddNum);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "ServicesAddForm";
            this.Text = "Добавить услугу";
            this.Load += new System.EventHandler(this.ServicesAddForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.ServiceAddNum)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Guna.UI2.WinForms.Guna2Button ServiceAddButton;
        private System.Windows.Forms.Label ServiceAddLabel3;
        private System.Windows.Forms.Label ServiceAddLabel2;
        private Guna.UI2.WinForms.Guna2NumericUpDown ServiceAddNum;
        private Bunifu.Framework.UI.BunifuMaterialTextbox ServiceAddTb;
    }
}