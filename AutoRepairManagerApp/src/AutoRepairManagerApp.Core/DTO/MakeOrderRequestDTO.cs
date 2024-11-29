using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutoRepairManagerApp.Core.DTO
{
    public class MakeOrderRequestDTO
    {
        public string Name {get; set;}

        public string Phone{get; set;}

        public string TechnicalPassport{ get ; set;}

        public string Make {get ; set; }

        public string Model {get; set;}

        public string ProblemDescription {get ; set;}
    }
}