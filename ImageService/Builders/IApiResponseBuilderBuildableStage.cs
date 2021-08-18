using ImageServiceApi.Models.Responses;
using System.Collections.Generic;

namespace ImageServiceApi.Builders
{
    public interface IApiResponseBuilderBuildableStage<TData> where TData : class
    {
        ApiResponse<TData> Build();
        IApiResponseBuilderBuildableStage<TData> IsSucceeded(bool succeeded = true);
        IApiResponseBuilderBuildableStage<TData> WithData(TData data);
        IApiResponseBuilderBuildableStage<TData> WithError(string error);
        IApiResponseBuilderBuildableStage<TData> WithErrors(IEnumerable<string> errors);
        IApiResponseBuilderBuildableStage<TData> WithMessage(string message);
    }
}