using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CardManagement.Domain.Entities;
using CardManagement.Domain.IRepository;
using Microsoft.EntityFrameworkCore;

namespace CardManagement.Data.Repositories
{
    public class TransactionRepository: BaseRepository<Transaction>, ITransactionRepository
    {
        private readonly AppDbContext _ctx;

        public TransactionRepository(AppDbContext ctx) : base(ctx)
        {
            _ctx = ctx;
        }
        public async Task<IEnumerable<Domain.Entities.Transaction>> GetTransactionsByUserId(string userId, int pageNumber ,int perPage)
        {
            var transactions = await _ctx.Transactions.Where(x => x.UserId == userId).Skip((pageNumber - 1) * perPage)
                                     .Take(perPage).ToListAsync();
            return transactions;
        }
        
    }
}