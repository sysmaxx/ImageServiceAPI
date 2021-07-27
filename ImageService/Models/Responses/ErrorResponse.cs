using System;

namespace ImageServiceApi.Models.Responses
{
    public class ErrorResponse
    {
        public string Message { get; set; }
        public ErrorResponse(string message)
        {
            Message = message ?? throw new ArgumentNullException(nameof(message));
        }
    }
}
