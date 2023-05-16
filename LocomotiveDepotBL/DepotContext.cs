using LocomotiveDepotBL.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LocomotiveDepotBL
{
    public class DepotContext : DbContext 
    {
        public DbSet<Locomotive> Locomotives { get; set; }
        public DbSet<Repair> Repairs { get; set; }
        public DbSet<Bonus> Bonuses { get; set; }
        public DbSet<Depot> Depots { get; set; }
        public DbSet<Worker> Workers { get; set; }
        public DbSet<Brigade> Brigades { get; set; }
        public DbSet<Chief> Chiefs { get; set; }
        public DbSet<WorkerToBrigade> WorkerToBrigades { get; set; }
        public DbSet<RepairService> RepairServices { get; set; }

        public DepotContext() : base("DepotConnection") { }
    }
}
