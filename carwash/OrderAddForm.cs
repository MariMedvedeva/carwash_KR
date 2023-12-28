using MySql.Data.MySqlClient;
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
using static Mysqlx.Expect.Open.Types.Condition.Types;

namespace carwash
{
    public partial class OrderAddForm : Form 
    {
        public OrderAddForm()
        {
            InitializeComponent();
            OnLoad(EventArgs.Empty);
        }

        public int SelectedOrderId { get; set; }

        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);

            if (SelectedOrderId > 0)
            {
                // Изменение текста кнопки и названия формы для режима изменения
                OrderAddButton.Text = "Изменить";
                this.Text = "Изменить заказ";
            }
            else
            {
                // Изменение текста кнопки и названия формы для режима добавления
                OrderAddButton.Text = "Добавить";
                this.Text = "Добавить заказ";
            }
        }

        private void OrderAddTb1_KeyPress(object sender, KeyPressEventArgs e)
        {
            // Проверяем, является ли вводимый символ цифрой или клавишей Backspace
            if (!char.IsDigit(e.KeyChar) && e.KeyChar != '\b')
            {
                // Если символ не цифра и не клавиша Backspace, отменяем его ввод
                e.Handled = true;
            }
        }

        private void OrderAddTb1_KeyDown(object sender, KeyEventArgs e)
        {
            // Проверяем, нажата ли клавиша пробела
            if (e.KeyCode == Keys.Space)
            {
                // Если нажата клавиша пробела, блокируем ее
                e.Handled = true;
            }
        }

        private void LoadWorkgroups()
        {
            OrderAddWorkgroup.Items.Clear();
            List<KeyValuePair<int, string>> workgroups = DatabaseManager.GetInstance().LoadWorkgroups();
            foreach (var workgroup in workgroups)
            {
                OrderAddWorkgroup.Items.Add(workgroup);
            }
        }

        private void LoadClients()
        {
            OrderAddClient.Items.Clear();
            List<KeyValuePair<int, string>> clients = DatabaseManager.GetInstance().LoadClients();
            foreach (var client in clients)
            {
                OrderAddClient.Items.Add(client);
            }
        }

        private void LoadServices()
        {
            OrderAddServices.Items.Clear();
            List<ServiceItem> services = DatabaseManager.GetInstance().LoadServices();
            foreach (var service in services)
            {
                OrderAddServices.Items.Add(service);
            }

            // Включение горизонтального скроллбара
            OrderAddServices.HorizontalScrollbar = true;
            // Изменяем режим выбора элементов в ListBox на One
            OrderAddServices.SelectionMode = SelectionMode.One;
        }

        private void OrderAddLb_SelectedIndexChanged(object sender, EventArgs e)
        {
            CalculateTotalCost();
        }

        private void CalculateTotalCost()
        {
            decimal totalCost = 0;

            foreach (ServiceItem service in OrderAddServices.CheckedItems)
            {
                totalCost += service.Cost;
            }

            OrderAddCost.Value = totalCost;
        }

        private void OrderAddLb_MouseDown(object sender, MouseEventArgs e)
        {
            int index = OrderAddServices.IndexFromPoint(e.Location);

            if (index != ListBox.NoMatches)
            {
                ServiceItem selectedService = (ServiceItem)OrderAddServices.Items[index];
                selectedService.IsChecked = !selectedService.IsChecked;

                OrderAddServices.Invalidate();
                CalculateTotalCost();
            }
        }

        private void AddOrderToDatabase()
        {
            // Проверка на заполнение всех полей
            if (OrderAddWorkgroup.SelectedItem == null || OrderAddClient.SelectedItem == null || 
                OrderAddStatus.SelectedItem == null || OrderAddServices.CheckedItems.Count == 0)
            {
                MessageBox.Show("Заполните все поля.", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            else
            {
                DateTime orderDate = OrderAddDate.Value;
                int orderAmount = Convert.ToInt32(OrderAddCost.Value);
                int workgroupId = ((KeyValuePair<int, string>)OrderAddWorkgroup.SelectedItem).Key;
                int clientId = ((KeyValuePair<int, string>)OrderAddClient.SelectedItem).Key;
                string orderStatus = OrderAddStatus.SelectedItem.ToString();

                // Формируем строку с названиями выбранных услуг
                string services = string.Empty;
                List<string> selectedServices = new List<string>();
                foreach (ServiceItem item in OrderAddServices.CheckedItems)
                {
                    selectedServices.Add(item.Name_Service);
                }
                services = string.Join(", ", selectedServices);

                bool addOrder = DatabaseManager.GetInstance().AddOrderToDatabase(workgroupId, clientId, orderDate, 
                    orderAmount, orderStatus, services);

                if(addOrder)
                {
                    DialogResult = DialogResult.OK;
                    MessageBox.Show("Заказ успешно добавлен.", "Успех", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    this.Close();
                }
            }
        }

        private void UpdateOrderInDatabase(int orderId)
        {
            // Проверка на заполнение всех полей
            if (OrderAddWorkgroup.SelectedItem == null ||
                OrderAddClient.SelectedItem == null ||
                OrderAddStatus.SelectedItem == null ||
                OrderAddServices.CheckedItems.Count == 0)
            {
                MessageBox.Show("Заполните все поля.", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            else
            {
                DateTime orderDate = OrderAddDate.Value;
                int orderAmount = Convert.ToInt32(OrderAddCost.Value);
                int workgroupId = ((KeyValuePair<int, string>)OrderAddWorkgroup.SelectedItem).Key;
                int clientId = ((KeyValuePair<int, string>)OrderAddClient.SelectedItem).Key;
                string orderStatus = OrderAddStatus.SelectedItem.ToString();

                // Формируем строку с названиями выбранных услуг
                string services = string.Empty;
                List<string> selectedServices = new List<string>();
                foreach (ServiceItem item in OrderAddServices.CheckedItems)
                {
                    selectedServices.Add(item.Name_Service);
                }
                services = string.Join(", ", selectedServices);

                bool updateOrder = DatabaseManager.GetInstance().UpdateOrderInDatabase(orderId, workgroupId, clientId, orderDate,
                    orderAmount, orderStatus, services);

                if (updateOrder)
                {
                    DialogResult = DialogResult.OK;
                    MessageBox.Show("Заказ успешно изменен.", "Успех", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    this.Close();
                }
            }
        }
        private void LoadOrderDetails(int orderId)
        {
            try
            {
                Order order = DatabaseManager.GetInstance().GetOrderById(orderId);
                if (order.WorkgroupId != null)
                {
                    var workgroupItem = OrderAddWorkgroup.Items.Cast<KeyValuePair<int, string>>().FirstOrDefault(item => item.Key == order.WorkgroupId);
                    OrderAddWorkgroup.SelectedItem = workgroupItem;
                }

                if (order.ClientId != null)
                {
                    var clientItem = OrderAddClient.Items.Cast<KeyValuePair<int, string>>().FirstOrDefault(item => item.Key == order.ClientId);
                    OrderAddClient.SelectedItem = clientItem;
                }

                OrderAddDate.Value = order.OrderDate;

                OrderAddCost.Value = order.OrderAmount;

                OrderAddStatus.SelectedItem = order.OrderStatus;

                CalculateTotalCost();
            }
            catch
            {
                MessageBox.Show("Ошибка загрузки данных о выбранном заказе.", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void OrderAddButton_Click(object sender, EventArgs e)
        {
            if (SelectedOrderId > 0)
            {
                // Выполнение действий для режима изменения заказа
                UpdateOrderInDatabase(SelectedOrderId);
            }
            else
            {
                // Выполнение действий для режима добавления заказа
                AddOrderToDatabase();
            }
        }

        private void OrderAddForm_Load(object sender, EventArgs e)
        {
            ClearForm();
            // Загрузка данных для ComboBox'ов
            LoadWorkgroups();
            LoadClients();
            LoadServices();

            if (SelectedOrderId > 0)
            {
                LoadOrderDetails(SelectedOrderId);
            }
        }

        private void ClearForm()
        {
            OrderAddWorkgroup.SelectedIndex = -1;
            OrderAddClient.SelectedIndex = -1;
            OrderAddServices.ClearSelected();
            OrderAddDate.Value = DateTime.Now;
            OrderAddCost.Value = 0;
            OrderAddStatus.SelectedIndex = -1;
        }
    }
}
