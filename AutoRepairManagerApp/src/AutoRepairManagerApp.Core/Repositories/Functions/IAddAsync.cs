namespace AutoRepairManagerApp.Core.Repositories.Functions;
public interface IAddAsync<TEntity>
{
    Task AddAsync(TEntity entity);
}
