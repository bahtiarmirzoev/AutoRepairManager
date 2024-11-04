using AutoRepairManagerApp.Core.DTO;
using AutoRepairManagerApp.Core.Models;
using AutoRepairManagerApp.Core.Models.Relations;
using AutoRepairManagerApp.Core.Repositories.Functions;
//using AutoRepairManagerApp.Core.Resources;

namespace AutoRepairManagerApp.Core.Repositories;
public interface IIdentityRepository : IDeleteAsync<User>, IGetAllAsync<User> { 
    Task<User?> Login(LogInDTO loginDto);
    Task<Guid?> Registration(RegistrationDTO registrationDto);

    Task<UserRole> GetRole(Guid Id);
    Task SendRepairOrder(RepairOrder repairOrder);
    
    Task<User?> GetByIdAsync(Guid userId);

    //Task<bool> ConfirmEmailAsync(User user, string code);
}