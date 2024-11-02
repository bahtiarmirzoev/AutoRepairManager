using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutoRepairManager.Models.DTOs
{
    public class CarDto
    {
        public Guid Id { get; set; }

        public string Make { get; set; }

        public string Model { get; set; }

        public string LicensePlate { get; set; }

        public Guid CustomerId { get; set; }

    }
}
