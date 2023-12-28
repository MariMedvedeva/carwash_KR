using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Microsoft.Office.Interop.Word;
using MySql.Data.MySqlClient;
using Mysqlx.Crud;
using MySqlX.XDevAPI;
using Org.BouncyCastle.Crypto;
using System.Data;
using static Guna.UI2.HtmlRenderer.Adapters.RGraphicsPath;

namespace carwash
{
    public class DatabaseManager
    {
        private static DatabaseManager instance;
        private readonly string connectionString = "Server=localhost;Database=carwash_db;Uid=root;Pwd=5675675t;";
        private MySqlConnection connection;

        // Приватный конструктор 
        private DatabaseManager()
        {
            connection = new MySqlConnection(connectionString);
            connection.Open();
        }

        // Метод получения экземпляра класса
        public static DatabaseManager GetInstance()
        {
            if (instance == null)
            {
                instance = new DatabaseManager();
            }
            return instance;
        }

        // Закрытие подключения
        public void CloseConnection()
        {
            connection?.Close();
        }

        //для логин форм все
        public bool AuthenticateUser(string username, string enteredHashedPassword)
        {
            try
            {
                string storedHashedPassword = null;

                string query = "SELECT password_user FROM users WHERE login_user = @username";
                using (MySqlCommand command = new MySqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@username", username);

                    using (MySqlDataReader reader = command.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            storedHashedPassword = reader.GetString("password_user");
                        }
                    }
                }

                if (storedHashedPassword != null)
                {
                    return enteredHashedPassword == storedHashedPassword;
                }

                return false;
            }
            catch
            {
                MessageBox.Show("Ошибка авторизации", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
        }

        //для формы регистрации
        public bool RegistrationUser(string login, string hashedPassword)
        {
            try
            {
                string checkQuery = "SELECT COUNT(*) FROM users WHERE login_user = @login";
                using (MySqlCommand checkCommand = new MySqlCommand(checkQuery, connection))
                {
                    checkCommand.Parameters.AddWithValue("@login", login);

                    int count = Convert.ToInt32(checkCommand.ExecuteScalar());

                    if (count > 0)
                    {
                        MessageBox.Show("Логин уже существует. Пожалуйста, выберите другой логин.", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return false;
                    }
                }
                string query = "INSERT INTO users (login_user, password_user) VALUES (@login, @password)";
                MySqlParameter[] parameters =
                {
                    new MySqlParameter("@login", login),
                    new MySqlParameter("@password", hashedPassword)
                };
                return ExecuteNonQuery(query, parameters);
            }
            catch
            {
                MessageBox.Show("Ошибка регистрации", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
        }
        // формочка бригад
        public bool AddTeamToDatabase(string number, DateTime date)
        {
            // Выполняем добавление в базу данных
            string query = "INSERT INTO workgroup (Number_Workgroup, Date_Of_Creation) VALUES (@Number_Workgroup, @Date_Of_Creation)";
            MySqlParameter[] parameters =
                {
                    new MySqlParameter("@Number_Workgroup", number),
                    new MySqlParameter("@Date_Of_Creation", date)
                };
            return ExecuteNonQuery(query, parameters);
        }
        public bool UpdateTeamInDatabase(int teamId, string number, DateTime date)
        {
            // Выполняем обновление данных в таблице "workgroup"
            string query = "UPDATE workgroup SET Number_Workgroup = @Number_Workgroup, Date_Of_Creation = @Date_Of_Creation WHERE ID_Workgroup = @TeamId";
            MySqlParameter[] parameters =
                {
                    new MySqlParameter("@TeamId", teamId),
                    new MySqlParameter("@Number_Workgroup", number),
                    new MySqlParameter("@Date_Of_Creation", date)
                };
            return ExecuteNonQuery(query, parameters);
        }
        public Workgroup GetTeamById(int teamId)
        {
            Workgroup workgroup = null;

            try
            {
                string query = "SELECT ID_Workgroup, Number_Workgroup, Date_Of_Creation FROM workgroup WHERE ID_Workgroup = @TeamId";

                using (MySqlCommand command = new MySqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@TeamId", teamId);

                    using (MySqlDataReader reader = command.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            int number = reader.GetInt32("Number_Workgroup");
                            DateTime dateOfCreation = reader.GetDateTime("Date_Of_Creation");

                            // Создаем объект Workgroup и заполняем его данными из базы данных
                            workgroup = new Workgroup
                            {
                                ID_Workgroup = teamId,
                                Number_Workgroup = number,
                                Date_Of_Creation = dateOfCreation
                            };
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Ошибка при получении данных бригады из базы данных: " + ex.Message);
            }

            return workgroup;
        }

        //формочка услуг
        public bool AddServiceToDatabase(string nameService, int cost)
        {
            string query = "INSERT INTO service (Name_Service, Cost) VALUES (@Name_Service, @Cost)";
            MySqlParameter[] parameters =
                {
                    new MySqlParameter("@Name_Service", nameService),
                    new MySqlParameter("@Cost", cost)
                };
            return ExecuteNonQuery(query, parameters);
        }
        public bool UpdateServiceInDatabase(int serviceId, string nameService, int cost)
        {
            string query = "UPDATE service SET Name_Service = @Name_Service, Cost = @Cost WHERE ID_Service = @ID_Service";
            MySqlParameter[] parameters =
                {
                    new MySqlParameter("@ID_Service", serviceId),
                    new MySqlParameter("@Name_Service", nameService),
                    new MySqlParameter("@Cost", cost)
                };
            return ExecuteNonQuery(query, parameters);
        }
        public Service GetServiceById(int serviceId)
        {
            Service service = null;
            string query = "SELECT * FROM service WHERE ID_Service = @ServiceId";

            using (MySqlCommand command = new MySqlCommand(query, connection))
            {
                command.Parameters.AddWithValue("@ServiceId", serviceId);

                using (MySqlDataReader reader = command.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        service = new Service
                        {
                            ID = reader.GetInt32("ID_Service"),
                            Name = reader.GetString("Name_Service"),
                            Cost = reader.GetInt32("Cost")
                        };
                    }
                }
            }
            return service;
        }


        //формочка машин
        public bool AddCarToDatabase(string brand, string model, string number)
        {
            // Выполняем добавление автомобиля в базу данных
            string query = "INSERT INTO car (Brand, Model, Car_Number) VALUES (@Brand, @Model, @Car_Number)";
            MySqlParameter[] parameters =
                {
                    new MySqlParameter("@Brand", brand),
                    new MySqlParameter("@Model", model),
                    new MySqlParameter("@Car_Number", number)
                };
            return ExecuteNonQuery(query, parameters);
        }
        public bool UpdateCarInDatabase(int carId, string brand, string model, string number)
        {
            string query = "UPDATE car SET Brand = @Brand, Model = @Model, Car_Number = @Car_Number WHERE ID_Car = @CarId";

            MySqlParameter[] parameters =
                {
                    new MySqlParameter("@CarId", carId),
                    new MySqlParameter("@Brand", brand),
                    new MySqlParameter("@Model", model),
                    new MySqlParameter("@Car_Number", number)
                };
            return ExecuteNonQuery(query, parameters);
        }
        public Car GetCarById(int carId)
        {
            Car car = null;

            string query = "SELECT * FROM car WHERE ID_Car = @CarId";

            using (MySqlCommand command = new MySqlCommand(query, connection))
            {
                command.Parameters.AddWithValue("@CarId", carId);

                using (MySqlDataReader reader = command.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        car = new Car
                        {
                            Id = reader.GetInt32("ID_Car"),
                            Brand = reader.GetString("Brand"),
                            Model = reader.GetString("Model"),
                            Car_Number = reader.GetString("Car_Number")
                        };
                    }
                }
            }
            return car;
        }


        // формочка клиента
        public bool AddClientToDatabase(int idCar, string nameClient, string phoneClient)
        {
            string query = "INSERT INTO client (IDCar, Name_Client, PhoneNumber_Client) VALUES (@IDCar, @Name_Client, @PhoneNumber_Client)";
            MySqlParameter[] parameters =
                {
                    new MySqlParameter("@IDCar", idCar),
                    new MySqlParameter("@Name_Client", nameClient),
                    new MySqlParameter("@PhoneNumber_Client", phoneClient)
                };
            return ExecuteNonQuery(query, parameters);
        }
        public bool UpdateClientInDatabase(int clientId, int idCar, string nameClient, string phoneClient)
        {
            string query = "UPDATE client SET IDCar = @IDCar, Name_Client = @Name_Client, PhoneNumber_Client = @PhoneNumber_Client WHERE ID_Client = @ID_Client";
            MySqlParameter[] parameters =
            {
                    new MySqlParameter("@ID_Client", clientId),
                    new MySqlParameter("@IDCar", idCar),
                    new MySqlParameter("@Name_Client", nameClient),
                    new MySqlParameter("@PhoneNumber_Client", phoneClient)
                };
            return ExecuteNonQuery(query, parameters);
        }
        public List<KeyValuePair<int, string>> GetUnassignedCars()
        {
            List<KeyValuePair<int, string>> unassignedCars = new List<KeyValuePair<int, string>>();

            string query = @"SELECT c.ID_Car, CONCAT(c.Brand, ' ', c.Model, ' ', c.Car_Number) AS CarInfo 
                                FROM car c 
                                LEFT JOIN client cl ON c.ID_Car = cl.IDCar 
                                WHERE cl.IDCar IS NULL";

            using (MySqlCommand command = new MySqlCommand(query, connection))
            {
                using (MySqlDataReader reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        int carId = reader.GetInt32("ID_Car");
                        string carInfo = reader.GetString("CarInfo");
                        unassignedCars.Add(new KeyValuePair<int, string>(carId, carInfo));
                    }
                }
            }
            return unassignedCars;
        }
        public KeyValuePair<int, string> GetClientCar(int selectedClientId)
        {
            KeyValuePair<int, string> clientCar = new KeyValuePair<int, string>();

            string query = "SELECT cl.IDCar, CONCAT(c.Brand, ' ', c.Model, ' ', c.Car_Number) AS CarInfo FROM client cl INNER JOIN car c ON cl.IDCar = c.ID_Car WHERE cl.ID_Client = @SelectedClientId";
            using (MySqlCommand command = new MySqlCommand(query, connection))
            {
                command.Parameters.AddWithValue("@SelectedClientId", selectedClientId);

                using (MySqlDataReader reader = command.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        int carId = reader.GetInt32("IDCar");
                        string carInfo = reader.GetString("CarInfo");
                        clientCar = new KeyValuePair<int, string>(carId, carInfo);
                    }
                }
            }
            return clientCar;
        }
        public KeyValuePair<string, string> GetClientInfo(int selectedClientId)
        {
            KeyValuePair<string, string> clientInfo = new KeyValuePair<string, string>();

            string query = "SELECT Name_Client, PhoneNumber_Client FROM client WHERE ID_Client = @SelectedClientId";

            using (MySqlCommand command = new MySqlCommand(query, connection))
            {
                command.Parameters.AddWithValue("@SelectedClientId", selectedClientId);

                using (MySqlDataReader reader = command.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        string name = reader.GetString("Name_Client");
                        string phone = reader.GetString("PhoneNumber_Client");
                        clientInfo = new KeyValuePair<string, string>(name, phone);
                    }
                }
            }

            return clientInfo;
        }

        // формочка заказов
        public bool AddOrderToDatabase(int workgroupId, int clientId, DateTime orderDate, int orderAmoumt, 
            string orderStatus, string services)
        {
            string query = "INSERT INTO orders (WorkgroupID, ClientID, Order_Date, Order_Amount, Order_Status, Services) " +
                    "VALUES (@WorkgroupId, @ClientId, @OrderDate, @OrderAmount, @OrderStatus, @Services)";
            MySqlParameter[] parameters =
                {
                    new MySqlParameter("@WorkgroupId", workgroupId),
                    new MySqlParameter("@ClientId", clientId),
                    new MySqlParameter("@OrderDate", orderDate),
                    new MySqlParameter("@OrderAmount", orderAmoumt),
                    new MySqlParameter("@OrderStatus", orderStatus),
                    new MySqlParameter("@Services", services)
                };
            return ExecuteNonQuery(query, parameters);
        }
        public bool UpdateOrderInDatabase(int orderId, int workgroupId, int clientId, DateTime orderDate, int orderAmoumt,
            string orderStatus, string services)
        {
            string query = "UPDATE orders SET WorkgroupID = @WorkgroupId, ClientID = @ClientId, Order_Date = @OrderDate, " +
                   "Order_Amount = @OrderAmount, Order_Status = @OrderStatus, Services = @Services WHERE ID_Order = @OrderId";
            MySqlParameter[] parameters =
                {
                    new MySqlParameter("@OrderId", orderId),
                    new MySqlParameter("@WorkgroupId", workgroupId),
                    new MySqlParameter("@ClientId", clientId),
                    new MySqlParameter("@OrderDate", orderDate),
                    new MySqlParameter("@OrderAmount", orderAmoumt),
                    new MySqlParameter("@OrderStatus", orderStatus),
                    new MySqlParameter("@Services", services)
                };
            return ExecuteNonQuery(query, parameters);
        }
        public List<KeyValuePair<int, string>> LoadWorkgroups()
        {
            List<KeyValuePair<int, string>> workgroups = new List<KeyValuePair<int, string>>();

            string query = "SELECT ID_Workgroup, CONCAT('Бригада ', Number_Workgroup) AS TeamName FROM workgroup";

            using (MySqlCommand command = new MySqlCommand(query, connection))
            {
                using (MySqlDataReader reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        int id = reader.GetInt32("ID_Workgroup");
                        string teamName = reader.GetString("TeamName");
                        workgroups.Add(new KeyValuePair<int, string>(id, teamName));
                    }
                }
            }

            return workgroups;
        }
        public List<KeyValuePair<int, string>> LoadClients()
        {
            List<KeyValuePair<int, string>> clients = new List<KeyValuePair<int, string>>();

            string query = "SELECT ID_Client, Name_Client FROM client";

            using (MySqlCommand command = new MySqlCommand(query, connection))
            {
                using (MySqlDataReader reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        int id = reader.GetInt32("ID_Client");
                        string name = reader.GetString("Name_Client");
                        clients.Add(new KeyValuePair<int, string>(id, name));
                    }
                }
            }

            return clients;
        }
        public List<ServiceItem> LoadServices()
        {
            List<ServiceItem> services = new List<ServiceItem>();

            string query = "SELECT ID_Service, Name_Service, Cost FROM service";

            using (MySqlCommand command = new MySqlCommand(query, connection))
            {
                using (MySqlDataReader reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        int serviceId = reader.GetInt32(0);
                        string serviceName = reader.GetString(1);
                        decimal serviceCost = reader.GetDecimal(2);

                        ServiceItem serviceItem = new ServiceItem(serviceId, serviceName, serviceCost);

                        services.Add(serviceItem);
                    }
                }
            }
            return services;
        }
        public Order GetOrderById(int orderId)
        {
            Order order = null;
            string query = "SELECT WorkgroupID, ClientID, Order_Date, Order_Amount, Order_Status, Services FROM orders WHERE ID_Order = @OrderId";

            using (MySqlCommand command = new MySqlCommand(query, connection))
            {
                command.Parameters.AddWithValue("@OrderId", orderId);

                using (MySqlDataReader reader = command.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        int workgroupId = reader.GetInt32("WorkgroupID");
                        int clientId = reader.GetInt32("ClientID");
                        DateTime orderDate = reader.GetDateTime("Order_Date");
                        int orderAmount = reader.GetInt32("Order_Amount");
                        string orderStatus = reader.GetString("Order_Status");
                        string selectedServices = reader.GetString("Services");


                        List<int> servicesList = selectedServices
                            .Split(new string[] { ", " }, StringSplitOptions.None)
                            .Select(item =>
                            {
                                int parsedValue;
                                if (int.TryParse(item, out parsedValue))
                                {
                                    return parsedValue;
                                }
                                return 0;
                            })
                            .ToList();

                        order = new Order
                        {
                            WorkgroupId = workgroupId,
                            ClientId = clientId,
                            OrderDate = orderDate,
                            OrderAmount = orderAmount,
                            OrderStatus = orderStatus,
                            SelectedServices = servicesList
                        };
                    }
                }
            }
            return order;
        }

        //формочка работников
        public bool AddWorkerToDatabase(int workgroupId, string nameWorker, int numberContract, 
            byte[] photo, DateTime dateOfEmployment){
            string query = "INSERT INTO workers (IDWorkgroup, Name_Worker, Number_Contract, Photo, Date_Of_Employment) " +
                               "VALUES (@IDWorkgroup, @Name_Worker, @Number_Contract, @Photo, @Date_Of_Employment)";
            MySqlParameter[] parameters =
                {
                    new MySqlParameter("@IDWorkgroup", workgroupId),
                    new MySqlParameter("@Name_Worker", nameWorker),
                    new MySqlParameter("@Number_Contract", numberContract),
                    new MySqlParameter("@Photo", photo),
                    new MySqlParameter("@Date_Of_Employment", dateOfEmployment)
                };
            return ExecuteNonQuery(query, parameters);
        }
        public bool UpdateWorkerInDatabase(int workerId, int workgroupId, string nameWorker, int numberContract,
            byte[] photo, DateTime dateOfEmployment)
        {
            string query = "UPDATE workers SET IDWorkgroup = @IDWorkgroup, Name_Worker = @Name_Worker, " +
                                     "Number_Contract = @Number_Contract, Photo = @Photo, Date_Of_Employment = @Date_Of_Employment " +
                                     "WHERE ID_Worker = @WorkerId"; 
            MySqlParameter[] parameters =
                {
                    new MySqlParameter("@WorkerId", workerId),
                    new MySqlParameter("@IDWorkgroup", workgroupId),
                    new MySqlParameter("@Name_Worker", nameWorker),
                    new MySqlParameter("@Number_Contract", numberContract),
                    new MySqlParameter("@Photo", photo),
                    new MySqlParameter("@Date_Of_Employment", dateOfEmployment)
                };
            return ExecuteNonQuery(query, parameters);
        }

        public List<KeyValuePair<int, string>> GetWorkgroupsForComboBox(int selectedWorkerId) 
        {
            List<KeyValuePair<int, string>> workgroups = new List<KeyValuePair<int, string>>();

            string query = "SELECT ID_Workgroup, CONCAT('Бригада', ' ', Number_Workgroup) AS WorkgroupInfo " +
                               "FROM workgroup " +
                               "WHERE (ID_Workgroup NOT IN " +
                               "(SELECT IDWorkgroup FROM workers GROUP BY IDWorkgroup HAVING COUNT(*) >= 3))";

            if (selectedWorkerId > 0)
            {
                query += " OR ID_Workgroup = (SELECT IDWorkgroup FROM workers WHERE ID_Worker = @SelectedWorkerId)";
            }

            using (MySqlCommand command = new MySqlCommand(query, connection))
            {
                if (selectedWorkerId > 0)
                {
                    command.Parameters.AddWithValue("@SelectedWorkerId", selectedWorkerId);
                }
                using (MySqlDataReader reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        int workgroupId = reader.GetInt32("ID_Workgroup");
                        string workgroupInfo = reader.GetString("WorkgroupInfo");
                        workgroups.Add(new KeyValuePair<int, string>(workgroupId, workgroupInfo));
                    }
                }
            }
            return workgroups;
        }

        public Worker GetWorkerById(int workerId) 
        {
            Worker worker = null;
            try
            {
                string query = "SELECT ID_Worker, IDWorkgroup, Name_Worker, Number_Contract, Photo, Date_Of_Employment " +
                               "FROM workers WHERE ID_Worker = @WorkerId";

                using (MySqlCommand command = new MySqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@WorkerId", workerId);

                    using (MySqlDataReader reader = command.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            worker = new Worker
                            {
                                ID = reader.GetInt32("ID_Worker"),
                                WorkgroupId = reader.GetInt32("IDWorkgroup"),
                                Name = reader.GetString("Name_Worker"),
                                NumberContract = reader.GetInt32("Number_Contract"),
                                Photo = (byte[])reader["Photo"],
                                DateOfEmployment = reader.GetDateTime("Date_Of_Employment")
                            };
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ошибка при получении данных о работнике: " + ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            return worker;
        }


        //main формочка
        public System.Data.DataTable GetCarsData()
        {
            string query = "SELECT * FROM car";
            return GetData(query);
        }

        public System.Data.DataTable GetServiceData()
        {
            string query = "SELECT * FROM service";
            return GetData(query);
        }

        public System.Data.DataTable GetTeamData()
        {
            string query = "SELECT workgroup.ID_Workgroup, workgroup.Number_Workgroup, workgroup.Date_Of_Creation, GROUP_CONCAT(workers.Name_Worker SEPARATOR ', ') AS TeamMembers FROM workgroup LEFT JOIN workers ON workgroup.ID_Workgroup = workers.IDWorkgroup GROUP BY workgroup.ID_Workgroup";
            return GetData(query);
        }
        public System.Data.DataTable GetClientsData()
        {
            string query = "SELECT ID_Client, Name_Client, PhoneNumber_Client, CONCAT(Brand, ' ', Model, ' ', Car_Number) AS CarInfo " +
                           "FROM client LEFT JOIN car ON client.IDCar = car.ID_Car";

            return GetData(query);
        }

        public System.Data.DataTable GetWorkersData()
        {
            string query = "SELECT workers.ID_Worker, workgroup.Number_Workgroup, workers.Name_Worker, workers.Number_Contract, workers.Date_Of_Employment " +
                           "FROM workers LEFT JOIN workgroup ON workers.IDWorkgroup = workgroup.ID_Workgroup";

            return GetData(query);
        }

        public System.Data.DataTable GetOrderData()
        {
            string query = @"SELECT o.ID_Order,
                    IFNULL(w.Number_Workgroup, '') AS WorkgroupID,
                    IFNULL(c.Name_Client, '') AS ClientID,
                    o.Order_Date,
                    o.Order_Amount,
                    o.Order_Status,
                    o.Services
             FROM orders o
             LEFT JOIN workgroup w ON o.WorkgroupID = w.ID_Workgroup
             LEFT JOIN client c ON o.ClientID = c.ID_Client";

            return GetData(query);
        }

        //выполнение запросов
        private bool ExecuteNonQuery(string query, params MySqlParameter[] parameters)
        {
            try
            {
                using (MySqlCommand command = new MySqlCommand(query, connection))
                {
                    if (parameters != null)
                    {
                        command.Parameters.AddRange(parameters);
                    }
                    int rowsAffected = command.ExecuteNonQuery();
                    return rowsAffected > 0;
                }
            }
            catch (MySqlException ex)
            {
                MessageBox.Show("Ошибка при выполнении запроса: " + ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
        }

        //удаления
        public bool DeleteCar(int idCar)
        {
            try
            {
                string query = "DELETE FROM car WHERE ID_Car = @ID_Car";
                MySqlParameter parameter = new MySqlParameter("@ID_Car", idCar);

                return ExecuteNonQuery(query, parameter);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ошибка при удалении автомобиля: " + ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
        }
        public bool UpdateClientCarIdToNull(int idCar)
        {
            try
            {
                string query = "UPDATE client SET IDCar = NULL WHERE IDCar = @ID_Car";
                MySqlParameter parameter = new MySqlParameter("@ID_Car", idCar);

                return ExecuteNonQuery(query, parameter);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ошибка при обновлении связи машины с клиентом: " + ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
        }
        public bool IsCarLinkedToClient(int idCar)
        {
            try
            {
                string query = "SELECT COUNT(*) FROM client WHERE IDCar = @ID_Car";
                using (MySqlCommand command = new MySqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@ID_Car", idCar);
                    object result = command.ExecuteScalar();

                    if (result != null && result != DBNull.Value)
                    {
                        int count = Convert.ToInt32(result);
                        return count > 0;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ошибка при проверке связи машины с клиентом: " + ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            return false;
        }
        public bool DeleteService(int idService)
        {
            try
            {
                string query = "DELETE FROM service WHERE ID_Service = @ID_Service";
                MySqlParameter parameter = new MySqlParameter("@ID_Service", idService);

                return ExecuteNonQuery(query, parameter);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ошибка при удалении услуги: " + ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
        }
        //удаление бригады
        public bool IsTeamLinkedToWorkers(int idTeam)
        {
            try
            {
                string query = "SELECT COUNT(*) FROM workers WHERE IDWorkgroup = @ID_Workgroup";
                return CheckRecordExistence(query, idTeam);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ошибка при проверке связи бригады с работниками: " + ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            return false;
        }

        public bool IsTeamLinkedToOrders(int idTeam)
        {
            try
            {
                string query = "SELECT COUNT(*) FROM orders WHERE WorkgroupID = @ID_Workgroup";
                return CheckRecordExistence(query, idTeam);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ошибка при проверке связи бригады с заказами: " + ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            return false;
        }

        private bool CheckRecordExistence(string query, int parameterValue)
        {
            using (MySqlCommand command = new MySqlCommand(query, connection))
            {
                command.Parameters.AddWithValue("@ID_Workgroup", parameterValue);
                int count = Convert.ToInt32(command.ExecuteScalar());
                return count > 0;
            }
        }

        public bool DeleteTeam(int idTeam)
        {
            try
            {
                if (IsTeamLinkedToWorkers(idTeam))
                {
                    string updateWorkersQuery = "UPDATE workers SET IDWorkgroup = NULL WHERE IDWorkgroup = @ID_Workgroup";
                    MySqlParameter parameter = new MySqlParameter("@ID_Workgroup", idTeam);
                    ExecuteNonQuery(updateWorkersQuery, parameter);
                }

                if (IsTeamLinkedToOrders(idTeam))
                {
                    string updateOrdersQuery = "UPDATE orders SET WorkgroupID = NULL WHERE WorkgroupID = @ID_Workgroup";
                    MySqlParameter parameter = new MySqlParameter("@ID_Workgroup", idTeam);
                    ExecuteNonQuery(updateOrdersQuery, parameter);
                }

                string deleteTeamQuery = "DELETE FROM workgroup WHERE ID_Workgroup = @ID_Workgroup";
                MySqlParameter deleteParameter = new MySqlParameter("@ID_Workgroup", idTeam);
                return ExecuteNonQuery(deleteTeamQuery, deleteParameter);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ошибка при удалении бригады: " + ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
        }
        //удалить клиента
        public bool DeleteClient(int clientId)
        {
            try
            {

                if (IsClientLinkedToOrder(clientId))
                {
                    string clearOrderLinkQuery = "UPDATE orders SET ClientID = NULL WHERE ClientID = @ID_Client";
                    MySqlParameter parameter2 = new MySqlParameter("@ID_Client", clientId);
                    ExecuteNonQuery(clearOrderLinkQuery, parameter2);
                }

                string deleteQuery = "DELETE FROM client WHERE ID_Client = @ID_Client";
                MySqlParameter deleteParameter = new MySqlParameter("@ID_Client", clientId);
                return ExecuteNonQuery(deleteQuery, deleteParameter);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ошибка при удалении клиента: " + ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
        }

        private bool IsClientLinkedToOrder(int clientId)
        {
            string query = "SELECT COUNT(*) FROM orders WHERE ClientID = @ID_Client";
            using (MySqlCommand command = new MySqlCommand(query, connection))
            {
                command.Parameters.AddWithValue("@ID_Client", clientId);
                int count = Convert.ToInt32(command.ExecuteScalar());
                return count > 0;
            }
        }

        // удаление работников
        public bool DeleteWorker(int idWorker)
        {
            try
            {
                string query = "DELETE FROM workers WHERE ID_Worker = @ID_Worker";
                using (MySqlCommand command = new MySqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@ID_Worker", idWorker);
                    command.ExecuteNonQuery();
                }
                return true;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ошибка при удалении работника: " + ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
        }

        // удаление заказов
        public bool DeleteOrder(int orderId)
        {
            try
            {
                string query = "DELETE FROM orders WHERE ID_Order = @ID_Order";
                MySqlParameter parameter = new MySqlParameter("@ID_Order", orderId);
                return ExecuteNonQuery(query, parameter);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ошибка при удалении заказа: " + ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
        }

        // фотка рабочего
        public byte[] GetWorkerPhotoFromDatabase(int workerId)
        {
            try
            {
                string query = "SELECT Photo FROM workers WHERE ID_Worker = @ID_Worker";
                using (MySqlCommand command = new MySqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@ID_Worker", workerId);

                    object result = command.ExecuteScalar();
                    if (result != null && result != DBNull.Value)
                    {
                        return (byte[])result;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ошибка при получении фотографии работника: " + ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            return null;
        }

        //статус заказа обновить
        public bool UpdateOrderStatus(int orderId, string status)
        {
            try
            {
                string updateQuery = "UPDATE orders SET Order_Status = @Status WHERE ID_Order = @OrderId";
                using (MySqlCommand updateCommand = new MySqlCommand(updateQuery, connection))
                {
                    updateCommand.Parameters.AddWithValue("@Status", status);
                    updateCommand.Parameters.AddWithValue("@OrderId", orderId);
                    int rowsAffected = updateCommand.ExecuteNonQuery();

                    return rowsAffected > 0;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ошибка при обновлении статуса заказа: " + ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
        }

        // отчет
        // Метод для получения номера бригады с наибольшим количеством выполненных заказов
        public int GetBrigadeNumber(DateTime startDate, DateTime endDate)
        {
            int brigadeNumber = 0;
            string query = "SELECT Number_Workgroup AS Brigade FROM workgroup WHERE ID_Workgroup = (SELECT WorkgroupID FROM (SELECT WorkgroupID, COUNT(*) AS Count FROM orders WHERE Order_Date BETWEEN @StartDate AND @EndDate GROUP BY WorkgroupID ORDER BY COUNT(*) DESC LIMIT 1) AS T)";
            using (MySqlCommand command = new MySqlCommand(query, connection))
            {
                command.Parameters.AddWithValue("@StartDate", startDate);
                command.Parameters.AddWithValue("@EndDate", endDate);
                brigadeNumber = Convert.ToInt32(command.ExecuteScalar());
            }
            return brigadeNumber;
        }

        // Метод для получения количества заказов, выполненных указанной бригадой
        public int GetBrigadeOrderCount(DateTime startDate, DateTime endDate)
        {
            int brigadeOrderCount = 0;
            string query = "SELECT COUNT(*) AS Count FROM orders WHERE WorkgroupID = (SELECT WorkgroupID FROM (SELECT WorkgroupID, COUNT(*) AS Count FROM orders WHERE Order_Date BETWEEN @StartDate AND @EndDate GROUP BY WorkgroupID ORDER BY COUNT(*) DESC LIMIT 1) AS T) AND Order_Date BETWEEN @StartDate AND @EndDate";
            using (MySqlCommand command = new MySqlCommand(query, connection))
            {
                command.Parameters.AddWithValue("@StartDate", startDate);
                command.Parameters.AddWithValue("@EndDate", endDate);
                brigadeOrderCount = Convert.ToInt32(command.ExecuteScalar());
            }
            return brigadeOrderCount;
        }

        // Метод для получения ID самого большого выполненного заказа
        public int GetLargestOrderId(DateTime startDate, DateTime endDate)
        {
            int largestOrderId = 0;
            string query = "SELECT ID_Order AS OrderId FROM orders WHERE Order_Status = 'Выполнен' AND Order_Date BETWEEN @StartDate AND @EndDate ORDER BY Order_Amount DESC LIMIT 1";
            using (MySqlCommand command = new MySqlCommand(query, connection))
            {
                command.Parameters.AddWithValue("@StartDate", startDate);
                command.Parameters.AddWithValue("@EndDate", endDate);
                largestOrderId = Convert.ToInt32(command.ExecuteScalar());
            }
            return largestOrderId;
        }

        // Метод для получения суммы самого большого выполненного заказа
        public decimal GetLargestOrderSum(DateTime startDate, DateTime endDate)
        {
            decimal largestOrderSum = 0;
            string query = "SELECT Order_Amount AS Sum FROM orders WHERE Order_Status = 'Выполнен' AND Order_Date BETWEEN @StartDate AND @EndDate ORDER BY Order_Amount DESC LIMIT 1";
            using (MySqlCommand command = new MySqlCommand(query, connection))
            {
                command.Parameters.AddWithValue("@StartDate", startDate);
                command.Parameters.AddWithValue("@EndDate", endDate);
                largestOrderSum = Convert.ToDecimal(command.ExecuteScalar());
            }
            return largestOrderSum;
        }

        // Метод для получения услуг из самого большого выполненного заказа
        public string GetOrderServices(int orderId)
        {
            string orderServices = string.Empty;
            string query = "SELECT Services FROM orders WHERE ID_Order = @OrderId";
            using (MySqlCommand command = new MySqlCommand(query, connection))
            {
                command.Parameters.AddWithValue("@OrderId", orderId);
                object result = command.ExecuteScalar();
                if (result != null && result != DBNull.Value)
                {
                    orderServices = Convert.ToString(result);
                }
            }
            return orderServices;
        }

        // Метод для получения количества заказов со статусом "Выполнен"
        public int GetOrderCountWithStatus(DateTime startDate, DateTime endDate)
        {
            int orderCount = 0;string query = "SELECT COUNT(*) AS Count FROM orders WHERE Order_Status = 'Выполнен' AND Order_Date BETWEEN @StartDate AND @EndDate";
            using (MySqlCommand command = new MySqlCommand(query, connection))
            {
                command.Parameters.AddWithValue("@StartDate", startDate);
                command.Parameters.AddWithValue("@EndDate", endDate);
                orderCount = Convert.ToInt32(command.ExecuteScalar());
            }
            return orderCount;
        }

        // Метод для получения суммы всех заказов со статусом "Выполнен"
        public decimal GetTotalOrderSum(DateTime startDate, DateTime endDate)
        {
            decimal orderSum = 0;string query = "SELECT SUM(Order_Amount) AS Sum FROM orders WHERE Order_Status = 'Выполнен' AND Order_Date BETWEEN @StartDate AND @EndDate";
            using (MySqlCommand command = new MySqlCommand(query, connection))
            {
                command.Parameters.AddWithValue("@StartDate", startDate);
                command.Parameters.AddWithValue("@EndDate", endDate);
                object result = command.ExecuteScalar();
                if (result != null && result != DBNull.Value)
                {
                    orderSum = Convert.ToDecimal(result);
                }
            }
            return orderSum;
        }

        //выполнение запросов загрузки
        public System.Data.DataTable GetData(string query)
        {
            System.Data.DataTable dataTable = new System.Data.DataTable();

            try
            {
                using (MySqlDataAdapter adapter = new MySqlDataAdapter(query, connection))
                {
                    adapter.Fill(dataTable);
                }
            }
            catch (MySqlException ex)
            {
                MessageBox.Show("Ошибка при загрузке данных: " + ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            return dataTable;
        }
    }
}
