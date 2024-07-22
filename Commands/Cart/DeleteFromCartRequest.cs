using MediatR;
using Repository_Layer.Entity;

namespace Book_Store.Controllers
{
    public class DeleteFromCartRequest : IRequest<CartEntity>
    {
        public int UserId {  get; set; }
        public int Id { get; set; }
        public DeleteFromCartRequest(int userId) 
        {
            UserId = userId;
        }

    }
}