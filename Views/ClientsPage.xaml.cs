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
using Avto.Models;

namespace Avto.Views
{
    /// <summary>
    /// Логика взаимодействия для ClientsPage.xaml
    /// </summary>
    public partial class ClientsPage : Page
    {
        Core db;
        public ClientsPage()
        {
            InitializeComponent();
            db = new Core();
            var result = db.context.Users.Where(x => x.login == Properties.Settings.Default.userLoginString).First();
            Console.WriteLine("Роль: " + result.id_roles);
                
            switch (result.id_roles)
            {
                case 1:
                    break;                 
                case 2:
                    break;
                case 3:
                    AddClientButton.Visibility = Visibility.Collapsed;
                    EditClientButton.Visibility = Visibility.Collapsed;
                    AddlAvtoButton.Visibility = Visibility.Collapsed;
                    SearchAvtoButton.Visibility = Visibility.Collapsed;


                   
                    
                    break;
                    
                case 1002:

                    break;
            }
           

        }

      

        private void RegBurron_Click(object sender, RoutedEventArgs e)
        {
            
        }

        private void AddClientButton_Click(object sender, RoutedEventArgs e)
        {
            this.NavigationService.Navigate(new RegisterPage());


        }

        private void LoginClientButton_Click(object sender, RoutedEventArgs e)
        {
            this.NavigationService.Navigate(new LogPassPage());
        }

       

        private void EditClientButton_Click(object sender, RoutedEventArgs e)
        {
            this.NavigationService.Navigate(new VIewAndEditingPage());
        }

        private void RegisterAvto_Click(object sender, RoutedEventArgs e)
        {

        }

        private void ControlAvto_Click(object sender, RoutedEventArgs e)
        {

        }

        private void ControlAvto_Click_1(object sender, RoutedEventArgs e)
        {

        }

        private void AddlAvto_Click(object sender, RoutedEventArgs e)
        {
            this.NavigationService.Navigate(new AddAvtoPage());
        }

        private void SearchAvto_Click(object sender, RoutedEventArgs e)
        {
            this.NavigationService.Navigate(new SearchAvtoPage());
        }

        private void TakeAvtoButton_Click(object sender, RoutedEventArgs e)
        {
            this.NavigationService.Navigate(new RentAvto());
        }
    }
}
