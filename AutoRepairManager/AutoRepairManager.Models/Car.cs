using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutoRepairManager.Models
{
    public class Car
    {
        public Guid Id { get; set; } = Guid.NewGuid();

        public string Make { get; set; }

        public string Model { get; set; }

        public string LicensePlate { get; set; }

        public Guid CustomerId { get; set; }

        public Customer Customer { get; set; }

        public ICollection<RepairHistory> RepairHistory { get; set; } = new List<RepairHistory>();
    }
}
