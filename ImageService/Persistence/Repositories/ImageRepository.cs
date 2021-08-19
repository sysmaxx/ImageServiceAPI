using EntityRepositoryLibrary;
using ImageServiceApi.Models;
using Microsoft.EntityFrameworkCore;

namespace ImageServiceApi.Persistence.Repositories
{
    public class ImageRepository : Repository<ImageData>, IImageRepository
    {
        public ImageRepository(DbContext context) : base(context)
        {
        }
    }
}
