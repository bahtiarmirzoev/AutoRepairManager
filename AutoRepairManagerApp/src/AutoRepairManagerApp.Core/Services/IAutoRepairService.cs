using AutoRepairManagerApp.Core.Models;
//using AutoRepairManagerApp.Core.DTO;

namespace AutoRepairManagerApp.Core.Services;
public interface IAutoRepairService
{
    Task<IEnumerable<AutoRepair>?> GetAllAsync();
    Task<IEnumerable<AutoRepair>?> GetByNameAsync(string name);
    Task<AutoRepair?> GetByIdAsync(Guid id);
    //IEnumerable<CommentDto>? GetComments(Guid id);
    Task DeleteAsync(Guid id);
    Task AddAsync(AutoRepair newAutoRepair);
}
