using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LocomotiveDepotBL.Models
{
    public class Worker
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Base { get; set; }
        public int YearExpirience { get; set; }
        public string Special { get; set; }
        public ICollection<WorkerToBrigade> WorkerToBrigades { get; set; }
    }
}
