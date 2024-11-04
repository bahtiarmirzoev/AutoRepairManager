using AutoRepairManagerApp.Core.DTO;
using AutoRepairManagerApp.Core.Models;
using AutoRepairManagerApp.Core.Models.Relations;

namespace AutoRepairManagerApp.Core.Services;
public interface IIdentityService
{
    Task<User?> Login(LoginDto loginDto);
    Task<Guid?> Registration(RegistrationDto registrationDto);
    Task<UserRole> GetRole(Guid userId);
    Task DeleteAsync(Guid id);
    Task<IEnumerable<User>?> GetAllAsync();
    Task PromoteAdminAsync(Guid id);
    Task SendRepairOrder(RepairOrder repairOrder);
    Task<User?> GetByIdAsync(Guid userId);
}
