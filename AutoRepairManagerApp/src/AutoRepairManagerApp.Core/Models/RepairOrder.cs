using System.ComponentModel.DataAnnotations;
using AutoRepairManagerApp.Core.Enums;

namespace AutoRepairManagerApp.Core.Models;

public class RepairOrder
{
    [Key]
    public Guid Id { get; set; } = Guid.NewGuid();
    [Required]
    public Guid UserId { get; set; }
    [Required]
    public Guid CarId { get; set; }
    [Required]
    public ServiceTypeEnum ServiceType { get; set; }
    [Required]
    public DateTime OrderDate { get; set; }
    [Required]
    public ServiceStatusEnum ServiceStatus { get; set; }
}