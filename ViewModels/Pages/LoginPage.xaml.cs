using MaraphonApp.Controllers;
using MaraphonApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
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
    /// Логика взаимодействия для LoginPage.xaml
    /// </summary>
    public partial class LoginPage : Page
    {
        public LoginPage()
        {
            Corebd crbd = new Corebd();
            InitializeComponent();
        }

        private async void login_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                DataBaseController obj = new DataBaseController();
                string connectionString = "Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=marathon_db;Integrated Security=True";
                if (await obj.DataBaseConnect(connectionString))
                {
                  UserController objUser = new UserController();
                  if (objUser.Login(EmailTextBox.Text, PasswordTextBox.Text))
                  {
                        ResultTextBlock.Text = " не установлеdfно";
                    }
                  else
                  {
                    ResultTextBlock.Text = "Соединенеие не установлено";
                   }
                }
                           
                    
                    else
                    {
                        ResultTextBlock.Text = "Пустое поле";
                    }
                }
            catch (Exception ex)
            {
                ResultTextBlock.Text = "Соединенеие не установлено";
            }
        }
    }
}
