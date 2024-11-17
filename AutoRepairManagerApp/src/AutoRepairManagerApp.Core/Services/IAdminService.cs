using AutoRepairManagerApp.Core.Models;

namespace AutoRepairManagerApp.Core.Services;
public interface IAdminService
{
    Task<IEnumerable<User>?> GetAllUsersAsync();
    Task<IEnumerable<RepairOrder>?> GetAllRepairOrdersAsync();
    Task<IEnumerable<RepairLog>?> GetAllRepairLogsAsync();
    Task DeleteUser(Guid id);
    Task DeleteAutoRepair(Guid id);
    Task DeleteRepairLog(Guid id);
    Task DeleteRepairOrder(Guid id);
    //Task DeleteComment(Guid id);
    
    //Task AcceptUserRequest(Guid requestId);
    //Task RejectUserRequest(Guid requestId);
    
    Task MakeRepairOrderNotDoneAsync(Guid id);
    Task MakeRepairOrderInProcessAsync(Guid id);
    Task MakeRepairOrderDoneAsync(Guid id);
}
