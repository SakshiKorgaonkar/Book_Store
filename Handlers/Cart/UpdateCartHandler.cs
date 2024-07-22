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
    public class UpdateCartHandler : IRequestHandler<UpdateCartRequest, CartEntity>
    {
        private readonly ICartRL cartRL;
        public UpdateCartHandler(ICartRL cartRL)
        {
            this.cartRL = cartRL;
        }

        public async Task<CartEntity> Handle(UpdateCartRequest request, CancellationToken cancellationToken)
        {
            var result = new CartML
            {
                BookId = request.BookId,
                Quantity = request.Quantity,
            };
            return await cartRL.UpdateCart(request.UserId,result);
        }
    }
}
