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
    /// Логика взаимодействия для ChiefPage.xaml
    /// </summary>
    public partial class ChiefPage : Page
    {
        public ChiefPage()
        {
            InitializeComponent();
            Update();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            if (ChiefList.SelectedIndex != -1)
            {
                using (DepotContext db = new DepotContext())
                {
                    db.Chiefs.Remove(db.Chiefs.ToList()[ChiefList.SelectedIndex]);
                    db.SaveChanges();
                }
            }
            Update();
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            if (Name.Text != string.Empty && Base.Text != string.Empty)
            {
                using (DepotContext db = new DepotContext())
                {
                    var chief = new Chief() { Name = Name.Text, Base = Base.Text };
                    db.Chiefs.Add(chief);
                    db.Brigades.Add(new Brigade() { Chief = chief });
                    db.SaveChanges();
                }
                Base.Text = Name.Text = string.Empty;
                Update();
            }
            else
            {
                MessageBox.Show("Неверно указано значение.", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void Update()
        {
            using (DepotContext db = new DepotContext())
            {
                ChiefList.ItemsSource = db.Chiefs.ToList();
            }
        }
    }
}
