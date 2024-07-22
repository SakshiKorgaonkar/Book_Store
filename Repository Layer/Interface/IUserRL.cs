using Model_Layer;
using Repository_Layer.Context;
using Repository_Layer.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository_Layer.Interface
{
    public interface IUserRL
    {
        public Task<UserEntity> RegisterUser(UserML userML,string role);
        public Task<string> LoginUser(LoginML loginML);
        public Task<UserEntity> GetById(int id);
        public Task<UserEntity> ResetPassword(string email,string newPassword);
        public Task<string> ForgotPassword(string email);
    }
}
