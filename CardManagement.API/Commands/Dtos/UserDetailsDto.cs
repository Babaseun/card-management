using System;

namespace CardManagement.API.Commands.Dtos
{
    public class UserDetailsDto
    {
        public string Id { get; set; }
        public string Firstname { get; set; }
        public string Lastname { get; set; }
        public string Email { get; set; }

        public DateTime CreatedDate { get; set; }
        
    }
}