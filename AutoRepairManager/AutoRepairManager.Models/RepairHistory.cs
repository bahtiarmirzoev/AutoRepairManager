using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutoRepairManager.Models
{
    public class RepairHistory
    {
        public Guid Id { get; set; } = Guid.NewGuid();

        public Guid CarId { get; set; }

        public Car Car { get; set; }

        public DateTime RepairDate { get; set; }

        public string Description { get; set; }

        public decimal Cost { get; set; }
    }
}
