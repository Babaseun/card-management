using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using CardManagement.Domain.Entities;
using CardManagement.Domain.IRepository;

namespace CardManagement.Domain.Services
{
    public class CardService : ICardService
    {
        private readonly ICardRepository _cardRepository;
        private readonly ICsvService _csvService;

        public CardService(ICardRepository cardRepository, ICsvService csvService)
        {
            _cardRepository = cardRepository;
            _csvService = csvService;
        }
        public async Task<IEnumerable<Card>> UploadCards(Stream stream)
        {
            var cards = _csvService.ProcessCsvFile(stream);
            await _cardRepository.AddRange(cards);
           return cards;
        }
    }
}