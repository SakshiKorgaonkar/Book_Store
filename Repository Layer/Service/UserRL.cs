using Model_Layer;
using Repository_Layer.Context;
using Repository_Layer.Custom_Exception;
using Repository_Layer.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Security;
using System.Text;
using System.Threading.Tasks;
using System.Security.Cryptography;
using Repository_Layer.Utility;
using Microsoft.EntityFrameworkCore;
using Repository_Layer.Entity;
using MailKit.Net.Smtp;
using MimeKit;
using Microsoft.Extensions.Configuration;



namespace Repository_Layer.Service
{
    public class UserRL : IUserRL
    {
        private readonly ProjectContext projectContext;
        private readonly Jwt jwt;
        private readonly IConfiguration configuration;

        public UserRL(ProjectContext projectContext1,Jwt jwt,IConfiguration configuration)
        {
            this.projectContext = projectContext1;
            this.jwt = jwt;
            this.configuration = configuration;
        }

        public async Task<string> LoginUser(LoginML loginML)
        {
            var result=await projectContext.Users.FirstOrDefaultAsync(x=>x.Email == loginML.Email);
            if(result == null)
            {
                throw new CustomException("Invalid email or password");
            }
            try
            {
                if ((PasswordEncryption.Decrypt(result.Password)) == loginML.Password)
                {
                    var token = jwt.GenerateToken(result);
                    return token;
                }
                else
                {
                    throw new CustomException("Invalid email or password");
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Something went wrong");
            }
        }

        public async Task<UserEntity> RegisterUser(UserML userML,string role)
        {
            var result = await projectContext.Users.FirstOrDefaultAsync(x => x.Email == userML.Email);
            if (result != null)
            {
                throw new CustomException("Email already exists");
            }
            try
            {
                UserEntity userEntity = new UserEntity();
                userEntity.Email = userML.Email.ToLower();
                userEntity.Name = userML.Name.ToLower();
                userEntity.Password = PasswordEncryption.Encrypt(userML.Password.ToLower());
                userEntity.Phone = userML.Phone;
                userEntity.Role = role;
                projectContext.Users.Add(userEntity);
                await projectContext.SaveChangesAsync();
                return userEntity;
            }
            catch (Exception ex)
            {
                throw new Exception("Something went wrong");
            }
        }
        public async Task<UserEntity> GetById(int id)
        {
            try
            {
                var user = await projectContext.Users.FirstOrDefaultAsync(x => x.UserId == id);
                if (user == null)
                {
                    throw new CustomException("User with given id doesn't exist");
                }
                return user;
            }
            catch(Exception ex)
            {
                throw new Exception("Something went wrong");
            }
            
        }
        public async Task<UserEntity> ResetPassword(string email, string newPassword)
        {
            try
            {
                var user = await projectContext.Users.FirstOrDefaultAsync(x => x.Email == email);
                user.Password = PasswordEncryption.Encrypt(newPassword.ToLower());
                projectContext.Users.Update(user);
                await projectContext.SaveChangesAsync();
                return user;
            }
            catch(Exception ex)
            {
                throw new Exception("Something went wrong");
            }
        }
        public async Task<string> ForgotPassword(string emailId)
        {
            try
            {
                if (string.IsNullOrEmpty(emailId))
                    throw new ArgumentException("EmailId cannot be null or empty", nameof(emailId));

                var user = await projectContext.Users.FirstOrDefaultAsync(x => x.Email == emailId);
                if (user == null)
                {
                    throw new CustomException("Email doesn't exist! Register first");
                }

                var email = new MimeMessage();
                email.From.Add(MailboxAddress.Parse(configuration["SMTP:emailId"]));
                email.To.Add(MailboxAddress.Parse(emailId));
                email.Subject = "Password reset link";

                string token = jwt.GenerateToken(user);
                string resetLink = "http://localhost:5240/api/users/reset?token=" + token;
                string body = $"<p>Please reset your password by clicking on the following link:</p><p><a href='{resetLink}'>Reset Password</a></p>";

                email.Body = new TextPart(MimeKit.Text.TextFormat.Html) { Text = body };

                using var smtp = new SmtpClient();
                smtp.Connect(configuration["SMTP:host"], 587, MailKit.Security.SecureSocketOptions.StartTls);
                smtp.Authenticate(configuration["SMTP:emailId"], configuration["SMTP:password"]);
                smtp.Send(email);
                smtp.Disconnect(true);
                return token;
            }
            catch(Exception ex)
            {
                throw new Exception("Something went wrong");
            }
        }
    }
}
