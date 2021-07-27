using ImageServiceApi.Models.Responses;
using ImageServiceApi.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace ImageServiceApi.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class ImageController : ControllerBase
    {
        private readonly IImageService _imageService;
        private readonly ILogger<ImageController> _logger;

        public ImageController(
            IImageService imageService,
            ILogger<ImageController> logger)
        {
            _imageService = imageService;
            _logger = logger;
        }

        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(FileStreamResult))]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(ErrorResponse))]
        [HttpGet("/{id:long}")]
        public async Task<IActionResult> Get(long id, CancellationToken cancellationToken = default)
        {
            try
            {
                var response = await _imageService
                    .GetImageByIdAsync(id, cancellationToken)
                    .ConfigureAwait(false);
                return File(response.ImageStream, response.MimeType, false);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, ex.Message, new object[] { id });
                return BadRequest(new ErrorResponse(ex.Message));
            }
        }

        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(UploadSuccessResponse))]
        [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(ErrorResponse))]
        [HttpPost]
        public async Task<IActionResult> Upload(IFormFile file, CancellationToken cancellationToken = default)
        {
            try
            {
                return Ok(await _imageService.AddFileAsync(file, cancellationToken).ConfigureAwait(false));
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, ex.Message, new object[] { file });
                return BadRequest(new ErrorResponse(ex.Message));
            }
        }

    }
}
