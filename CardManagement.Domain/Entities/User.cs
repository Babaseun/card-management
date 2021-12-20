using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Identity;

namespace CardManagement.Domain.Entities
{
    public class User : IdentityUser
    {
        public string Firstname { get; set; }
        public string Lastname { get; set; }
        public DateTime LastLoginTime { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime LastPasswordChangeDate { get; set; }
        public List<Account> Accounts { get; set; }
    }
}