using AutoRepairManagerApp.Core.Models;
using AutoRepairManagerApp.Core.Repositories.Functions;

namespace AutoRepairManagerApp.Core.Repositories;
public interface IAdminRepository { 
    
    
    Task<IEnumerable<RepairOrder>?> GetAllRepairOrdersAsync();
    Task<IEnumerable<User>?> GetAllUsersAsync();
    
    Task<IEnumerable<RepairLog>?> GetAllRepairLogsAsync();
    
    Task MakeRepairOrderNotDoneAsync(Guid id);
    Task MakeRepairOrderInProcessAsync(Guid id);
    Task MakeRepairOrderDoneAsync(Guid id);
    
    Task DeleteAutoRepair(Guid id);
    Task DeleteRepairLog(Guid id);
    Task DeleteRepairOrder(Guid id);
    Task DeleteUser(Guid id);
    
}