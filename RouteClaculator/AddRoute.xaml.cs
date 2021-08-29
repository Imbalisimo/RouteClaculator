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
    /// Interaction logic for AddRoute.xaml
    /// </summary>
    public partial class AddRoute : Window
    {
        public AddRoute()
        {
            InitializeComponent();
            cb_cities.ItemsSource = RoutesDatabaseContext.GetCities();
            cb_cities.SelectedIndex = 0;
        }

        private void CityCb_Opened(object sender, EventArgs e)
        {
            cb_cities.ItemsSource = RoutesDatabaseContext.GetCities();
        }

        private void CityCb_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            cb_locationStarting.ItemsSource = RoutesDatabaseContext.GetLocationsByCity((Cities)cb_cities.SelectedItem);
        }

        private void StartingLocationCb_Opened(object sender, EventArgs e)
        {
            cb_locationStarting.ItemsSource = RoutesDatabaseContext.GetLocationsByCity((Cities)cb_cities.SelectedItem);
        }

        private void FinalLocationCb_Opened(object sender, EventArgs e)
        {
            cb_locationFinal.ItemsSource = RoutesDatabaseContext.GetLocationsByCity((Cities)cb_cities.SelectedItem);
        }

        private void AddButton_Click(object sender, RoutedEventArgs e)
        {
            decimal distance;
            if(decimal.TryParse(tb_distance.Text, out distance))
            {
                Routes route = new Routes();
                route.City = ((Cities)cb_cities.SelectedItem).Id;
                route.LocationStart = ((Locations)cb_locationStarting.SelectedItem).Id;
                route.LocationEnd = ((Locations)cb_locationFinal.SelectedItem).Id;
                route.RouteLength = distance;
                RoutesDatabaseContext.AddRoute(route);
                tb_distance.Text = "";
            }
        }
    }
}
