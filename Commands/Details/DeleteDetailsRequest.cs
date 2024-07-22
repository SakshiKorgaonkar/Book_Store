using MediatR;
using Repository_Layer.Entity;

namespace Book_Store.Controllers
{
    public class DeleteDetailsRequest : IRequest<CustomerDetailsEntity>
    {
        public int UserId {  get; set; }
        public string? Type { get; set; }
        public DeleteDetailsRequest(int userId)
        {
            UserId = userId;
        }
    }
}