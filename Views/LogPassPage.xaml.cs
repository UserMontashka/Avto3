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
using Avto.Controllers;
using Avto.Models;

namespace Avto.Views
{

    /// <summary>
    /// Логика взаимодействия для LogPass.xaml
    /// </summary>
    public partial class LogPassPage : Page
    {
        Core db;
        public LogPassPage()
        {
            InitializeComponent();
            db = new Core();
        }

       

        private void LogInButton_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                UserController objUser = new UserController();
                Console.WriteLine(LoginTextBox.Text);
                Console.WriteLine(PasswordTextBox.Text);

                bool resultLogin = objUser.CheckLogin(LoginTextBox.Text);
                bool resultPass = objUser.CheckPassword(PasswordTextBox.Text);
                
                if (resultLogin == true && resultPass == true)

                {
                   
                    Properties.Settings.Default.Save();
                    Properties.Settings.Default.userLoginString = LoginTextBox.Text;
                    Properties.Settings.Default.Save();
                Console.WriteLine(Properties.Settings.Default.userLoginString);
                    this.NavigationService.Navigate(new ClientsPage());

                }
                else
                {
                    MessageBox.Show("Пользователь не найден");
                    return;
                }
            }
            catch
            {
                MessageBox.Show("Неверный логин или пароль");
                return;
            }
            this.NavigationService.Navigate(new ClientsPage());

            

        }
    }
}
