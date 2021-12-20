using System.Collections.Generic;
using System.Threading.Tasks;
using CardManagement.Domain.Entities;
using CardManagement.Domain.IRepository;

namespace CardManagement.Domain.Services
{
    public class TransactionService : ITransactionService
    {
        private readonly ITransactionRepository _transactionRepository;

        public TransactionService(ITransactionRepository transactionRepository)
        {
            _transactionRepository = transactionRepository;
        }
        public async Task<Transaction> SaveTransaction(Transaction transaction)
        {
            await _transactionRepository.Save(transaction);
            return transaction;
        }

        public async Task<IEnumerable<Transaction>> GetTransactionsByUserId(string userId, int pageNumber, int perPage)
        {
            var transactions = await _transactionRepository.GetTransactionsByUserId(userId,
                pageNumber, perPage);

            return transactions;
        }
    }
}