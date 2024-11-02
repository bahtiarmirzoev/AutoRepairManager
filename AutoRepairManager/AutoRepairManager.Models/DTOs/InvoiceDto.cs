using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutoRepairManager.Models.DTOs
{
    public class InvoiceDto
    {
        public Guid Id { get; set; }

        public Guid CustomerId { get; set; }

        public Guid RepairOrderId { get; set; }

        public DateTime InvoiceDate { get; set; }

        public decimal Amount { get; set; }

        public string InvoiceStatus { get; set; }

    }
}
