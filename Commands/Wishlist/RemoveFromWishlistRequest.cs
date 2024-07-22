using MediatR;
using Repository_Layer.Entity;

namespace Book_Store.Controllers
{
    public class RemoveFromWishlistRequest : IRequest<WishlistEntity>
    {
        public int Id;

        public RemoveFromWishlistRequest(int id)
        {
            this.Id = id;
        }

        public int BookId { get; set; }
    }
}