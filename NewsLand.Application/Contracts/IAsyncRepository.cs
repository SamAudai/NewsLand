namespace NewsLand.Application.Contracts
{
    public interface IAsyncRepository<TEntity> where TEntity : class
    {
        Task<TEntity> CreateAsync(TEntity entity);
        Task UpdateAsync(TEntity entity); 
        Task DeleteAsync(TEntity entity);
        Task<TEntity> GetByIdAsync(Guid id);
        Task<IReadOnlyList<TEntity>> GetAllAsync();
    }
}
