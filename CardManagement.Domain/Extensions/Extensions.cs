using CardManagement.Domain.Entities;
using CardManagement.Domain.Response;

namespace CardManagement.Domain.Extensions
{
    public static class Extensions
    {
        public static CardDto CardDto(this Card card)
        {
            return new CardDto()
            {
                CardNumber = card.CardNumber,
                Id = card.Id,
                State = card.State,
                Type = card.Type,
                Valid = card.Valid
            };
        }
        
    }
}