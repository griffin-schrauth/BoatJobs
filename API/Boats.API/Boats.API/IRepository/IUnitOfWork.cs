using Boats.API.Data;

namespace Boats.API.IRepository
{
    public interface IUnitOfWork : IDisposable
    {
        IGenericRepository<Boat> Boats { get; }

        Task Save();
    }
}
