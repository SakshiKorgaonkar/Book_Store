using Book_Store.Controllers;
using MediatR;
using Repository_Layer.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Handlers.User
{
    public class ForgotPasswordHandler:IRequestHandler<ForgotPasswordRequest,string>
    {
        private readonly IUserRL userRL;
        public ForgotPasswordHandler(IUserRL userRL)
        {
            this.userRL = userRL;
        }

        public async Task<string> Handle(ForgotPasswordRequest request, CancellationToken cancellationToken)
        {
            return await userRL.ForgotPassword(request.EmailId);
        }
    }
}
