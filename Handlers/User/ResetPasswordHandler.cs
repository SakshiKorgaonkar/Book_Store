using Book_Store.Controllers;
using MediatR;
using Repository_Layer.Entity;
using Repository_Layer.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Handlers.User
{
    public class ResetPasswordHandler:IRequestHandler<ResetPasswordRequest,UserEntity>
    {
        private readonly IUserRL userRL;
        public ResetPasswordHandler(IUserRL userRL)
        {
            this.userRL = userRL;
        }

        public async Task<UserEntity> Handle(ResetPasswordRequest request, CancellationToken cancellationToken)
        {
            return await userRL.ResetPassword(request.Email, request.NewPassword);
        }
    }
}
