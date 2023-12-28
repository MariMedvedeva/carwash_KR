using Guna.UI2.WinForms.Suite;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace carwash
{
    public partial class WorkersAddForm : Form
    {
        private Worker selectedWorker;
        public WorkersAddForm()
        {
            InitializeComponent();
            OnLoad(EventArgs.Empty);
            WorkersAddName.KeyPress += WorkersAddName_KeyPress;
        }

        public int SelectedWorkerId { get; set; }

        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);

            if (SelectedWorkerId > 0)
            {
                // Изменение текста кнопки и названия формы для режима изменения
                WorkersAddButton.Text = "Изменить";
                this.Text = "Изменить работника";

                WorkersAddPb.SizeMode = PictureBoxSizeMode.Zoom;
            }
            else
            {
                // Изменение текста кнопки и названия формы для режима добавления
                WorkersAddButton.Text = "Добавить";
                this.Text = "Добавить работника";

                WorkersAddPb.SizeMode = PictureBoxSizeMode.Zoom;
            }
        }

        private void WorkersAddButton2_Click(object sender, EventArgs e)
        {
            // Создание и настройка OpenFileDialog
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "Image Files (*.jpg, *.png, *.bmp)|*.jpg;*.png;*.bmp";

            // Проверка, была ли выбрана фотография
            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                // Загрузка выбранной фотографии в PictureBox
                string selectedImagePath = openFileDialog.FileName;
                Image selectedImage = Image.FromFile(selectedImagePath);
                WorkersAddPb.Image = selectedImage;
            }
        }

        private void AddWorkerToDatabase()
        {
            if (string.IsNullOrEmpty(WorkersAddName.Text) ||
                string.IsNullOrEmpty(WorkersAddNum.Text) ||
                WorkersAddWorkgroup.SelectedItem == null ||
                string.IsNullOrEmpty(WorkersAddDate.Text) ||
                WorkersAddPb.Image == null)
            {
                MessageBox.Show("Пожалуйста, заполните все поля и выберите фото работника.", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            else{
                KeyValuePair<int, string> selectedWorkgroup = (KeyValuePair<int, string>)WorkersAddWorkgroup.SelectedItem;
                int selectedWorkgroupId = selectedWorkgroup.Key;
                string nameWorker = WorkersAddName.Text;
                int numberContract = Convert.ToInt32(WorkersAddNum.Text);
                byte[] photo = GetByteArrayFromImage(WorkersAddPb.Image);
                DateTime dateOfEmployment = WorkersAddDate.Value;

                bool addWorker = DatabaseManager.GetInstance().AddWorkerToDatabase(selectedWorkgroupId, nameWorker, 
                    numberContract, photo, dateOfEmployment);
                if (addWorker)
                {
                    DialogResult = DialogResult.OK;
                    MessageBox.Show("Работник успешно добавлен.", "Успех", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    this.Close();
                }
            }
        }

        private void UpdateWorkerInDatabase(int workerId)
        {
            if (string.IsNullOrEmpty(WorkersAddName.Text) ||
                string.IsNullOrEmpty(WorkersAddNum.Text) ||
                WorkersAddWorkgroup.SelectedItem == null ||
                string.IsNullOrEmpty(WorkersAddDate.Text) ||
                WorkersAddPb.Image == null)
            {
                MessageBox.Show("Пожалуйста, заполните все поля и выберите фото работника.", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            else
            {
                KeyValuePair<int, string> selectedWorkgroup = (KeyValuePair<int, string>)WorkersAddWorkgroup.SelectedItem;
                int selectedWorkgroupId = selectedWorkgroup.Key;
                string nameWorker = WorkersAddName.Text;
                int numberContract = Convert.ToInt32(WorkersAddNum.Text);
                byte[] photo = GetByteArrayFromImage(WorkersAddPb.Image);
                DateTime dateOfEmployment = WorkersAddDate.Value;

                bool updateWorker = DatabaseManager.GetInstance().UpdateWorkerInDatabase(workerId, selectedWorkgroupId, nameWorker,
                    numberContract, photo, dateOfEmployment);
                if (updateWorker)
                {
                    DialogResult = DialogResult.OK;
                    MessageBox.Show("Работник успешно изменен.", "Успех", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    this.Close();
                }
            }
        }

        private void WorkersAddButton1_Click(object sender, EventArgs e)
        {
            if (SelectedWorkerId > 0)
            {
                UpdateWorkerInDatabase(SelectedWorkerId);
            }
            else
            {
                AddWorkerToDatabase();
            }
        }

        // Метод для преобразования изображения в массив байтов
        private byte[] GetByteArrayFromImage(Image image)
        {
            using (MemoryStream stream = new MemoryStream())
            {
                image.Save(stream, ImageFormat.Jpeg);
                return stream.ToArray();
            }
        }

        private void ClearForm()
        {
            WorkersAddWorkgroup.SelectedIndex = -1;
            WorkersAddName.Text = "";
            WorkersAddNum.Text = " ";
            WorkersAddDate.Value = DateTime.Now;
            WorkersAddPb.Image = null;
        }

        private void WorkersAddForm_Load(object sender, EventArgs e)
        {
            ClearForm();

            int selectedWorkerId = SelectedWorkerId;

            List<KeyValuePair<int, string>> workgroups = DatabaseManager.GetInstance().GetWorkgroupsForComboBox(selectedWorkerId);

            WorkersAddWorkgroup.Items.Clear();

            foreach (var workgroup in workgroups)
            {
                WorkersAddWorkgroup.Items.Add(workgroup);
            }

            // Если выбран работник для изменения, загрузить его данные в поля формы
            if (selectedWorkerId > 0)
            {
                selectedWorker = DatabaseManager.GetInstance().GetWorkerById(selectedWorkerId); 

                if (selectedWorker != null)
                {
                    // Заполнение полей формы данными выбранного работника
                    WorkersAddName.Text = selectedWorker.Name;
                    WorkersAddNum.Text = selectedWorker.NumberContract.ToString();
                    //WorkersAddPb1.Image = ByteArrayToImage(selectedWorker.Photo);
                    WorkersAddDate.Value = selectedWorker.DateOfEmployment;

                    // Установка выбранной бригады в ComboBox
                    SetSelectedWorkgroupInComboBox(selectedWorker.WorkgroupId);
                }
            }
        }
        private void SetSelectedWorkgroupInComboBox(int? selectedWorkgroupId)
        {
            if (selectedWorkgroupId.HasValue)
            {
                for (int i = 0; i < WorkersAddWorkgroup.Items.Count; i++)
                {
                    KeyValuePair<int, string> workgroup = (KeyValuePair<int, string>)WorkersAddWorkgroup.Items[i];

                    if (workgroup.Key == selectedWorkgroupId)
                    {
                        WorkersAddWorkgroup.SelectedIndex = i;
                        break;
                    }
                }
            }
        }

        private void WorkersAddTb3_KeyPress(object sender, KeyPressEventArgs e)
        {
            // Проверяем, является ли вводимый символ цифрой или клавишей Backspace
            if (!char.IsDigit(e.KeyChar) && e.KeyChar != '\b')
            {
                // Если символ не цифра и не клавиша Backspace, отменяем его ввод
                e.Handled = true;
            }
        }

        private void WorkersAddTb3_KeyDown(object sender, KeyEventArgs e)
        {
            // Проверяем, нажата ли клавиша пробела
            if (e.KeyCode == Keys.Space)
            {
                // Если нажата клавиша пробела, блокируем ее
                e.Handled = true;
            }
        }
        private bool ValidateNameInput(string input)
        {
            // Регулярное выражение для проверки на соответствие ввода только буквы
            string pattern = @"^[\s\p{IsCyrillic}]+$";
            return Regex.IsMatch(input, pattern);
        }
        private void WorkersAddName_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!ValidateNameInput(e.KeyChar.ToString()) && e.KeyChar != '\b')
            {
                e.Handled = true;
            }
        }
    }
}
