using System;
using System.Collections.Generic;
using System.IO;
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
using Microsoft.Win32;


namespace Avto.Views
{
    /// <summary>
    /// Логика взаимодействия для EditAvtoPage.xaml
    /// </summary>
  
    public partial class EditAvtoPage : Page
    {
        Cars item;
        Core db = new Core();
        byte[] convertImageToByte;
        public EditAvtoPage(Cars Carsitem, Core db)
        {
            InitializeComponent();
            item = Carsitem;
            this.DataContext = item;
            this.db = db;
            byte[] img = item.image_cars;
            StateNumberBox.Text = item.state_number;
            BrandBox.Text = item.brand;
            ColorBox.Text = item.color;
            YearOfIssueBox.Text = Convert.ToString(item.year_of_issue); 
            AvailabilityBox.Text = Convert.ToString(item.availability); 
            convertImageToByte = item.image_cars;





        }

        private void EditImageButton_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog ei = new OpenFileDialog();
            ei.Filter = "JPEG Files (*.jpeg)|*.jpeg|PNG Files (*.png)|*.png|JPG Files (*.jpg)|*.jpg|GIF Files (*.gif)|*.gif";
            if (ei.ShowDialog() == true)
            {
                Uri eii = new Uri(ei.FileName);
                Image.Source = new BitmapImage(eii);
                convertImageToByte = File.ReadAllBytes(ei.FileName);
                MessageBox.Show("Картинка измененна");
                

            }
            
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            item.state_number = StateNumberBox.Text;
            item.brand = BrandBox.Text;
            item.color = ColorBox.Text;
            item.year_of_issue = Convert.ToDateTime(YearOfIssueBox.Text);
            item.availability = Convert.ToByte(AvailabilityBox.Text);
            item.image_cars = convertImageToByte;
            



            var resultMessageBox = MessageBox.Show("Вы действительно хотите изменить данные?", "Изменить", MessageBoxButton.YesNo, MessageBoxImage.Information);
            if (resultMessageBox == MessageBoxResult.Yes)
            {
                MessageBox.Show("Данные изменены!", "Уведомление", MessageBoxButton.OK, MessageBoxImage.Information);
                db.context.SaveChanges();
                this.NavigationService.Navigate(new SearchAvtoPage());
            }




        }
    }
}
