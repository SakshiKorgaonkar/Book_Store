using MediatR;
using Repository_Layer.Entity;

namespace Book_Store.Controllers
{
    public class ResetPasswordRequest : IRequest<UserEntity>
    {
        public ResetPasswordRequest(string email, string newPassword)
        {
            Email = email;
            NewPassword = newPassword;
        }

        public string Email { get; set; }
        public string NewPassword { get; set; }
    }
}