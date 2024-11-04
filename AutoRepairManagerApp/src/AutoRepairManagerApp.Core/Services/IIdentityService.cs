using AutoRepairManagerApp.Core.DTO;
using AutoRepairManagerApp.Core.Models;

namespace AutoRepairManagerApp.Core.Services;
public interface IIdentityService
{
    Task<User?> Login(LoginDto loginDto);
    Task<Guid?> Registration(RegistrationDto registrationDto);
    Task<string> GetRole(Guid userId);
    Task DeleteAsync(Guid id);
    Task<IEnumerable<User>?> GetAllAsync();
    Task PromoteAdminAsync(Guid id);
    Task SendRepairOrder(RepairOrder repairOrder);
    Task<User?> GetByIdAsync(Guid userId)
}
