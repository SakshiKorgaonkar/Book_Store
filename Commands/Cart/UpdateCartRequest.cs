using MediatR;
using Repository_Layer.Entity;

namespace Book_Store.Controllers
{
    public class UpdateCartRequest : IRequest<CartEntity>
    {
        public int UserId { get; set; }
        public int BookId { get; set; }
        public int Quantity {  get; set; }

        public UpdateCartRequest(int id, int bookId, int quantity)
        {
            this.UserId = id;
            this.BookId = bookId;
            this.Quantity = quantity;
        }
    }
}