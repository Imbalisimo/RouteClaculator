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

namespace RouteClaculator
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            cb_cities.ItemsSource = RoutesDatabaseContext.GetCities();
            cb_cities.SelectedIndex = 0;
        }

        private void MenuItemAddCity_Click(object sender, RoutedEventArgs e)
        {
            AddCity addCityWindow = new AddCity();
            addCityWindow.Show();
        }

        private void AllPreviousRoutes_Click(object sender, RoutedEventArgs e)
        {

        }

        private void MenuItemAllRoutes_Click(object sender, RoutedEventArgs e)
        {

        }

        private void MenuItemAddRoute_Click(object sender, RoutedEventArgs e)
        {
            AddRoute addRouteWindow = new AddRoute();
            addRouteWindow.Show();
        }

        private void MenuItemAddLocation_Click(object sender, RoutedEventArgs e)
        {
            AddLocation addLocationsWindow = new AddLocation();
            addLocationsWindow.Show();
        }

        private void CitiesDropDownOpened(object sender, EventArgs e)
        {
            cb_cities.ItemsSource = RoutesDatabaseContext.GetCities();
        }

        private void GenerateButton_Clicked(object sender, RoutedEventArgs e)
        {
            decimal distance;
            if (decimal.TryParse(tb_distance.Text, out distance))
            {
                List<Path> paths = RoutesDatabaseContext.GetRoutesWithLength(distance, (Cities)cb_cities.SelectedItem);
                foreach(Path path in paths)
                {
                    tb_paths.Text += path.ToString();
                }
            }
        }
    }
}
