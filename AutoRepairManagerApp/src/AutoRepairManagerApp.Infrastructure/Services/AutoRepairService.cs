
using AutoRepairManagerApp.Core.DTO;
using AutoRepairManagerApp.Core.Models;
using AutoRepairManagerApp.Core.Repositories;
using AutoRepairManagerApp.Core.Services;

namespace AutoRepairManagerApp.Infrastructure.Services;

public class AutoRepairService : IAutoRepairService
{
    private readonly IAutoRepairRepository autoRepairRepository; 
    //private readonly IOptionsSnapshot<string> connectionString;
    public AutoRepairService(IAutoRepairRepository autoRepairRepository)//, IOptionsSnapshot<string> connectionString)
    {
        //this.connectionString = connectionString;
        this.autoRepairRepository = autoRepairRepository;
    }
    public async Task AddAsync(AutoRepair newAutoRepair)
    {
        await this.autoRepairRepository.AddAsync(newAutoRepair);
    }

    public async Task DeleteAsync(Guid id)
    {
        await this.autoRepairRepository.DeleteAsync(id);
    }

    public async Task<IEnumerable<AutoRepair>?> GetAllAsync()
    {
        return await this.autoRepairRepository.GetAllAsync();
    }

    public async Task<AutoRepair?> GetByIdAsync(Guid id)
    {
        return await this.autoRepairRepository.GetByIdAsync(id);
    }

    public async Task<IEnumerable<AutoRepair>?> GetByNameAsync(string name)
    {
        return await this.autoRepairRepository.GetByNameAsync(name);
    }
}