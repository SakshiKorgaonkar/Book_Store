using MediatR;
using Repository_Layer.Entity;

namespace Book_Store.Controllers
{
    public class AddToCartRequest : IRequest<CartEntity>
    {
        public int BookId {  get; set; }
        public int Quantity {  get; set; }
        public int Id {  get; set; }
        public AddToCartRequest(int bookId,int quantity,int id) 
        {
            BookId = bookId;
            Quantity = quantity;
            Id = id;
        }
    }
}