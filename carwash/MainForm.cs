using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static carwash.LoginForm;
using Word = Microsoft.Office.Interop.Word;

namespace carwash
{
    public partial class MainForm : Form
    {
        private DatabaseManager dbManager;
        private int originalWidth;
        private int reducedWidth;
        public MainForm()
        {
            InitializeComponent();
            MenuTab.SelectedIndexChanged += MenuTab_SelectedIndexChanged;
            dbManager = DatabaseManager.GetInstance();
            originalWidth = this.Width;
            reducedWidth = originalWidth / 2;
        }

        private void LoadCarsData()
        {
            DataTable dataTable = dbManager.GetCarsData();
            CarsGrid.DataSource = dataTable;
            CarsGrid.ClearSelection();
        }

        private void LoadServiceData()
        {
            DataTable dataTable = dbManager.GetServiceData();
            ServicesGrid.DataSource = dataTable;
            ServicesGrid.ClearSelection();
        }

        private void LoadTeamData()
        {
            DataTable dataTable = dbManager.GetTeamData();
            TeamGrid.DataSource = dataTable;
            TeamGrid.ClearSelection();
        }

        private void LoadClientsData()
        {
            DataTable dataTable = dbManager.GetClientsData();
            ClientsGrid.DataSource = dataTable;
            ClientsGrid.ClearSelection();
        }

        private void LoadWorkersData()
        {
            DataTable dataTable = dbManager.GetWorkersData();
            WorkersGrid.DataSource = dataTable;
            WorkersGrid.ClearSelection();
        }

        private void LoadOrderData()
        {
            DataTable dataTable = dbManager.GetOrderData();
            OrderGrid.DataSource = dataTable;
            OrderGrid.ClearSelection();
        }

        private void OrderAddButton_Click(object sender, EventArgs e)
        {
            OrderAddForm orderaddForm = new OrderAddForm();
            orderaddForm.FormClosed += OrderAddForm_FormClosed;
            orderaddForm.Show();
        }

        private void OrderAddForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            LoadOrderData();
        }

        private void ServicesAddButton_Click(object sender, EventArgs e)
        {
            ServicesAddForm servicesaddForm = new ServicesAddForm();
            servicesaddForm.FormClosed += ServicesaddForm_FormClosed;
            servicesaddForm.Show();
        }

        private void ServicesaddForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            LoadServiceData();
        }

        private void ClientsAddButton_Click(object sender, EventArgs e)
        {
            ClientsAddForm clientsaddForm = new ClientsAddForm();
            clientsaddForm.FormClosed += ClientsAddForm_FormClosed;
            clientsaddForm.Show();
        }

        private void ClientsAddForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            LoadClientsData();
        }

        private void CarsAddButton_Click(object sender, EventArgs e)
        {
            CarsAddForm carsaddForm = new CarsAddForm();
            carsaddForm.FormClosed += CarsAddForm_FormClosed;
            carsaddForm.Show();
        }

        private void CarsAddForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            LoadCarsData();
        }

        private void WorkersAddButton_Click(object sender, EventArgs e)
        {
            WorkersAddForm workersaddForm = new WorkersAddForm();
            workersaddForm.FormClosed += WorkersAddForm_FormClosed;
            workersaddForm.Show();
        }

        private void WorkersAddForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            LoadWorkersData();
        }

        private void TeamAddButton_Click(object sender, EventArgs e)
        {
            TeamAddForm teamaddForm = new TeamAddForm();
            teamaddForm.FormClosed += TeamAddForm_FormClosed;
            teamaddForm.Show();
        }

        private void TeamAddForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            LoadTeamData();
        }

        private void MenuTab_SelectedIndexChanged(object sender, EventArgs e)
        {
            // Получаем текущий выбранный TabPage
            TabPage selectedTabPage = MenuTab.SelectedTab;

            // Проверяем, что это нужный TabPage, на котором хотим загрузить данные
            if (selectedTabPage == mainpage)
            {
                MainStartDate.Value = DateTime.Now;
                MainEndDate.Value = DateTime.Now;
                this.Width = reducedWidth; // Устанавливаем ширину в 2 раза меньше исходной для вкладки mainpage
            }
            else
            {
                this.Width = originalWidth; // Возвращаем исходную ширину для других вкладок
                if (selectedTabPage == carspage)
                {
                    LoadCarsData();
                }
                else if (selectedTabPage == servicespage)
                {
                    LoadServiceData();
                }
                else if (selectedTabPage == teampage)
                {
                    LoadTeamData();
                }
                else if (selectedTabPage == clientspage)
                {
                    LoadClientsData();
                }
                else if (selectedTabPage == workerspage)
                {
                    LoadWorkersData();
                }
                else if (selectedTabPage == orderpage)
                {
                    LoadOrderData();
                }
            }
        }

        private void CarsGrid_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            CarsGrid.Columns["ID_Car"].HeaderText = "ID автомобиля";
            CarsGrid.Columns["Brand"].HeaderText = "Марка";
            CarsGrid.Columns["Model"].HeaderText = "Модель";
            CarsGrid.Columns["Car_Number"].HeaderText = "Гос. номер";
        }

        private void CarsDeleteButton_Click(object sender, EventArgs e)
        {
            if (CarsGrid.SelectedRows.Count > 0)
            {
                DialogResult result = MessageBox.Show("Вы действительно хотите удалить выбранную строку?", "Подтверждение удаления", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                if (result == DialogResult.Yes)
                {
                    int idCar = (int)CarsGrid.SelectedRows[0].Cells["ID_Car"].Value;

                    if (dbManager.IsCarLinkedToClient(idCar))
                    {
                        if (dbManager.UpdateClientCarIdToNull(idCar))
                        {
                            if (dbManager.DeleteCar(idCar))
                            {
                                LoadCarsData();
                            }
                        }
                    }
                    else
                    {
                        if (dbManager.DeleteCar(idCar))
                        {
                            LoadCarsData();
                        }
                    }
                }
            }
            else
            {
                MessageBox.Show("Выберите строку для удаления.", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void ServicesGrid_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            ServicesGrid.Columns["ID_Service"].HeaderText = "ID услуги";
            ServicesGrid.Columns["Name_Service"].HeaderText = "Наименование";
            ServicesGrid.Columns["Cost"].HeaderText = "Цена";
        }

        private void ServicesDeleteButton_Click(object sender, EventArgs e)
        {
            if (ServicesGrid.SelectedRows.Count > 0)
            {
                DialogResult result = MessageBox.Show("Вы действительно хотите удалить выбранную строку?", "Подтверждение удаления", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                if (result == DialogResult.Yes)
                {
                    int idService = (int)ServicesGrid.SelectedRows[0].Cells["ID_Service"].Value;

                    if (dbManager.DeleteService(idService))
                    {
                        LoadServiceData();
                    }
                }
            }
            else
            {
                MessageBox.Show("Выберите строку для удаления.", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void TeamGrid_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            TeamGrid.Columns["ID_Workgroup"].HeaderText = "ID бригады";
            TeamGrid.Columns["Number_Workgroup"].HeaderText = "Номер бригады";
            TeamGrid.Columns["Date_Of_Creation"].HeaderText = "Дата формирования";
            TeamGrid.Columns["TeamMembers"].HeaderText = "Состав бригады";
        }

        private void TeamDeleteButton_Click(object sender, EventArgs e)
        {
            if (TeamGrid.SelectedRows.Count > 0)
            {
                DialogResult result = MessageBox.Show("Вы действительно хотите удалить выбранную строку?", "Подтверждение удаления", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                if (result == DialogResult.Yes)
                {
                    int idTeam = (int)TeamGrid.SelectedRows[0].Cells["ID_Workgroup"].Value;

                    if (dbManager.DeleteTeam(idTeam))
                    {
                        LoadTeamData();
                    }
                }
            }
            else
            {
                MessageBox.Show("Выберите строку для удаления.", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void ClientsGrid_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            ClientsGrid.Columns["ID_Client"].HeaderText = "ID клиента";
            ClientsGrid.Columns["Name_Client"].HeaderText = "Имя клиента";
            ClientsGrid.Columns["PhoneNumber_Client"].HeaderText = "Номер телефона";
            ClientsGrid.Columns["CarInfo"].HeaderText = "Автомобиль";
        }

        private void ClientsDeleteButton_Click(object sender, EventArgs e)
        {
            if (ClientsGrid.SelectedRows.Count > 0)
            {
                DialogResult result = MessageBox.Show("Вы действительно хотите удалить выбранную строку?", "Подтверждение удаления", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                if (result == DialogResult.Yes)
                {
                    int idClient = (int)ClientsGrid.SelectedRows[0].Cells["ID_Client"].Value;

                    if (dbManager.DeleteClient(idClient))
                    {
                        LoadClientsData();
                    }
                }
            }
            else
            {
                MessageBox.Show("Выберите строку для удаления.", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void WorkersGrid_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            WorkersGrid.Columns["ID_Worker"].HeaderText = "ID работника";
            WorkersGrid.Columns["Number_Workgroup"].HeaderText = "Бригада";
            WorkersGrid.Columns["Name_Worker"].HeaderText = "Имя работника";
            WorkersGrid.Columns["Number_Contract"].HeaderText = "Номер договора";
            WorkersGrid.Columns["Date_Of_Employment"].HeaderText = "Дата трудоустройства";
        }

        private void WorkersGrid_SelectionChanged(object sender, EventArgs e)
        {
            if (WorkersGrid.SelectedRows.Count > 0)
            {
                // Получаем выбранную строку
                DataGridViewRow selectedRow = WorkersGrid.SelectedRows[0];

                // Получаем значение ID_Worker из выбранной строки
                int selectedWorkerId = Convert.ToInt32(selectedRow.Cells["ID_Worker"].Value);

                // Получаем фото работника из базы данных
                byte[] photoBytes = DatabaseManager.GetInstance().GetWorkerPhotoFromDatabase(selectedWorkerId);

                // Отображаем фото в PictureBox
                if (photoBytes != null)
                {
                    using (MemoryStream ms = new MemoryStream(photoBytes))
                    {
                        WorkersPictureBox.Image = Image.FromStream(ms);
                    }
                }
                else
                {
                    // Очищаем PictureBox
                    WorkersPictureBox.Image = null;
                }
            }
            else
            {
                // Очищаем PictureBox, если ни одна строка не выбрана
                WorkersPictureBox.Image = null;
            }
        }

        private void WorkersDeleteButton_Click(object sender, EventArgs e)
        {
            if (WorkersGrid.SelectedRows.Count > 0)
            {
                DialogResult result = MessageBox.Show("Вы действительно хотите удалить выбранную строку?", "Подтверждение удаления", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                if (result == DialogResult.Yes)
                {
                    int idWorker = (int)WorkersGrid.SelectedRows[0].Cells["ID_Worker"].Value;

                    if (dbManager.DeleteWorker(idWorker))
                    {
                        LoadWorkersData();
                    }
                }
            }
            else
            {
                MessageBox.Show("Выберите строку для удаления.", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void OrderGrid_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            OrderGrid.Columns["ID_Order"].HeaderText = "ID заказа";
            OrderGrid.Columns["WorkgroupID"].HeaderText = "Бригада";
            OrderGrid.Columns["ClientID"].HeaderText = "Клиент";
            OrderGrid.Columns["Order_Date"].HeaderText = "Дата";
            OrderGrid.Columns["Order_Amount"].HeaderText = "Сумма заказа";
            OrderGrid.Columns["Order_Status"].HeaderText = "Статус";
            OrderGrid.Columns["Services"].HeaderText = "Наименования услуг";
        }

        private void OrderDeleteButton_Click(object sender, EventArgs e)
        {
            // Проверяем, что есть выбранная строка
            if (OrderGrid.SelectedRows.Count > 0)
            {
                // Отображаем диалоговое окно подтверждения удаления
                DialogResult result = MessageBox.Show("Вы действительно хотите удалить выбранную строку?", "Подтверждение удаления", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                if (result == DialogResult.Yes)
                {
                    // Получаем ID выбранной строки
                    int idOrder = (int)OrderGrid.SelectedRows[0].Cells["ID_Order"].Value;

                    // Вызываем метод удаления заказа из класса DatabaseManager
                    bool isDeleted = DatabaseManager.GetInstance().DeleteOrder(idOrder);

                    if (isDeleted)
                    {
                        MessageBox.Show("Заказ успешно удален.", "Успех", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        // Обновляем DataGridView
                        LoadOrderData();
                    }
                    else
                    {
                        MessageBox.Show("Ошибка удаления заказа.", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
            else
            {
                MessageBox.Show("Выберите строку для удаления.", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void OrderChangeButton_Click(object sender, EventArgs e)
        {
            if (OrderGrid.SelectedRows.Count > 0)
            {
                int selectedOrderId = Convert.ToInt32(OrderGrid.SelectedRows[0].Cells["ID_Order"].Value);

                OrderAddForm orderAddForm = new OrderAddForm();
                orderAddForm.SelectedOrderId = selectedOrderId;
                orderAddForm.Show();
                orderAddForm.FormClosed += OrderAddForm_FormClosed;
            }
            else
            {
                MessageBox.Show("Выберите заказ для изменения.", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void OrderChangeButton2_Click(object sender, EventArgs e)
        {
            // Проверяем, выбрана ли строка в OrderGrid
            if (OrderGrid.SelectedRows.Count > 0)
            {
                // Получаем выбранный orderId из выделенной строки
                int selectedOrderId = Convert.ToInt32(OrderGrid.SelectedRows[0].Cells["ID_Order"].Value);

                // Создаем экземпляр формы ChangeStatusForm и передаем selectedOrderId в конструктор
                ChangeStatusForm changeStatusForm = new ChangeStatusForm(selectedOrderId);

                // Открываем форму ChangeStatusForm в диалоговом режиме
                DialogResult result = changeStatusForm.ShowDialog(this);

                // Проверяем результат диалога
                if (result == DialogResult.OK)
                {
                    // Получаем выбранный статус из формы ChangeStatusForm
                    string selectedStatus = changeStatusForm.SelectedStatus;

                    // Обновляем статус заказа в базе данных по выбранному orderId
                    UpdateOrderStatus(selectedOrderId, selectedStatus);
                }

                // Закрываем форму ChangeStatusForm
                changeStatusForm.Close();
            }
            else
            {
                MessageBox.Show("Пожалуйста, выберите заказ.", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void UpdateOrderStatus(int orderId, string status)
        {
            // Вызов метода из класса DatabaseManager для обновления статуса заказа
            bool isUpdated = DatabaseManager.GetInstance().UpdateOrderStatus(orderId, status);

            if (isUpdated)
            {
                LoadOrderData();
                OrderGrid.ClearSelection();
                MessageBox.Show("Статус заказа успешно обновлен.", "Успех", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void WorkersPictureBox_Click(object sender, EventArgs e)
        {
            if (WorkersPictureBox.Image != null)
            {
                // Открытие формы с увеличенным изображением
                var enlargedForm = new EnlargedForm(WorkersPictureBox.Image);
                enlargedForm.ShowDialog();
            }
        }

        private void ServicesChangeButton_Click(object sender, EventArgs e)
        {
            if (ServicesGrid.SelectedRows.Count > 0)
            {
                int selectedServiceId = Convert.ToInt32(ServicesGrid.SelectedRows[0].Cells["ID_Service"].Value);

                ServicesAddForm servicesAddForm = new ServicesAddForm();
                servicesAddForm.SelectedServiceId = selectedServiceId;
                servicesAddForm.Show();
                servicesAddForm.FormClosed += ServicesaddForm_FormClosed;
            }
            else
            {
                MessageBox.Show("Выберите услугу для изменения.", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void ClientsChangeButton_Click(object sender, EventArgs e)
        {
            if (ClientsGrid.SelectedRows.Count > 0)
            {
                int selectedClientId = Convert.ToInt32(ClientsGrid.SelectedRows[0].Cells["ID_Client"].Value);

                ClientsAddForm clientAddForm = new ClientsAddForm();
                clientAddForm.SelectedClientId = selectedClientId;
                clientAddForm.Show();
                clientAddForm.FormClosed += ClientsAddForm_FormClosed;
            }
            else
            {
                MessageBox.Show("Выберите клиента для изменения.", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void CarsChangeButton_Click(object sender, EventArgs e)
        {
            if (CarsGrid.SelectedRows.Count > 0)
            {
                int selectedCarId = Convert.ToInt32(CarsGrid.SelectedRows[0].Cells["ID_Car"].Value);

                CarsAddForm carAddForm = new CarsAddForm();
                carAddForm.SelectedCarId = selectedCarId;
                carAddForm.Show();
                carAddForm.FormClosed += CarsAddForm_FormClosed;

            }
            else
            {
                MessageBox.Show("Выберите автомобиль для изменения.", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void WorkersChangeButton_Click(object sender, EventArgs e)
        {
            if (WorkersGrid.SelectedRows.Count > 0)
            {
                int selectedWorkerId = Convert.ToInt32(WorkersGrid.SelectedRows[0].Cells["ID_Worker"].Value);

                WorkersAddForm workersAddForm = new WorkersAddForm();
                workersAddForm.SelectedWorkerId = selectedWorkerId;
                workersAddForm.Show();
                workersAddForm.FormClosed += WorkersAddForm_FormClosed;

            }
            else
            {
                MessageBox.Show("Выберите работника для изменения.", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void TeamChangeButton_Click(object sender, EventArgs e)
        {
            if (TeamGrid.SelectedRows.Count > 0)
            {
                int selectedTeamId = Convert.ToInt32(TeamGrid.SelectedRows[0].Cells["ID_Workgroup"].Value);

                TeamAddForm teamAddForm = new TeamAddForm();
                teamAddForm.SelectedTeamId = selectedTeamId;
                teamAddForm.Show();
                teamAddForm.FormClosed += TeamAddForm_FormClosed;

            }
            else
            {
                MessageBox.Show("Выберите бригаду для изменения.", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void OrderCb1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (OrderCb1.SelectedItem != null) // Добавляем проверку на null
            {
                string selectedFilter = OrderCb1.SelectedItem.ToString();

                switch (selectedFilter)
                {
                    case "По дате":
                        OrderGrid.Sort(OrderGrid.Columns["Order_Date"], ListSortDirection.Ascending);
                        break;
                    case "По сумме":
                        OrderGrid.Sort(OrderGrid.Columns["Order_Amount"], ListSortDirection.Descending);
                        break;
                    default:
                        // Очистить сортировку
                        OrderGrid.Sort(OrderGrid.Columns["ID_Order"], ListSortDirection.Ascending);
                        break;
                }
            }
            OrderGrid.ClearSelection();
        }

        private void MainButton1_Click(object sender, EventArgs e)
        {
            DateTime startDate = MainStartDate.Value;
            DateTime endDate = MainEndDate.Value;

            // Проверка, чтобы дата начала не была позже даты окончания
            if (startDate > endDate)
            {
                MessageBox.Show("Пожалуйста, выберите корректные даты.", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            generatereport();
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            MainStartDate.Value = DateTime.Now;
            MainEndDate.Value = DateTime.Now;
            this.FormBorderStyle = FormBorderStyle.FixedSingle;
            this.Size = new Size(943, 430);
        }

        private void OrderButton_Click(object sender, EventArgs e)
        {
            MenuTab.SelectedIndex = 1;
            this.Text = "Заказы";
            OrderCb1.SelectedIndex = -1;
            // Сброс выбранных путей и текста на кнопках
            templatePath = null;
            saveFolderPath = null;
            SelectTemplateButton.Text = "Выберите путь к шаблону";
            SelectSavePathButton.Text = "Выберите путь сохранения";
        }

        private void MainButton_Click(object sender, EventArgs e)
        {
            MenuTab.SelectedIndex = 0;
            this.Text = "Главная";
        }

        private void ServiceButton_Click(object sender, EventArgs e)
        {
            MenuTab.SelectedIndex = 2;
            this.Text = "Услуги";
        }

        private void ClientsButton_Click(object sender, EventArgs e)
        {
            MenuTab.SelectedIndex = 3;
            this.Text = "Клиенты";
        }

        private void CarButton_Click(object sender, EventArgs e)
        {
            MenuTab.SelectedIndex = 4;
            this.Text = "Автомобили";
        }

        private void WorkerButton_Click(object sender, EventArgs e)
        {
            MenuTab.SelectedIndex = 5;
            this.Text = "Работники";
        }

        private void TeamButton_Click(object sender, EventArgs e)
        {
            MenuTab.SelectedIndex = 6;
            this.Text = "Бригады";
        }


        private string templatePath; // переменная для хранения пути к шаблону
        private string saveFolderPath; // переменная для хранения пути сохранения отчета
        private void SelectTemplateButton_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "Документ Word (*.docx)|*.docx";
            openFileDialog.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.Desktop); // Установка начальной директории
            openFileDialog.Title = "Выберите шаблон отчета";

            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                templatePath = openFileDialog.FileName;
                SelectTemplateButton.Text = "Путь к шаблону выбран";
            }
        }

        private void generatereport()
        {
            // Проверяем наличие выбранного шаблона и пути сохранения отчета
            if (string.IsNullOrEmpty(templatePath) || string.IsNullOrEmpty(saveFolderPath))
            {
                MessageBox.Show("Выберите путь к шаблону и путь для сохранения отчета.", "Ошибка");
                return;
            }

            // Получаем значения дат начала и конца из элементов управления на форме
            DateTime startDate = MainStartDate.Value;
            DateTime endDate = MainEndDate.Value;

            try
            {
                // Создаем объект Word.Application
                Word.Application wordApp = new Word.Application();
                Word.Document reportDoc = wordApp.Documents.Open(templatePath, ReadOnly: true, ConfirmConversions: false);

                // Устанавливаем значения дат в шаблоне
                reportDoc.Content.Find.Execute(FindText: "date1", ReplaceWith: startDate.ToShortDateString());
                reportDoc.Content.Find.Execute(FindText: "date2", ReplaceWith: endDate.ToShortDateString());

                // Получаем необходимые данные из базы данных с помощью DatabaseManager
                int orderCount = dbManager.GetOrderCountWithStatus(startDate, endDate);
                decimal totalOrderSum = dbManager.GetTotalOrderSum(startDate, endDate);
                int brigadeNumber = dbManager.GetBrigadeNumber(startDate, endDate);
                int brigadeOrderCount = dbManager.GetBrigadeOrderCount(startDate, endDate);
                int largestOrderId = dbManager.GetLargestOrderId(startDate, endDate);
                decimal largestOrderSum = dbManager.GetLargestOrderSum(startDate, endDate);
                string orderServices = dbManager.GetOrderServices(largestOrderId);

                // Заменяем соответствующие метки в отчете полученными значениями
                reportDoc.Content.Find.Execute(FindText: "count", ReplaceWith: orderCount.ToString());
                reportDoc.Content.Find.Execute(FindText: "sum", ReplaceWith: totalOrderSum.ToString());
                reportDoc.Content.Find.Execute(FindText: "brigade", ReplaceWith: brigadeNumber.ToString());
                reportDoc.Content.Find.Execute(FindText: "countbrigada", ReplaceWith: brigadeOrderCount.ToString());
                reportDoc.Content.Find.Execute(FindText: "orderid", ReplaceWith: largestOrderId.ToString());
                reportDoc.Content.Find.Execute(FindText: "sumorder", ReplaceWith: largestOrderSum.ToString());
                reportDoc.Content.Find.Execute(FindText: "uslugi", ReplaceWith: orderServices);

                // Генерируем имя файла на основе текущей даты и времени
                string fileName = "Отчет_" + DateTime.Now.ToString("yyyyMMdd_HHmmss") + ".docx";

                // Преобразуем путь сохранения в кодировку Windows-1251 и сохраняем отчет
                byte[] pathBytes = Encoding.GetEncoding("Windows-1251").GetBytes(saveFolderPath);
                saveFolderPath = Encoding.GetEncoding("Windows-1251").GetString(pathBytes);

                string saveFilePath = Path.Combine(saveFolderPath, fileName);
                reportDoc.SaveAs2(saveFilePath);

                // Отображаем отчет и открываем сохраненный отчет для пользователя
                wordApp.Visible = true;
                Process.Start(saveFilePath);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ошибка при создании отчета: " + ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void SelectSavePathButton_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog folderBrowserDialog = new FolderBrowserDialog();
            folderBrowserDialog.Description = "Выберите папку для сохранения отчета";
            folderBrowserDialog.RootFolder = Environment.SpecialFolder.Desktop;

            if (folderBrowserDialog.ShowDialog() == DialogResult.OK)
            {
                saveFolderPath = folderBrowserDialog.SelectedPath;
                SelectSavePathButton.Text = "Путь к сохранению выбран";
            }
        }
    }
}