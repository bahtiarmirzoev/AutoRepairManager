using AutoRepairManagerApp.Core.Models;
using AutoRepairManagerApp.Core.Repositories;
using AutoRepairManagerApp.Infrastructure.Repositories.EfCore.DbContexts;

namespace AutoRepairManagerApp.Infrastructure.Repositories.EfCore;

public class LogEfCoreRepository : ILogRepository
{
    private readonly AutoRepairDbContext dbContext;
    public LogEfCoreRepository(AutoRepairDbContext dbContext)
    {
        this.dbContext = dbContext;
    }

    public async Task AddAsync(RepairLog newLog)
    {
        await dbContext.RepairLogs.AddAsync(newLog);
        await dbContext.SaveChangesAsync();
    }
}