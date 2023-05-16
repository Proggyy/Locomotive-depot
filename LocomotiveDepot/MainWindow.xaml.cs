using LocomotiveDepot.Pages;
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

namespace LocomotiveDepot
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public Page tent { get; set; }
        public MainWindow()
        {
            InitializeComponent();
        }
        private void WorkerButton_Click(object sender, RoutedEventArgs e) => MainFrame.Content = new WorkerPage();
        private void BrigadeButton_Click(object sender, RoutedEventArgs e) => MainFrame.Content = new BrigadePage();
        private void ChiefButton_Click(object sender, RoutedEventArgs e) => MainFrame.Content = new ChiefPage();
        private void LocomotiveButton_Click(object sender, RoutedEventArgs e) => MainFrame.Content = new LocomotivePage();
        private void DepotButton_Click(object sender, RoutedEventArgs e) => MainFrame.Content = new DepotPage();
        private void ServiceButton_Click(object sender, RoutedEventArgs e) => MainFrame.Content = new ServicePage();
        private void ServiceListButton_Click(object sender, RoutedEventArgs e) => MainFrame.Content = new ShowServicesPage();
    }
}
