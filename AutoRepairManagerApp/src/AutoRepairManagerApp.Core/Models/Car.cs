using System.ComponentModel.DataAnnotations;

namespace AutoRepairManagerApp.Core.Models;

public class Car
{
    [Key]
    public Guid Id { get; set; } = Guid.NewGuid();
    [Required]
    public string? Make { get; set; }
    [Required]
    public string? Model { get; set; }
    [Required]
    [RegularExpression(@"^\d{2}-\d{2}-\d{3}$", ErrorMessage = "Invalid car plate format. It should be in the format 00-AA-000.")]
    [StringLength(7, MinimumLength = 7, ErrorMessage = "Car plate must be 7 characters!")]
    public string? PlateNumber { get; set; }
    [Required]
    public ICollection<RepairLog>? RepairHistory { get; set; }
}