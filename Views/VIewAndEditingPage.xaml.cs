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
    /// Логика взаимодействия для VIewAndEditingPage.xaml
    /// </summary>
    public partial class VIewAndEditingPage : Page
    {
        Core db;
        public VIewAndEditingPage()
        {
            InitializeComponent();
            db = new Core();
            DataGridClients.ItemsSource = db.context.Client.ToList();
        }

        private void Button_Click(object sender, RoutedEventArgs e) ///Кнопка удаления пользователя
        {
            try
            {
                Button selectedButton = (Button)sender;
                Client item = selectedButton.DataContext as Client;
                var item1 = db.context.Users.Where(x => x.login == item.email).First();

                MessageBoxResult result = MessageBox.Show("Вы действительно хотите удалить?", "Удаление", MessageBoxButton.YesNoCancel, MessageBoxImage.Question);
                if (result ==MessageBoxResult.Yes)
                {
                    db.context.Client.Remove(item);
                    db.context.Users.Remove(item1);
                    db.context.SaveChanges();
                    MessageBox.Show("Данные удалены");
                }
                //обновление DataGrid
                DataGridClients.ItemsSource = db.context.Client.ToList();


            }
          catch (Exception)
            {
                MessageBox.Show("Данные удалены");
            }

        }
        
        private void Button_Click_1(object sender, RoutedEventArgs e) ///Кнопка кнопка редактирования пользователя
        {
            Button selelectedButton = sender as Button;
            Client item = selelectedButton.DataContext as Client;
            this.NavigationService.Navigate(new EditClentPage(item,db));

        }
        
       

        private void FioTextBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            string fio = Convert.ToString(FioTextBox.Text);
            DataGridClients.ItemsSource = db.context.Client.Where(x => x.name.Contains(fio)).ToList();
       
        }

        private void TextBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            string fio = Convert.ToString(SearchNumberBox.Text);
            DataGridClients.ItemsSource = db.context.Client.Where(x => x.drivers_licensed.Contains(fio)).ToList();
        }

        private void TextBox_TextChanged_1(object sender, TextChangedEventArgs e)
        {
            string fio = Convert.ToString(SearchArdessBox.Text);
            DataGridClients.ItemsSource = db.context.Client.Where(x => x.address.Contains(fio)).ToList();
        }
    }
}

