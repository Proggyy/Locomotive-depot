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
    /// Логика взаимодействия для ServicePage.xaml
    /// </summary>
    public partial class ServicePage : Page
    {
        private List<Locomotive> Locomotives = new List<Locomotive>();
        private List<Depot> Depots = new List<Depot>();
        private List<Brigade> Brigades = new List<Brigade>();
        public ServicePage()
        {
            InitializeComponent();
            Update();
        }

        private void Update()
        {
            using (DepotContext db = new DepotContext())
            {
                Locomotives = db.Locomotives.ToList();
                Depots = db.Depots.ToList();
                Brigades = db.Brigades.ToList();
                LocomotiveList.ItemsSource = Locomotives.Select(l => l.RegNumber);
                DepotList.ItemsSource = Depots.Select(d => d.Address);
                BrigadeList.ItemsSource = Brigades.Select(b => db.Chiefs.Where(c => c.Id == b.ChiefId).FirstOrDefault().Name);
            }
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            decimal price = 0;
            int percent = 0;
            decimal bonus = 0;
            bool isSelected = LocomotiveList.SelectedIndex != -1 && DepotList.SelectedIndex != -1 && BrigadeList.SelectedIndex != -1;
            bool isNotEmpty = RepairType.Text != string.Empty && RepairReason.Text != string.Empty && Quality.IsChecked.HasValue == true && BonusType.Text != string.Empty && Comment.Text != string.Empty;
            bool isCorrectValue = int.TryParse(BonusPercent.Text, out percent) && decimal.TryParse(Bonus.Text, out bonus) && decimal.TryParse(RepairPrice.Text, out price);
            bool isDatePicked = RepairStart.SelectedDate != null && RepairEnd.SelectedDate != null;

            if (isSelected && isNotEmpty && isCorrectValue && isDatePicked)
            {
                using (DepotContext db = new DepotContext())
                {
                    var mbonus = db.Bonuses.Add(new Bonus() { BonusType = BonusType.Text, BonusWorker = bonus, Comment = Comment.Text });

                    var mrepair = db.Repairs.Add(new Repair()
                    {
                        DateStart = RepairStart.SelectedDate.Value,
                        DateStop = RepairEnd.SelectedDate.Value,
                        BonusInPercent = percent,
                        Price = price,
                        Quality = Quality.IsChecked.Value,
                        Reason = RepairReason.Text,
                        RepairType = RepairType.Text
                    });

                    db.SaveChanges();

                    db.RepairServices.Add(new RepairService()
                    {
                        BonusId = mbonus.Id,
                        RepairId = mrepair.Id,
                        LocomotiveId = Locomotives[LocomotiveList.SelectedIndex].Id,
                        BrigadeId = Brigades[BrigadeList.SelectedIndex].Id,
                        DepotId = Depots[DepotList.SelectedIndex].Id
                    });

                    db.SaveChanges();
                }
                MessageBox.Show("Подробность ремонта добавлена.");
            }
            else
            {
                MessageBox.Show("Неверно указано значение.", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
            }
            Update();
        }
    }
}
