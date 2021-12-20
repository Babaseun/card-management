using CardManagement.Domain.Entities;
using CardManagement.Domain.IRepository;

namespace CardManagement.Data.Repositories
{
    public class CardRepository : BaseRepository<Card>, ICardRepository
    {
        public CardRepository(AppDbContext ctx) : base(ctx)
        {
        }
    }
}