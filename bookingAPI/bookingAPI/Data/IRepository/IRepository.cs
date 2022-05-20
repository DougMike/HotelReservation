using bookingAPI.Data.DomainObjects;

namespace bookingAPI.Data.Repository
{
    public interface IRepository<T> : IDisposable where T : Entity
    {
        Task<IEnumerable<T>> GetAll();
        Task<T> GetById(Guid id);
    }
}
