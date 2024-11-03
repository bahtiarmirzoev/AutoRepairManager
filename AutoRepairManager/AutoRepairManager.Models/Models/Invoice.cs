using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutoRepairManager.Models.Models
{
    public class Invoice
    {
        public Guid Id { get; set; } = Guid.NewGuid();

        public Guid CustomerId { get; set; }

        public Guid RepairOrderId { get; set; }

        public DateTime InvoiceDate { get; set; } = DateTime.UtcNow;

        public decimal Amount { get; set; }

        public string InvoiceStatus { get; set; }

        public Customer Customer { get; set; }

        public RepairOrder RepairOrder { get; set; }

    }
}
