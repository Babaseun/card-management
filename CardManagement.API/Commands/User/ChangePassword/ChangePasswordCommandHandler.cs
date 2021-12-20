using System.Threading;
using System.Threading.Tasks;
using MediatR;
using Microsoft.AspNetCore.Identity;

namespace CardManagement.API.Commands.User.ChangePassword
{
	public class ChangePasswordCommandHandler : IRequestHandler<ChangePasswordCommand,bool>
	{
		private readonly UserManager<Domain.Entities.User> _userManager;

		public ChangePasswordCommandHandler(UserManager<Domain.Entities.User> userManager)
		{
			_userManager = userManager;
		}
		

		public async Task<bool> ChangePassword(string userId, string currentPassword, string newPassword)
		{
			var user = await _userManager.FindByIdAsync(userId);

			if (user is null)
			{
				return false;
			}

			var result = await _userManager.ChangePasswordAsync(user, currentPassword, newPassword);

			if (!result.Succeeded)
			{
				return false;
			}

			return result.Succeeded;
		}

		public async Task<bool> Handle(ChangePasswordCommand command, CancellationToken cancellationToken)
		{
			return await ChangePassword(command.UserId, command.CurrentPassword, command.NewPassword);

		}
	}
}