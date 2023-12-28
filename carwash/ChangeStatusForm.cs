using Mysqlx.Crud;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace carwash
{
    public partial class ChangeStatusForm : Form
    {
        private int orderId;

        public string SelectedStatus { get; private set; }

        public ChangeStatusForm(int orderId)
        {
            InitializeComponent();
            this.orderId = orderId; // Сохраняем значение orderId
                                    // Установка названия формы с учетом выбранного ID заказа
            ChStatusLabel.Text = "Укажите статус заказа " + orderId.ToString();

            // Установка обработчика события для кнопки ChStatusButton
            ChStatusButton.Click += ChStatusButton_Click;
        }

        private void ChStatusButton_Click(object sender, EventArgs e)
        {
            // Проверяем, выбрано ли значение в ChStatusCb
            if (ChStatusCb.SelectedItem != null)
            {
                // Получаем выбранный статус
                SelectedStatus = ChStatusCb.SelectedItem.ToString();

                // Закрываем форму с результатом DialogResult.OK
                this.DialogResult = DialogResult.OK;
                this.Close();
            }
            else
            {
                MessageBox.Show("Выберите статус заказа.", "Предупреждение", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }
    }
}
