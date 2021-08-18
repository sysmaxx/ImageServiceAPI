using System;
using System.Collections.Generic;
using System.Net;

namespace ImageServiceApi.Exceptions
{
    public class ApiException : Exception
    {
        public IEnumerable<string> Errors { get; set; }
        public int? StatusCode { get; set; } = (int)HttpStatusCode.BadRequest;

        public ApiException() { }
        public ApiException(string message) : base(message) { }
        public ApiException(string message, IEnumerable<string> errors) : base(message)
        {
            Errors = errors;
        }
        public ApiException(string message, string error) : base(message)
        {
            Errors = new List<string> { error };
        }
    }
}
