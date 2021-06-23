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
using Microsoft.Win32;
using System.IO;

namespace Avto.Views
{
    /// <summary>
    /// Логика взаимодействия для AddAvtoPage.xaml
    /// </summary>
    public partial class AddAvtoPage : Page
    {
        Core db = new Core();
        byte[] convertImageToByte;

        public AddAvtoPage()
        {
            InitializeComponent();
            

        }

        private void AddNewAvto_Click(object sender, RoutedEventArgs e)
        {
            if (BrandTextBox.Text == "" || ColorTextBox.Text == "" || YearIssueDatePicker.Text == "" || NumberTextBox.Text =="" || AvailabilityTextBox.Text =="" || convertImageToByte == null)
            {
                MessageBox.Show("Заполните все поля");
            }
            else
            {
                Cars objectCars = new Cars()
                {
                    state_number = NumberTextBox.Text,
                    brand = BrandTextBox.Text,
                    color = ColorTextBox.Text,
                    year_of_issue = Convert.ToDateTime(YearIssueDatePicker.SelectedDate),
                    availability = Convert.ToByte(AvailabilityTextBox.Text),
                    image_cars = convertImageToByte,


                };
                db.context.Cars.Add(objectCars);
                db.context.SaveChanges();
                MessageBox.Show("Автомобиль добавлен");
            }
            
        }

        private void AddImageAvtoButton_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog fileDialog = new OpenFileDialog();
            fileDialog.Filter = "JPEG Files (*.jpeg)|*.jpeg|PNG Files (*.png)|*.png|JPG Files (*.jpg)|*.jpg|GIF Files (*.gif)|*.gif";
            if (fileDialog.ShowDialog() == true)
            {
                convertImageToByte = File.ReadAllBytes(fileDialog.FileName);
                MessageBox.Show("Картинка добавлена");
            }


        }
    }
}
