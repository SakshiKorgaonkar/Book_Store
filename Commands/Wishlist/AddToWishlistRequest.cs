using MediatR;
using Repository_Layer.Entity;

namespace Book_Store.Controllers
{
    public class AddToWishlistRequest : IRequest<WishlistEntity>
    {
        public int Id { get; set; }
        public int BookId { get; set; }
        public AddToWishlistRequest(int id) { Id = id; }
    }
}