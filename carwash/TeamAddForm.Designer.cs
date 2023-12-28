namespace carwash
{
    partial class TeamAddForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(TeamAddForm));
            this.TeamAddLabel3 = new System.Windows.Forms.Label();
            this.TeamAddDate = new Guna.UI2.WinForms.Guna2DateTimePicker();
            this.TeamAddTb = new Bunifu.Framework.UI.BunifuMaterialTextbox();
            this.TeamAddButton = new Guna.UI2.WinForms.Guna2Button();
            this.TeamAddLabel2 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // TeamAddLabel3
            // 
            this.TeamAddLabel3.AutoSize = true;
            this.TeamAddLabel3.Font = new System.Drawing.Font("Century Gothic", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.TeamAddLabel3.Location = new System.Drawing.Point(16, 79);
            this.TeamAddLabel3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.TeamAddLabel3.Name = "TeamAddLabel3";
            this.TeamAddLabel3.Size = new System.Drawing.Size(282, 21);
            this.TeamAddLabel3.TabIndex = 51;
            this.TeamAddLabel3.Text = "Выберите дату формирования:";
            // 
            // TeamAddDate
            // 
            this.TeamAddDate.CheckedState.Parent = this.TeamAddDate;
            this.TeamAddDate.FillColor = System.Drawing.Color.MediumSlateBlue;
            this.TeamAddDate.FocusedColor = System.Drawing.Color.MediumBlue;
            this.TeamAddDate.Font = new System.Drawing.Font("Century Gothic", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.TeamAddDate.Format = System.Windows.Forms.DateTimePickerFormat.Long;
            this.TeamAddDate.HoverState.Parent = this.TeamAddDate;
            this.TeamAddDate.Location = new System.Drawing.Point(20, 104);
            this.TeamAddDate.Margin = new System.Windows.Forms.Padding(4);
            this.TeamAddDate.MaxDate = new System.DateTime(9998, 12, 31, 0, 0, 0, 0);
            this.TeamAddDate.MinDate = new System.DateTime(1753, 1, 1, 0, 0, 0, 0);
            this.TeamAddDate.Name = "TeamAddDate";
            this.TeamAddDate.ShadowDecoration.Parent = this.TeamAddDate;
            this.TeamAddDate.Size = new System.Drawing.Size(415, 44);
            this.TeamAddDate.TabIndex = 50;
            this.TeamAddDate.Value = new System.DateTime(2023, 5, 30, 15, 38, 44, 622);
            // 
            // TeamAddTb
            // 
            this.TeamAddTb.BackColor = System.Drawing.SystemColors.Window;
            this.TeamAddTb.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.TeamAddTb.Font = new System.Drawing.Font("Century Gothic", 9.75F);
            this.TeamAddTb.ForeColor = System.Drawing.Color.Gray;
            this.TeamAddTb.HintForeColor = System.Drawing.Color.Empty;
            this.TeamAddTb.HintText = "";
            this.TeamAddTb.isPassword = false;
            this.TeamAddTb.LineFocusedColor = System.Drawing.Color.MediumBlue;
            this.TeamAddTb.LineIdleColor = System.Drawing.Color.MediumSlateBlue;
            this.TeamAddTb.LineMouseHoverColor = System.Drawing.Color.MediumBlue;
            this.TeamAddTb.LineThickness = 3;
            this.TeamAddTb.Location = new System.Drawing.Point(20, 35);
            this.TeamAddTb.Margin = new System.Windows.Forms.Padding(5);
            this.TeamAddTb.Name = "TeamAddTb";
            this.TeamAddTb.Size = new System.Drawing.Size(415, 39);
            this.TeamAddTb.TabIndex = 49;
            this.TeamAddTb.TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            // 
            // TeamAddButton
            // 
            this.TeamAddButton.CheckedState.Parent = this.TeamAddButton;
            this.TeamAddButton.CustomImages.Parent = this.TeamAddButton;
            this.TeamAddButton.FillColor = System.Drawing.Color.MediumSlateBlue;
            this.TeamAddButton.Font = new System.Drawing.Font("Century Gothic", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.TeamAddButton.ForeColor = System.Drawing.Color.White;
            this.TeamAddButton.HoverState.Parent = this.TeamAddButton;
            this.TeamAddButton.Location = new System.Drawing.Point(20, 156);
            this.TeamAddButton.Margin = new System.Windows.Forms.Padding(4);
            this.TeamAddButton.Name = "TeamAddButton";
            this.TeamAddButton.ShadowDecoration.Parent = this.TeamAddButton;
            this.TeamAddButton.Size = new System.Drawing.Size(415, 55);
            this.TeamAddButton.TabIndex = 48;
            this.TeamAddButton.Text = "Добавить";
            this.TeamAddButton.Click += new System.EventHandler(this.TeamAddButton_Click);
            // 
            // TeamAddLabel2
            // 
            this.TeamAddLabel2.AutoSize = true;
            this.TeamAddLabel2.Font = new System.Drawing.Font("Century Gothic", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.TeamAddLabel2.Location = new System.Drawing.Point(16, 9);
            this.TeamAddLabel2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.TeamAddLabel2.Name = "TeamAddLabel2";
            this.TeamAddLabel2.Size = new System.Drawing.Size(223, 21);
            this.TeamAddLabel2.TabIndex = 47;
            this.TeamAddLabel2.Text = "Введите номер бригады:";
            // 
            // TeamAddForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(455, 223);
            this.Controls.Add(this.TeamAddLabel3);
            this.Controls.Add(this.TeamAddDate);
            this.Controls.Add(this.TeamAddTb);
            this.Controls.Add(this.TeamAddButton);
            this.Controls.Add(this.TeamAddLabel2);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "TeamAddForm";
            this.Text = "Добавить бригаду";
            this.Load += new System.EventHandler(this.TeamAddForm_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label TeamAddLabel3;
        private Guna.UI2.WinForms.Guna2DateTimePicker TeamAddDate;
        private Bunifu.Framework.UI.BunifuMaterialTextbox TeamAddTb;
        private Guna.UI2.WinForms.Guna2Button TeamAddButton;
        private System.Windows.Forms.Label TeamAddLabel2;
    }
}