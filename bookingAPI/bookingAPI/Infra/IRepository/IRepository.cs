using bookingAPI.Data.DomainObjects;

namespace bookingAPI.Data.Repository
{
    public interface IRepository<TEntity> : IDisposable where TEntity : Entity
    {
        IEnumerable<TEntity> GetAll();
        TEntity GetById(Guid id);
        void Add(TEntity Entity);

        void Update(TEntity entity);

        void Delete(TEntity entity);


    }
}
