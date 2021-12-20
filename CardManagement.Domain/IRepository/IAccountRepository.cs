using System.Collections.Generic;
using System.Threading.Tasks;
using CardManagement.Domain.Entities;

namespace CardManagement.Domain.IRepository
{
    public interface IAccountRepository : IRepository<Account>
    {
        Task<IEnumerable<Account>> GetAccountsByUserId(string userId, int pageNumber, int perPage);
    }
}