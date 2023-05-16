
using System.Collections.Generic;

namespace LocomotiveDepotBL.Models
{
    public class Locomotive
    {
        public int Id { get; set; }
        public string RegNumber { get; set; }
        public string RegName { get; set; }
        public string Kind { get; set; }
        public string Type { get; set; }
        public int Year { get; set; }
        public ICollection<RepairService> RepairServices { get; set; }
    }
}
