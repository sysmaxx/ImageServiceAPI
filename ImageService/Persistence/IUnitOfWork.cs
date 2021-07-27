using ImageServiceApi.Persistence.Repositories;
using System.Threading;
using System.Threading.Tasks;

namespace ImageServiceApi.Persistence
{
    public interface IUnitOfWork
    {

        IImageRepository Images { get; }

        int Complete();
        Task<int> CompleteAsync(CancellationToken cancellationToken = default);
    }
}
