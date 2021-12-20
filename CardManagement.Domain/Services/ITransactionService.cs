using System.Collections.Generic;
using System.Threading.Tasks;
using CardManagement.Domain.Entities;

namespace CardManagement.Domain.Services
{
    public interface ITransactionService
    {
        Task<Transaction> SaveTransaction(Transaction transaction);
        Task<IEnumerable<Transaction>> GetTransactionsByUserId(string userId, int pageNumber, int perPage);
    }
}