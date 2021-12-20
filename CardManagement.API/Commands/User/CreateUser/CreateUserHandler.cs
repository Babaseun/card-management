using AutoMapper;
using CardManagement.API.Commands.Dtos;
using CardManagement.API.Exceptions;
using MediatR;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace CardManagement.API.Commands.User.CreateUser
{
	public class CreateUserHandler : IRequestHandler<CreateUserCommand, UserDetailsDto>
    {
        private readonly IMapper _mapper;
        private readonly UserManager<Domain.Entities.User> _userManager;

        public CreateUserHandler(IMapper mapper,
                                 UserManager<Domain.Entities.User> userManager)
        {
            _mapper = mapper;
            _userManager = userManager;
        }

        public async Task<UserDetailsDto> Handle(CreateUserCommand request,
                                                 CancellationToken cancellationToken)
        {
            var userToAdd = await _userManager.Users.FirstOrDefaultAsync(x => x.Email == request.Email,
                cancellationToken: cancellationToken);

            if (userToAdd != null)
            {
                throw new UserExistsException(request.Email);
            }

            var newUser = _mapper.Map<Domain.Entities.User>(request);
            newUser.CreatedDate = DateTime.Now;
            newUser.LastPasswordChangeDate = DateTime.Now;
            newUser.LastLoginTime = DateTime.Now;
            var result = await _userManager.CreateAsync(newUser, request.Password);
             
            if (!result.Succeeded)
            {
                var message = string.Join(",", result.Errors.Select(s => $"{s.Description}"));
                throw new BadRequestException(message);
            }
            
            await _userManager.AddToRoleAsync(newUser, "User");

            var response = _mapper.Map<UserDetailsDto>(newUser);

            return response;
        }
    }
}