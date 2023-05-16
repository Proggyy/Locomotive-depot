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
    /// Логика взаимодействия для ShowServicesPage.xaml
    /// </summary>
    public partial class ShowServicesPage : Page
    {
        private List<RepairService> RepairServices = new List<RepairService>();
        public ShowServicesPage()
        {
            InitializeComponent();
            Update();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {

            if (ServiceList.SelectedIndex != -1)
            {
                using (DepotContext db = new DepotContext())
                {
                    var service = RepairServices[ServiceList.SelectedIndex];
                    db.RepairServices.Remove(db.RepairServices.ToList()[ServiceList.SelectedIndex]);
                    db.Repairs.Remove(db.Repairs.Where(r => r.Id == service.RepairId).FirstOrDefault());
                    db.Bonuses.Remove(db.Bonuses.Where(r => r.Id == service.BonusId).FirstOrDefault());
                    db.SaveChanges();
                }
            }
            Update();

        }
        private void Update()
        {
            using (DepotContext db = new DepotContext())
            {
                RepairServices = db.RepairServices.ToList();
            }
            ServiceList.ItemsSource = RepairServices.Select(s => s.Id);
        }

        private void ServiceList_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (ServiceList.SelectedIndex != -1)
            {
                using (DepotContext db = new DepotContext())
                {
                    var service = RepairServices[ServiceList.SelectedIndex];
                    var Chief = db.Chiefs.Where(c => c.Id == db.Brigades.Where(b => b.Id == service.BrigadeId).FirstOrDefault().ChiefId).FirstOrDefault();
                    var Locomotive = db.Locomotives.Where(l => l.Id == service.LocomotiveId).FirstOrDefault();
                    var Repair = db.Repairs.Where(r => r.Id == service.RepairId).FirstOrDefault();
                    var Bonus = db.Bonuses.Where(b => b.Id == service.BonusId).FirstOrDefault();

                    regnum.Text = Locomotive.RegNumber;
                    kind.Text = Locomotive.Kind;
                    reason.Text = Repair.Reason;
                    datestart.Text = Repair.DateStart.ToString();
                    dateend.Text = Repair.DateStop.ToString();
                    chief.Text = Chief.Name;
                    bonus.Text = Bonus.BonusWorker.ToString();
                    price.Text = Repair.Price.ToString();
                    quality.Text = Repair.Quality ? "Отличное качество" : "В пределах нормы";
                }
            }

        }
    }
}
