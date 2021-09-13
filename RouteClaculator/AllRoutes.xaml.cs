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
    /// Interaction logic for AllRoutes.xaml
    /// </summary>
    public partial class AllRoutes : Window
    {
        public AllRoutes()
        {
            InitializeComponent();
            cb_cities.ItemsSource = RoutesDatabaseContext.GetCities();
            cb_cities.SelectedIndex = 0;
            lb_routes.ItemsSource = RoutesDatabaseContext.GetRoutesByCity((City)cb_cities.SelectedItem);
            lb_routes.SelectedIndex = 0;
        }

        private void AddNewCity_Click(object sender, RoutedEventArgs e)
        {
            AddCity addCityWindow = new AddCity();
            addCityWindow.Show();
        }

        private void AddNewRoute_Click(object sender, RoutedEventArgs e)
        {
            AddRoute addRouteWindow = new AddRoute();
            addRouteWindow.ShowDialog();
            lb_routes.ItemsSource = RoutesDatabaseContext.GetRoutesByCity((City)cb_cities.SelectedItem);
            lb_routes.SelectedIndex = 0;
        }

        private void EditRoute_Click(object sender, RoutedEventArgs e)
        {
            AddRoute addRouteWindow = new AddRoute((Route)lb_routes.SelectedItem);
            addRouteWindow.Show();
        }

        private void DeleteRoute_Click(object sender, RoutedEventArgs e)
        {
            RoutesDatabaseContext.DeleteRoute((Route)lb_routes.SelectedItem);
        }

        private void CitiesDropDownOpened(object sender, EventArgs e)
        {
            cb_cities.ItemsSource = RoutesDatabaseContext.GetCities();
        }

        private void CityDropdownSelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            lb_routes.ItemsSource = RoutesDatabaseContext.GetRoutesByCity((City)cb_cities.SelectedItem);
            lb_routes.SelectedItem = 0;
        }
    }
}
