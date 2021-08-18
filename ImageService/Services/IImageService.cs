using ImageServiceApi.Models.Responses;
using Microsoft.AspNetCore.Http;
using System.Threading;
using System.Threading.Tasks;

namespace ImageServiceApi.Services
{
    public interface IImageService
    {
        Task<ApiResponse<UploadResponse>> AddFileAsync(IFormFile file, CancellationToken cancellationToken = default);
        Task<ApiResponse<ImageResponse>> GetImageByIdAsync(long id, CancellationToken cancellationToken = default);
    }
}
