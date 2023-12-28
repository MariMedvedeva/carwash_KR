namespace carwash
{
    partial class CarsAddForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(CarsAddForm));
            this.CarBrand = new Bunifu.Framework.UI.BunifuMaterialTextbox();
            this.CarsAddButton = new Guna.UI2.WinForms.Guna2Button();
            this.CarsAddLabel3 = new System.Windows.Forms.Label();
            this.CarsAddLabel2 = new System.Windows.Forms.Label();
            this.CarModel = new Bunifu.Framework.UI.BunifuMaterialTextbox();
            this.CarNumber = new Bunifu.Framework.UI.BunifuMaterialTextbox();
            this.CarsAddLabel4 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // CarBrand
            // 
            this.CarBrand.BackColor = System.Drawing.SystemColors.Window;
            this.CarBrand.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.CarBrand.Font = new System.Drawing.Font("Century Gothic", 9.75F);
            this.CarBrand.ForeColor = System.Drawing.Color.Gray;
            this.CarBrand.HintForeColor = System.Drawing.Color.Empty;
            this.CarBrand.HintText = "";
            this.CarBrand.isPassword = false;
            this.CarBrand.LineFocusedColor = System.Drawing.Color.MediumBlue;
            this.CarBrand.LineIdleColor = System.Drawing.Color.MediumSlateBlue;
            this.CarBrand.LineMouseHoverColor = System.Drawing.Color.MediumBlue;
            this.CarBrand.LineThickness = 3;
            this.CarBrand.Location = new System.Drawing.Point(18, 36);
            this.CarBrand.Margin = new System.Windows.Forms.Padding(5);
            this.CarBrand.Name = "CarBrand";
            this.CarBrand.Size = new System.Drawing.Size(415, 39);
            this.CarBrand.TabIndex = 39;
            this.CarBrand.TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            // 
            // CarsAddButton
            // 
            this.CarsAddButton.CheckedState.Parent = this.CarsAddButton;
            this.CarsAddButton.CustomImages.Parent = this.CarsAddButton;
            this.CarsAddButton.FillColor = System.Drawing.Color.MediumSlateBlue;
            this.CarsAddButton.Font = new System.Drawing.Font("Century Gothic", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.CarsAddButton.ForeColor = System.Drawing.Color.White;
            this.CarsAddButton.HoverState.Parent = this.CarsAddButton;
            this.CarsAddButton.Location = new System.Drawing.Point(19, 224);
            this.CarsAddButton.Margin = new System.Windows.Forms.Padding(4);
            this.CarsAddButton.Name = "CarsAddButton";
            this.CarsAddButton.ShadowDecoration.Parent = this.CarsAddButton;
            this.CarsAddButton.Size = new System.Drawing.Size(415, 55);
            this.CarsAddButton.TabIndex = 38;
            this.CarsAddButton.Text = "Добавить";
            this.CarsAddButton.Click += new System.EventHandler(this.CarsAddButton_Click);
            // 
            // CarsAddLabel3
            // 
            this.CarsAddLabel3.AutoSize = true;
            this.CarsAddLabel3.Font = new System.Drawing.Font("Century Gothic", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.CarsAddLabel3.Location = new System.Drawing.Point(14, 80);
            this.CarsAddLabel3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.CarsAddLabel3.Name = "CarsAddLabel3";
            this.CarsAddLabel3.Size = new System.Drawing.Size(258, 21);
            this.CarsAddLabel3.TabIndex = 37;
            this.CarsAddLabel3.Text = "Введите модель автомобиля:";
            // 
            // CarsAddLabel2
            // 
            this.CarsAddLabel2.AutoSize = true;
            this.CarsAddLabel2.Font = new System.Drawing.Font("Century Gothic", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.CarsAddLabel2.Location = new System.Drawing.Point(14, 10);
            this.CarsAddLabel2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.CarsAddLabel2.Name = "CarsAddLabel2";
            this.CarsAddLabel2.Size = new System.Drawing.Size(250, 21);
            this.CarsAddLabel2.TabIndex = 36;
            this.CarsAddLabel2.Text = "Введите марку автомобиля:";
            // 
            // CarModel
            // 
            this.CarModel.BackColor = System.Drawing.SystemColors.Window;
            this.CarModel.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.CarModel.Font = new System.Drawing.Font("Century Gothic", 9.75F);
            this.CarModel.ForeColor = System.Drawing.Color.Gray;
            this.CarModel.HintForeColor = System.Drawing.Color.Empty;
            this.CarModel.HintText = "";
            this.CarModel.isPassword = false;
            this.CarModel.LineFocusedColor = System.Drawing.Color.MediumBlue;
            this.CarModel.LineIdleColor = System.Drawing.Color.MediumSlateBlue;
            this.CarModel.LineMouseHoverColor = System.Drawing.Color.MediumBlue;
            this.CarModel.LineThickness = 3;
            this.CarModel.Location = new System.Drawing.Point(19, 106);
            this.CarModel.Margin = new System.Windows.Forms.Padding(5);
            this.CarModel.Name = "CarModel";
            this.CarModel.Size = new System.Drawing.Size(415, 39);
            this.CarModel.TabIndex = 40;
            this.CarModel.TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            // 
            // CarNumber
            // 
            this.CarNumber.BackColor = System.Drawing.SystemColors.Window;
            this.CarNumber.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.CarNumber.Font = new System.Drawing.Font("Century Gothic", 9.75F);
            this.CarNumber.ForeColor = System.Drawing.Color.Gray;
            this.CarNumber.HintForeColor = System.Drawing.Color.Empty;
            this.CarNumber.HintText = "";
            this.CarNumber.isPassword = false;
            this.CarNumber.LineFocusedColor = System.Drawing.Color.MediumBlue;
            this.CarNumber.LineIdleColor = System.Drawing.Color.MediumSlateBlue;
            this.CarNumber.LineMouseHoverColor = System.Drawing.Color.MediumBlue;
            this.CarNumber.LineThickness = 3;
            this.CarNumber.Location = new System.Drawing.Point(19, 176);
            this.CarNumber.Margin = new System.Windows.Forms.Padding(5);
            this.CarNumber.Name = "CarNumber";
            this.CarNumber.Size = new System.Drawing.Size(415, 39);
            this.CarNumber.TabIndex = 42;
            this.CarNumber.TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            // 
            // CarsAddLabel4
            // 
            this.CarsAddLabel4.AutoSize = true;
            this.CarsAddLabel4.Font = new System.Drawing.Font("Century Gothic", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.CarsAddLabel4.Location = new System.Drawing.Point(14, 151);
            this.CarsAddLabel4.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.CarsAddLabel4.Name = "CarsAddLabel4";
            this.CarsAddLabel4.Size = new System.Drawing.Size(291, 21);
            this.CarsAddLabel4.TabIndex = 41;
            this.CarsAddLabel4.Text = "Введите гос. номер автомобиля:";
            // 
            // CarsAddForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(447, 286);
            this.Controls.Add(this.CarNumber);
            this.Controls.Add(this.CarsAddLabel4);
            this.Controls.Add(this.CarModel);
            this.Controls.Add(this.CarBrand);
            this.Controls.Add(this.CarsAddButton);
            this.Controls.Add(this.CarsAddLabel3);
            this.Controls.Add(this.CarsAddLabel2);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "CarsAddForm";
            this.Text = "Добавить автомобиль";
            this.Load += new System.EventHandler(this.CarsAddForm_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Bunifu.Framework.UI.BunifuMaterialTextbox CarBrand;
        private Guna.UI2.WinForms.Guna2Button CarsAddButton;
        private System.Windows.Forms.Label CarsAddLabel3;
        private System.Windows.Forms.Label CarsAddLabel2;
        private Bunifu.Framework.UI.BunifuMaterialTextbox CarModel;
        private Bunifu.Framework.UI.BunifuMaterialTextbox CarNumber;
        private System.Windows.Forms.Label CarsAddLabel4;
    }
}