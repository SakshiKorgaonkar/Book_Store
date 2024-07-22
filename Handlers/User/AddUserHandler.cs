using Commands.User;
using MediatR;
using Model_Layer;
using Repository_Layer.Entity;
using Repository_Layer.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Handlers.User
{
    public class AddUserHandler : IRequestHandler<AddUserRequest, UserEntity>
    {
        private readonly IUserRL userRL;
        public AddUserHandler(IUserRL userRL)
        {
            this.userRL = userRL;
        }
        public async Task<UserEntity> Handle(AddUserRequest request, CancellationToken cancellationToken)
        {
            var userDetails = new UserML()
            {
                Name = request.Name,
                Email = request.Email,
                Password = request.Password,
                Phone = request.Phone
            };
            return await userRL.RegisterUser(userDetails, request.Role);
        }
    }
}
