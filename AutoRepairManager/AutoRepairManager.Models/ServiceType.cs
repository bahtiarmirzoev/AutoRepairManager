using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutoRepairManager.Models
{
    public class ServiceType
    {
        public Guid Id { get; set; } = Guid.NewGuid();

        public string Name { get; set; }

        public decimal Price { get; set; }  
    }
}
