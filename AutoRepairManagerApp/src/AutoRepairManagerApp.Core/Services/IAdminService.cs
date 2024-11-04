using AutoRepairManagerApp.Core.Models;

namespace AutoRepairManagerApp.Core.Services;
public interface IAdminService
{
    Task<IEnumerable<User>?> GetAllUsersAsync();
    Task DeleteUser(Guid id);
    Task DeleteAutoRepair(Guid id);
    //Task DeleteComment(Guid id);
    
    Task<IEnumerable<RepairOrder>?> GetAllRepairOrdersAsync();
    Task<IEnumerable<RepairLog>?> GetAllRepairLogsAsync();
    //Task AcceptUserRequest(Guid requestId);
    //Task RejectUserRequest(Guid requestId);
}
