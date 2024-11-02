using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutoRepairManager.Models.DTOs
{
    public class RepairHistoryDto
    {
        public Guid Id { get; set; }

        public Guid CarId { get; set; }

        public DateTime RepairDate { get; set; }

        public string Description { get; set; }

        public decimal Cost { get; set; }
    }
}
