using ImageServiceApi.Persistence.Repositories;
using System.Threading;
using System.Threading.Tasks;

namespace ImageServiceApi.Persistence
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly Context _context;

        public UnitOfWork(Context context)
        {
            _context = context;
            InstantiateRepositories(_context);
        }

        private void InstantiateRepositories(Context context)
        {
            Images = new ImageRepository(context);
        }

        public IImageRepository Images { get; private set; }

        public int Complete() => _context.SaveChanges();

        public async Task<int> CompleteAsync(CancellationToken cancellationToken = default)
            => await _context.SaveChangesAsync(cancellationToken).ConfigureAwait(false);
    }
}
