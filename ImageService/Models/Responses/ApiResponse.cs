using System.Collections.Generic;

namespace ImageServiceApi.Models.Responses
{
    public class ApiResponse<TResponse> where TResponse : class
    {
        public bool Succeeded { get; set; } = false;
        public string Message { get; set; }
        public TResponse Data { get; set; }
        public IEnumerable<string> Errors { get; set; }

        public ApiResponse(TResponse data, string message = null, IEnumerable<string> errors = null, bool succeeded = true)
        {
            Succeeded = succeeded;
            Message = message;
            Data = data;
            Errors = errors;
        }

        public ApiResponse(string message)
        {
            Message = message;
        }

        public ApiResponse()
        {

        }

    }
}
