using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutoRepairManager.Models
{
    public class RepairOrder
    {
        public Guid Id { get; set; } = Guid.NewGuid();

        public Guid CustomerId { get; set; }

        public Guid CarId { get; set; }

        public Guid ServiceTypeId { get; set; }

        public DateTime OrderDate { get; set; }

        public string Status {  get; set; }

        public Customer Customer { get; set; }

        public Car Car { get; set; }

        public ServiceType ServiceType { get; set; }


    }
}
