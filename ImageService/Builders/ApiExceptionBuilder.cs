using ImageServiceApi.Exceptions;
using System;
using System.Collections.Generic;
using System.Reflection;

namespace ImageServiceApi.Builders
{
    public class ApiExceptionBuilder<TException>  : IApiExceptionBuilderThrowableStage<TException>
        where TException : ApiException
    {

        public IEnumerable<string> Errors { get; private set; }

        private readonly TException _exception;

        private ApiExceptionBuilder() 
        {
            _exception = (TException)Activator.CreateInstance(typeof(TException));
        }

        public static IApiExceptionBuilderThrowableStage<TException> Create()
        {
            return new ApiExceptionBuilder<TException>();
        }

        public IApiExceptionBuilderThrowableStage<TException> WithMessage(string message)
        {
            var flags = BindingFlags.Instance | BindingFlags.NonPublic;
            _exception.GetType().GetField("_message", flags).SetValue(_exception, message);
            return this;
        }

        public IApiExceptionBuilderThrowableStage<TException> WithErrors(IEnumerable<string> errors)
        {
            _exception.Errors = errors;
            return this;
        }

        public IApiExceptionBuilderThrowableStage<TException> WithError(string error)
        {
            return WithErrors(new List<string> { error });
        }

        public TException Build()
        {
            return _exception;
        }

        public void Throw()
        {
            throw _exception;
        }


    }
}
