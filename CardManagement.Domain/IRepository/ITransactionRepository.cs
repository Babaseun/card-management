using System.Collections.Generic;
using System.Threading.Tasks;
using CardManagement.Domain.Entities;

namespace CardManagement.Domain.IRepository
{
    public interface ITransactionRepository: IRepository<Transaction>
    {
        Task<IEnumerable<Domain.Entities.Transaction>> GetTransactionsByUserId(string userId,
                                                                               int pageNumber,
                                                                               int perPage);

    }
}