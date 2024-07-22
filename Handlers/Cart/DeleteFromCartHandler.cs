using Book_Store.Controllers;
using MediatR;
using Repository_Layer.Entity;
using Repository_Layer.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Handlers.Cart
{
    public class DeleteFromCartHandler : IRequestHandler<DeleteFromCartRequest, CartEntity>
    {
        private readonly ICartRL cartRL;

        public DeleteFromCartHandler(ICartRL cartRL)
        {
            this.cartRL = cartRL;
        }

        public async Task<CartEntity> Handle(DeleteFromCartRequest request, CancellationToken cancellationToken)
        {
            return await cartRL.DeleteFromCart(request.UserId,request.Id);
        }
    }
}
