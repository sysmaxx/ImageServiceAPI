using EntityRepositoryLibrary;
using ImageServiceApi.Models;

namespace ImageServiceApi.Persistence.Repositories
{
    public interface IImageRepository : IRepository<ImageData>
    {
    }
}
