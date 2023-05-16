using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LocomotiveDepotBL.Models
{
    public class Bonus
    {
        public int Id { get; set; }
        public decimal BonusWorker { get; set; }
        public string BonusType { get; set; }
        public string Comment { get; set; }
        public ICollection<RepairService> RepairServices { get; set; }
    }
}
