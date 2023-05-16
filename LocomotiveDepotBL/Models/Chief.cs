using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LocomotiveDepotBL.Models
{
    public class Chief
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Base { get; set; }
        public ICollection<Brigade> Brigades { get; set; }

        public override string ToString()
        {
            return Name;
        }
    }
}
