using System.Collections.Generic;
using System.Threading.Tasks;
using CardManagement.Domain.Services;

namespace CardManagement.API.Queries.Account
{
    public class AccountQueries
    {
        private readonly IAccountService _accountService;

        public AccountQueries(IAccountService accountService)
        {
            _accountService = accountService;
        }

        public async Task<IEnumerable<Domain.Entities.Account>> GetAccountsByUserId(string userId, int perPage, int pageNumber)
            => await _accountService.GetAccountsByUserId(userId, pageNumber, perPage);
    }
}