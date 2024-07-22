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
    public class WishlistHandler:IRequestHandler<AddToWishlistRequest,WishlistEntity>
    {
        private readonly IWishListRL wishListRL;
        public WishlistHandler(IWishListRL wishListRL)
        {
            this.wishListRL = wishListRL;
        }

        public async Task<WishlistEntity> Handle(AddToWishlistRequest request, CancellationToken cancellationToken)
        {
            return await wishListRL.AddToWishList(request.Id, request.BookId);
        }
    }
}
