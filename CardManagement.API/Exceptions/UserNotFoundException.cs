using System;

namespace CardManagement.API.Exceptions
{
    public class UserNotFoundException : Exception
    {
        public  string Message { get; }

        public UserNotFoundException(string message) : base($"User with email '{message}' is not registered.")
            => Message = message;
    }
}