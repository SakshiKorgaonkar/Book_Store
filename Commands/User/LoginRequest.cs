using MediatR;
using Model_Layer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Commands.User
{
    public class LoginRequest : IRequest<string>
    {
        public string Email { get; set; }
        public string Password { get; set; }

        public LoginRequest(string email, string password)
        {
            Email = email;
            Password = password;
        }
    }
}
