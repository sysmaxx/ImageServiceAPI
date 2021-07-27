using ImageServiceApi.Models.Responses;
using Microsoft.AspNetCore.Http;
using System.Threading;
using System.Threading.Tasks;

namespace ImageServiceApi.Services
{
    public interface IImageService
    {
        Task<UploadSuccessResponse> AddFileAsync(IFormFile file, CancellationToken cancellationToken = default);
        Task<ImageResponse> GetImageByIdAsync(long id, CancellationToken cancellationToken = default);
    }
}
