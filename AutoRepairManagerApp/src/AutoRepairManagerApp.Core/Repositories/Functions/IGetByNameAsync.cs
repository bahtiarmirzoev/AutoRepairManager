namespace AutoRepairManagerApp.Core.Repositories.Functions;
public interface IGetByNameAsync<TEntity>
{
    Task<IEnumerable<TEntity>?> GetByNameAsync(string name);
}
