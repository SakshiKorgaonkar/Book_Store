using MediatR;

namespace Book_Store.Controllers
{
    public class ForgotPasswordRequest : IRequest<string>
    {
        public string EmailId {  get; set; }

        public ForgotPasswordRequest(string emailId)
        {
            this.EmailId = emailId;
        }
    }
}