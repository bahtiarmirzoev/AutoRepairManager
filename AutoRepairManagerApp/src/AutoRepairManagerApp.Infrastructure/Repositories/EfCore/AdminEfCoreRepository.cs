using AutoRepairManagerApp.Core.Models;
using AutoRepairManagerApp.Core.Repositories;
using AutoRepairManagerApp.Infrastructure.Repositories.EfCore.DbContexts;

namespace AutoRepairManagerApp.Infrastructure.Repositories.EfCore;

public class AdminEfCoreRepository : IAdminRepository
{
    private readonly AutoRepairDbContext dbContext;

    public AdminEfCoreRepository()
    {
    }

    public AdminEfCoreRepository(AutoRepairDbContext dbContext)
    {
        this.dbContext = dbContext;
    }

    public Task DeleteAsync(Guid entity)
    {
        throw new NotImplementedException();
    }


    public async Task<IEnumerable<RepairOrder>?> GetAllRepairOrdersAsync()
    {
        return dbContext.RepairOrders;
    }

    public Task<IEnumerable<RepairOrder>?> GetAllUserOrdersAsync()
    {
        throw new NotImplementedException();
    }
}