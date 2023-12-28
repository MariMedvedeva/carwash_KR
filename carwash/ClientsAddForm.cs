using MySql.Data.MySqlClient;
using MySqlX.XDevAPI;
using Org.BouncyCastle.Crypto;
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
    public partial class ClientsAddForm : Form 
    {
        public ClientsAddForm()
        {
            InitializeComponent();
            OnLoad(EventArgs.Empty);
            ClientsAddName.KeyPress += ClientsAddName_KeyPress;
            ClientsAddPhone.KeyPress += ClientsAddPhone_KeyPress;
        }

        public int SelectedClientId { get; set; }

        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);

            if (SelectedClientId > 0)
            {
                // Изменение текста кнопки и названия формы для режима изменения
                ClientsAddButton.Text = "Изменить";
                this.Text = "Изменить клиента";
            }
            else
            {
                // Изменение текста кнопки и названия формы для режима добавления
                ClientsAddButton.Text = "Добавить";
                this.Text = "Добавить клиента";
            }
        }

        private void ClientsAddForm_Load(object sender, EventArgs e)
        {
            ClientsAddCar.SelectedIndex = -1;
            ClientsAddName.Text = string.Empty;
            ClientsAddPhone.Text = string.Empty;

            List<KeyValuePair<int, string>> unassignedCars = DatabaseManager.GetInstance().GetUnassignedCars();

            ClientsAddCar.Items.Clear();
            foreach (var car in unassignedCars)
            {
                ClientsAddCar.Items.Add(car);
            }

            if (SelectedClientId > 0)
            {
                KeyValuePair<int, string> clientCar = DatabaseManager.GetInstance().GetClientCar(SelectedClientId);
                ClientsAddCar.Items.Add(clientCar);
                ClientsAddCar.SelectedItem = clientCar;

                KeyValuePair<string, string> clientInfo = DatabaseManager.GetInstance().GetClientInfo(SelectedClientId);
                ClientsAddName.Text = clientInfo.Key; // Имя клиента
                ClientsAddPhone.Text = clientInfo.Value; // Телефон клиента
            }
        }

        private void AddClientToDatabase()
        {
            // Проверяем, что все поля заполнены
            if (string.IsNullOrEmpty(ClientsAddName.Text) || string.IsNullOrEmpty(ClientsAddPhone.Text) ||
                ClientsAddCar.SelectedItem == null)
            {
                MessageBox.Show("Пожалуйста, заполните все поля и выберите машину из списка.", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            else
            {
                KeyValuePair<int, string> selectedCar = (KeyValuePair<int, string>)ClientsAddCar.SelectedItem;
                int selectedCarId = selectedCar.Key;
                string nameClient = ClientsAddName.Text;
                string phoneClient = ClientsAddPhone.Text;
                bool addCar = DatabaseManager.GetInstance().AddClientToDatabase(selectedCarId, nameClient, phoneClient);

                if (addCar)
                {
                    DialogResult = DialogResult.OK;
                    MessageBox.Show("Клиент успешно добавлен.", "Успех", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    this.Close();
                }
            }
        }

        private void UpdateClientInDatabase(int clientId)
        {
            // Проверяем, что все поля заполнены
            if (string.IsNullOrEmpty(ClientsAddName.Text) ||
                string.IsNullOrEmpty(ClientsAddPhone.Text) ||
                ClientsAddCar.SelectedItem == null)
            {
                MessageBox.Show("Пожалуйста, заполните все поля и выберите машину из списка.", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            else
            {
                int carId = ((KeyValuePair<int, string>)ClientsAddCar.SelectedItem).Key;
                string clientName = ClientsAddName.Text;
                string phoneNumber = ClientsAddPhone.Text;
                bool updateClient = DatabaseManager.GetInstance().UpdateClientInDatabase(clientId, carId, clientName, phoneNumber);

                if (updateClient)
                {
                    DialogResult = DialogResult.OK;
                    MessageBox.Show("Клиент успешно изменен.", "Успех", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    this.Close();
                }
            }
        }

        private void ClientsAddButton_Click(object sender, EventArgs e)
        {
            if (SelectedClientId > 0)
            {
                // Выполнение действий для режима изменения клиента
                UpdateClientInDatabase(SelectedClientId);
            }
            else
            {
                // Выполнение действий для режима добавления клиента
                AddClientToDatabase();
            }
        }


        private bool ValidateNameInput(string input)
        {
            // Регулярное выражение для проверки на соответствие ввода символам русского алфавита
            string pattern = @"^[А-Яа-яёЁ\s]+$";
            return Regex.IsMatch(input, pattern);
        }
        private bool ValidatePhoneInput(string input)
        {
            // Регулярное выражение для проверки на соответствие ввода только цифрам
            string pattern = @"^\d+$";
            return Regex.IsMatch(input, pattern);
        }
        private void ClientsAddName_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!ValidateNameInput(e.KeyChar.ToString()) && e.KeyChar != '\b')
            {
                e.Handled = true;
            }
        }

        private void ClientsAddPhone_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!ValidatePhoneInput(e.KeyChar.ToString()) && e.KeyChar != '\b')
            {
                e.Handled = true;
            }
        }
    }
}
