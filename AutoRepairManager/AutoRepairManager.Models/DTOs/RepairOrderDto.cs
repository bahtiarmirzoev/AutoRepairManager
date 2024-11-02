using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutoRepairManager.Models.DTOs
{
    public class RepairOrderDto
    {
        public Guid Id { get; set; }
        public Guid CustomerId { get; set; }
        public Guid CarId { get; set; }
        public Guid ServiceTypeId { get; set; }
        public DateTime OrderDate { get; set; }
        public string Status { get; set; }
    }
}
