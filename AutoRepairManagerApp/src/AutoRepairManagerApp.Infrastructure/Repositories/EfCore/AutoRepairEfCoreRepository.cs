using Microsoft.EntityFrameworkCore;
using AutoRepairManagerApp.Core.DTO;
using AutoRepairManagerApp.Core.Models;
using AutoRepairManagerApp.Core.Repositories;
using AutoRepairManagerApp.Infrastructure.Repositories.EfCore.DbContexts;

namespace AutoRepairManagerApp.Infrastructure.Repositories.EfCore;

public class AutoRepairEfCoreRepository : IAutoRepairRepository
{
    private readonly AutoRepairDbContext dbContext;
    public AutoRepairEfCoreRepository(AutoRepairDbContext dbContext)
    {
        this.dbContext = dbContext;
    }

    public async Task AddAsync(AutoRepair newAutoRepair)
    {
        await dbContext.AutoRepairs.AddAsync(newAutoRepair);
        await dbContext.SaveChangesAsync();
    }

    public async Task<IEnumerable<AutoRepair>?> GetAllAsync()
    {
        return dbContext.AutoRepairs;
    }

    public async Task<AutoRepair?> GetByIdAsync(Guid id)
    {
        return dbContext.AutoRepairs.FirstOrDefault(book => book.Id == id);
    }

    public async Task<IEnumerable<AutoRepair>?> GetByNameAsync(string name)
    {
        return dbContext.AutoRepairs.Where(book => book.Name == name);
    }

    public async Task DeleteAsync(Guid id)
    {
        var book = await dbContext.AutoRepairs.FindAsync(id);
        if (book != null)
        {
            dbContext.AutoRepairs.Remove(book);
            await dbContext.SaveChangesAsync();
        }
    }

}