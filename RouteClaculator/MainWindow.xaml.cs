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
        }

        private void AllRoutes_Click(object sender, RoutedEventArgs e)
        {
            AllRoutes allRoutesWindow = new AllRoutes();
            allRoutesWindow.Show();
        }

        private void Generate_Click(object sender, RoutedEventArgs e)
        {
            Generate generateWindow = new Generate();
            generateWindow.Show();
        }
    }
}
