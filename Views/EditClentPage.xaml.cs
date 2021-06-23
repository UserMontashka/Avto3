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
    /// Логика взаимодействия для EditClentPage.xaml
    /// </summary>
    public partial class EditClentPage : Page
    {
        Client item;
        Core db = new Core();
        public EditClentPage(Client Clientitem, Core db)
        {

            InitializeComponent();
            item = Clientitem;
            this.DataContext = item;
            this.db = db;
            NameBox.Text = item.name ;
            SnameBox.Text = item.sname;
            PatronymicBox.Text = item.patronymic;
            Drivers_licensedBox.Text = item.drivers_licensed;
            Seria_passportBox.Text = item.seria_passport;
            AddressBox.Text = item.address;

        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            item.name = NameBox.Text;
            item.sname = SnameBox.Text;
            item.patronymic = PatronymicBox.Text;
            item.drivers_licensed = Drivers_licensedBox.Text;
            item.seria_passport = Seria_passportBox.Text;
            item.address = AddressBox.Text;

            var resultMessageBox = MessageBox.Show("Вы действительно хотите изменить данные?", "Изменить", MessageBoxButton.YesNo, MessageBoxImage.Information);
            if (resultMessageBox == MessageBoxResult.Yes)
            {
                MessageBox.Show("Данные изменены!", "Уведомление", MessageBoxButton.OK, MessageBoxImage.Information);
                db.context.SaveChanges();
                this.NavigationService.Navigate(new VIewAndEditingPage());
            }
        }
    }
}
