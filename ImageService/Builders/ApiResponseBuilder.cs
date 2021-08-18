using ImageServiceApi.Models.Responses;
using System.Collections.Generic;

namespace ImageServiceApi.Builders
{
    public class ApiResponseBuilder<TData> : 
        IApiResponseBuilderBuildableStage<TData> 
        where TData : class
    {

        private readonly ApiResponse<TData> _response;

        private ApiResponseBuilder()
        {
            _response = new ApiResponse<TData>();
        }

        public static IApiResponseBuilderBuildableStage<TData> Create()
        {
            return new ApiResponseBuilder<TData>();
        }

        public IApiResponseBuilderBuildableStage<TData> WithMessage(string message)
        {
            _response.Message = message;
            return this;
        }

        public IApiResponseBuilderBuildableStage<TData> WithData(TData data)
        {
            _response.Data = data;
            return this;
        }

        public IApiResponseBuilderBuildableStage<TData> WithErrors(IEnumerable<string> errors)
        {
            _response.Errors = errors;
            return this;
        }

        public IApiResponseBuilderBuildableStage<TData> WithError(string error)
        {
            _response.Errors = new List<string> { error };
            return this;
        }

        public IApiResponseBuilderBuildableStage<TData> IsSucceeded(bool succeeded = true)
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
