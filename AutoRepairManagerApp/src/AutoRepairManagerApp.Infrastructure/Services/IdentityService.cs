using Microsoft.Extensions.Options;
using AutoRepairManagerApp.Core.DTO;
using AutoRepairManagerApp.Core.Models;
using AutoRepairManagerApp.Core.Repositories;
using AutoRepairManagerApp.Core.Services;
using AutoRepairManagerApp.Core.Models.Relations;

namespace AutoRepairManagerApp.Infrastructure.Services;

public class IdentityService : IIdentityService
{
    private readonly IIdentityRepository identityRepository; 
    private readonly IOptionsSnapshot<string> connectionString;
    public IdentityService(IIdentityRepository identityRepository, IOptionsSnapshot<string> connectionString)
    {
        this.connectionString = connectionString;
        this.identityRepository = identityRepository;
    }
    public async Task DeleteAsync(Guid id)
    {
        await this.identityRepository.DeleteAsync(id);
    }

    public async Task<IEnumerable<User>?> GetAllAsync()
    {
        return await this.identityRepository.GetAllAsync();
    }

    public async Task SendRepairOrder(RepairOrder repairOrder){
        await this.identityRepository.SendRepairOrder(repairOrder);
    }

    public async Task<User?> GetByIdAsync(Guid userId){
        return await this.identityRepository.GetByIdAsync(userId);
    }

    public Task<User?> Login(LoginDto loginDto)
    {
        return this.identityRepository.Login(loginDto);
    }

    public Task<Guid?> Registration(RegistrationDto registrationDto)
    {
        return this.identityRepository.Registration(registrationDto);
    }

    Task<UserRole> IIdentityService.GetRole(Guid userId)
    {
        throw new NotImplementedException();
    }

    public Task PromoteAdminAsync(Guid id)
    {
        throw new NotImplementedException();
    }


    // public async Task<bool> ConfirmEmailAsync(Guid userId, string code)
    // {
    //     var user = await identityRepository.GetByIdAsync(userId);
    //     if (user == null)
    //     {
    //         return false;
    //     }
    //     return await identityRepository.ConfirmEmailAsync(user, code);
    // }
}