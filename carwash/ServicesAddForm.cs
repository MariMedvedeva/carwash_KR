using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace carwash
{
    public partial class ServicesAddForm : Form
    {
        public ServicesAddForm()
        {
            InitializeComponent();
            OnLoad(EventArgs.Empty);
            ServiceAddTb.KeyPress += ServiceAddTb_KeyPress;
        }

        public int SelectedServiceId { get; set; }

        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);

            if (SelectedServiceId > 0)
            {
                // Изменение текста кнопки и названия формы для режима изменения
                ServiceAddButton.Text = "Изменить";
                this.Text = "Изменить услугу";
            }
            else
            {
                // Изменение текста кнопки и названия формы для режима добавления
                ServiceAddButton.Text = "Добавить";
                this.Text = "Добавить услугу";
            }
        }

        private void AddServiceToDatabase()
        {
            // Проверяем, что все поля заполнены и значение в NumericUpdown больше нуля
            if (string.IsNullOrEmpty(ServiceAddTb.Text) || ServiceAddNum.Value <= 0)
            {
                MessageBox.Show("Пожалуйста, заполните все поля и введите корректное значение.", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            else
            {
                int cost = Convert.ToInt32(ServiceAddNum.Value);
                string nameService = ServiceAddTb.Text;
                bool addService =  DatabaseManager.GetInstance().AddServiceToDatabase(nameService, cost);

                if (addService)
                {
                    DialogResult = DialogResult.OK;
                    MessageBox.Show("Услуга успешно добавлена.", "Успех", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    this.Close();
                }
            }
        }

        private void UpdateServiceInDatabase(int serviceId)
        {
            // Проверяем, что все поля заполнены и значение в NumericUpdown больше нуля
            if (string.IsNullOrEmpty(ServiceAddTb.Text) || ServiceAddNum.Value <= 0)
            {
                MessageBox.Show("Пожалуйста, заполните все поля и введите корректное значение.", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            else
            {
                // Преобразуем значение из NumericUpdown в числовой формат (decimal)
                int cost = Convert.ToInt32(ServiceAddNum.Value);
                string nameService = ServiceAddTb.Text;
                bool updateService = DatabaseManager.GetInstance().UpdateServiceInDatabase(serviceId, nameService, cost);
                if (updateService)
                {
                    DialogResult = DialogResult.OK;
                    MessageBox.Show("Услуга успешно изменена.", "Успех", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    this.Close();
                }
            }
        }


        private void ServiceAddButton_Click(object sender, EventArgs e)
        {
            if (SelectedServiceId > 0)
            {
                // Выполнение действий для режима изменения услуги
                UpdateServiceInDatabase(SelectedServiceId);
            }
            else
            {
                // Выполнение действий для режима добавления услуги
                AddServiceToDatabase();
            }
        }
        private void ServicesAddForm_Load(object sender, EventArgs e)
        {
            ServiceAddTb.Text = string.Empty;
            ServiceAddNum.Value = 0;

            if (SelectedServiceId > 0)
            {
                Service service = DatabaseManager.GetInstance().GetServiceById(SelectedServiceId);

                if (service != null)
                {
                    ServiceAddTb.Text = service.Name;
                    ServiceAddNum.Value = service.Cost;
                }
            }
        }
        private bool ValidateServiceInput(string input)
        {
            // Регулярное выражение для проверки, что ввод содержит только английские и русские буквы, цифры и пробелы
            string pattern = @"^[\w\s\p{IsCyrillic}]+$";
            return Regex.IsMatch(input, pattern);
        }
        private void ServiceAddTb_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!ValidateServiceInput(e.KeyChar.ToString()) && e.KeyChar != '\b')
            {
                e.Handled = true;
            }
        }
    }
}
