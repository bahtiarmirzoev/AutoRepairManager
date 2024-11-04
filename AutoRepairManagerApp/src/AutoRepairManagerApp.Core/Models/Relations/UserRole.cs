using System.ComponentModel.DataAnnotations;

namespace AutoRepairManagerApp.Core.Models.Relations;

public class UserRole{
    [Key]
    public Guid UserId { get; set; }
    [Required]
    public int RoleId { get; set; }
}