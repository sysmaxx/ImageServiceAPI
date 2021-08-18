using ImageServiceApi.Builders;
using ImageServiceApi.Configurations.Models;
using ImageServiceApi.Exceptions;
using ImageServiceApi.Models;
using ImageServiceApi.Models.Responses;
using ImageServiceApi.Persistence;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Options;
using System;
using System.IO;
using System.Linq;
using System.Net;
using System.Threading;
using System.Threading.Tasks;
using static ImageServiceApi.Utility.HashUtility;

namespace ImageServiceApi.Services
{
    public class ImageService : IImageService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IOptions<ImageServiceConfiguration> _options;

        public ImageService(
            IUnitOfWork unitOfWork, 
            IOptions<ImageServiceConfiguration> options)
        {
            _unitOfWork = unitOfWork;
            _options = options;
        }

        public async Task<ApiResponse<UploadResponse>> AddFileAsync(IFormFile file, CancellationToken cancellationToken = default)
        {
            if (file is null || file.Length < 1)
            {
                ApiExceptionBuilder<ImageNullReferenceException>
                    .Create()
                    .WithMessage("Adding image failed")
                    .WithError($"{nameof(file)} can not be null or empty")
                    .Throw();
            }

            if (!_options.Value.SupportedMimeTypes.Contains(file.ContentType))
            {
                ApiExceptionBuilder<MimeTypeNotSupportedException>
                    .Create()
                    .WithMessage("Adding image failed")
                    .WithError($"Type: {file.ContentType} not supported")
                    .Throw();
            }

            var fileStream = file.OpenReadStream();
            var checksum =  GetHashFromStream(fileStream);
            var filePath = Path.Combine(_options.Value.DefaultPath, checksum);

            await WriteFileIfNotExistsAsync(file, filePath, cancellationToken).ConfigureAwait(false);

            var image = new Image { Name = file.FileName, PhysicalDirectory = _options.Value.DefaultPath, MimeType = file.ContentType, PhysicalFileName = checksum };
            await _unitOfWork.Images.AddAsync(image, cancellationToken).ConfigureAwait(false);
            await _unitOfWork.CompleteAsync(cancellationToken).ConfigureAwait(false);

            return ApiResponseBuilder<UploadResponse>
                .Create()
                .WithData(new UploadResponse(image.Id))
                .IsSucceeded()
                .Build();
        }

        public async Task<ApiResponse<ImageResponse>> GetImageByIdAsync(long id, CancellationToken cancellationToken = default)
        {
            var image = await _unitOfWork.Images
                .GetAsync(id, cancellationToken)
                .ConfigureAwait(false);

            if (image is null)
            {
                ApiExceptionBuilder<ImageNotFoundException>
                    .Create()
                    .WithMessage("Getting Image failed")
                    .WithError($"Image with Id: {id} not found")
                    .WithStatusCode(HttpStatusCode.NotFound)
                    .Throw();
            }

            var path = Path.Combine(image.PhysicalDirectory, image.PhysicalFileName);

            if (!File.Exists(path))
            {
                ApiExceptionBuilder<ImageNotFoundException>
                    .Create()
                    .WithMessage("Getting Image failed")
                    .WithError($"Image with Id: {id} not found localy")
                    .WithStatusCode(HttpStatusCode.NotFound)
                    .Throw();
            }

            return ApiResponseBuilder<ImageResponse>
                .Create()
                .WithData(new ImageResponse
                {
                    ImageStream = GetFileStream(path),
                    MimeType = image.MimeType,
                    Name = image.Name
                })
                .IsSucceeded()
                .Build();
        }

        private FileStream GetFileStream(string path) => new(path, FileMode.Open, FileAccess.Read, FileShare.Read, _options.Value.BufferSize, FileOptions.Asynchronous | FileOptions.SequentialScan);

        private static async Task WriteFileIfNotExistsAsync(IFormFile file, string filePath, CancellationToken cancellationToken = default)
        {
            if (!File.Exists(@filePath))
            {
                using Stream outStream = File.OpenWrite(@filePath);
                await file.CopyToAsync(outStream, cancellationToken).ConfigureAwait(false);
            }
        }
    }
}
