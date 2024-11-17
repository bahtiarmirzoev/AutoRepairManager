using AutoRepairManagerApp.Core.DTO;
using AutoRepairManagerApp.Core.Models;
using AutoRepairManagerApp.Core.Models.Relations;

namespace AutoRepairManagerApp.Core.Services;
public interface IIdentityService
{
    Task<User?> Login(LogInDTO loginDto);
    Task<Guid?> Registration(RegistrationDTO registrationDto);
    Task<UserRole> GetRole(Guid userId);
    Task<IEnumerable<User>?> GetAllAsync();
    Task PromoteAdminAsync(Guid id);
    Task SendRepairOrder(RepairOrder repairOrder);
    Task<User?> GetByIdAsync(Guid userId);
}
