﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LocomotiveDepotBL.Models
{
    public class WorkerToBrigade
    {
        public int Id { get; set; }
        public int BrigadeId { get; set; }
        public Brigade Brigade { get; set; }
        public int WorkerId { get; set; }
        public Worker Worker { get; set; }
    }
}
