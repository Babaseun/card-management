using System.Collections.Generic;
using System.Threading.Tasks;
using CardManagement.Domain.Entities;
using CardManagement.Domain.Response;

namespace CardManagement.Domain.Services
{
    public interface IAccountService
    {
        Task<Account> CreateAccount(Account account);
        Task<IEnumerable<Account>> GetAccountsByUserId(string userId, int pageNumber, int perPage);
    }
}