using Microsoft.Extensions.Options;
using AutoRepairManagerApp.Core.Models;
using AutoRepairManagerApp.Core.Repositories;
using AutoRepairManagerApp.Core.Services;

namespace AutoRepairManagerApp.Infrastructure.Services;

public class LogService : ILogService
{
    private readonly ILogRepository logRepository; 
    private readonly IOptionsSnapshot<string> connectionString;
    public LogService(ILogRepository logRepository, IOptionsSnapshot<string> connectionString)
    {
        this.connectionString = connectionString;
        this.logRepository = logRepository;
    }

    public Task AddAsync(RepairLog newLog)
    {
        throw new NotImplementedException();
    }
}