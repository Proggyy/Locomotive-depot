using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LocomotiveDepotBL.Models
{
    public class RepairService
    {
        public int Id { get; set; }
        public int LocomotiveId { get; set; }
        public Locomotive Locomotive { get; set; }
        public int RepairId { get; set; }
        public Repair Repair { get; set; }
        public int BonusId { get; set; }
        public Bonus Bonus { get; set; }
        public int DepotId { get; set; }
        public Depot Depot { get; set; }
        public int BrigadeId { get; set; }
        public Brigade Brigade { get; set; }
    }
}
