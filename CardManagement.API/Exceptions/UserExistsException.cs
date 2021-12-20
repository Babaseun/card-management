using System;

namespace CardManagement.API.Exceptions
{
    public class UserExistsException : Exception
    {
        public string Email { get; }

        public UserExistsException(string email) : base($"User with email '{email}' already registered.")
            => Email = email;
    }
}