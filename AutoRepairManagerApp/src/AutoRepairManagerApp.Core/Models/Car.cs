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
    public string? CarPlate { get; set; }
    [Required]
    public ICollection<RepairLog>? RepairHistory { get; set; }
}