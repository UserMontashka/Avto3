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
    /// Логика взаимодействия для RentAvto.xaml
    /// </summary>
    public partial class RentAvto : Page
    {
        Core db = new Core();
        
        public RentAvto()
        {
            InitializeComponent();
            DataGridSearchAvto.ItemsSource = db.context.Cars.ToList();
        }
    }
}
