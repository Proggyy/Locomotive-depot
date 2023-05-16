using LocomotiveDepotBL;
using LocomotiveDepotBL.Models;
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

namespace LocomotiveDepot.Pages
{
    /// <summary>
    /// Логика взаимодействия для LocomotivePage.xaml
    /// </summary>
    public partial class LocomotivePage : Page
    {
        public LocomotivePage()
        {
            InitializeComponent();
            Update();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {

            if (LocomotiveList.SelectedIndex != -1)
            {
                using (DepotContext db = new DepotContext())
                {
                    var a = db.Locomotives.ToList();
                    db.Locomotives.Remove(a[LocomotiveList.SelectedIndex]);
                    db.SaveChanges();
                }
            }

            Update();
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            int year = 0;
            if (RegName.Text != string.Empty && Regnumber.Text != string.Empty && Kind.Text != string.Empty && Type.Text != string.Empty &&
                int.TryParse(Year.Text, out year))
            {
                using (DepotContext db = new DepotContext())
                {
                    db.Locomotives.Add(new Locomotive() { RegName = RegName.Text, RegNumber = Regnumber.Text, Kind = Kind.Text, Type = Type.Text, Year = year });
                    db.SaveChanges();
                }
                RegName.Text = Regnumber.Text = Kind.Text = Type.Text = Year.Text = string.Empty;
            }
            else
            {
                MessageBox.Show("Неверно указано значение.", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
            }
            Update();
        }
        private void Update()
        {
            using (DepotContext db = new DepotContext())
            {
                LocomotiveList.ItemsSource = db.Locomotives.ToList();
            }
        }
    }
}
