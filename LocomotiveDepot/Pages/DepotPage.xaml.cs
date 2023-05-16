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
    /// Логика взаимодействия для DepotPage.xaml
    /// </summary>
    public partial class DepotPage : Page
    {
        public DepotPage()
        {
            InitializeComponent();
            Update();
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            decimal inn = 0;
            if (IsExternal != null && Bank.Text != string.Empty && Adress.Text != string.Empty && decimal.TryParse(Inn.Text, out inn))
            {
                using (DepotContext db = new DepotContext())
                {
                    db.Depots.Add(new Depot() { IsExternal = IsExternal.IsChecked.Value, Bank = Bank.Text, Address = Adress.Text, Inn = inn });
                    db.SaveChanges();
                }
                Adress.Text = Inn.Text = Bank.Text = string.Empty;
                IsExternal.IsChecked = false;
            }
            else
            {
                MessageBox.Show("Неверно указано значение.", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
            }
            Update();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            if (DepotList.SelectedIndex != -1)
            {
                using (DepotContext db = new DepotContext())
                {
                    var a = db.Depots.ToList();
                    db.Depots.Remove(a[DepotList.SelectedIndex]);
                    db.SaveChanges();
                }
            }
            Update();
        }
        private void Update()
        {
            using (DepotContext db = new DepotContext())
            {
                DepotList.ItemsSource = db.Depots.ToList();
            }
        }
    }
}
