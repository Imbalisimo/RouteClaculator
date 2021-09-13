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
    /// Interaction logic for Generate.xaml
    /// </summary>
    public partial class Generate : Window
    {
        public Generate()
        {
            InitializeComponent();
            cb_cities.ItemsSource = RoutesDatabaseContext.GetCities();
            cb_cities.SelectedIndex = 0;
        }

        private void CitiesDropDownOpened(object sender, EventArgs e)
        {
            cb_cities.ItemsSource = RoutesDatabaseContext.GetCities();
        }

        private void GenerateButton_Clicked(object sender, RoutedEventArgs e)
        {
            tb_paths.Text = "";
            decimal distance;
            if (decimal.TryParse(tb_distance.Text, out distance))
            {
                List<Path> paths = RoutesDatabaseContext.GetRandomRoutesWithLength(distance, (City)cb_cities.SelectedItem);
                foreach (Path path in paths)
                {
                    tb_paths.Text += path.ToString() + "\n\n";
                }
            }
        }
    }
}
