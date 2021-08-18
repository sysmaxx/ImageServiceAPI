using System;
using System.Collections.Generic;
using System.Net;

namespace ImageServiceApi.Builders
{
    public interface IApiExceptionBuilderThrowableStage<TException>
    {
        TException Build();
        void Throw();
        IApiExceptionBuilderThrowableStage<TException> WithMessage(string msg);
        IApiExceptionBuilderThrowableStage<TException> WithErrors(IEnumerable<string> errors);
        IApiExceptionBuilderThrowableStage<TException> WithStatusCode(HttpStatusCode statusCode);
        IApiExceptionBuilderThrowableStage<TException> WithError(string error);
    }
}
