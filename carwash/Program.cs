using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace carwash
{
    internal static class Program
    {
        private static DatabaseManager dbManager;
        /// <summary>
        /// Главная точка входа для приложения.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            dbManager = DatabaseManager.GetInstance();

            LoginForm loginForm = new LoginForm();
            if (loginForm.ShowDialog() == DialogResult.OK)
            {
                Application.Run(new MainForm());
            }
            Application.ApplicationExit += OnApplicationExit;
        }
        private static void OnApplicationExit(object sender, EventArgs e)
        {
            dbManager.CloseConnection();
        }
    }
}
