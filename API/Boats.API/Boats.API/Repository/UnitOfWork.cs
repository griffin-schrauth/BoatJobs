using Boats.API.Data;
using Boats.API.IRepository;

namespace Boats.API.Repository
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly BoatsDbContext _context;

        private IGenericRepository<Boat> _boats; 
        public UnitOfWork(BoatsDbContext context)
        {
            _context = context;   
        }
        public IGenericRepository<Boat> Boats => _boats ??= new GenericRepository<Boat>(_context);

        public void Dispose()
        {
            _context.Dispose();
            GC.SuppressFinalize(this);
        }

        public async Task Save()
        {
            await _context.SaveChangesAsync();
        }
    }
}
