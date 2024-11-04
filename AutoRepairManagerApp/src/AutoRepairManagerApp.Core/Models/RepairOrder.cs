using AutoRepairManagerApp.Core.Enums;

namespace AutoRepairManagerApp.Core.Models;

public class RepairOrder
{
    public Guid Id { get; set; } = Guid.NewGuid();
    public Guid UserId { get; set; }
    public Guid CarId { get; set; }
    public ServiceTypeEnum ServiceType { get; set; }
    public DateTime OrderDate { get; set; }
    public ServiceStatusEnum ServiceStatus { get; set; }
}