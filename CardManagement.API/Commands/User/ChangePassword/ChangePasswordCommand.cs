using MediatR;

namespace CardManagement.API.Commands.User.ChangePassword
{
	public class ChangePasswordCommand : IRequest<bool>
	{
		public string ConfirmNewPassword { get; set; }

		public string CurrentPassword { get; set; }

		public string UserId { get; set; }

		public string NewPassword { get; set; }
	}
}