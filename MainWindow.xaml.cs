using Avto.Views;
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

namespace Avto
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            MainFrame.Navigate(new LogPassPage());
        }

        private void Back_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            if (MainFrame.CanGoBack)
            {
                MainFrame.GoBack();
               
            }
           

        }

        private void Forward_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            if (MainFrame.CanGoForward)
            {
                MainFrame.GoForward();
            }

        }

        private void Home_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            MainFrame.Navigate(new ClientsPage());

        }

        private void MainFrame_ContentRendered(object sender, EventArgs e)
        {
            {
                if (!MainFrame.CanGoBack)

                { 
                   
                    Home.Visibility = Visibility.Collapsed; 
                  
                }

                else

                
                { Home.Visibility = Visibility.Visible; }

                if (!MainFrame.CanGoBack)

                {

                    Back.Visibility = Visibility.Collapsed;

                }

                else


                { Back.Visibility = Visibility.Visible; }

                if (!MainFrame.CanGoBack)

                {

                    Forward.Visibility = Visibility.Collapsed;

                }

                else


                { Forward.Visibility = Visibility.Visible; }


            }
        }
    }
}
