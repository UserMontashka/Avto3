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
using Avto.Controllers;

namespace Avto.Views
{
    /// <summary>
    /// Логика взаимодействия для SearchAvtoPage.xaml
    /// </summary>
    public partial class SearchAvtoPage : Page
    {
        Core db;
        UserController obj = new UserController();
        public SearchAvtoPage()
        {
            InitializeComponent();
            db = new Core();
            DataGridSearchAvto.ItemsSource = db.context.Cars.ToList();
            SearchStateNumberBox.MaxLength = 9;
        }

        private void Button_Click(object sender, RoutedEventArgs e) //Удаление данных об автомобилях
        {
            try
            {
                Button selectedButton = (Button)sender;
                Cars res = selectedButton.DataContext as Cars;

                MessageBoxResult result = MessageBox.Show("Вы действительно хотите удалить?", "Удаление", MessageBoxButton.YesNoCancel, MessageBoxImage.Question);
                if (result == MessageBoxResult.Yes)
                {
                    db.context.Cars.Remove(res);
                    db.context.SaveChanges();
                    MessageBox.Show("Данные удалены");
                }
                //обновление DataGrid
                DataGridSearchAvto.ItemsSource = db.context.Cars.ToList();
            }
             catch (Exception)
            {
                MessageBox.Show("Данные удалены");
            }
        }

        private void EditClick(object sender, RoutedEventArgs e) //Редактирование данных об автомобилях
        {
            Button selelectedButton = sender as Button;
            Cars item = selelectedButton.DataContext as Cars;
            this.NavigationService.Navigate(new EditAvtoPage(item,db));
        }

        private void SearchStateNumberBox_TextChanged(object sender, TextChangedEventArgs e) //Поиск по гос.номеру
        {
            bool result = obj.TextGosNumber(SearchStateNumberBox.Text);
            if (result)
                Format.Text = "";
            else
                Format.Text="неправельный формат";
            string search = Convert.ToString(SearchStateNumberBox.Text); 
            DataGridSearchAvto.ItemsSource = db.context.Cars.Where(x => x.state_number.Contains(search)).ToList();
        }

        private void SearchBrendBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            string fio = Convert.ToString(SearchBrendBox.Text);
            DataGridSearchAvto.ItemsSource = db.context.Cars.Where(x => x.brand.Contains(fio)).ToList();
        }
    }
}
