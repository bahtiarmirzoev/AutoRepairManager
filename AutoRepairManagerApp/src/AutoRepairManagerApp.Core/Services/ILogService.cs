using AutoRepairManagerApp.Core.Models;

namespace AutoRepairManagerApp.Core.Services;
public interface ILogService
{
    Task AddAsync(RepairLog newLog);
}
