using ImageServiceApi.Models.Responses;
using ImageServiceApi.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
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

        public ImageController(
            IImageService imageService
            )
        {
            _imageService = imageService;
        }

        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(ApiResponse<UploadResponse>))]
        [ProducesResponseType(StatusCodes.Status500InternalServerError, Type = typeof(ApiResponse<string>))]
        [HttpPost]
        public async Task<IActionResult> Upload(IFormFile file, CancellationToken cancellationToken = default)
        {
            return Ok(await _imageService.AddFileAsync(file, cancellationToken).ConfigureAwait(false));
        }


        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(FileStreamResult))]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError, Type = typeof(ApiResponse<string>))]
        [HttpGet("/{id:long}")]
        public async Task<IActionResult> Get(long id, CancellationToken cancellationToken = default)
        {
            var response = await _imageService
                .GetImageByIdAsync(id, cancellationToken)
                .ConfigureAwait(false);
            return File(response.Data.ImageStream, response.Data.MimeType, false);
        }

        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(FileStreamResult))]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError, Type = typeof(ApiResponse<string>))]
        [HttpGet("/{id:long}/w{width:int}")]
        public async Task<IActionResult> GetResizedWidth(long id,int width, CancellationToken cancellationToken = default)
        {
            throw new NotImplementedException();
        }

        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(FileStreamResult))]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError, Type = typeof(ApiResponse<string>))]
        [HttpGet("/{id:long}/h{heigth:int}")]
        public async Task<IActionResult> GetResizedHeigth(long id, int heigth, CancellationToken cancellationToken = default)
        {
            throw new NotImplementedException();
        }



    }
}
