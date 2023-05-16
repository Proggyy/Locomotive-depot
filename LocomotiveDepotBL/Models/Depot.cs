using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LocomotiveDepotBL.Models
{
    public class Depot
    {
        public int Id { get; set; }
        public bool IsExternal { get; set; }
        public string Bank { get; set; }
        public decimal Inn { get; set; }
        public string Address { get; set; }
        public ICollection<RepairService> RepairServices { get; set; }
    }
}
