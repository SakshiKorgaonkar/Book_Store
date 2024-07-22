using MediatR;
using Repository_Layer.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace Commands.User
{
    public class AddUserRequest : IRequest<UserEntity>
    {
        public string Name { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public long Phone { get; set; }
        public string Role { get; set; }

        public AddUserRequest(string name, string email, string password, long phone, string role)
        {
            Name = name;
            Email = email;
            Password = password;
            Phone = phone;
            Role = role;
        }
    }
}
