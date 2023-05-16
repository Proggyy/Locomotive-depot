using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LocomotiveDepotBL.Models
{
    public class Repair
    {
        public int Id { get; set; }
        public string RepairType { get; set; }
        public decimal Price { get; set; }
        public bool Quality { get; set; }
        public int BonusInPercent { get; set; }
        public DateTime DateStart { get; set; }
        public DateTime DateStop { get; set; }
        public string Reason { get; set; }
        public ICollection<RepairService> RepairServices { get; set; }

    }
}
