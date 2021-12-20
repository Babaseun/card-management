using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;
using CardManagement.Domain.Entities;

namespace CardManagement.Domain.Services
{
    public interface ICardService
    {
        Task<IEnumerable<Card>> UploadCards(Stream stream);
    }
}