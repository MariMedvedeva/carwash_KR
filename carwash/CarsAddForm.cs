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
using MySql.Data.MySqlClient;

namespace carwash
{
    public partial class CarsAddForm : Form
    {
        public CarsAddForm()
        {
            InitializeComponent();
            OnLoad(EventArgs.Empty);
        }

        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);

            if (SelectedCarId > 0)
            {
                // Изменение текста кнопки и названия формы для режима изменения
                CarsAddButton.Text = "Изменить";
                this.Text = "Изменить автомобиль";
            }
            else
            {
                // Изменение текста кнопки и названия формы для режима добавления
                CarsAddButton.Text = "Добавить";
                this.Text = "Добавить автомобиль";
            }
        }

        public int SelectedCarId { get; set; }

        private void AddCarToDataBase()
        {
            // Проверяем, что все текстовые поля не пустые
            if (
                string.IsNullOrEmpty(CarBrand.Text) ||
                string.IsNullOrEmpty(CarModel.Text) ||
                string.IsNullOrEmpty(CarNumber.Text))
            {
                MessageBox.Show("Пожалуйста, заполните все поля.", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            else
            {
                string brand = CarBrand.Text;
                string model = CarModel.Text;
                string number = CarNumber.Text;
                bool addCar = DatabaseManager.GetInstance().AddCarToDatabase(brand, model, number);

                if(addCar)
                {
                    DialogResult = DialogResult.OK;
                    MessageBox.Show("Автомобиль успешно добавлен.", "Успех", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    this.Close();
                }
            }
        }

        private void UpdateCarInDataBase(int carId)
        {
            // Проверка на заполнение всех полей
            if (string.IsNullOrEmpty(CarBrand.Text) ||
                string.IsNullOrEmpty(CarModel.Text) ||
                string.IsNullOrEmpty(CarNumber.Text))
            {
                MessageBox.Show("Заполните все поля.", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            else
            {
                string brand = CarBrand.Text;
                string model = CarModel.Text;
                string number = CarNumber.Text;
                bool updateCar = DatabaseManager.GetInstance().UpdateCarInDatabase(carId, brand, model, number);
                if (updateCar)
                {
                    DialogResult = DialogResult.OK;
                    MessageBox.Show("Автомобиль успешно изменен.", "Успех", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    this.Close();
                }
            }
        }

        private void CarsAddButton_Click(object sender, EventArgs e)
        {
            if (SelectedCarId > 0)
            {
                // Выполнение действий для режима изменения автомобиля
                UpdateCarInDataBase(SelectedCarId);
            }
            else
            {
                // Выполнение действий для режима добавления автомобиля
                AddCarToDataBase();
            }
        }

        private void CarsAddForm_Load(object sender, EventArgs e)
        {
            CarBrand.Text = string.Empty;
            CarModel.Text = string.Empty;
            CarNumber.Text = string.Empty;

            if (SelectedCarId > 0)
            {
                Car car = DatabaseManager.GetInstance().GetCarById(SelectedCarId);
                if (car != null)
                {
                    CarBrand.Text = car.Brand;
                    CarModel.Text = car.Model;
                    CarNumber.Text = car.Car_Number;
                }
            }
        }
    }
}
