using MySql.Data.MySqlClient;
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
    public partial class TeamAddForm : Form
    {
        public TeamAddForm()
        {
            InitializeComponent();
            OnLoad(EventArgs.Empty);
        }

        public int SelectedTeamId { get; set; }

        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);

            if (SelectedTeamId > 0)
            {
                // Изменение текста кнопки и названия формы для режима изменения
                TeamAddButton.Text = "Изменить";
                this.Text = "Изменить бригаду";
            }
            else
            {
                // Изменение текста кнопки и названия формы для режима добавления
                TeamAddButton.Text = "Добавить";
                this.Text = "Добавить бригаду";
            }
        }

        private void AddTeamToDatabase()
        {
            if (string.IsNullOrEmpty(TeamAddTb.Text) || TeamAddDate.Value == null)
            {
                MessageBox.Show("Пожалуйста, заполните все поля.", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            else
            {
                if(TeamAddDate.Value != null && !string.IsNullOrEmpty(TeamAddTb.Text)) 
                {
                    string number = TeamAddTb.Text;
                    DateTime date = TeamAddDate.Value;
                    bool teamAdd = DatabaseManager.GetInstance().AddTeamToDatabase(number, date);

                    if (teamAdd)
                    {
                        DialogResult = DialogResult.OK;
                        MessageBox.Show("Бригада успешно добавлена.", "Успех", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        this.Close();
                    }
                }
            }
        }

        private void UpdateTeamInDatabase(int teamId)
        {
            if (string.IsNullOrEmpty(TeamAddTb.Text) || TeamAddDate.Value == null)
            {
                MessageBox.Show("Пожалуйста, заполните все поля.", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            else
            {
                if (TeamAddDate.Value != null && !string.IsNullOrEmpty(TeamAddTb.Text))
                {
                    string number = TeamAddTb.Text;
                    DateTime date = TeamAddDate.Value;
                    bool teamUpdate = DatabaseManager.GetInstance().UpdateTeamInDatabase(teamId, number, date);

                    if (teamUpdate)
                    {
                        DialogResult = DialogResult.OK;
                        MessageBox.Show("Бригада успешно изменена.", "Успех", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        this.Close();
                    }
                }
            }
        }

        private void TeamAddButton_Click(object sender, EventArgs e)
        {
            // Проверяем, открыта ли форма для добавления новой бригады или для изменения существующей
            if (SelectedTeamId > 0)
            {
                UpdateTeamInDatabase(SelectedTeamId);
            }
            else
            {
                AddTeamToDatabase();
            }
        }
        private void TeamAddTb_KeyPress(object sender, KeyPressEventArgs e)
        {
            // Разрешаем только цифры и управляющие клавиши (Backspace, Delete и т.д.)
            if (!ValidateTeamInput(e.KeyChar.ToString()) && e.KeyChar != '\b')
            {
                e.Handled = true;
            }
        }
        private void TeamAddForm_Load(object sender, EventArgs e)
        {
            TeamAddTb.Text = string.Empty;
            TeamAddDate.Value = DateTime.Now;
            TeamAddTb.KeyPress += new KeyPressEventHandler(TeamAddTb_KeyPress);

            // При нажатии кнопки "Изменить" инициализируем форму данными выбранной бригады
            if (SelectedTeamId > 0)
            {
                Workgroup team = DatabaseManager.GetInstance().GetTeamById(SelectedTeamId);

                if (team != null)
                {
                    TeamAddTb.Text = team.Number_Workgroup.ToString();
                    TeamAddDate.Value = team.Date_Of_Creation;
                }
            }
        }
        private bool ValidateTeamInput(string input)
        {
            string pattern = @"^[\d]+$";
            return Regex.IsMatch(input, pattern);
        }
    }
}
