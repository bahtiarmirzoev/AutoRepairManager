using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutoRepairManager.Models
{
    public class Customer
    {
        public Guid Id { get; set; } = Guid.NewGuid();

        public string Username { get; set; }

        public string Name { get; set; }

        public string Surname { get; set; }

        public string Email { get; set; }

        public string Phone { get; set; }

        public ICollection<Car> Cars { get; set; } = new List<Car>();

        public ICollection<RepairHistory> RepairHistory { get; set; } = new List<RepairHistory>();
    }
}
