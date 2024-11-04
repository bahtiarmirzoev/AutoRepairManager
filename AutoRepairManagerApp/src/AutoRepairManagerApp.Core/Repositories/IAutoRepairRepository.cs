//using AutoRepairManagerApp.Core.DTO;
using AutoRepairManagerApp.Core.Models;
using AutoRepairManagerApp.Core.Repositories.Functions;

namespace AutoRepairManagerApp.Core.Repositories;
public interface IBookRepository : IGetAllAsync<AutoRepair>, IAddAsync<AutoRepair>, IGetByNameAsync<AutoRepair> , IGetByIdAsync<AutoRepair>, IDeleteAsync<AutoRepair> {
    //IEnumerable<CommentDto>? GetComments(Guid id) ;
    
}