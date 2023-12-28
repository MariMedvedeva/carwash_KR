namespace carwash
{
    partial class ChangeStatusForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ChangeStatusForm));
            this.ChStatusButton = new Guna.UI2.WinForms.Guna2Button();
            this.ChStatusLabel = new System.Windows.Forms.Label();
            this.ChStatusCb = new MetroFramework.Controls.MetroComboBox();
            this.SuspendLayout();
            // 
            // ChStatusButton
            // 
            this.ChStatusButton.CheckedState.Parent = this.ChStatusButton;
            this.ChStatusButton.CustomImages.Parent = this.ChStatusButton;
            this.ChStatusButton.FillColor = System.Drawing.Color.MediumSlateBlue;
            this.ChStatusButton.Font = new System.Drawing.Font("Century Gothic", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.ChStatusButton.ForeColor = System.Drawing.Color.White;
            this.ChStatusButton.HoverState.Parent = this.ChStatusButton;
            this.ChStatusButton.Location = new System.Drawing.Point(16, 81);
            this.ChStatusButton.Margin = new System.Windows.Forms.Padding(4);
            this.ChStatusButton.Name = "ChStatusButton";
            this.ChStatusButton.ShadowDecoration.Parent = this.ChStatusButton;
            this.ChStatusButton.Size = new System.Drawing.Size(415, 55);
            this.ChStatusButton.TabIndex = 19;
            this.ChStatusButton.Text = "Изменить";
            this.ChStatusButton.Click += new System.EventHandler(this.ChStatusButton_Click);
            // 
            // ChStatusLabel
            // 
            this.ChStatusLabel.AutoSize = true;
            this.ChStatusLabel.Font = new System.Drawing.Font("Century Gothic", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.ChStatusLabel.Location = new System.Drawing.Point(12, 14);
            this.ChStatusLabel.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.ChStatusLabel.Name = "ChStatusLabel";
            this.ChStatusLabel.Size = new System.Drawing.Size(213, 21);
            this.ChStatusLabel.TabIndex = 18;
            this.ChStatusLabel.Text = "Укажите статус заказа:";
            // 
            // ChStatusCb
            // 
            this.ChStatusCb.FormattingEnabled = true;
            this.ChStatusCb.ItemHeight = 24;
            this.ChStatusCb.Items.AddRange(new object[] {
            "Выполнен",
            "Отклонен",
            "В процессе"});
            this.ChStatusCb.Location = new System.Drawing.Point(16, 38);
            this.ChStatusCb.Margin = new System.Windows.Forms.Padding(4);
            this.ChStatusCb.Name = "ChStatusCb";
            this.ChStatusCb.Size = new System.Drawing.Size(413, 30);
            this.ChStatusCb.TabIndex = 17;
            this.ChStatusCb.UseSelectable = true;
            // 
            // ChangeStatusForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(448, 155);
            this.Controls.Add(this.ChStatusButton);
            this.Controls.Add(this.ChStatusLabel);
            this.Controls.Add(this.ChStatusCb);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "ChangeStatusForm";
            this.Text = "Изменить статус заказа";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Guna.UI2.WinForms.Guna2Button ChStatusButton;
        private System.Windows.Forms.Label ChStatusLabel;
        private MetroFramework.Controls.MetroComboBox ChStatusCb;
    }
}