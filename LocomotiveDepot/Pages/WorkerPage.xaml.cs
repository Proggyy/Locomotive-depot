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
    /// Логика взаимодействия для WorkerPage.xaml
    /// </summary>
    public partial class WorkerPage : Page
    {
        private List<Brigade> Brigades = new List<Brigade>();
        private List<Worker> Workers = new List<Worker>();
        public WorkerPage()
        {
            InitializeComponent();
            Update();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            int result;
            if (int.TryParse(Experience.Text, out result) && Name.Text != string.Empty && Base.Text != string.Empty && Special.Text != string.Empty && Brigadiers.SelectedIndex != -1)
            {
                using (DepotContext db = new DepotContext())
                {
                    var worker = new Worker() { Name = Name.Text, Base = Base.Text, Special = Special.Text, YearExpirience = result };
                    db.WorkerToBrigades.Add(new WorkerToBrigade() { Brigade = db.Brigades.ToList()[Brigadiers.SelectedIndex], Worker = worker });
                    db.Workers.Add(worker);
                    db.SaveChanges();
                }
                Experience.Text = Special.Text = Base.Text = Name.Text = string.Empty;
                Brigadiers.SelectedIndex = -1;
            }
            else
            {
                MessageBox.Show("Неверно указано значение.", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
            }
            Update();

        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            if (WorkerList.SelectedIndex != -1)
            {
                using (DepotContext db = new DepotContext())
                {
                    db.Workers.Remove(db.Workers.ToList()[WorkerList.SelectedIndex]);
                    db.SaveChanges();
                }
            }

            Update();
        }

        private void Update()
        {
            using (DepotContext db = new DepotContext())
            {
                Workers = db.Workers.ToList();
                WorkerList.ItemsSource = Workers;
                Brigades = db.Brigades.ToList();
                Brigadiers.ItemsSource = Brigades.Select(x => db.Chiefs.Where(y => y.Id == x.ChiefId).FirstOrDefault().Name);
            }
        }
    }
}
