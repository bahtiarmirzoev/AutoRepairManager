using AutoRepairManagerApp.Core.Models;
using AutoRepairManagerApp.Core.Repositories.Functions;

namespace AutoRepairManagerApp.Core.Repositories;
public interface IAdminRepository : IDeleteAsync<User>, IDeleteAsync<RepairLog>, IDeleteAsync<RepairOrder>, IDeleteAsync<AutoRepair> { 
    
    
    Task<IEnumerable<RepairOrder>?> GetAllUserOrdersAsync();
    Task AcceptUserRequest(Guid requestId);
    Task RejectUserRequest(Guid requestId);
}