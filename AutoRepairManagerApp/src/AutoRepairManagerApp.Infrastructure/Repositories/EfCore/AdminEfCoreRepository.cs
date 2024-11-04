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

    public async Task RejectUserRequest(Guid requestId)
    {

        var userRequest = dbContext.RepairOrders.Find(requestId);
        if (userRequest != null)
        {
            dbContext.RepairOrders.Remove(userRequest);
            await dbContext.SaveChangesAsync();
        }
    }

    public async Task<IEnumerable<RepairOrder>?> GetAllUserRequestsAsync()
    {
        return dbContext.RepairOrders;
    }

    public Task<IEnumerable<RepairOrder>?> GetAllUserOrdersAsync()
    {
        throw new NotImplementedException();
    }
}