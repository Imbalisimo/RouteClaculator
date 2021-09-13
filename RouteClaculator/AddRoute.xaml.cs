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
        RouteModel model = new RouteModel();
        public AddRoute()
        {
            InitializeComponent();
            cb_cities.ItemsSource = RoutesDatabaseContext.GetCities();
            this.DataContext = model;
            cb_cities.SelectedIndex = 0;
        }

        public AddRoute(Route route)
        {
            InitializeComponent();
            List<City> cities = RoutesDatabaseContext.GetCities();
            cb_cities.ItemsSource = cities;
            RouteMapper.Map(model, route);
            this.DataContext = model;
        }

        private void CityCb_Opened(object sender, EventArgs e)
        {
            cb_cities.ItemsSource = RoutesDatabaseContext.GetCities();
        }

        private void AddButton_Click(object sender, RoutedEventArgs e)
        {
            if (!model.IsFilled)
                return;
            if(!model.IsEdit)
            {
                RoutesDatabaseContext.AddRoute(model);
            }
            else
            {
                RoutesDatabaseContext.EditRoute(model);
            }
            Close();
        }
    }
}
