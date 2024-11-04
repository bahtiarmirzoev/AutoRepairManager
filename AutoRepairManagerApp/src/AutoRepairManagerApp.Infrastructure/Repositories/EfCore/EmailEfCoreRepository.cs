using AutoRepairManagerApp.Core.Models;
using AutoRepairManagerApp.Core.Repositories;
using AutoRepairManagerApp.Infrastructure.Repositories.EfCore.DbContexts;

namespace AutoRepairManagerApp.Infrastructure.Repositories.EfCore;

public class EmailEfCoreRepository : IEmailRepository
{
    private readonly AutoRepairDbContext dbContext;

    public EmailEfCoreRepository(AutoRepairDbContext dbContext)
    {
        this.dbContext = dbContext;
    }

    public async Task VerifyEmail(Guid userId)
    {
        var user = await dbContext.Users.FindAsync(userId);
        if (user != null)
        {
            dbContext.Users.FirstOrDefault(c => c.Id == userId).EmailVerified = true;
            await dbContext.SaveChangesAsync();
        }
    }
}