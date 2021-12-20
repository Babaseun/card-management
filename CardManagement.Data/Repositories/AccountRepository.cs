using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CardManagement.Domain.Entities;
using CardManagement.Domain.IRepository;
using Microsoft.EntityFrameworkCore;

namespace CardManagement.Data.Repositories
{
    public class AccountRepository : BaseRepository<Account>, IAccountRepository
    {
        private readonly AppDbContext _ctx;

        public AccountRepository(AppDbContext ctx) : base(ctx)
        {
            _ctx = ctx;
        }

        public async Task<IEnumerable<Account>> GetAccountsByUserId(string userId, int pageNumber ,int perPage)
        {
            var accounts = await _ctx.Accounts.Where(x => x.UserId == userId).Skip((pageNumber - 1) * perPage)
                                     .Take(perPage).ToListAsync();
            return accounts;
        }
    }
}