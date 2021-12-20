using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using CardManagement.API.Commands.Dtos;
using CardManagement.Domain.Services;
using MediatR;

namespace CardManagement.API.Commands.Card.UploadCard
{
    public class UploadCardHandler : IRequestHandler<UploadCardCommand, IEnumerable<Domain.Entities.Card>>
    {
        private readonly ICardService _cardService;
        private readonly IMapper _mapper;

        public UploadCardHandler(ICardService cardService, IMapper mapper)
        {
            _cardService = cardService;
            _mapper = mapper;
        }

        public async Task<IEnumerable<Domain.Entities.Card>> Handle(UploadCardCommand request, CancellationToken cancellationToken)
        {
            var stream = request.File.OpenReadStream();
            var response = await _cardService.UploadCards(stream);
            return response;
        }
    }
}