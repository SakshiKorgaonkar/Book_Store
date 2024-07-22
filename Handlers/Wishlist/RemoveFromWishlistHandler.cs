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
    public class RemoveFromWishlistHandler:IRequestHandler<RemoveFromWishlistRequest,WishlistEntity>
    {
        private readonly IWishListRL wishListRL;
        public RemoveFromWishlistHandler(IWishListRL wishListRL)
        {
            this.wishListRL = wishListRL;
        }

        public async Task<WishlistEntity> Handle(RemoveFromWishlistRequest request, CancellationToken cancellationToken)
        {
            return await wishListRL.RemoveFromWishList(request.Id, request.BookId);
        }
    }
}
