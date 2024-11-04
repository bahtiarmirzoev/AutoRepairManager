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

    public Task DeleteAutoRepair(Guid id)
    {
        throw new NotImplementedException();
    }

    public Task DeleteUser(Guid id)
    {
        throw new NotImplementedException();
    }

    public Task<IEnumerable<User>?> GetAllUsersAsync()
    {
        throw new NotImplementedException();
    }

    public Task<IEnumerable<RepairOrder>?> GetAllRepairOrdersAsync()
    {
        throw new NotImplementedException();
    }

    public Task<IEnumerable<RepairLog>?> GetAllRepairLogsAsync()
    {
        throw new NotImplementedException();
    }
}