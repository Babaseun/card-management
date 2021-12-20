using System.Collections.Generic;
using System.Threading.Tasks;

namespace CardManagement.Domain.IRepository
{
    public interface IRepository<T>
    {
        Task<IEnumerable<T>> FindAll();
        Task<T> Find(int? id);
        Task Update(T t);
        Task Save(T t);
        Task Delete(int? id);
        Task<bool> Exist(int? id);
        Task<int> Count();
        Task AddRange(IEnumerable<T> t);
    }
}