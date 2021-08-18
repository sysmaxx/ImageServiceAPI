using ImageServiceApi.Models.Responses;
using System.Collections.Generic;

namespace ImageServiceApi.Builders
{
    public class ApiResponseBuilder<TData> 
        where TData : class
    {

        private readonly ApiResponse<TData> _response;

        private ApiResponseBuilder() {
            _response = new ApiResponse<TData>();
        }

        public static ApiResponseBuilder<TData> Create()
        {
            return new ApiResponseBuilder<TData>();
        }

        public ApiResponseBuilder<TData> WithMessage(string message)
        {
            _response.Message = message;
            return this;
        }

        public ApiResponseBuilder<TData> WithData(TData data)
        {
            _response.Data = data;
            return this;
        }

        public ApiResponseBuilder<TData> WithErrors(IEnumerable<string> errors)
        {
            _response.Errors = errors;
            return this;
        }

        public ApiResponseBuilder<TData> WithError(string error)
        {
            _response.Errors = new List<string> { error };
            return this;
        }

        public ApiResponseBuilder<TData> IsSucceeded(bool succeeded = true)
        {
            _response.Succeeded = succeeded;
            return this;
        }

        public ApiResponse<TData> Build()
        {
            return _response;
        }
    }
}
