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
using System.Windows.Shapes;

namespace RouteClaculator
{
    /// <summary>
    /// Interaction logic for AddLocation.xaml
    /// </summary>
    public partial class AddLocation : Window
    {
        public AddLocation()
        {
            InitializeComponent();
            cb_cities.ItemsSource = RoutesDatabaseContext.GetCities();
            cb_cities.SelectedIndex = 0;
        }

        private void CitiesDropDownOpened(object sender, EventArgs e)
        {
            cb_cities.ItemsSource = RoutesDatabaseContext.GetCities();
        }

        private void ButtonAdd_Click(object sender, RoutedEventArgs e)
        {
            if (tb_locationName.Text != "")
                RoutesDatabaseContext.AddLocation(new Locations(tb_locationName.Text, (Cities)cb_cities.SelectedItem));
            tb_locationName.Text = "";
        }
    }
}
