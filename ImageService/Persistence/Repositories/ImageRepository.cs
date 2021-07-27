using EntityRepositoryLibrary;
using ImageServiceApi.Models;
using Microsoft.EntityFrameworkCore;

namespace ImageServiceApi.Persistence.Repositories
{
    public class ImageRepository : Repository<Image>, IImageRepository
    {
        public ImageRepository(DbContext context) : base(context)
        {
        }
    }
}
