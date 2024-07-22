using Book_Store.Controllers;
using MediatR;
using Model_Layer;
using Repository_Layer.Entity;
using Repository_Layer.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Handlers.Cart
{
    public class AddToCartHandler : IRequestHandler<AddToCartRequest, CartEntity>
    {
        private readonly ICartRL cartRL;
        public AddToCartHandler(ICartRL cartRL)
        {
            this.cartRL = cartRL;
        }

        public async Task<CartEntity> Handle(AddToCartRequest request, CancellationToken cancellationToken)
        {
            var result = new CartML
            {
                BookId = request.BookId,
                Quantity = request.Quantity,
            };
            return await cartRL.AddToCart(result,request.Id);
        }
    }
}
