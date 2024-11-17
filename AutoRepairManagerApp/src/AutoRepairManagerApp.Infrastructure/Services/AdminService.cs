using Microsoft.Extensions.Options;
using AutoRepairManagerApp.Core.Models;
using AutoRepairManagerApp.Core.Repositories;
using AutoRepairManagerApp.Core.Services;

namespace AutoRepairManagerApp.Infrastructure.Services;

public class AdminService : IAdminService
{
    private readonly IAdminRepository adminRepository; 
    private readonly IOptionsSnapshot<string> connectionString;
    public AdminService(IAdminRepository adminRepository, IOptionsSnapshot<string> connectionString)
    {
        this.connectionString = connectionString;
        this.adminRepository = adminRepository;
    }


    public Task<IEnumerable<User>?> GetAllUsersAsync()
    {
        return this.adminRepository.GetAllUsersAsync();
    }

    public Task<IEnumerable<RepairOrder>?> GetAllRepairOrdersAsync()
    {
        return this.adminRepository.GetAllRepairOrdersAsync();
    }

    public Task<IEnumerable<RepairLog>?> GetAllRepairLogsAsync()
    {
        throw new NotImplementedException();
    }
    public async Task MakeRepairOrderNotDoneAsync(Guid id){
        await this.adminRepository.MakeRepairOrderNotDoneAsync(id);
    }
    public async Task MakeRepairOrderInProcessAsync(Guid id){
        await this.adminRepository.MakeRepairOrderInProcessAsync(id);
    }
    public async Task MakeRepairOrderDoneAsync(Guid id){
        await this.adminRepository.MakeRepairOrderDoneAsync(id);
    }

    public Task DeleteUser(Guid id)
    {
        throw new NotImplementedException();
    }

    public Task DeleteRepairLog(Guid id)
    {
        throw new NotImplementedException();
    }

    public Task DeleteRepairOrder(Guid id)
    {
        throw new NotImplementedException();
    }
    
    public Task DeleteAutoRepair(Guid id)
    {
        throw new NotImplementedException();
    }
}