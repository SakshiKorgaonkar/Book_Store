using Book_Store.Controllers;
using MediatR;
using Repository_Layer.Entity;
using Repository_Layer.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Handlers.Wishlist
{
    public class GetWishlistHandler:IRequestHandler<GetWishlistRequest,List<WishlistEntity>>
    {
        private readonly IWishListRL wishListRL;
        public GetWishlistHandler(IWishListRL wishListRL)
        {
            this.wishListRL = wishListRL;
        }

        public async Task<List<WishlistEntity>> Handle(GetWishlistRequest request, CancellationToken cancellationToken)
        {
            return await wishListRL.GetWishList(request.Id);
        }
    }

}
