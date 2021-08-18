using System;
using System.Collections.Generic;

namespace ImageServiceApi.Builders
{
    public interface IApiExceptionBuilderThrowableStage<TException>
    {
        TException Build();
        void Throw();
        IApiExceptionBuilderThrowableStage<TException> WithMessage(string msg);
        IApiExceptionBuilderThrowableStage<TException> WithErrors(IEnumerable<string> errors);
        IApiExceptionBuilderThrowableStage<TException> WithError(string error);
    }
}
