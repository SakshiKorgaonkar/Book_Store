using Commands.User;
using MediatR;
using Microsoft.IdentityModel.Tokens;
using Model_Layer;
using Repository_Layer.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Handlers.User
{
    public class LoginHandler : IRequestHandler<LoginRequest, string>
    {
        private readonly IUserRL userRL;

        public LoginHandler(IUserRL userRL)
        {
            this.userRL = userRL;
        }

        public async Task<string> Handle(LoginRequest request, CancellationToken cancellationToken)
        {
            var result = new LoginML
            {
                Email = request.Email,
                Password = request.Password,
            };
            return await userRL.LoginUser(result);
        }
    }
}
