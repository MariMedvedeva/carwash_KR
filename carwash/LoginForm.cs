using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace carwash
{
    public partial class LoginForm : Form
    {
        public LoginForm()
        {
            InitializeComponent();
        }

        private void ConnectButton_Click(object sender, EventArgs e)
        {
            string username = usernameTb.Text;
            string password = passwordTb.Text;

            if (username != "Имя пользователя" && password != "Пароль")
            {
                string enteredHashedPassword = HashPassword(password);

                bool authenticated = DatabaseManager.GetInstance().AuthenticateUser(username, enteredHashedPassword);

                if (authenticated)
                {
                    DialogResult = DialogResult.OK;
                    return;
                }
                else
                {
                    // Вывести сообщение о неправильном вводе имени пользователя или пароля
                    MessageBox.Show("Неверное имя пользователя или пароль", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                // Вывести сообщение о неправильном вводе имени пользователя или пароля
                MessageBox.Show("Пожалуйста, введите имя пользователя и пароль", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
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
        private void LoginForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            if (this.DialogResult != DialogResult.OK)
            {
                Application.Exit();
            }
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
            passwordTb.isPassword = true;
        }

        private void passwordTb_Leave(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(passwordTb.Text))
            {
                passwordTb.ForeColor = Color.Gray;
                passwordTb.Text = "Пароль";
                passwordTb.isPassword = false;
            }
        }

        private bool mouseIsDown = false;
        private System.Windows.Forms.Timer timer;
        private void pictureBox3_MouseDown(object sender, MouseEventArgs e)
        {
            mouseIsDown = true;
            timer = new System.Windows.Forms.Timer();
            timer.Interval = 100; 
            timer.Tick += new EventHandler(timer1_Tick);
            timer.Start();
        }

        private void pictureBox3_MouseUp(object sender, MouseEventArgs e)
        {
            mouseIsDown = false;
            timer.Stop();
            passwordTb.isPassword = true;
            pictureBox3.Image = Properties.Resources.hidden;          
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            if (mouseIsDown)
            {
                passwordTb.isPassword = false;
                pictureBox3.Image = Properties.Resources.vieweye;
            }
        }

        private void label1_Click(object sender, EventArgs e)
        {
            // Создаем и открываем форму регистрации
            RegForm regForm = new RegForm();
            regForm.ShowDialog();
        }
    }
}
