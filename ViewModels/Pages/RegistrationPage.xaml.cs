using MaraphonApp.Controllers;
using MaraphonApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace MaraphonApp.ViewModels.Pages
{
    /// <summary>
    /// Логика взаимодействия для Page1.xaml
    /// </summary>
    public partial class RegistrationPage : Page
    {
        int role;
        string gender;
        public RegistrationPage()
        {
            InitializeComponent();
            Corebd crbd = new Corebd();
            RoleComboBox.ItemsSource = crbd.entities.roles.ToList();
            genderComboBox.ItemsSource = crbd.entities.genders.ToList();
        }

        /// <summary>
        /// добавление данных
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private async void RegButton_Click(object sender, RoutedEventArgs e)
        {
            string pattern = @"^(\w+@[a-zA-Z_]+?\.[a_zA-Z]{2,6})$";
            try
            {
                DataBaseController obj = new DataBaseController();
                string connectionString = "Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=marathon_db;Integrated Security=True";
                if (await obj.DataBaseConnect(connectionString))
                {

                    UserController objUser = new UserController();
                    if (string.IsNullOrWhiteSpace(EmailTextBox.Text) || string.IsNullOrWhiteSpace(FirstTextBox.Text) || string.IsNullOrWhiteSpace(LastNameTextBox.Text) || string.IsNullOrWhiteSpace(PasswordTextBox.Text))
                    {
                        if (Regex.IsMatch(EmailTextBox.Text, pattern, RegexOptions.IgnoreCase))
                        {
                            if (await objUser.FindUsers(EmailTextBox.Text) == true)
                            {
                                if (objUser.SaveRunnerData(EmailTextBox.Text, FirstTextBox.Text, LastNameTextBox.Text, role, gender, PasswordTextBox.Text))
                                {
                                    //переход на страницу RunnerMenuPage (если роль - бегун) }
                                }
                                else
                                {
                                    ResultTextBlock.Text = "Соединенеие не установлено";
                                }
                            }
                            else
                            {
                                ResultTextBlock.Text = "Такая почта существует";
                            }
                        }
                        else
                        {
                            ResultTextBlock.Text = "Неправильная почта";
                        }
                    }
                    else
                    {
                        ResultTextBlock.Text = "Пустое поле";
                    }
                }
            }

            catch (Exception ex)
            {
                ResultTextBlock.Text = "Соединенеие не установлено";
            }
        }

        private void RoleComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
           role = Convert.ToInt32(RoleComboBox.SelectedValue);
          


        }

        private void genderComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
             gender = Convert.ToString(genderComboBox.SelectedValue);
        }
    }
}
    

