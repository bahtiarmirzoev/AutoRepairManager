using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutoRepairManager.Models
{

    public enum UserRole
    { 
        SuperAdmin,
        Admin, 
        Customer 
    
    }
    public class User
    {
        public Guid Id { get; set; }

        public string Username { get; set; }

        public string PasswordHash { get; set; } // хэширование сделаю потом

        public UserRole Role { get; set; } 
    }
}
