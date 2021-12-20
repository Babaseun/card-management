using System.Collections.Generic;
using CardManagement.API.Commands.Dtos;
using MediatR;
using Microsoft.AspNetCore.Http;

namespace CardManagement.API.Commands.Card.UploadCard
{
    public class UploadCardCommand : IRequest<IEnumerable<Domain.Entities.Card>>
    {
        public IFormFile File { get; set; }
    }
}