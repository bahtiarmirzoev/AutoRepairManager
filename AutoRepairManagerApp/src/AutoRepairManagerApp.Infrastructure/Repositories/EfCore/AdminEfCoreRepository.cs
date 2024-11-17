using AutoRepairManagerApp.Core.Enums;
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


    public async Task<IEnumerable<RepairOrder>?> GetAllRepairOrdersAsync()
    {
        return dbContext.RepairOrders;
    }
    public async Task<IEnumerable<RepairLog>?> GetAllRepairLogsAsync()
    {
        return dbContext.RepairLogs;
    }

    public async Task<IEnumerable<User>?> GetAllUsersAsync()
    {
        return dbContext.Users;
    }


    public async Task MakeRepairOrderNotDoneAsync(Guid id){
        this.dbContext.RepairOrders.FirstOrDefault(log => log.Id == id).ServiceStatus = ServiceStatusEnum.NotDone;
    }

    public async Task MakeRepairOrderInProcessAsync(Guid id){
        this.dbContext.RepairOrders.FirstOrDefault(log => log.Id == id).ServiceStatus = ServiceStatusEnum.InProcess;
    }

    public async Task MakeRepairOrderDoneAsync(Guid id){
        this.dbContext.RepairOrders.FirstOrDefault(log => log.Id == id).ServiceStatus = ServiceStatusEnum.Done;
    }

    public async Task DeleteAutoRepair(Guid id)
    {
        var autoRepair = await dbContext.AutoRepairs.FindAsync(id);
        if (autoRepair != null)
        {
            dbContext.AutoRepairs.Remove(autoRepair);
            await dbContext.SaveChangesAsync();
        }
    }

    public async Task DeleteRepairLog(Guid id)
    {
        var repairLog = await dbContext.RepairLogs.FindAsync(id);
        if (repairLog != null)
        {
            dbContext.RepairLogs.Remove(repairLog);
            await dbContext.SaveChangesAsync();
        }
    }

    public async Task DeleteRepairOrder(Guid id)
    {
        var repairOrder = await dbContext.RepairOrders.FindAsync(id);
        if (repairOrder != null)
        {
            dbContext.RepairOrders.Remove(repairOrder);
            await dbContext.SaveChangesAsync();
        }
    }

    public async Task DeleteUser(Guid id)
    {
        var user = await dbContext.Users.FindAsync(id);
        var userRole = await dbContext.UserRoles.FindAsync(id);
        if (user != null)
        {
            dbContext.Users.Remove(user);
            await dbContext.SaveChangesAsync();
        }
        if (userRole != null)
        {
            dbContext.UserRoles.Remove(userRole);
            await dbContext.SaveChangesAsync();
        }
    }
}