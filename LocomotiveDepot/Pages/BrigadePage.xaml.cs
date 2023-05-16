using LocomotiveDepotBL;
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
    /// Логика взаимодействия для BrigadePage.xaml
    /// </summary>
    public partial class BrigadePage : Page
    {
        public BrigadePage()
        {
            InitializeComponent();
            using (DepotContext db = new DepotContext())
            {
                ChiefSelect.ItemsSource = db.Chiefs.ToList();
            }

        }

        private void ChiefSelect_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (ChiefSelect.SelectedIndex != -1)
            {
                using (DepotContext db = new DepotContext())
                {
                    var chief = db.Chiefs.ToList()[ChiefSelect.SelectedIndex];
                    var brigade = db.Brigades.Where(b => b.ChiefId == chief.Id).FirstOrDefault();
                    var workerToBrigades = db.WorkerToBrigades.Where(wb => wb.BrigadeId == brigade.Id);
                    BrigadeList.ItemsSource = db.Workers.Where(w => workerToBrigades.Any(d => d.WorkerId == w.Id)).ToList();
                }
            }
        }
    }
}
