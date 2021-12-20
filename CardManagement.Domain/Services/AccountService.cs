using System.Collections.Generic;
using System.Threading.Tasks;
using CardManagement.Domain.Entities;
using CardManagement.Domain.Response;
using CardManagement.Domain.IRepository;

namespace CardManagement.Domain.Services
{
    public class AccountService : IAccountService
    {
        private readonly IAccountRepository _accountRepository;

        public AccountService(IAccountRepository accountRepository)
        {
            _accountRepository = accountRepository;
        }

        public async Task<IEnumerable<Account>> GetAccountsByUserId(string userId, int pageNumber, int perPage)
        {
            var accounts = await _accountRepository.GetAccountsByUserId(userId,pageNumber,perPage);
            return accounts;
        }

        public async Task<Account> CreateAccount(Account account)
        {

            await _accountRepository.Save(account);

           

            return account;
        }
    }
}