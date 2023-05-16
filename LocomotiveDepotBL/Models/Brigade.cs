using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LocomotiveDepotBL.Models
{
    public class Brigade
    {
        public int Id { get; set; }
        public int ChiefId { get; set; }
        public Chief Chief { get; set; }
        public ICollection<RepairService> RepairServices { get; set; }
        public ICollection<WorkerToBrigade> WorkerToBrigades { get; set; }
    }
}
