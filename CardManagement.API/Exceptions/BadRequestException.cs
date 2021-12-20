using System;

namespace CardManagement.API.Exceptions
{
    public class BadRequestException : Exception
    {
        public string Message { get; }

        public BadRequestException(string message) : base($"Error occured while processing request due to {message}")
            => Message = message;
    }
}