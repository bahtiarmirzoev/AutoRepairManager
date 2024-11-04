using System.ComponentModel.DataAnnotations;

namespace AutoRepairManagerApp.Core.Models;

public class User
{
    [Key]
    public Guid Id { get; set; } = Guid.NewGuid();
    [Required]
    [StringLength(50)]
    public string? Name { get; set; }
    [Required]
    [StringLength(50)]
    public string? Surname { get; set; }
    [Required]
    [StringLength(100)]
    public string? Email { get; set; }
    [Required]
    [StringLength(100)]
    public string? Password { get; set; }
    public bool EmailVerified { get; set; }
}