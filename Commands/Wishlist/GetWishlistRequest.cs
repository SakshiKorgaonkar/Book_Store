using MediatR;
using Repository_Layer.Entity;

namespace Book_Store.Controllers
{
    public class GetWishlistRequest : IRequest<List<WishlistEntity>>
    {
        public int Id;

        public GetWishlistRequest(int id)
        {
            this.Id = id;
        }
    }
}