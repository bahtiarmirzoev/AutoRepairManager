using System.ComponentModel.DataAnnotations;

namespace AutoRepairManagerApp.Core.Models;
public class RepairLog
{
    [Key]
    public Guid Id { get; set; } = Guid.NewGuid();
    [Required]
    public Guid CarId { get; set; }
    [Required]
    public DateTime RepairDate { get; set; }
    [Required]
    public string? Description { get; set; }
    [Required]
    public float Cost { get; set; }
}