using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Text.RegularExpressions;
using System.Security.Cryptography;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.StartPanel;

namespace carwash
{
    public partial class RegForm : Form
    {
        public RegForm()
        {
            InitializeComponent();
        }

        // Метод для хеширования пароля
        private string HashPassword(string password)
        {
            // Создаем объект SHA256 для вычисления хеша
            using (SHA256 sha256 = SHA256.Create())
            {
                // Преобразуем пароль в массив байтов
                byte[] passwordBytes = Encoding.UTF8.GetBytes(password);

                // Вычисляем хеш пароля
                byte[] hashBytes = sha256.ComputeHash(passwordBytes);

                // Преобразуем хеш в строку в шестнадцатеричном формате
                string hashedPassword = BitConverter.ToString(hashBytes).Replace("-", "").ToLower();

                return hashedPassword;
            }
        }

        private void RegButton_Click(object sender, EventArgs e)
        {
            // Получаем введенные данные из текстовых полей
            string login = usernameTb.Text;
            string password = passwordTb.Text;

            // Хешируем пароль
            string hashedPassword = HashPassword(password);

            // Выполняем проверку на заполненность полей
            if (string.IsNullOrEmpty(login) || string.IsNullOrEmpty(password) || login == "Имя пользователя" || password == "Пароль")
            {
                MessageBox.Show("Пожалуйста, заполните все поля и введите корректные данные.", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            // Выполняем проверку на наличие кириллических символов в логине и пароле
            if (ContainsCyrillicCharacters(login) || ContainsCyrillicCharacters(password))
            {
                MessageBox.Show("Пожалуйста, используйте только латинские символы и числа в логине и пароле.", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            bool registration = DatabaseManager.GetInstance().RegistrationUser(login, hashedPassword);

            if (registration)
            {
                DialogResult = DialogResult.OK;
                MessageBox.Show("Регистрация прошла успешно!", "Успех", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.Close();
            }
        }


        private bool ContainsCyrillicCharacters(string text)
        {
            Regex regex = new Regex(@"\p{IsCyrillic}");
            return regex.IsMatch(text);
        }

        private void usernameTb_Enter(object sender, EventArgs e)
        {
            if (usernameTb.Text == "Имя пользователя")
            {
                usernameTb.ForeColor = Color.Black;
                usernameTb.Text = "";
            }
        }

        private void usernameTb_Leave(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(usernameTb.Text))
            {
                usernameTb.ForeColor = Color.Gray;
                usernameTb.Text = "Имя пользователя";
            }
        }

        private void passwordTb_Enter(object sender, EventArgs e)
        {
            if (passwordTb.Text == "Пароль")
            {
                passwordTb.ForeColor = Color.Black;
                passwordTb.Text = "";
            }
        }

        private void passwordTb_Leave(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(passwordTb.Text))
            {
                passwordTb.ForeColor = Color.Gray;
                passwordTb.Text = "Пароль";
            }
        }
    }
}
